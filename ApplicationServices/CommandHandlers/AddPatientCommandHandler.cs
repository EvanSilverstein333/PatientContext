using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.UnitOfWork;
using Domain.Entities;
using PatientManager.Contract.Commands;
using PatientManager.Contract.Events;
using ValueObjects.ContactInformation;
using PatientManager.Contract.Dto;
using ValueObjects.Health;


namespace ApplicationServices.CommandHandlers
{
    public class AddPatientCommandHandler : ICommandHandler<AddPatientCommand>
    {
        private IUnitOfWork _unitOfWork;
        private IPostCommitRegistrator _postCommit;
        private IDomainEventStore _eventStore;
        
        public AddPatientCommandHandler(IUnitOfWork unitOfWork, IPostCommitRegistrator postCommit, IDomainEventStore eventStore)
        {
            _unitOfWork = unitOfWork;
            _postCommit = postCommit;
            _eventStore = eventStore;
        }
           
        public void Execute(AddPatientCommand command)
        {
            var patientDto = command.Patient;
            var contactInfoDto = command.ContactInfo;
            var healthIdDto = command.HealthId;

            var patient = new Patient(patientDto.Id);
            patient.EditIdentity(patientDto.FirstName, patientDto.LastName, patientDto.DateOfBirth, patientDto.Gender, null);

            patient.ContactInfo = new ContactInfo(patientDto.Id,contactInfoDto.Address, contactInfoDto.PrimaryPhoneNumber, contactInfoDto.SecondaryPhoneNumber, contactInfoDto.Email);
            patient.Identification = new HealthIdentification(patientDto.Id,healthIdDto.Healthcard);
            _eventStore.AddToEventQueue(new NewPatientRegisteredEvent(patient.Id));
            _unitOfWork.Patients.Add(patient);
            _unitOfWork.Complete();

            _postCommit.Committed += () =>
            {
                // Set the output property.
                command.CommandCompleted(true);
            };
        }
    
    }
}
