using HeftITGemer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web._services.User
{
    public partial class AddAdress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                HeftITGemer.UserInfo ui = (HeftITGemer.UserInfo)Session["User"];

                Adress adress = new Adress(Request.Form["country"], Request.Form["city"], Request.Form["street"], Request.Form["zip"], Request.Form["phone"], Request.Form["department"]);

                int baid = Adress.AddAdress(adress);

                ui.BillingadressID = baid;
                ui.DeliveryadressID = baid;

                Session["User"] = ui;
                Response.Write($"{baid} \r\n");
                Response.StatusCode = 200;
                Response.End();
            }
            else
            {
                Adress adress = new Adress(Request.Form["country"], Request.Form["city"], Request.Form["street"], Request.Form["zip"], Request.Form["phone"], Request.Form["department"]);

                int baid = Adress.AddAdress(adress);
                Response.Write($"{baid} \r\n");
                Response.StatusCode = 200;
                Response.End();
            }
        }
    }
}