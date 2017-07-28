using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ControllerEvents.UpdateHostViewRequested
{
    public class UpdateHostViewRequestedEvent : IControllerEvent
    {
        public UpdateHostViewRequestedEvent(string caption, bool showDetailsTabCollection)
        {
            Caption = caption;
            ShowDetailsTabCollection = showDetailsTabCollection;
        }
        public string Caption { get; set; }
        public bool ShowDetailsTabCollection { get; set; }
    }
}
