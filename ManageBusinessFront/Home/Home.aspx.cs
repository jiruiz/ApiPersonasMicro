using System;
using System.Web.UI;

namespace ManageBusinessFront.Home
{
    public partial class Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Aquí puedes agregar lógica adicional si es necesario
        }

        protected void btnGoToBusinesses_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Business/BusinessList.aspx");
        }

        protected void btnGoToEmployees_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employees/EmployeesList.aspx");
        }
    }
}