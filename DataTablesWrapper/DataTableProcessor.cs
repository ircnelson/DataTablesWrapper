using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTablesWrapper.Interfaces;
using DynamicLinq;

namespace DataTablesWrapper
{
    public class DataTableProcessor : IDataTableProcessor
    {
        public void Process<T>(DataTableParams param, ICollection<T> collection, out DataTableResult result)
        {
            IQueryable<T> queryable = (IQueryable<T>)collection;

            //TODO: Utilizar DynamicQueryable

            //if (!String.IsNullOrEmpty(param.sSearch))
            //    resultado = collection.Where(e => e.Nome.ToLower().Contains(param.sSearch.ToLower()));

            var displayed = queryable
                .Skip(param.iDisplayStart)
                .Take(param.iDisplayLength);

            result = new DataTableResult();
            result.aaData = queryable;
            result.iTotalRecords = collection.Count();
            result.iTotalDisplayRecords = queryable.Count();
        }
    }
}
