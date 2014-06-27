using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Web.Security;
namespace UISupermercado.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }
       

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            BLAutenticar auten = new BLAutenticar();

            if (auten.Autenticar(LoginUser.UserName, LoginUser.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, LoginUser.RememberMeSet);
                Response.Redirect("~/Administrador.aspx");
            }
        }
    }
}
