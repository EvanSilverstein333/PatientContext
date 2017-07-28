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
    public class UpdateHealthIdCommandHandler : ICommandHandler<UpdateHealthIdCommand>
    {
        IUnitOfWork _unitOfWork;
        IDomainEventStore _eventStore;
        IPostCommitRegistrator _postCommit;

        public UpdateHealthIdCommandHandler(IUnitOfWork unitOfWork, IPostCommitRegistrator postCommit, IDomainEventStore eventStore)
        {
            _unitOfWork = unitOfWork;
            _postCommit = postCommit;
            _eventStore = eventStore;
        }

        public void Execute(UpdateHealthIdCommand command)
        {
            var healthIdDto = command.HealthId;

            var healthId = _unitOfWork.HealthIdentification.GetByPatientId(command.PatientId);

            healthId.ChangeHealthcard(healthIdDto.Healthcard, healthIdDto.RowVersion);
            _eventStore.AddToEventQueue(new HealthcardChangedEvent(healthId.Id));
            _unitOfWork.Complete();
            _postCommit.Committed += () =>
            {
                // Set the output property.
                command.CommandCompleted(true);
            };
        }
    }
}
