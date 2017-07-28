using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;

namespace Controllers.ViewInterfaces
{
    public interface IViewHostView : IView<ViewHostController>
    {
        void ComposeView(IViewBase masterView, params IViewBase[] detailViews);
        void SetDetailTabCollectionVisible(bool visible);

    }
}
