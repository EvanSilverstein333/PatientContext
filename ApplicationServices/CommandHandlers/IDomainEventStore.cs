﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Contract.Events;

namespace ApplicationServices.CommandHandlers
{
    public interface IDomainEventStore
    {
        void AddToEventQueue(IDomainEvent e);
    }
}
