using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers.ViewInterfaces;
using Controllers.ControllerEvents;
using Controllers.ControllerEvents.LaunchView;

namespace Controllers.Controllers
{
    public class MainController : IController
    {
        private IMainView _mainView;
        private IControllerFactory _controllerFactory;
        private IControllerEventRaiser _eventRaiser;
        public IViewBase View { get { return _mainView; } }


        public bool ViewWasDisposed { get { return _mainView.IsDisposed; } }

        public MainController(IMainView mainView, IControllerFactory controllerFactory, IControllerEventRaiser eventRaiser)
        {
            _mainView = mainView;
            _eventRaiser = eventRaiser;
            _controllerFactory = controllerFactory;
            _mainView.SetController(this);
            _mainView.Text = "";
        }


        //public void StartApplication()
        //{
        //    Application.EnableVisualStyles();
        //    //Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run((Form)_mainView);
        //}

        //private void Initialize()
        //{

        //}

        public void LaunchPatientView()
        {
            var patientController = _controllerFactory.Resolve<PatientController>();
            patientController.Load();
            var patientInfoController = _controllerFactory.Resolve<PatientInfoController>();
            var patientVisitController = _controllerFactory.Resolve<PatientVisitController>();
            _eventRaiser.Raise(new LaunchViewEvent(patientController.View, patientInfoController.View, patientVisitController.View));
            //var controller = GetController<PatientController>();
            //var controller = GetController<CompositePatientController>();
            //controller.Load();
        }


        public void LaunchPatientVisitView()
        {
            var controller = GetController<PatientVisitController>();
            controller.Load();

        }

        public TController GetController<TController>() where TController : class, IController
        {
            var controller = _controllerFactory.Resolve<TController>();
            return controller;

        }



    }
}
