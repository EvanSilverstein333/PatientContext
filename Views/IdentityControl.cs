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
    public partial class IdentityControl : UserControl
    {
        private bool _readOnly;
        private int DEFAULT_CONTROL_HEIGHT;

        public IdentityControl()
        {
            InitializeComponent();
            tableLayoutPanel1.SizeChanged += TableLayoutPanel1_SizeChanged;
            

            //FormatDateTimePicker(nullableDateTimePicker1, true);
            //nullableDateTimePicker1.ValueChanged += InputDateOfBirth_ValueChanged;
        }

        private void TableLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            DEFAULT_CONTROL_HEIGHT = tableLayoutPanel1.Height;
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
        public string FirstName
        {
            get { return inputFirstName.Text; }
            set { inputFirstName.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LastName
        {
            get { return inputLastName.Text; }
            set { inputLastName.Text = value; }
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? DateOfBirth
        {
            get { return inputDateOfBirth.Value; }
            set { inputDateOfBirth.Value = value; }
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public GenderType Gender
        {
            get { return inputGender.Value; }
            set { inputGender.Value = value; }
        }

        [Category("Appearance")]
        public GenderOptions GenderOptions
        {
            get { return inputGender.GenderOptions; }
            set { inputGender.GenderOptions = value; }
        }


        private void FormatReadOnly()
        {
            foreach (var input in tableLayoutPanel1.Controls)
            {
                if (input is TextBox)
                {
                    var tb = input as TextBox;
                    tb.ReadOnly = _readOnly;
                    tb.Margin = (_readOnly) ? new Padding(5) : new Padding(3);
                    tb.BorderStyle = (_readOnly) ? BorderStyle.None : BorderStyle.FixedSingle;
                    tb.Dock = DockStyle.None; //required to reset margins
                    tb.Dock = DockStyle.Top;
                }
                else if (input is NullableDateTimePicker)
                {
                    var dtp = input as NullableDateTimePicker;
                    dtp.Enabled = !_readOnly;
                }
                else if(input is GenderControl)
                {
                    var gender = input as GenderControl;
                    gender.Enabled = !_readOnly;
                    gender.Margin = (_readOnly) ? new Padding(5) : new Padding(3);
                    gender.BorderStyle = (_readOnly) ? BorderStyle.None : BorderStyle.FixedSingle;
                    gender.Dock = DockStyle.None; //required to reset margins
                    gender.Dock = DockStyle.Top;



                }

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
            tableLayoutPanel1.BackColor = this.BackColor;
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            tableLayoutPanel1.ForeColor = this.ForeColor;
        }


        //protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        //{
        //    // EDIT: ADD AN EXTRA HEIGHT VALIDATION TO AVOID INITIALIZATION PROBLEMS
        //    // BITWISE 'AND' OPERATION: IF ZERO THEN HEIGHT IS NOT INVOLVED IN THIS OPERATION
        //    if ((specified & BoundsSpecified.Height) == 0 || height == DEFAULT_CONTROL_HEIGHT)
        //    {
        //        base.SetBoundsCore(x, y, width, DEFAULT_CONTROL_HEIGHT, specified);
        //    }
        //    else
        //    {
        //        return; // RETURN WITHOUT DOING ANY RESIZING
        //    }
        //}

        public void Clear()
        {
            FirstName = null;
            LastName = null;
            DateOfBirth = null;
            Gender = GenderType.None;
        }

    }
}
