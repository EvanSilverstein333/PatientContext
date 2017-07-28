using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Contract.Dto;
using PatientManager.Contract.Commands;
using PatientManager.Contract.Queries;

using ApplicationServices.MessageBus.CommandDispatcher;
using ApplicationServices.MessageBus.QueryDispatcher;
using Controllers.ViewInterfaces;
using ApplicationServices.Validation;

namespace Controllers.Controllers
{
    public class PatientVisitController : IController
    {

        private ICommandService _commandDispatcher;
        private IQueryService _queryDispatcher;
        public IPatientVisitView _patientVisitView;

        public IViewBase View { get { return _patientVisitView; } }
        public bool ViewWasDisposed { get { return _patientVisitView.IsDisposed; } }

        public PatientVisitController(ICommandService commandDispatcher, IQueryService queryDispatcher, IPatientVisitView patientView)
        {

            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _patientVisitView = patientView;
            _patientVisitView.SetController(this);
            _patientVisitView.Text = "Medical History";
        }

        public void BindToPatient(PatientDto patient)
        {
            _patientVisitView.BindToPatient(patient);
        }

        public void Load()
        {
            //_patientVisitView.Initialize();
            //_patientVisitView.Show();
        }

        public IEnumerable<PatientVisitDto> GetAllPatientVisits()
        {
            var query = new GetAllPatientVisitsQuery();
            var patientVisits = _queryDispatcher.Submit(query) as IEnumerable<PatientVisitDto>;
            return patientVisits;
        }

        public IEnumerable<PatientVisitDto> GetVisitsByPatient(Guid patientId)
        {
            var query = new GetPatientVisitsByPatientQuery(patientId);
            var visits = _queryDispatcher.Submit(query) as IEnumerable<PatientVisitDto>;
            return visits;
        }

        public ActionResult AddPatientVisit(PatientVisitDto visit, Guid patientId)
        {
            var result = new ActionResult();
            var command = new AddPatientVisitCommand(visit, patientId);
            command.NotifyOnCompletion += (cmd, args) => result.ActionSucceeded = args.Success;
            _commandDispatcher.Submit(command);
            return result;
        }

        public ActionResult RemovePatientVisit(Guid visitId)
        {
            var result = new ActionResult();
            var command = new DeletePatientVisitCommand(visitId);
            command.NotifyOnCompletion += (cmd, args) => result.ActionSucceeded = args.Success;
            _commandDispatcher.Submit(command);
            return result;
        }

        public ActionResult UpdatePatientVisit(PatientVisitDto visit)
        {
            var result = new ActionResult();
            var command = new UpdatePatientVisitCommand(visit);
            command.NotifyOnCompletion += (cmd, args) => result.ActionSucceeded = args.Success;
            _commandDispatcher.Submit(command);
            return result;
        }




    }


}
