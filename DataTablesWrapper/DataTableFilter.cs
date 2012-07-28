using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTablesWrapper.Interfaces;

namespace DataTablesWrapper
{
    public class DataTableFilter<T> where T : class
    {
        private IDataTableProcessor processor = new DataTableProcessor();
        private DataTableResult Result;

        public DataTableFilter()
        {
            Result = new DataTableResult();
        }

        public DataTableFilter(IDataTableProcessor processor, DataTableParams param, ICollection<T> collection)
            : this(param, collection)
        {
            this.processor = processor;
        }

        public DataTableFilter(DataTableParams param, ICollection<T> collection)
        {
            this.processor.Process<T>(param, collection, out Result);
        }

        public DataTableResult GetResult()
        {
            return Result;
        }
    }
}
