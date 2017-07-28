using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;
using PatientManager.Contract.Dto;

namespace Controllers.ViewInterfaces
{
    public interface IPatientInfoView : IView<PatientInfoController>
    {
        void Initialize();
        void BindToPatient(PatientDto patient);
    }
}
