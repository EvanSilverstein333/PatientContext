﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.MessageBus.QueryDispatcher;
using PatientManager.Contract.Queries;
using ApplicationServices.QueryHandlers;
using SimpleInjector;
using System.ServiceModel;
using System.Reflection;
using ValueObjects.Wcf;

namespace Infrastructure.AbstractFactories
{
    [ServiceContract()]
    [ServiceKnownType(nameof(GetKnownTypes))]
    public class PatientManagerQueryProcessor : IQueryService
    {

        public PatientManagerQueryProcessor()
        {
            //_container = container;
        }



        [OperationContract]
        [FaultContract(typeof(MyValidator))]
        public object Submit(dynamic query)
        {

            try
            {
                Type queryType = query.GetType();
                Type resultType = GetQueryResultType(queryType);
                Type queryHandlerType = typeof(IQueryHandler<,>).MakeGenericType(queryType, resultType);

                dynamic queryHandler = Bootstrapper.Container.GetInstance(queryHandlerType);

                return queryHandler.Handle(query);
            }
            catch (Exception ex)
            {
                if (ex is FaultException == false)
                {
                    Bootstrapper.Logger.Error("Unknown error occured", ex); // unknown error
                    var faultException = WcfExceptionTranslatorDebugger.CreateFaultExceptionOrNull(ex);
                    if (faultException != null) { throw faultException; }
                }

                throw;
            }
        }



        //public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        //{
        //    var types = Bootstrapper.AllContractTypes.ToList();
        //    //types.Add(typeof(ValidationException));
        //    types.Add(typeof(WcfValidationFailure));
        //    types.Add(typeof(WcfValidator));
        //    return types;

        //}

        public static IEnumerable<Type> GetKnownTypes(
        ICustomAttributeProvider provider)
        {
            var contractAssembly = typeof(IQuery<>).Assembly;

            var queryTypes = (
                from type in contractAssembly.GetExportedTypes()
                where TypeIsQueryType(type)
                select type)
                .ToList();

            var resultTypes =
                from queryType in queryTypes
                select GetQueryResultType(queryType);

            return queryTypes.Union(resultTypes).ToArray();
        }

        private static bool TypeIsQueryType(Type type)
        {
            return GetQueryInterface(type) != null;
        }

        private static Type GetQueryResultType(Type queryType)
        {
            return GetQueryInterface(queryType).GetGenericArguments()[0];
        }

        private static Type GetQueryInterface(Type type)
        {
            return (
                from interfaceType in type.GetInterfaces()
                where interfaceType.IsGenericType
                where typeof(IQuery<>).IsAssignableFrom(
                    interfaceType.GetGenericTypeDefinition())
                select interfaceType)
                .SingleOrDefault();
        }

    }







}

