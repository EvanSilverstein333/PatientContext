using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;

namespace Controllers.ControllerEvents.LaunchView
{
    public class LaunchViewEventHandler : IControllerEventHandler<LaunchViewEvent>
    {

        private ViewHostController _hostController;

        public LaunchViewEventHandler(ViewHostController hostController)
        {
            _hostController = hostController;
        }


        public void Handle(LaunchViewEvent controllerEvent)
        {
            _hostController.ComposeView(controllerEvent.MasterView, controllerEvent.DetailViews);
        }
    }
}
