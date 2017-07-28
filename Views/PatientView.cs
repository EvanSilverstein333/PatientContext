using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers.Controllers;
using Controllers.ViewInterfaces;
using PatientManager.Contract.Dto;
using FluentValidation;

namespace Views
{
    public partial class PatientView : Form, IPatientView
    {
        private PatientController _controller;
        private PatientDto _selectedPatient;
        //private NewPatientDialog patientDialog;

        //private HealthIdentificationDto _patienthealthId;
        //private ContactInfoDto _patientContactInfo;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PatientDto SelectedPatient
        {
            get { return _selectedPatient; }
            private set
            {
                _selectedPatient = value;
                OnSelectedPatientChanged();
            }
        }

        public PatientView()
        {
            InitializeComponent();
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; // required 1: or error thrown if mouse in wrong spot at wrong time http://stackoverflow.com/questions/14934003/system-invalidoperationexception-this-operation-cannot-be-performed-while-an-au
            InitializeControls();
            //StartUpFormat();
        }



        private void InitializeControls()
        {
            dgvPatients.BorderStyle = BorderStyle.None;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.MultiSelect = false;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.ReadOnly = true;
            btnAddPatient.Click += BtnAddPatient_Click;
            btnRemovePatient.Click += BtnRemovePatient_Click;
            btnUpdatePatient.Click += BtnUpdatePatient_Click;
            txtSearchBox.TextChanged += TxtSearchBox_TextChanged;



        }




        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // required 2: or error thrown if mouse in wrong spot at wrong time http://stackoverflow.com/questions/14934003/system-invalidoperationexception-this-operation-cannot-be-performed-while-an-au
        }


        
        private void DgvPatients_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvPatients.SelectedRows.Count>0)
            {
                var patient = dgvPatients.SelectedRows[0].DataBoundItem as PatientDto;
                SelectedPatient = patient;
                //if(SelectedPatient != patient) { SelectedPatient = patient; }
                
            }
            else { SelectedPatient = null; }


        }

        private void TxtSearchBox_TextChanged(object sender, EventArgs e)
        {
            _controller.SearchPatientsByName(txtSearchBox.Text);
        }

        private void BtnRemovePatient_Click(object sender, EventArgs e)
        {
            if(_selectedPatient == null)
            {
                MessageBox.Show("Please select a patient");
                return;
            }
            var result = _controller.RemovePatient(SelectedPatient.Id); // not async: otherewise errors might arise if update props of a pt in the process of being removed
            if(result.ActionSucceeded)
            {
                dgvPatients.SelectionChanged -= DgvPatients_SelectionChanged;
                UpdatePatientsGrid(_controller.GetAllPatients());
                dgvPatients.SelectionChanged += DgvPatients_SelectionChanged;
                dgvPatients.ClearSelection();
                SelectedPatient = null;
            }
        }

        private void BtnAddPatient_Click(object sender, EventArgs e)
        {
            using (var addPatientDialog = new NewPatientDialog()) // ensures dialog is disposed
            {
                addPatientDialog.Save += AddPatientDialog_Save2;
                addPatientDialog.ShowIdentityTab = true;
                addPatientDialog.ShowContactInfoTab = true;
                addPatientDialog.ShowHealthcardTab = true;
                addPatientDialog.ShowDialog();
            }

        }

        private void BtnUpdatePatient_Click(object sender, EventArgs e)
        {
            if (_selectedPatient == null)
            {
                MessageBox.Show("Please select a patient");
                return;
            }
            using (var updatePatientDialog = new NewPatientDialog()) // ensures dialog is disposed
            {
                PopulateDialogWithPatientInfo(updatePatientDialog, _selectedPatient);
                updatePatientDialog.Save += UpdatePatientDialog_Save2;
                updatePatientDialog.ShowIdentityTab = true;
                updatePatientDialog.ShowDialog();
            }
        }


        private async void AddPatientDialog_Save2(object sender, CancelEventArgs e)
        {
            var dialog = sender as NewPatientDialog;
            dialog.Enabled = false; // prevent mutiple calls
            e.Cancel = true; // let future commandEvent close dialog (if successful)

            var patient = new PatientDto(Guid.NewGuid());
            var contactInfo = new ContactInfoDto();
            var healthId = new HealthIdentificationDto();

            PopulatePatientDtoFromDialog(dialog, patient);
            PopulateContactInfoDtoFromDialog(dialog, contactInfo);
            PopulateHealthIdDtoFromDialog(dialog, healthId);

            var result = await Task.Run(() => _controller.AddPatient(patient, contactInfo, healthId));

            if (result.ActionSucceeded)
            {
                dialog.Close();
                dialog.Dispose();
                dgvPatients.SelectionChanged -= DgvPatients_SelectionChanged;
                UpdatePatientsGrid(_controller.GetAllPatients());
                dgvPatients.ClearSelection();
                dgvPatients.SelectionChanged += DgvPatients_SelectionChanged;
                dgvPatients.Rows[dgvPatients.Rows.Count - 1].Selected = true; // select new pt
            }
            else { dialog.Enabled = true; }
        }

        private async void UpdatePatientDialog_Save2(object sender, CancelEventArgs e)
        {
            var dialog = sender as NewPatientDialog;
            dialog.Enabled = false; // prevent mutiple calls
            e.Cancel = true; // let future commandEvent close dialog (if succeeded)

            var patient = _selectedPatient;
            PopulatePatientDtoFromDialog(dialog, patient);
            
            var result = await Task.Run(() => _controller.UpdatePatient(patient));

            if (result.ActionSucceeded)
            {
                dgvPatients.Refresh();
                dialog.Close();
                dialog.Dispose();
            }
            else { dialog.Enabled = true; }
        }

        private void DeletePatient(PatientDto patient)
        {
            if (patient != null)
            {
                _controller.RemovePatient(SelectedPatient.Id);
                dgvPatients.SelectionChanged -= DgvPatients_SelectionChanged;
                UpdatePatientsGrid(_controller.GetAllPatients());
                dgvPatients.SelectionChanged += DgvPatients_SelectionChanged;
                dgvPatients.ClearSelection();

            }
        }


        //private void AddPatientDialog_Save(object sender, CancelEventArgs e)
        //{
        //    bool succeeded;
        //    var dialog = sender as NewPatientDialog;
        //    AttemptAction(() => AddPatient(dialog), out succeeded);
        //    e.Cancel = !succeeded;
        //}


        //private void UpdatePatientDialog_Save(object sender, CancelEventArgs e)
        //{
        //    bool succeeded;
        //    var dialog = sender as NewPatientDialog;
        //    AttemptAction(() => UpdatePatient(dialog), out succeeded);
        //    e.Cancel = !succeeded;
        //}

        //private void UpdatePatient(NewPatientDialog dialog)
        //{
        //    dgvPatients.Refresh();
        //}

        //private void AddPatient(NewPatientDialog dialog)
        //{
        //    var patient = new PatientDto();
        //    var contactInfo = new ContactInfoDto();
        //    var healthId = new HealthIdentificationDto();

        //    PopulatePatientDtoFromDialog(dialog, patient);
        //    PopulateContactInfoDtoFromDialog(dialog, contactInfo);
        //    PopulateHealthIdDtoFromDialog(dialog, healthId);

        //    _controller.AddPatient(patient, contactInfo, healthId);

        //    dgvPatients.SelectionChanged -= DgvPatients_SelectionChanged;
        //    UpdatePatientsGrid(_controller.GetAllPatients());
        //    dgvPatients.ClearSelection();
        //    dgvPatients.SelectionChanged += DgvPatients_SelectionChanged;
        //    dgvPatients.Rows[dgvPatients.Rows.Count - 1].Selected = true; // select new pt

        //}

        //private void AddPatientCallBack(bool addedPatientSuccessfully)
        //{
        //    if(addedPatientSuccessfully)
        //    {
        //        patientDialog.Close();
        //        patientDialog.Dispose();
        //        dgvPatients.SelectionChanged -= DgvPatients_SelectionChanged;
        //        UpdatePatientsGrid(_controller.GetAllPatients());
        //        dgvPatients.ClearSelection();
        //        dgvPatients.SelectionChanged += DgvPatients_SelectionChanged;
        //        dgvPatients.Rows[dgvPatients.Rows.Count - 1].Selected = true; // select new pt
        //    }
        //    else { patientDialog.Enabled = true; }

        //}

        //public void UpdatePatientCallBack(bool updatedPatientSuccessfully)
        //{
        //    if (updatedPatientSuccessfully)
        //    {
        //        patientDialog.Close();
        //        patientDialog.Dispose();
        //    }
        //    else { patientDialog.Enabled = true; }

        //}




        //private void AttemptAction(Action action)
        //{
        //    bool success;
        //    AttemptAction(action, out success);
        //}



        //private void AttemptAction(Action action, out bool succeeded)
        //{
        //    try
        //    {
        //        action();
        //        succeeded = true;
        //    }
        //    catch (Exception err)
        //    {
        //        ShowExceptionMessage(err);
        //        succeeded = false;
        //    }

        //}







        private void PopulateDialogWithPatientInfo(NewPatientDialog dialog, PatientDto patient)
        {
            dialog.FirstName = patient.FirstName;
            dialog.LastName = patient.LastName;
            dialog.DateOfBirth = patient.DateOfBirth;
            dialog.Gender = patient.Gender;
            dialog.PatientRowVersion = patient.RowVersion;
        }

        private void PopulatePatientDtoFromDialog(NewPatientDialog dialog, PatientDto patient)
        {
            patient.FirstName = dialog.FirstName;
            patient.LastName = dialog.LastName;
            patient.DateOfBirth = dialog.DateOfBirth;
            patient.Gender = dialog.Gender;
            patient.RowVersion = dialog.PatientRowVersion;
        }

        private void PopulateContactInfoDtoFromDialog(NewPatientDialog dialog, ContactInfoDto contactInfo)
        {

            contactInfo.Address = dialog.Address;
            contactInfo.PrimaryPhoneNumber = dialog.PrimaryPhoneNumber;
            contactInfo.SecondaryPhoneNumber = dialog.SecondaryPhoneNumber;
            contactInfo.Email = dialog.Email;
            contactInfo.RowVersion = dialog.ContactInfoRowVersion;

        }

        private void PopulateHealthIdDtoFromDialog(NewPatientDialog dialog, HealthIdentificationDto healthId)
        {
            healthId.Healthcard = dialog.Healthcard;
            healthId.RowVersion = dialog.HealthcardRowVersion;
        }


        //private void DisplayPatientDetails(PatientDto patient)
        //{
        //    if(patient == null) { throw new Exception("details cannot be displayed, becasue patient is null"); } // this is for internal use
        //    {
        //        _patientContactInfo = _controller.GetPatientContactInfo(patient.Id) ?? new ContactInfoDto();
        //        _patienthealthId = _controller.GetPatientHealthIdentification(patient.Id) ?? new HealthIdentificationDto();
        //        healthcardControl1.Healthcard = _patienthealthId.Healthcard;
        //        contactInfoControl1.Address = _patientContactInfo.Address;
        //        contactInfoControl1.PrimaryPhoneNumber = _patientContactInfo.PrimaryPhoneNumber;
        //        contactInfoControl1.SecondaryPhoneNumber = _patientContactInfo.SecondaryPhoneNumber;
        //        contactInfoControl1.Email = _patientContactInfo.Email;
        //    }
           
        //}

        //private void ClearPatientDetails()
        //{
        //    _patientContactInfo = null;
        //    _patienthealthId = null;
        //    contactInfoControl1.Clear();
        //    healthcardControl1.Clear();
        //}

        public void Initialize()
        {
            var patients = _controller.GetAllPatients();
            UpdatePatientsGrid(patients);
            dgvPatients.ClearSelection(); // clean slate
            SelectedPatient = null;

        }

        public void UpdatePatientsGrid(IEnumerable<PatientDto> patients)
        {
            dgvPatients.DataSource = null; // sometimes needed to refresh if changed
            dgvPatients.DataSource = patients;
            //dgvPatients.ClearSelection();


        }


        public void SetController(PatientController controller)
        {
            _controller = controller;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            dgvPatients.ClearSelection();
            dgvPatients.SelectionChanged += DgvPatients_SelectionChanged;

        }

        public event EventHandler SelectedPatientChanged;

        protected virtual void OnSelectedPatientChanged()
        {
            //if (_selectedPatient != null) { DisplayPatientDetails(_selectedPatient); }
            //else { ClearPatientDetails(); }
            //panelPatientDetails.Visible = (_selectedPatient != null);
            _controller.SelectedPatientChanged(_selectedPatient);
            _controller.UpdateHostViewRequest(_selectedPatient);
            var handler = SelectedPatientChanged;
            if(handler != null) { handler.Invoke(this, EventArgs.Empty); }
        }


        private void ShowExceptionMessage(Exception e)
        {
            string caption = null;
            if(e is ValidationException) { caption = "Validation Errors"; }
            else { caption = "Unknown Error"; }

            ShowErrorMessage( caption, e.Message);
        }


        private void ShowErrorMessage(string caption, string message)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
