using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObjects.Health;

namespace PatientManager.Contract.Dto
{
    public class HealthIdentificationDto
    {
        [Browsable(false)]
        public Guid Id { get; set; }
        public Healthcard Healthcard { get; set; }
        [Browsable(false)]
        public byte[] RowVersion { get; set; }

    }
}
