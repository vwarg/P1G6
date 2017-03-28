using EshopSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web._services.Products
{
    public partial class GetProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var pList = SQL.GetAllProducts();
            var jsonStr = "[";
            foreach (var p in pList)
            {
                jsonStr += p.ToJson();
                jsonStr += ",";
            }
            jsonStr = jsonStr.Remove(jsonStr.Length - 2);
            jsonStr += "]";
            Response.ContentType = "application/json";
            Response.Write(jsonStr);
            Response.End();
        }
    }
}