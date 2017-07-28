using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.ViewInterfaces;
using System.Windows.Forms;
using Controllers.ControllerEvents;
using Controllers.ControllerEvents.LaunchView;


namespace Controllers.Controllers
{
    public class ViewHostController : IController
    {
        private IViewHostView _viewHost;
        //private IView<IController> _masterView;
        //private IView<IController>[] _detailViews;
        private IControllerFactory _controllerFactory;

        public IViewBase View { get { return _viewHost; } }
        public bool ViewWasDisposed { get { return _viewHost.IsDisposed; } }

        public ViewHostController(IViewHostView viewHost, IControllerFactory controllerFactory)
        {
            _viewHost = viewHost;
            _controllerFactory = controllerFactory;
        }

        public void StartApplication()
        {
            Application.EnableVisualStyles();
            LaunchMainView();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run((Form)_viewHost);
        }

        public void ComposeView(IViewBase masterView, params IViewBase[] detailViews)
        {
            //_masterView = masterView;
            //_detailViews = detailViews;
            _viewHost.ComposeView(masterView, detailViews);

        }

        public void SetCaption(string caption)
        {
            _viewHost.Text = caption;
        }

        public void DetailTabCollectionVisible(bool visible)
        {
            _viewHost.SetDetailTabCollectionVisible(visible);
        }

        private void LaunchMainView()
        {
            var mainController = _controllerFactory.Resolve<MainController>();
            ComposeView(mainController.View);

            //ControllerEventsRaiser.Raise(new LaunchViewEvent(mainController.))
        }

        //public void Load()
        //{
        //    _viewHost.ComposeView(_masterView, _detailViews);
        //}


    }
}
