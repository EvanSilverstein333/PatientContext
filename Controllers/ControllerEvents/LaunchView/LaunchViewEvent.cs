using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;
using Controllers.ViewInterfaces;

namespace Controllers.ControllerEvents.LaunchView
{
    public class LaunchViewEvent : IControllerEvent
    {
        public IViewBase MasterView { get; set; }
        public IViewBase[] DetailViews { get; set; }

        public LaunchViewEvent(IViewBase masterView, params IViewBase[] detailViews)
        {
            MasterView = masterView;
            DetailViews = detailViews;
        }

    }
}
