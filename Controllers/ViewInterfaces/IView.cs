using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;

namespace Controllers.ViewInterfaces
{
    public interface IView<TController> : IViewBase where TController : IController
    {
        string Text { get; set; }
        void SetController(TController controller);
        bool IsDisposed { get; }
        void Show();
    }
}
