using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web._services.Order
{
    public partial class GetProductsInOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((HeftITGemer.User)Session["User"] == null)
            {
                Response.StatusCode = 403;
                Response.End();
                return;
            }
            if (Request.Form["oid"] == null)
            {
                Response.StatusCode = 404;
                Response.End();
                return;
            }
            var oid = Convert.ToInt32(Request.Form["oid"].ToString());
            var u = ((HeftITGemer.User)Session["User"]);

            var oList = EshopSQL.SQL.GetProductsInOrder(oid);
            var jsonStr = "[";

            if (oList.Count > 0)
            {
                foreach (var o in oList)
                {
                    jsonStr += o.ToJson();
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