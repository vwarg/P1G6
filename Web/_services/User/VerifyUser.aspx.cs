using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web._services.User
{
    public partial class VerifyUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                EshopSQL.User u = (EshopSQL.User)Session["User"];
                Response.Write($"{u.ID}\r\n");
                Response.End();
            }
            else
            {
                Response.Write("-1\r\n");
                Response.End();
            }
        }
    }
}