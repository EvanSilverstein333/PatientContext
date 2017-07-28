using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.ViewInterfaces;

namespace Controllers.Controllers
{

    public interface IControllerFactory
    {
        TController Resolve<TController>() where TController : class, IController;

    }
}
