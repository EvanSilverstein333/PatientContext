using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using System.Windows.Forms;

namespace Views.ExceptionProcessor
{
    public static class ExceptionProcessor
    {
        private static readonly object _locker = new object();

        public static void Process(Exception e)
        {
            lock (_locker)
            {
                Handle(e);
            }
        }

        private static void Handle(Exception e)
        {
            if (e is ValidationException) { ShowErrorMessage("Validation Errors", e.Message); }
            else { throw e; }
        }

        private static void ShowErrorMessage(string caption, string message)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
