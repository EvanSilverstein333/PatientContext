using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ControllerEvents
{
    public interface IControllerEventHandlerFactory
    {
        IControllerEventHandler<TEvent> Resolve<TEvent>() where TEvent : IControllerEvent;
    }
}
