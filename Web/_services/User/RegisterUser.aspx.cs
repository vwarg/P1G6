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
                /*HeftITGemer.User u = (HeftITGemer.User)Session["User"];
                // User user = new User(Request.Form["firstname"], Request.Form["lastname"], Request.Form["phone"], Request.Form["companyname"], -1, -1); //adress FÅR EJ vara -1. MÅSTE ha ID tack vare FK.
                int uiid = UserInfo.AddUserInfo(userinfo);
                u.Contactinfo = uiid;
                Session["User"] = u;
                Response.Write($"{userinfo.ID}\r\n");
                Response.StatusCode = 200;
                Response.End(); */
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