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
    public class UpdateContactInfoCommandHandler : ICommandHandler<UpdateContactInformationCommand>
    {
        IUnitOfWork _unitOfWork;
        IDomainEventStore _eventStore;
        IPostCommitRegistrator _postCommit;

        public UpdateContactInfoCommandHandler(IUnitOfWork unitOfWork, IPostCommitRegistrator postCommit, IDomainEventStore eventStore)
        {
            _unitOfWork = unitOfWork;
            _postCommit = postCommit;
            _eventStore = eventStore;
        }

        public void Execute(UpdateContactInformationCommand command)
        {
            var contactInfoDto = command.ContactInfo;

            var contactInfo = _unitOfWork.ContactInformation.GetByPatientId(command.PatientId);

            contactInfo.ChangeInfo(contactInfoDto.Address, contactInfoDto.PrimaryPhoneNumber, contactInfoDto.SecondaryPhoneNumber, contactInfoDto.Email, contactInfoDto.RowVersion);
            _eventStore.AddToEventQueue(new ContactInfoChangedEvent(contactInfo.Id));
            _unitOfWork.Complete();
            _postCommit.Committed += () =>
            {
                // Set the output property.
                command.CommandCompleted(true);
            };
        }
    }
}
