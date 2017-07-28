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

namespace Views
{
    public partial class NewPatientVisitDialog : Form
    {
        public NewPatientVisitDialog()
        {
            InitializeComponent();

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public byte[] RowVersion { get; set; }


        [Browsable(false)]
        public string PatientName
        {
            get { return patientName.Text; }
            set { patientName.Text = value; }
        }

        [Browsable(false)]
        public DateTime Date
        {
            get { return dateTimePicker1.Value; }
            set { dateTimePicker1.Value = value; }
        }

        [Browsable(false)]
        public string Diagnosis
        {
            get { return diagnosis.Text; }
            set { diagnosis.Text = value; }
        }

        [Browsable(false)]
        public string Notes
        {
            get { return notes.Text; }
            set { notes.Text = value; }
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


        private void BtnSave_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            OnCancel();
        }

    }
}
