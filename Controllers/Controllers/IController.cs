using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.ViewInterfaces;

namespace Controllers.Controllers
{
    public interface IController
    {
        IViewBase View { get; }
        bool ViewWasDisposed { get; }
    }
}
