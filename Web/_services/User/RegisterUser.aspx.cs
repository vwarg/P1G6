using EshopSQL;
using HeftITGemer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web._services.User
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int uid = SQL.AddUser(Request.Form["email"], Request.Form["password"], Convert.ToInt32(Request.Form["contactInfo"]));
            HeftITGemer.User u = SQL.GetUserByID(uid);
            Session["User"] = u;

        }
    }
}