using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManageBusinessFront
{
    public partial class Negocios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Si no hay sesión activa, redirigir al login
                if (Session["IdUsuario"] == null)
                    Response.Redirect("Login.aspx");
                else
                    lblBienvenida.Text = "Bienvenido, usuario " + Session["IdUsuario"];
            }

        }
    }
}