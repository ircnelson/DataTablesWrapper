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
            IQueryable<T> queryable = collection.AsQueryable();

            //TODO: Utilizar DynamicQueryable

            var columns = typeof(T)
                .GetProperties()
                .Where(p => p.GetGetMethod() != null)
                .Select(p => Tuple.Create(p.Name, p.PropertyType)).ToArray();

            if (!String.IsNullOrEmpty(param.sSearch))
            {
                var searchColumns = new List<string>();
                var parameters = new List<object>();

                for (int i = 0; i < param.iColumns; i++)
                {
                    if (param.bSearchables[i])
                    {
                        searchColumns.Add(PrepareClause(param.sSearch, columns[i], parameters));
                    }
                }

                queryable = queryable.Where(string.Join(" or ", searchColumns), parameters);
            }


            Console.WriteLine(queryable);

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

        private string PrepareClause(string query, Tuple<string, Type> column, List<object> linqParameters)
        {
            var columnType = column.Item2.GetType();
            
            if (columnType == typeof(string))
            {
                query = FilterString(query);
            }

            var parts = query.Split('~').Select(q => string.Format("({1} == null ? \"\" : {1}.ToString()).{0}", FilterString(q), column.Item1));
            return "(" + string.Join(") OR (", parts) + ")";
        }

        private string FilterString(string q)
        {
            if (q.StartsWith("^"))
            {
                return "ToLower().StartsWith(\"" + q.ToLower().Substring(1).Replace("\"", "\"\"") + "\")";
            }
            else
            {
                return "ToLower().Contains(\"" + q.ToLower().Replace("\"", "\"\"") + "\")";
            }
        }
    }
}
