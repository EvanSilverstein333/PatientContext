using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ControllerEvents
{
    public interface IControllerEventHandler<TEvent> where TEvent : IControllerEvent
    {
        void Handle(TEvent controllerEvent);
    }
}
