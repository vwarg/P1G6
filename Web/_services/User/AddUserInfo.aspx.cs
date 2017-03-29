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
                UserInfo userinfo = new UserInfo(Request.Form["firstname"], Request.Form["lastname"], Request.Form["phone"], Request.Form["companyname"], Convert.ToInt32(Request.Form["billingadressID"]), Convert.ToInt32(Request.Form["deliveryadressID"])); 

                
                int uiid = UserInfo.AddUserInfo(userinfo);
                u.Contactinfo = uiid;

                Session["User"] = u;
                Response.Write($"{uiid}\r\n");
                Response.StatusCode = 200;
                Response.End();
            }
            else
            {
                UserInfo userinfo = new UserInfo(Request.Form["firstname"], Request.Form["lastname"], Request.Form["phone"], Request.Form["companyname"], Convert.ToInt32(Request.Form["billingadressID"]), Convert.ToInt32(Request.Form["deliveryadressID"]));
                
                int uiid = UserInfo.AddUserInfo(userinfo);

                Response.Write($"{uiid}\r\n");
                Response.StatusCode = 200;
                Response.End();
            }
        }
    }
}