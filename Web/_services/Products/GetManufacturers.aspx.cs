using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web._services.Products
{
    public partial class GetManufacturers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var jsonStr = "[";
            var mList = EshopSQL.SQL.GetAllManufacturers();

            if (mList.Count > 0)
            {
                foreach (var m in mList)
                {
                    jsonStr += m.ToJson();
                    jsonStr += ", ";
                }
                jsonStr = jsonStr.Remove(jsonStr.Length - 2);
            }

            jsonStr += "]";
            Response.ContentType = "application/json";
            Response.Write(jsonStr);
            Response.End();
        }
    }
}