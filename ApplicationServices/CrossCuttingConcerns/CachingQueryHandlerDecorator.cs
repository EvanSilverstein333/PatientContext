using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using PatientManager.Contract.Queries;
using PatientManager.Contract.Dto;
using ApplicationServices.QueryHandlers;

namespace ApplicationServices.CrossCuttingConcerns
{
    public class CachingQueryHandlerDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private IQueryHandler<TQuery, TResult> _decorated;
        private ObjectCache _cache;
        

        public CachingQueryHandlerDecorator(IQueryHandler<TQuery,TResult> queryHandler, ObjectCache cache)
        {
            _decorated = queryHandler;
            _cache = cache;
        }
        public TResult Handle(TQuery query)
        {
            if(query is FindPatientsBySearchTextQuery) { return _decorated.Handle(query); } // dont cache this query
            else
            {
                var cacehKey = GetCacheKey(query);
                var result = (TResult)_cache.Get(cacehKey);
                if (result == null)
                {
                    var policy = new CacheItemPolicy();
                    policy.SlidingExpiration = new TimeSpan(0, 30, 0); // 30 min
                    result = _decorated.Handle(query);
                    if (result == null) { return result; } // cant cache null values
                    _cache.Add(cacehKey, result, policy);
                }
                return result;
            }

        }

        private string GetCacheKey(TQuery query)
        {
            var queryType = typeof(TQuery);
            var key = queryType.Name;
            //var propertyStringValues = new List<string>(); 
            foreach(var prop in queryType.GetProperties()) // should be simple queriable properties like "Id", "Name", etc
            {
                key += prop.GetValue(query);
                //propertyStringValues.Add(prop.GetValue(query).ToString());
            }
            return key;
        }
    }
}
