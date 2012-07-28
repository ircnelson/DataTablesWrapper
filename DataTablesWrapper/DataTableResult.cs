using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DataTablesWrapper
{
    public class DataTableResult
    {
        [DataMember(Name = "aaData")]
        public dynamic aaData { get; set; }

        [IgnoreDataMember]
        public string ContentType { get; set; }

        [DataMember(Name = "iTotalDisplayRecords")]
        public int iTotalDisplayRecords { get; set; }

        [DataMember(Name = "iTotalRecords")]
        public int iTotalRecords { get; set; }

        [DataMember(Name = "sColumns")]
        public string sColumns { get; set; }

        [DataMember(Name = "sEcho")]
        public int sEcho { get; private set; }
    }
}
