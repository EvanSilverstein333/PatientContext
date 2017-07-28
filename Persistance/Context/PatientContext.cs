using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;


namespace Persistance.Context
{
    public class PatientContext:DbContext
    {

        public PatientContext()
        {
            Database.SetInitializer<PatientContext>(new DropCreateDatabaseIfModelChanges<PatientContext>());
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<HealthIdentification> HealthId { get; set; }
        public DbSet<PatientVisit> Visits { get; set; }


    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Types<IEntity<Guid>>().Configure(e => e.Property(p => p.RowVersion).IsRowVersion());
            modelBuilder.Entity<Patient>().Property(s => s.RowVersion).IsRowVersion();
            modelBuilder.Entity<PatientVisit>().Property(s => s.RowVersion).IsRowVersion();
            modelBuilder.Entity<HealthIdentification>().Property(s => s.RowVersion).IsRowVersion();
            modelBuilder.Entity<ContactInfo>().Property(s => s.RowVersion).IsRowVersion();

            modelBuilder.Entity<Patient>()
                .Property(patient => patient.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);


            //modelBuilder.ComplexType<PhoneNumber>();
            //modelBuilder.ComplexType<Address>();

            modelBuilder.Entity<Patient>()
               .HasOptional(pt => pt.ContactInfo)
               .WithRequired(ci => ci.Patient)
               .WillCascadeOnDelete(true);

            modelBuilder.Entity<Patient>()
               .HasOptional(pt => pt.Identification)
               .WithRequired(healthId => healthId.Patient)
               .WillCascadeOnDelete(true);


            modelBuilder.Entity<PatientVisit>()
                .HasRequired(visit => visit.Patient)
                .WithMany();


            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureRowVersion<TId>(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types<IEntity<TId>>().Configure(e => e.Property(p => p.RowVersion).IsRowVersion());
        }

    }
}
