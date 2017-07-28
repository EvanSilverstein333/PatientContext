using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.MessageBus.QueryDispatcher;
using Controllers.Controllers;

namespace Controllers.ControllerEvents.PatientSelected
{
    public class PatientSelectionChangedEventHandler : IControllerEventHandler<PatientSelectionChangedEvent>
    {
        private IQueryService _queryDispatcher;
        private ViewHostController _hostController;
        private PatientVisitController _visitsController;
        private PatientInfoController _ptInfoController;
    
        public PatientSelectionChangedEventHandler(IQueryService queryDispatcher, ViewHostController hostController,  PatientInfoController patientInfoController, PatientVisitController visitsController)
        {
            //_queryDispatcher = queryDispatcher;
            _hostController = hostController;
            _visitsController = visitsController;
            _ptInfoController = patientInfoController;
        }

        public void Handle(PatientSelectionChangedEvent controllerEvent)
        {
            var patient = controllerEvent.Patient;
            _ptInfoController.BindToPatient(patient);
            _visitsController.BindToPatient(patient);

        }

        //private void DataActions(PatientDto patient)
        //{
            
        //}

        //private void FormatViews(PatientDto patient)
        //{
        //    var caption = (patient == null) ? "" : string.Format("{0} {1}", patient.FirstName, patient.LastName);
        //    _hostController.SetCaption(caption);
        //    _hostController.DetailTabCollectionVisible(patient != null);

        //}
    }
}
