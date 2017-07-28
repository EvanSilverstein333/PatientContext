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
    public class DeletePatientCommandHandler : ICommandHandler<DeletePatientCommand>
    {
        IUnitOfWork _unitOfWork;
        IDomainEventStore _eventStore;
        IPostCommitRegistrator _postCommit;

        public DeletePatientCommandHandler(IUnitOfWork unitOfWork, IPostCommitRegistrator postCommit, IDomainEventStore eventStore)
        {
            _unitOfWork = unitOfWork;
            _postCommit = postCommit;
            _eventStore = eventStore;
        }

        public void Execute(DeletePatientCommand command)
        {
            var patient = _unitOfWork.Patients.Get(command.PatientId);
            _unitOfWork.Patients.Remove(patient);
            _eventStore.AddToEventQueue(new PatientRemovedEvent(patient.Id));
            _unitOfWork.Complete();
            _postCommit.Committed += () =>
            {
                // Set the output property.
                command.CommandCompleted(true);
            };

        }

    }
}
