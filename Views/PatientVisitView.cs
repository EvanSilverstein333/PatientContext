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
    public partial class PatientVisitView : Form, IPatientVisitView
    {
        private PatientVisitController _controller;
        private PatientVisitDto _selectedVisit;
        private PatientDto _selectedPatient;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PatientVisitDto SelectedVisit
        {
            get { return _selectedVisit; }
            private set
            {
                _selectedVisit = value;
                OnSelectedPatientVisitChanged();
            }
        }

        public PatientVisitView()
        {
            InitializeComponent();
            dgvPatientVisits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; // required 1: or error thrown if mouse in wrong spot at wrong time http://stackoverflow.com/questions/14934003/system-invalidoperationexception-this-operation-cannot-be-performed-while-an-au
            InitializeControls();
        }

        public void BindToPatient(PatientDto patient)
        {
            dgvPatientVisits.SelectionChanged -= DgvPatientVisits_SelectionChanged;
            _selectedPatient = patient;
            if(_selectedPatient == null) { UpdatePatientVisitsGrid(null); }
            else
            {
                var visits = _controller.GetVisitsByPatient(patient.Id);
                Initialize(visits);
            }
            dgvPatientVisits.SelectionChanged += DgvPatientVisits_SelectionChanged;


        }



        private void InitializeControls()
        {
            dgvPatientVisits.BorderStyle = BorderStyle.None;
            dgvPatientVisits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatientVisits.MultiSelect = false;
            dgvPatientVisits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatientVisits.ReadOnly = true;
            btnAddPatientVisit.Click += BtnAddPatientVisit_Click;
            btnRemovePatientVisit.Click += BtnRemovePatientVisit_Click;
            btnUpdatePatientVisit.Click += BtnUpdatePatientVisit_Click;
            //btnAddPatient.Click += BtnAddPatient_Click;
            //btnRemovePatient.Click += BtnRemovePatient_Click;
            //btnUpdatePatient.Click += BtnUpdatePatient_Click;
            //txtSearchBox.TextChanged += TxtSearchBox_TextChanged;



        }


       

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dgvPatientVisits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // required 2: or error thrown if mouse in wrong spot at wrong time http://stackoverflow.com/questions/14934003/system-invalidoperationexception-this-operation-cannot-be-performed-while-an-au
        }

        private void DgvPatientVisits_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPatientVisits.SelectedRows.Count > 0)
            {
                var visit = dgvPatientVisits.SelectedRows[0].DataBoundItem as PatientVisitDto;
                SelectedVisit = visit;
                //if(SelectedPatient != patient) { SelectedPatient = patient; }

            }
            else { SelectedVisit = null; }


        }


        private void BtnAddPatientVisit_Click(object sender, EventArgs e)
        {
            if(_selectedPatient == null)
            {
                MessageBox.Show("Please select a patient");
                return;
            }
            using (var addPatientVisitDialog = new NewPatientVisitDialog()) // ensures dialog is disposed
            {
                PopulateDialogWithPatientVisitInfo(addPatientVisitDialog, new PatientVisitDto());
                addPatientVisitDialog.Save += AddPatientVisitDialog_Save;
                addPatientVisitDialog.ShowDialog();
            }

        }



        private void BtnRemovePatientVisit_Click(object sender, EventArgs e)
        {
            if(_selectedVisit == null)
            {
                MessageBox.Show("Please select a medical history entry");
                return;
            }

            var result = _controller.RemovePatientVisit(_selectedVisit.Id); // not async..see patient view (delete pt)

            if (result.ActionSucceeded)
            {
                dgvPatientVisits.SelectionChanged -= DgvPatientVisits_SelectionChanged;
                UpdatePatientVisitsGrid(_controller.GetVisitsByPatient(_selectedPatient.Id));
                dgvPatientVisits.SelectionChanged += DgvPatientVisits_SelectionChanged;
                dgvPatientVisits.ClearSelection();
            }
            this.Enabled = true;
        }

        private void BtnUpdatePatientVisit_Click(object sender, EventArgs e)
        {
            if (_selectedVisit == null)
            {
                MessageBox.Show("Please select a medical history entry");
                return;
            }
            using (var updatePatientDialog = new NewPatientVisitDialog()) // ensures dialog is disposed
            {
                PopulateDialogWithPatientVisitInfo(updatePatientDialog, _selectedVisit);
                updatePatientDialog.Save += UpdatePatientVisitDialog_Save;
                updatePatientDialog.ShowDialog();
            }

        }




        private async void AddPatientVisitDialog_Save(object sender, CancelEventArgs e)
        {
            var dialog = sender as NewPatientVisitDialog;
            dialog.Enabled = false; // prevent mutiple calls
            e.Cancel = true; // let future commandEvent close dialog (if successful)

            var visit = new PatientVisitDto(Guid.NewGuid());
            PopulatePatientVisitDtoFromDialog(dialog, visit);

            var result = await Task.Run(() => _controller.AddPatientVisit(visit, _selectedPatient.Id));

            if(result.ActionSucceeded)
            {
                dialog.Close();
                dgvPatientVisits.SelectionChanged -= DgvPatientVisits_SelectionChanged;
                UpdatePatientVisitsGrid(_controller.GetVisitsByPatient(_selectedPatient.Id));
                dgvPatientVisits.ClearSelection();
                dgvPatientVisits.SelectionChanged += DgvPatientVisits_SelectionChanged;
                dgvPatientVisits.Rows[dgvPatientVisits.Rows.Count - 1].Selected = true; // select new pt
            }
            else { dialog.Enabled = true; }

        }




        private async void UpdatePatientVisitDialog_Save(object sender, CancelEventArgs e)
        {

            var dialog = sender as NewPatientVisitDialog;
            dialog.Enabled = false; // prevent mutiple calls
            e.Cancel = true; // let future commandEvent close dialog (if successful)


            var visit = _selectedVisit;
            PopulatePatientVisitDtoFromDialog(dialog, visit);
            var result = await Task.Run(() => _controller.UpdatePatientVisit(visit));
            if(result.ActionSucceeded)
            {
                dialog.Close();
                dgvPatientVisits.Refresh();
            }
            else { dialog.Enabled = true; }

        }


        //private void AddPatientVisit()
        //{
        //    using (var dialog = new NewPatientVisitDialog()) // ensures dialog is disposed
        //    {
        //        dialog.Save += Dialog_Save;
        //        dialog.ShowDialog();
        //    }

        //}



        private void UpdatePatientVisit(NewPatientVisitDialog dialog)
        {
            var visit = _selectedVisit;
            PopulatePatientVisitDtoFromDialog(dialog, visit);
            _controller.UpdatePatientVisit(visit);
            dgvPatientVisits.Refresh();
        }




        private void DeletePatient(PatientVisitDto visit)
        {
            if (visit != null)
            {
                _controller.RemovePatientVisit(_selectedVisit.Id);
                dgvPatientVisits.SelectionChanged -= DgvPatientVisits_SelectionChanged;
                UpdatePatientVisitsGrid(_controller.GetVisitsByPatient(_selectedPatient.Id));
                dgvPatientVisits.SelectionChanged += DgvPatientVisits_SelectionChanged;
                dgvPatientVisits.ClearSelection();


            }
        }


        private void AttemptAction(Action action)
        {
            bool success;
            AttemptAction(action, out success);
        }



        private void AttemptAction(Action action, out bool succeeded)
        {
            try
            {
                action();
                succeeded = true;
            }
            catch (Exception err)
            {
                ShowExceptionMessage(err);
                succeeded = false;
            }

        }

        private void PopulateDialogWithPatientVisitInfo(NewPatientVisitDialog dialog, PatientVisitDto visit)
        {
            dialog.PatientName = string.Format("{0} {1}", _selectedPatient.FirstName, _selectedPatient.LastName);
            dialog.Date = (visit.Date == null)? DateTime.Now : visit.Date.Value; 
            dialog.Diagnosis = visit.Diagnosis;
            dialog.Notes = visit.Notes;
        }

        private void PopulatePatientVisitDtoFromDialog(NewPatientVisitDialog dialog, PatientVisitDto visit)
        {
            //visit.PatientFullName = dialog.PatientName;
            visit.Date = dialog.Date;
            visit.Diagnosis = dialog.Diagnosis;
            visit.Notes = dialog.Notes;
            
        }


        private void Initialize(IEnumerable<PatientVisitDto> visits)
        {
            UpdatePatientVisitsGrid(visits);
            dgvPatientVisits.ClearSelection(); // clean slate
            SelectedVisit = null;

        }

        public void UpdatePatientVisitsGrid(IEnumerable<PatientVisitDto> patientVisits)
        {
            dgvPatientVisits.DataSource = null; // sometimes needed to refresh if changed
            dgvPatientVisits.DataSource = patientVisits;


        }

        public void SetController(PatientVisitController controller)
        {
            _controller = controller;
        }

        public event EventHandler SelectedPatientVisitChanged;

        protected virtual void OnSelectedPatientVisitChanged()
        {
            var handler = SelectedPatientVisitChanged;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }
        }


        private void ShowExceptionMessage(Exception e)
        {
            string errorMessage = null;
            if (e is ValidationException) { errorMessage = e.Message; }
            else { errorMessage = e.Message; }

            ShowErrorMessage(errorMessage);
        }


        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            dgvPatientVisits.ClearSelection();
            dgvPatientVisits.SelectionChanged += DgvPatientVisits_SelectionChanged;

        }


    }
}
