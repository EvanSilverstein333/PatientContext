using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Contract.Commands;

namespace ApplicationServices.CommandHandlers
{
    public interface ICommandHandler<TCommand> //: IMessageHandler<TCommand,CommandResult> 
        where TCommand : ICommand 
    {
        void Execute(TCommand command);
    }
}
