using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObjects.Health;
using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class HealthIdentification : IEntity<Guid>
    {
        internal HealthIdentification() { }
        public HealthIdentification(Guid id, Healthcard healthcard)
        {
            Id = id;
            Healthcard = healthcard;
        }
        public Guid Id { get; private set; }
        public Healthcard Healthcard { get; private set; } 
        public virtual Patient Patient { get; private set; }
        public byte[] RowVersion { get; private set; }

        public void ChangeHealthcard(Healthcard healthcard, byte[] rowVersion)
        {
            Healthcard = healthcard;
            RowVersion = rowVersion;
        }

    }
}



    
