using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web._services.Products
{
    public partial class GetCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var jsonStr = "[";
            var catList = EshopSQL.SQL.GetAllCategories();

            if (catList.Count > 0)
            {
                foreach (var c in catList)
                {
                    jsonStr += c.ToJson();
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