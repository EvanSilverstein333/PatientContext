using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;

namespace Controllers.ViewInterfaces
{
    public interface IPatientView : IView<PatientController>
    {
        void Initialize();
        //void UpdatePatientCallBack(bool updatedPatientSuccessfully);
        //void AddPatientCallBack(bool addedPatientSuccessfully);


    }
}
