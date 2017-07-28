using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatientManager.Contract.Dto;
using ValueObjects.ContactInformation;
using ValueObjects.Health;


namespace Views
{
    public partial class NewPatientDialog : Form
    {

        public NewPatientDialog()
        {
            InitializeComponent();
            InitializeControls();
        }

        public void InitializeControls()
        {

            btnSave.Click += BtnSave_Click; // for external validation
            btnCancel.Click += BtnCancel_Click;

        }



        private void BtnSave_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            OnCancel();
        }

        public bool ShowIdentityTab { get; set; }
        public bool ShowContactInfoTab { get; set; }
        public bool ShowHealthcardTab { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public byte[] PatientRowVersion { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public byte[] ContactInfoRowVersion { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public byte[] HealthcardRowVersion { get; set; }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FirstName
        {
            get { return identityControl1.FirstName; }
            set { identityControl1.FirstName = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LastName
        {
            get { return identityControl1.LastName; }
            set { identityControl1.LastName = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? DateOfBirth
        {
            get { return identityControl1.DateOfBirth; }
            set { identityControl1.DateOfBirth = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public GenderType Gender
        {
            get { return identityControl1.Gender; }
            set { identityControl1.Gender = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Address Address
        {
            get { return contactInfoControl1.Address; }
            set { contactInfoControl1.Address = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PhoneNumber PrimaryPhoneNumber
        {
            get { return contactInfoControl1.PrimaryPhoneNumber; }
            set { contactInfoControl1.PrimaryPhoneNumber = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PhoneNumber SecondaryPhoneNumber
        {
            get { return contactInfoControl1.SecondaryPhoneNumber; }
            set { contactInfoControl1.SecondaryPhoneNumber = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Email
        {
            get { return contactInfoControl1.Email; }
            set { contactInfoControl1.Email = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Healthcard Healthcard
        {
            get { return healthcardControl1.Healthcard; }
            set { healthcardControl1.Healthcard = value; }
        }


        private void TabsToShow()
        {
            tabControl1.TabPages.Clear();
            if (ShowIdentityTab) { tabControl1.TabPages.Add(tabIdentity); }
            if (ShowContactInfoTab) { tabControl1.TabPages.Add(tabContactInfo); }
            if (ShowHealthcardTab) { tabControl1.TabPages.Add(tabHealthcard); }
        }

        public event CancelEventHandler Save;
        public event CancelEventHandler Cancel;

        protected void OnSave()
        {
            var e = new CancelEventArgs(false);
            var handler = Save;
            if (handler != null) { handler.Invoke(this, e); }

            this.DialogResult = (e.Cancel) ? DialogResult.None : DialogResult.OK;


        }

        protected void OnCancel()
        {
            var e = new CancelEventArgs(false);
            var handler = Cancel;
            if (handler != null) { handler.Invoke(this, e); }

            this.DialogResult = (e.Cancel) ? DialogResult.None : DialogResult.Cancel;

        }


        protected override void OnShown(EventArgs e)
        {
            TabsToShow();
            base.OnShown(e);
        }



    }
}
