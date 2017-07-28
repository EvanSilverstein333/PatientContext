
using System;
using System.Collections.Generic;
using System.ServiceModel;
using FluentValidation;
using FluentValidation.Results;
using PatientManager.Contract.Commands;
using ApplicationServices.MessageBus;
using ValueObjects.Wcf;

namespace Infrastructure.AbstractFactories
{

    public static class WcfExceptionTranslatorDebugger
    {
        public static FaultException CreateFaultExceptionOrNull(Exception exception)
        {


#if DEBUG
            return new FaultException(exception.ToString());
#else
            return null;
#endif
        }
    }
}