using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace Views
{
    public partial class NullableDateTimePicker : DateTimePicker
    {
        private DateTime? _value = null;
        private bool _EditByDatePicker = false;


        public NullableDateTimePicker()
        {
            InitializeComponent();
            Format = DateTimePickerFormat.Long;
            FormatDateTimePickerValue(true);
        }

        [Category("Behavior")]
        [DataType(DataType.DateTime)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public new DateTime? Value
        {
            get
            {
                var value = (_value != null) ? (DateTime?)base.Value : null;
                return value;
            }
            set
            {
                _EditByDatePicker = false;
                _value = value;
                base.Value = value ?? DateTime.Now;
                _EditByDatePicker = true; //turn it back on

            }
        }

        [Category("Appearance")]
        public new DateTimePickerFormat Format { get; set; }


        protected override void OnValueChanged(EventArgs eventargs)
        {
            if (_EditByDatePicker) { _value = base.Value; }
            FormatDateTimePickerValue(_value == null);
            base.OnValueChanged(eventargs);
        }

        private void FormatDateTimePickerValue(bool nullFormat)
        {

            if (nullFormat)
            {
                //datePicker.CustomFormat = (datePicker.Checked && datePicker.Value != datePicker.MinDate) ? "MM/dd/yyyy" : " ";
                // hide date value since it's not set
                this.CustomFormat = " ";
                base.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                this.CustomFormat = null;
                base.Format = Format; // set the date format you want.
            }
        }

        //public new event EventHandler ValueChanged;
        //protected void OnValueChanged()
        //{

        //}
    }
}
