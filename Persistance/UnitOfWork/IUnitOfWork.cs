using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;
using Persistance.Repositories;

namespace Persistance.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        PatientRepository Patients { get; }
        //RecordRepository Records { get; }
        PatientVisitRepository PatientVisits { get; }
        ContactInfoRepository ContactInformation { get; }
        HealthIdRepository HealthIdentification { get; }
        //FinancialAccountRepository FinancialAccounts { get; }
        //FinancialTransactionRepository FinancialTransactions { get; }
        int Complete();
    }
}
