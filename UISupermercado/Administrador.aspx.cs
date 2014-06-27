using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UISupermercado
{
    public partial class Administrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvcontacto_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
        }

        protected void gvcontacto_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //int idcontacto = Convert.ToInt32(gvContacto.DataKeys[e.NewSelectedIndex].Value);

            //Response.Redirect(string.Format("EditarContacto.aspx?id={0}", idcontacto));

        }
    }
}