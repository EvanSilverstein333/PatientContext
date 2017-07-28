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
    public class UpdatePatientCommandHandler : ICommandHandler<UpdatePatientCommand>
    {
        IUnitOfWork _unitOfWork;
        IDomainEventStore _eventStore;
        IPostCommitRegistrator _postCommit;

        public UpdatePatientCommandHandler(IUnitOfWork unitOfWork, IPostCommitRegistrator postCommit, IDomainEventStore eventStore)
        {
            _unitOfWork = unitOfWork;
            _postCommit = postCommit;
            _eventStore = eventStore;
        }

        public void Execute(UpdatePatientCommand command)
        {
            var patientDto = command.Patient;

            //var patient = _unitOfWork.Patients.GetWithDetails(patientDto.Id);
            var patient = new Patient(patientDto.Id);
            patient.EditIdentity(patientDto.FirstName, patientDto.LastName, patientDto.DateOfBirth, patientDto.Gender, patientDto.RowVersion);
            _unitOfWork.Patients.Update(patient);
            _eventStore.AddToEventQueue(new PatientIdentityChangedEvent(patientDto.Id));
            _unitOfWork.Complete();
            _postCommit.Committed += () =>
            {
                // Set the output property.
                command.CommandCompleted(true);
            };
        }
    }
}
