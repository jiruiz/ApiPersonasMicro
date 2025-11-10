using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManageBusinessFront
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

           // Si no hay usuario en sesión, ocultar el botón de logout
            if (Session["IdUsuario"] == null)
            {
                lnkLogout.Visible = false;
                lnkBusiness.Visible = false;
                lnkEmployees.Visible = false;

            }
            else
            {
                lnkLogout.Visible = true;
                lnkBusiness.Visible = true;
                lnkEmployees.Visible = true;
            }



        }


    }
}