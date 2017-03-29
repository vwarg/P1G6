using HeftITGemer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web._services.Products
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((HeftITGemer.User)Session["User"] == null || ((HeftITGemer.User)Session["User"]).Status != 1)
            {
                Response.StatusCode = 403;
                Response.End();
            }
            
            Product.AddProduct(Request.Form["name"], 
                Request.Form["shortDesc"], 
                Request.Form["longDesc"], 
                Convert.ToInt32(Request.Form["parentProduct"]), 
                (float)Convert.ToDouble(Request.Form["price"]), 
                Convert.ToInt32(Request.Form["countPerUnit"]), 
                Convert.ToInt32(Request.Form["quantity"]), 
                Request.Form["comment"], 
                Request.Form["image"], 
                Request.Form["video"], 
                Convert.ToInt32(Request.Form["status"]), 
                Convert.ToInt32(Request.Form["manufacturerID"]), 
                Request.Form["manufacturerProdNum"], 
                Convert.ToInt32(Request.Form["categoryID"]));
        }
    }
}