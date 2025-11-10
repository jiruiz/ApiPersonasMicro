using System;
using System.Web;
using System.Web.Security;

namespace ManageBusinessFront
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // No tocar nada de UI, ni MasterPage: solo limpiar y salir.

            // 1) Autenticación (si usás FormsAuth)
            FormsAuthentication.SignOut();

            // 2) Sesión
            Session.Clear();
            Session.Abandon();

            // 3) Cookies (session + auth)
            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                var sc = new HttpCookie("ASP.NET_SessionId", "");
                sc.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(sc);
            }
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                var ac = new HttpCookie(FormsAuthentication.FormsCookieName, "");
                ac.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(ac);
            }

            // 4) Evitar cache del browser al volver atrás
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            // 5) Redirigir limpio
            Response.Redirect("~/login.aspx", true);
        }
    }
}