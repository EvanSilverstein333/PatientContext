using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValueObjects.Health;

namespace Views
{
    public partial class HealthcardControl : UserControl
    {
        private bool _readOnly;


        public HealthcardControl()
        {
            InitializeComponent();
        }


        [Category("Behavior")]
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                OnReadOnlyChanged();
            }
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Healthcard Healthcard
        {
            get { return ComposeHealthcard(); }
            set { BindToHealthcard(value); }
            
        }

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
        public string Number
        {
            get { return inputHealthNumber.Text; }
            set { inputHealthNumber.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Version
        {
            get { return inputVersionCode.Text; }
            set { inputVersionCode.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? ExpiryDate
        {
            get { return inputExpiryDate.Value; }
            set { inputExpiryDate.Value = value; }
        }

        private Healthcard ComposeHealthcard()
        {
            var healthcard = new Healthcard(
                FirstName, null, LastName, DateOfBirth, Gender, Number, Version, ExpiryDate
                );
            return healthcard;
        }

        private void BindToHealthcard(Healthcard healthcard)
        {
            FirstName = healthcard.FirstName;
            LastName = healthcard.LastName;
            DateOfBirth = healthcard.DateOfBirth;
            Gender = healthcard.Gender;
            Number = healthcard.Number;
            Version = healthcard.VersionCode;
            ExpiryDate = healthcard.ExpiryDate;

        }


        private void FormatReadOnly()
        {
            identityControl1.ReadOnly = _readOnly;
            foreach (var input in tableLayoutPanel2.Controls)
            {
                if (input is TextBox)
                {
                    var tb = input as TextBox;
                    tb.Margin = (_readOnly) ? new Padding(5) : new Padding(3);
                    tb.ReadOnly = _readOnly;
                    tb.BorderStyle = (_readOnly) ? BorderStyle.None : BorderStyle.FixedSingle;
                    tb.Dock = DockStyle.None; //required to reset margins
                    tb.Dock = DockStyle.Top;
                }
                else if (input is NullableDateTimePicker)
                {
                    var dtp = input as NullableDateTimePicker;
                    dtp.Enabled = !_readOnly;
                }
                //else if()

            }
        }


        public event EventHandler ReadOnlyChanged;
        protected virtual void OnReadOnlyChanged()
        {
            FormatReadOnly();
            var handler = ReadOnlyChanged;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            identityControl1.BackColor = this.BackColor;
            tableLayoutPanel1.BackColor = this.BackColor;
            tableLayoutPanel2.BackColor = this.BackColor;
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            identityControl1.ForeColor = this.ForeColor;
            tableLayoutPanel1.ForeColor = this.ForeColor;
            tableLayoutPanel2.ForeColor = this.ForeColor;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (DesignMode) { Invalidate(); }
            base.OnVisibleChanged(e);
        }


        public void Clear()
        {
            Healthcard = new Healthcard();
        }

    }



}
