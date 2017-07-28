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
    public class DeletePatientVisitCommandHandler : ICommandHandler<DeletePatientVisitCommand>
    {
        IUnitOfWork _unitOfWork;
        IDomainEventStore _eventStore;
        IPostCommitRegistrator _postCommit;

        public DeletePatientVisitCommandHandler(IUnitOfWork unitOfWork, IPostCommitRegistrator postCommit, IDomainEventStore eventStore)
        {
            _unitOfWork = unitOfWork;
            _postCommit = postCommit;
            _eventStore = eventStore;
        }

        public void Execute(DeletePatientVisitCommand command)
        {
            var visit = _unitOfWork.PatientVisits.GetWithPatient(command.VisitId);
            _eventStore.AddToEventQueue(new PatientVisitRemovedEvent(visit.Patient.Id, visit.Id)); // info only available before removal
            _unitOfWork.PatientVisits.Remove(visit);
            _unitOfWork.Complete();
            _postCommit.Committed += () =>
            {
                // Set the output property.
                command.CommandCompleted(true);
            };

        }
    }
}
