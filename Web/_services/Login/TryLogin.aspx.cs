using EshopSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web._services.Login
{
    public partial class TryLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!SQL.TryLogin(Request.Form["email"], Request.Form["password"]))
            {
                Response.StatusCode = 403;
                Response.Write("403\r\n");
                Response.End();
            }
            else
            {
                Response.StatusCode = 200;
                Response.Write("200\r\n");
                Session["User"] = SQL.GetUserByEmail(Request.Form["email"]);
                Response.End();
            }
        }
    }
}