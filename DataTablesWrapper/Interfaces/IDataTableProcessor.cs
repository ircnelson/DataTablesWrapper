using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTablesWrapper.Interfaces
{
    public interface IDataTableProcessor
    {
        void Process<T>(DataTableParams param, ICollection<T> collection, out DataTableResult result);
    }
}
