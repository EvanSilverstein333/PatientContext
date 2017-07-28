using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.UnitOfWork;
using Domain.Entities;
using PatientManager.Contract.Commands;
using PatientManager.Contract.Events;


namespace ApplicationServices.CommandHandlers
{
    public class AddPatientVisitCommandHandler : ICommandHandler<AddPatientVisitCommand>
    {

        private IUnitOfWork _unitOfWork;
        private IPostCommitRegistrator _postCommit;
        private IDomainEventStore _eventStore;

        public AddPatientVisitCommandHandler(IUnitOfWork unitOfWork, IPostCommitRegistrator postCommit, IDomainEventStore eventStore)
        {
            _unitOfWork = unitOfWork;
            _postCommit = postCommit;
            _eventStore = eventStore;
        }

        public void Execute(AddPatientVisitCommand command)
        {
            var visitDto = command.Visit;
            var patient = _unitOfWork.Patients.Get(command.PatientId);
            var patientVisit = new PatientVisit(visitDto.Id, visitDto.Date.Value, visitDto.Notes,visitDto.Diagnosis, patient);
            _eventStore.AddToEventQueue(new PatientVisitedEvent(patient.Id, patientVisit.Id));

            _unitOfWork.PatientVisits.Add(patientVisit);
            _unitOfWork.Complete();

            _postCommit.Committed += () =>
            {
                // Set the output property.
                command.CommandCompleted(true);
            };

        }

    }
}
