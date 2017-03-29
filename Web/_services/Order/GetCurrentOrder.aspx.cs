using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web._services.Order
{
    public partial class GetCurrentOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((HeftITGemer.User)Session["User"] == null)
            {
                Response.StatusCode = 403;
                Response.End();
                return;
            }
            var u = ((HeftITGemer.User)Session["User"]);
            var uid = u.ID;
            if (((HeftITGemer.User)Session["User"]).Status > 1 && Request.Form["uid"] != null)
            {
                uid = Convert.ToInt32(Request.Form["uid"].ToString());
            }

            var o = EshopSQL.SQL.GetActiveOrders(uid);
            var jsonStr = "{ }";
            if (o != null)
            {
                jsonStr = o.ToJson(true);
            }

            Response.StatusCode = 200;
            Response.ContentType = "application/json";
            Response.Write(jsonStr);
            Response.End();
        }
    }
}