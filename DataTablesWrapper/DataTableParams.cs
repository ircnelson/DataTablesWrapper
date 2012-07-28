using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTablesWrapper.Enums;

namespace DataTablesWrapper
{
    public class DataTableParams
    {
        public IList<string> mDataProps { get; set; }
        public bool? bEscapeRegex { get; set; }

        public IList<bool> bEscapeRegexs { get; set; }
        public IList<bool> bSearchables { get; set; }
        public IList<bool> bSortables { get; set; }

        public int iColumns { get; set; }
        public int iDisplayLength { get; set; }
        public int iDisplayStart { get; set; }

        public IList<int> iSortCols { get; set; }

        public int iSortingCols { get; set; }
        public int sEcho { get; set; }
        public string sSearch { get; set; }

        public IList<string> sSearchs { get; set; }
        public IList<DataTableSortDirection> sSortDirs { get; set; }

        public DataTableParams()
        {
            mDataProps = new List<string>();
            bSortables = new List<bool>();
            bSearchables = new List<bool>();
            sSearchs = new List<string>();
            iSortCols = new List<int>();
            sSortDirs = new List<DataTableSortDirection>();
            bEscapeRegexs = new List<bool>();
        }
    }
}
