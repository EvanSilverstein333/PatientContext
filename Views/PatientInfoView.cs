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
using ValueObjects.ContactInformation;
using ValueObjects.Health;
using FluentValidation;
using PatientManager.Contract.Dto;

namespace Views
{
    public partial class PatientInfoView : Form, IPatientInfoView
    {
        private PatientDto _patient;
        private ContactInfoDto _contactInfo;
        private HealthIdentificationDto _healthId;
        private PatientInfoController _controller;

        public PatientInfoView()
        {
            InitializeComponent();
            InitializeControls();

        }

        private void InitializeControls()
        {
            btnEdit.Click += BtnEdit_Click;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            using (var updatePersonalInfoDialog = new NewPatientDialog()) // ensures dialog is disposed
            {
                updatePersonalInfoDialog.Save += UpdatePersonalInfoDialog_Save;
                updatePersonalInfoDialog.ShowContactInfoTab = true;
                updatePersonalInfoDialog.ShowHealthcardTab = true;
                PopulateDialogWithPerosnalInfo(updatePersonalInfoDialog, _contactInfo, _healthId);
                updatePersonalInfoDialog.ShowDialog();
            }

        }

        private async void UpdatePersonalInfoDialog_Save(object sender, CancelEventArgs e)
        {
            var dialog = sender as NewPatientDialog;
            dialog.Enabled = false;
            e.Cancel = true; // let cmd result determine if dialog should close

            PopulateContactInfoDtoFromDialog(dialog, _contactInfo);
            PopulateHealthIdDtoFromDialog(dialog, _healthId);

            var result = await Task.Run(() => _controller.UpdatePatientPersonlInfo(_patient.Id, _contactInfo, _healthId));
            if(result.ActionSucceeded)
            {
                dialog.Close();
                contactInfoControl1.Address = _contactInfo.Address;
                healthcardControl1.Healthcard = _healthId.Healthcard;
            }
            else { dialog.Enabled = true; }

        }

        private void UpdatePersonalInfo(NewPatientDialog dialog)
        {
            PopulateContactInfoDtoFromDialog(dialog, _contactInfo);
            PopulateHealthIdDtoFromDialog(dialog, _healthId);
            _controller.UpdatePatientPersonlInfo(_patient.Id,_contactInfo,_healthId);
            contactInfoControl1.Address = _contactInfo.Address;
            healthcardControl1.Healthcard = _healthId.Healthcard;
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

        private void PopulateDialogWithPerosnalInfo(NewPatientDialog dialog, ContactInfoDto contactInfo, HealthIdentificationDto healthId)
        {

            dialog.Address = contactInfo.Address;
            dialog.PrimaryPhoneNumber = contactInfo.PrimaryPhoneNumber;
            dialog.SecondaryPhoneNumber = contactInfo.SecondaryPhoneNumber;
            dialog.Email = contactInfo.Email;

            dialog.Healthcard = healthId.Healthcard;

        }


        private void PopulateContactInfoDtoFromDialog(NewPatientDialog dialog, ContactInfoDto contactInfo)
        {

            contactInfo.Address = dialog.Address;
            contactInfo.PrimaryPhoneNumber = dialog.PrimaryPhoneNumber;
            contactInfo.SecondaryPhoneNumber = dialog.SecondaryPhoneNumber;
            contactInfo.Email = dialog.Email;

        }

        private void PopulateHealthIdDtoFromDialog(NewPatientDialog dialog, HealthIdentificationDto healthId)
        {
            healthId.Healthcard = dialog.Healthcard;
        }



        public void Initialize()
        {
        }

        public void BindToPatient(PatientDto patient)
        {
            _patient = patient;
            if(patient == null)
            {
                contactInfoControl1.Address = new Address();
                healthcardControl1.Healthcard = new Healthcard();
            }
            else
            {
                _contactInfo = _controller.GetPatientContactInfo(patient.Id);
                _healthId = _controller.GetPatientHealthIdentification(patient.Id);
                contactInfoControl1.Address = _contactInfo.Address;
                healthcardControl1.Healthcard = _healthId.Healthcard;

            }

        }


        private void ShowExceptionMessage(Exception e)
        {
            string caption = null;
            if (e is ValidationException) { caption = "Validation Errors"; }
            else { caption = "Unknown Error"; }

            ShowErrorMessage(caption, e.Message);
        }

        private void ShowErrorMessage(string caption, string message)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void SetController(PatientInfoController controller)
        {
            _controller = controller;
        }
    }
}
