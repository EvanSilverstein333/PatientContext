using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared.ValueObjects;
using ValueObjects.Health;

namespace Views
{

    public partial class GenderControl : UserControl
    {
        private bool genderPropertyChangedDirectly = true;
        private GenderType _value;
        private GenderOptions _genderOptions;

        public GenderControl()
        {
            InitializeComponent();
            Value = GenderType.None; //default
            GenderOptions = GenderOptions.MaleFemaleOther; //default
            btnMale.CheckedChanged += Gender_CheckedChanged;
            btnFemale.CheckedChanged += Gender_CheckedChanged;
            btnOther.CheckedChanged += Gender_CheckedChanged;

        }

        [Category("Appearance")]
        public GenderOptions GenderOptions
        {
            get { return _genderOptions; }
            set
            {
                _genderOptions = value;
                OnGenderOptionsChanged();
            }
        }

        [Category("Behavior")]
        public GenderType Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (genderPropertyChangedDirectly) { FormatRadioButton(value); }
                OnGenderChanged();
            }
        }


        private void FormatRadioButton(GenderType gender)
        {

            btnMale.CheckedChanged -= Gender_CheckedChanged;
            btnFemale.CheckedChanged -= Gender_CheckedChanged;
            btnOther.CheckedChanged -= Gender_CheckedChanged;


            switch (gender)
            {
                case GenderType.Male:
                    btnMale.Checked = true;
                    break;
                case GenderType.Female:
                    btnFemale.Checked = true;
                    break;
                case GenderType.Other:
                    btnOther.Checked = true;
                    break;
                default:
                    btnFemale.Checked = btnMale.Checked = btnOther.Checked = false;
                    break;

            }

            btnMale.CheckedChanged += Gender_CheckedChanged;
            btnFemale.CheckedChanged += Gender_CheckedChanged;
            btnOther.CheckedChanged += Gender_CheckedChanged;

        }

        private void Gender_CheckedChanged(object sender, EventArgs e)
        {
            genderPropertyChangedDirectly = false;
            var btn = sender as RadioButton;
            if (btn.Checked) { GenderSelectionByRadioBtn(btn); } // ignore btn that was deselected
            genderPropertyChangedDirectly = true; // reset for nexttime
        }

        private void GenderSelectionByRadioBtn(RadioButton btn)
        {
            GenderType gender;
            if (btnMale.Checked) { gender = GenderType.Male; }
            else if (btnFemale.Checked) { gender = GenderType.Female; }
            else if (btnOther.Checked) { gender = GenderType.Other; }
            else { gender = GenderType.None; }

            if (Value != gender) { Value = gender; }
        }

        public event EventHandler GenderChanged;
        public event EventHandler GenderOptionsChanged;

        protected virtual void OnGenderOptionsChanged()
        {
            var OtherGenderOptionAllowed = (GenderOptions == GenderOptions.MaleFemaleOther);
            btnOther.Visible = OtherGenderOptionAllowed;
            if(!OtherGenderOptionAllowed && Value == GenderType.Other) { Value = GenderType.None; }
            var handler = GenderOptionsChanged;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }

        }

        protected virtual void OnGenderChanged()
        {
            if (GenderOptions != GenderOptions.MaleFemaleOther)
            {
                if (Value == GenderType.Other)
                {
                    Value = GenderType.None;
                    return;
                }
            }
            var handler = GenderChanged;
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




    }

}

