using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValueObjects.ContactInformation;

namespace Views
{
    public partial class ContactInfoControl : UserControl
    {
        private bool _readOnly;

        public ContactInfoControl()
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
        public Address Address
        {
            get { return ComposeAddress(); }
            set { BindToAddress(value); }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string City
        {
            get { return inputCity.Text; }
            set { inputCity.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Provice
        {
            get { return inputProvince.Text; }
            set { inputProvince.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Country
        {
            get { return inputCountry.Text; }
            set { inputCountry.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string StreetAddress
        {
            get { return inputStreetAddress.Text; }
            set { inputStreetAddress.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AppartmentUnit
        {
            get { return inputAppartmentUnit.Text; }
            set { inputAppartmentUnit.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PostalCode
        {
            get { return inputPostalCode.Text; }
            set { inputPostalCode.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PhoneNumber SecondaryPhoneNumber
        {
            get { return new PhoneNumber(inputSecondaryPhoneNumber.Text); }
            set { inputSecondaryPhoneNumber.Text = value.Number; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PhoneNumber PrimaryPhoneNumber
        {
            get { return new PhoneNumber(inputPrimaryPhoneNumber.Text); }
            set { inputPrimaryPhoneNumber.Text = value.Number; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Email
        {
            get { return inputEmail.Text; }
            set { inputEmail.Text = value; }
        }


        [Category("Appearance")]
        public TableLayoutPanelCellBorderStyle CellBorderStyle
        {
            get { return tableLayoutPanel1.CellBorderStyle; }
            set { tableLayoutPanel1.CellBorderStyle = value; }
        }

        private void FormatReadOnly()
        {
            SuspendLayout();
            foreach (var input in tableLayoutPanel1.Controls)
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
            }
            ResumeLayout();
        }

        private Address ComposeAddress()
        {
            var address = new Address(
                Country, Provice, City, StreetAddress, AppartmentUnit, PostalCode
                );
            return address;
        }

        private void BindToAddress(Address address)
        {
            Country = address.Country;
            Provice = address.Province;
            City = address.City;
            StreetAddress = address.StreetAddress;
            AppartmentUnit = address.AppartmentUnit;
            PostalCode = address.PostalCode;
        }

        public event EventHandler ReadOnlyChanged;
        protected virtual void OnReadOnlyChanged()
        {
            FormatReadOnly();
            var handler = ReadOnlyChanged;
            if(handler!= null) { handler.Invoke(this, EventArgs.Empty); }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            tableLayoutPanel1.BackColor = this.BackColor;
        }

        public void Clear()
        {
            
            Address = new Address(null,null,null,null,null,null);
            PrimaryPhoneNumber = new PhoneNumber(null);
            SecondaryPhoneNumber = new PhoneNumber(null);
            Email = null;

        }


    }
}
