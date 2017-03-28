using EshopSQL;
using HeftITGemer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web._services.Order
{
    public partial class AddProductToOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                var id = Request.Form["productID"];
                if (Request.Form["variation"] != null && Convert.ToInt32(Request.Form["variation"]) > 0)
                {
                    id = Request.Form["variation"];
                }
                int q = 1;
                if(Request.Form["quantity"] != null)
                {
                    q = Convert.ToInt32(Request.Form["quantity"]);
                }
                HeftITGemer.User u = (HeftITGemer.User)Session["User"];
                var p = Product.GetProductById(Convert.ToInt32(id));
                int oid;
                var ao = u.ActiveOrder;
                if (ao == null)
                {
                    oid = HeftITGemer.Order.AddOrder(u);
                }
                else
                {
                    oid = ao.ID;
                }
                //
                if(SQL.GetProductsInOrder(oid).Exists(pr => pr.ID == p.ID))
                {
                    HeftITGemer.Order.IncreaseQuantityOfProduct(p.ID, oid, q);
                }
                else
                {
                    HeftITGemer.Order.AddProductToOrder(p.ID, oid, q);
                }
                Response.Redirect("/");
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