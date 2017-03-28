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
            //User:: Request.Form["email"], Request.Form["password"]
            //UserInfo:: se AddUserInfo
            //Adress:: _minst_ en, se Adress();

            if (Session["User"] != null)
            {
                HeftITGemer.User u = (HeftITGemer.User)Session["User"];

                int uid = SQL.AddUser(Request.Form["email"], Request.Form["password"], Convert.ToInt32(Request.Form["contactInfo"]));

                u.ID = uid;

                Session["User"] = u;
                Response.Write($"{uid} \r\n");
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