using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Contract.Commands
{
    public abstract class MessageNotifyOnCompletion
    {
        public MessageNotifyOnCompletion() { }
        public void CommandCompleted(bool success)
        {
            OnCompletionChanged(new MessageCompletedEventArgs(success));
        }

        [field: NonSerialized]
        public event EventHandler<MessageCompletedEventArgs> NotifyOnCompletion;

        protected virtual void OnCompletionChanged(MessageCompletedEventArgs args)
        {
            var handler = NotifyOnCompletion;
            if(handler != null) { handler.Invoke(this, args); }
        }
    }
}
