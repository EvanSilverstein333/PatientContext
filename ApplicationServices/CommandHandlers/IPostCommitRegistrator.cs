using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.CommandHandlers
{
    public interface IPostCommitRegistrator
    {
        //event Action<MessageCompletedEventArgs> Completed;
        event Action Committed;

    }
}
