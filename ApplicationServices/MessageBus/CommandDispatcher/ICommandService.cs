using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ApplicationServices.MessageBus.CommandDispatcher
{
    //[ServiceContract]
    public interface ICommandService
    {
        //[OperationContract]
        void Submit(dynamic command);
    }
}
