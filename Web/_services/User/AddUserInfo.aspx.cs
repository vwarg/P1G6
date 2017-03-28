using HeftITGemer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web._services.User
{
    public partial class AddUserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                HeftITGemer.User u = (HeftITGemer.User)Session["User"];
                Response.Write($"{u.ID}\r\n");
                UserInfo.AddUserInfo(u.Info.Firstname, u.Info.Lastname, u.Info.Phone, u.Info.Companyname, u.Info.DeliveryadressID, u.Info.BillingadressID);
                Response.StatusCode = 200;
                Response.End();
            }
            else
            {
                Response.StatusCode = 403;
                Response.Write("-1\r\n");
                Response.End();
            }
        }
    }
}