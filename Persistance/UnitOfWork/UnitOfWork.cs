using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using Domain.Entities;
using Persistance.Repositories;
using Persistance.Context;
using System.Data;

namespace Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PatientContext _context;
        private PatientRepository _patients;
        private PatientVisitRepository _patientVisits;
        private HealthIdRepository _healthcards;
        private ContactInfoRepository _contactInfo;

        public PatientRepository Patients { get { return _patients; } }
        public PatientVisitRepository PatientVisits { get { return _patientVisits; } }
        public HealthIdRepository HealthIdentification { get { return _healthcards; } }
        public ContactInfoRepository ContactInformation { get { return _contactInfo; } }

        
        public UnitOfWork(PatientContext context)
        {
            _context = context;
            RepositoryFactory(context);
        }

        //private void RepositoryFactory(DbContext context, PatientRepository patientRepository, PatientVisitRepository patientVisitRepository, HealthIdRepository healthIdRepository, ContactInfoRepository contactInfoRepository)

        private void RepositoryFactory(DbContext context)
        {

            _patients = new PatientRepository(context);
            _patientVisits = new PatientVisitRepository(context);
            _healthcards = new HealthIdRepository(context);
            _contactInfo = new ContactInfoRepository(context);
        }

        public int Complete()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new OptimisticConcurrencyException("Another user has updated that entry", e);
            }
            
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
