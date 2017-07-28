using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;

namespace Controllers.ControllerEvents.UpdateHostViewRequested
{
    public class UpdateHostViewRequestedEventHandler : IControllerEventHandler<UpdateHostViewRequestedEvent>
    {
        private ViewHostController _hostController;

        public UpdateHostViewRequestedEventHandler(ViewHostController hostController)
        {
            _hostController = hostController;
        }

        public void Handle(UpdateHostViewRequestedEvent controllerEvent)
        {
            _hostController.SetCaption(controllerEvent.Caption);
            _hostController.DetailTabCollectionVisible(controllerEvent.ShowDetailsTabCollection);
        }
    }
}
