using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Contract.Commands
{
    public class MessageCompletedEventArgs : EventArgs
    {
        public MessageCompletedEventArgs() { }
        public MessageCompletedEventArgs(bool success)
        {
            Success = success;
        }
        public bool Success { get; }
    }
}
