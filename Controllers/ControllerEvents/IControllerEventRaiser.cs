﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ControllerEvents
{
    public interface IControllerEventRaiser
    {
        void Raise<TEvent>(TEvent ControllerEvent) where TEvent : class, IControllerEvent;
    }
}