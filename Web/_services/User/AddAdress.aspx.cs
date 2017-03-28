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
                Adress adress = new Adress(Request.Form["country"], Request.Form["city"], Request.Form["street"], Request.Form["zip"], Request.Form["phone"], Request.Form["department"]);
                int aid = Adress.AddAdress(adress);
                Response.Write($"{adress.ID} \r\n");
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