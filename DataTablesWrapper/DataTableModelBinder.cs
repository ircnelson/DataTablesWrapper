using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DataTablesWrapper.Enums;

namespace DataTablesWrapper
{
    public class DataTableModelBinder : IModelBinder
    {

        public object BindModel(System.Web.Mvc.ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            DataTableParams obj = new DataTableParams();
            var request = controllerContext.HttpContext.Request.Params;

            obj.iDisplayStart = Convert.ToInt32(request["iDisplayStart"]);
            obj.iDisplayLength = Convert.ToInt32(request["iDisplayLength"]);
            obj.iColumns = Convert.ToInt32(request["iColumns"]);
            obj.sSearch = request["sSearch"];
            obj.bEscapeRegex = Convert.ToBoolean(request["bEscapeRegex"]);
            obj.iSortingCols = Convert.ToInt32(request["iSortingCols"]);
            obj.sEcho = int.Parse(request["sEcho"]);

            for (int i = 0; i < obj.iColumns; i++)
            {
                obj.mDataProps.Add(request["mDataProp_" + i]);
                obj.bSortables.Add(Convert.ToBoolean(request["bSortable_" + i]));
                obj.bSearchables.Add(Convert.ToBoolean(request["bSearchable_" + i]));
                obj.sSearchs.Add(request["bSearch_" + i]);
                obj.bEscapeRegexs.Add(Convert.ToBoolean(request["bEscapeRegex_" + i]));
                obj.iSortCols.Add(Convert.ToInt32(request["iSortCol_" + i]));

                DataTableSortDirection defaultSortDirection = DataTableSortDirection.asc;

                Enum.TryParse<DataTableSortDirection>(request["sSortDir_" + i], out defaultSortDirection);

                obj.sSortDirs.Add(defaultSortDirection);
            }

            return obj;
        }
    }
}
