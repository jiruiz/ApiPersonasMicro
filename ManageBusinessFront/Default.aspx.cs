using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManageBusinessFront
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // aca deberia ir la logica del usuario logueado, si se requiere

            if (Session["IdUsuario"] == null)
            {
                // Nadie logueado → redirigir al login
                Response.Redirect("~/Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            if (!IsPostBack)
            {
                Session.Clear(); // limpiar sesión vieja
                                 // mostrar panel de login si no hay usuario logueado
            }
        }
    }
}