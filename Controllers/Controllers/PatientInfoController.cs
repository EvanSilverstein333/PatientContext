using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.MessageBus.CommandDispatcher;
using ApplicationServices.MessageBus.QueryDispatcher;
using Controllers.ViewInterfaces;
using PatientManager.Contract.Dto;
using PatientManager.Contract.Commands;
using PatientManager.Contract.Queries;



namespace Controllers.Controllers
{
    public class PatientInfoController : IController
    {
        private ICommandService _commandDispatcher;
        private IQueryService _queryDispatcher;
        private IPatientInfoView _patientInfoView;

        public IViewBase View { get { return _patientInfoView; } }
        public bool ViewWasDisposed { get { return _patientInfoView.IsDisposed; } }

        public IPatientInfoView PatientInfoView { get { return _patientInfoView; } }

        public PatientInfoController(ICommandService commandDispatcher, IQueryService queryDispatcher, IPatientInfoView patientInfoView)
        {
            _patientInfoView = patientInfoView;
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
            _patientInfoView.SetController(this);
            _patientInfoView.Text = "Personal";
        }

        //public void Load()
        //{
        //    _patientInfoView.Initialize();
        //    //_patientInfoView.Show();
            
        //}

        public void BindToPatient(PatientDto patient)
        {
            _patientInfoView.BindToPatient(patient);
        }

        public ContactInfoDto GetPatientContactInfo(Guid patientId)
        {
            var query = new GetContactInfoByPatientQuery(patientId);
            var contactInfo = _queryDispatcher.Submit(query) as ContactInfoDto;
            return contactInfo;
        }

        public HealthIdentificationDto GetPatientHealthIdentification(Guid patientId)
        {
            var query = new GetHealthIdByPatientQuery(patientId);
            var healthId = _queryDispatcher.Submit(query) as HealthIdentificationDto;
            return healthId;
        }

        public ActionResult UpdatePatientPersonlInfo(Guid patientId, ContactInfoDto contactInfo, HealthIdentificationDto healthId)
        {
            var result = new ActionResult();
            //var command = new UpdateHealthIdCommand(patientId, contactInfo, healthId);
            //command.NotifyOnCompletion += (cmd, args) => result.ActionSucceeded = args.Success;
            //_commandDispatcher.Submit(command);
            return result;
        }






    }
}
