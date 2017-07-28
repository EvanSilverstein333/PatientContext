using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;
using SimpleInjector;

namespace Infrastructure.AbstractFactories
{
    public class ControllerFactory : IControllerFactory
    {

        private Container _container;

        public ControllerFactory(Container container)
        {
            _container = container;
        }

        public TController Resolve<TController>() where TController : class, IController
        {
            var controller = _container.GetInstance<TController>();
            return controller;

        }
    }
}
