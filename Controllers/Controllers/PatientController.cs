using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.MessageBus.CommandDispatcher;
using ApplicationServices.MessageBus.QueryDispatcher;
using Controllers.ViewInterfaces;
using ApplicationServices.Validation;
using Controllers.ControllerEvents.PatientSelected;
using Controllers.ControllerEvents.UpdateHostViewRequested;
using Controllers.ControllerEvents;
using PatientManager.Contract.Commands;
using PatientManager.Contract.Dto;
using PatientManager.Contract.Queries;
using Shared.ValueObjects;


namespace Controllers.Controllers
{
    public class PatientController : IController
    {
        private ICommandService _commandDispatcher;
        private IQueryService _queryDispatcher;
        private IPatientView _patientView;
        private IControllerEventRaiser _eventRaiser;
        public IViewBase View { get { return _patientView; } }

        public bool ViewWasDisposed { get { return _patientView.IsDisposed; } }

        public IPatientView PatientView { get { return _patientView; } }

        public PatientController(ICommandService commandDispatcher, IQueryService queryDispatcher, IPatientView patientView, IControllerEventRaiser eventRaiser)
        {
           
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _patientView = patientView;
            _eventRaiser = eventRaiser;
            _patientView.SetController(this);
            _patientView.Text = "Patients";

        }

        public void Load()
        {
            //AddPatient(null, null, new ContactInfo());
            _patientView.Initialize();
            //_patientView.Show();
            
 
        }

        public void SelectedPatientChanged(PatientDto patient)
        {
            _eventRaiser.Raise(new PatientSelectionChangedEvent(patient));
            
        }



        public ActionResult AddPatient(PatientDto patient, ContactInfoDto contactInfo, HealthIdentificationDto healthId)
        {
            ActionResult result = new ActionResult();
            var command = new AddPatientCommand(patient, contactInfo, healthId);
            command.NotifyOnCompletion += (cmd, args) => result.ActionSucceeded = args.Success;
            _commandDispatcher.Submit(command);
            return result;

        }



        public ActionResult RemovePatient (Guid patientId)
        {
            ActionResult result = new ActionResult();
            var command = new DeletePatientCommand(patientId);
            command.NotifyOnCompletion += (cmd, args) => result.ActionSucceeded = args.Success;
            _commandDispatcher.Submit(command);
            return result;
        }


        public ActionResult UpdatePatient(PatientDto patient)
        {

            ActionResult result = new ActionResult();
            
            var command = new UpdatePatientCommand(patient);
            command.NotifyOnCompletion += (cmd, args) => result.ActionSucceeded = args.Success;
            _commandDispatcher.Submit(command);
            return result;
        }

        public void SearchPatientsByName(string text)
        {

        }

        public IEnumerable<PatientDto> GetAllPatients()
        {
            var query = new GetAllPatientsQuery();
            var patients = _queryDispatcher.Submit(query) as IEnumerable<PatientDto>;
            return patients;
        }

        public void UpdateHostViewRequest(PatientDto patient)
        {
            var caption = (patient == null)? "" : string.Format("{0} {1}", patient.FirstName, patient.LastName);
            var showDetails = patient != null;
            _eventRaiser.Raise(new UpdateHostViewRequestedEvent(caption, showDetails));
        }

        //public ContactInfoDto GetPatientContactInfo(int patientId)
        //{
        //    var query = new GetContactInfoByPatientQuery(patientId);
        //    var contactInfo = _queryDispatcher.Submit(query);
        //    return contactInfo;
        //}

        //public HealthIdentificationDto GetPatientHealthIdentification(int patientId)
        //{
        //    var query = new GetHealthIdByPatientQuery(patientId);
        //    var healthId = _queryDispatcher.Submit(query);
        //    return healthId;
        //}

        //public IEnumerable<PatientVisitDto> GetPatientVisits(int patientId)
        //{
        //    //return _commandDispatcher.GetPatientVisits(patientId);
        //    return null; // temp
        //}

        //public void NewPatientVisitEntry(int id, DateTime date, string notes, string diagnosis)
        //{
        //    //var visit = CreatePatientVisitDTO(id, date, notes, diagnosis);
        //    //_commandDispatcher.AddPatientVisit(visit);
        //}


        //public IEnumerable<RecordDto> GetPatientRecords(int pateintId)
        //{
        //    //return _commandDispatcher.GetPatientRecords(pateintId);
        //    return null;
        //}

        //private PatientDto CreatePatientDto(int id = default(int), string firstName = null, string lastName = null, Address contactInfo = default(Address))
        //{
        //    var patient = new PatientDto();
        //    patient.Id = id;
        //    patient.FirstName = firstName;
        //    patient.LastName = lastName;
        //    return patient;
        //}

        //private PatientVisitDto CreatePatientVisitDTO(int id = default(int), DateTime date = default(DateTime), string notes = null, string diagnosis = null)
        //{
        //    var visit = new PatientVisitDto();
        //    visit.Id = id;
        //    visit.Date = date;
        //    visit.Notes = notes;
        //    visit.Diagnosis = diagnosis;
        //    return visit;
        //}

        //public void Dispose()
        //{
        //    //_commandDispatcher.Dispose();
        //    _patientView.Dispose();
        //}
    }
}
