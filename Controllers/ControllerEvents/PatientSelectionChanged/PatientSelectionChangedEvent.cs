using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Contract.Dto;

namespace Controllers.ControllerEvents.PatientSelected
{
    public class PatientSelectionChangedEvent : IControllerEvent
    {
        public PatientDto Patient { get; set; }
        public PatientSelectionChangedEvent(PatientDto patient)
        {
            Patient = patient;
        }
    }
}
