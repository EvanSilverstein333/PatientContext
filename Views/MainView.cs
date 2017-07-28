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

namespace Views
{
    public partial class MainView : Form, IMainView
    {
        private MainController _controller;
        public MainView()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            btnViewPatients.Click += BtnViewPatients_Click;
            btnPatientVisitView.Click += BtnPatientVisitView_Click;
            
        }

        //public void Initialize()
        //{
        //    throw new NotImplementedException();
        //}


        private void BtnPatientVisitView_Click(object sender, EventArgs e)
        {
            _controller.LaunchPatientVisitView();
        }



        private void BtnViewPatients_Click(object sender, EventArgs e)
        {
            _controller.LaunchPatientView();
        }

        public void SetController(MainController controller)
        {
            _controller = controller;
        }



    }
}
