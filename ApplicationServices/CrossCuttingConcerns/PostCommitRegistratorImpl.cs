using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.CommandHandlers;

namespace ApplicationServices.CrossCuttingConcerns
{
    public sealed class PostCommitRegistratorImpl : IPostCommitRegistrator
    {
        public event Action Committed;
        //public event EventHandler<MessageCompletedEventArgs> Committed;

        //public void MessageCompleted(bool success)
        //{
        //    var handler = Committed;
        //    if(handler!= null) { Committed.Invoke(this, new MessageCompletedEventArgs(success)); }
        //}

        //public void Reset()
        //{
        //    Committed = (y,x) => { }; // clears list of handlers
        //}
        public void ExecuteActions()
        {
            var handler = Committed;
            if(handler != null) { handler.Invoke(); }
        }

        public void Reset()
        {
            // Clears the list of actions.
            this.Committed = () => { };
        }
    }
}
