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
    public class UpdatePatientVisitCommandHandler : ICommandHandler<UpdatePatientVisitCommand>
    {
        IUnitOfWork _unitOfWork;
        IDomainEventStore _eventStore;
        IPostCommitRegistrator _postCommit;

        public UpdatePatientVisitCommandHandler(IUnitOfWork unitOfWork, IPostCommitRegistrator postCommit, IDomainEventStore eventStore)
        {
            _unitOfWork = unitOfWork;
            _postCommit = postCommit;
            _eventStore = eventStore;

        }

        public void Execute(UpdatePatientVisitCommand command)
        {
            var visitDto = command.Visit;
            var visit = _unitOfWork.PatientVisits.GetWithPatient(command.Visit.Id);
            visit.EditMedicalInfo(visitDto.Date.Value, visitDto.Diagnosis, visitDto.Notes, visitDto.RowVersion);
            _eventStore.AddToEventQueue(new PatientVisitChangedEvent(visit.Patient.Id, visit.Id));
            _unitOfWork.Complete();
            _postCommit.Committed += () =>
            {
                // Set the output property.
                command.CommandCompleted(true);
            };

        }

    }
}
