using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
namespace ManageBusinessFront.Employees
{
    public partial class EmployeesList : System.Web.UI.Page
    {
        private int idBusiness;
        public class Employee
        {
            public int Id { get; set; }
            public string EmployeeCode { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Departament {  get; set; }
            public string Range { get; set; }

            public string HireDate { get; set; }
            public string State { get; set; }
        }

        public class Business
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Industry { get; set; } = string.Empty;
            public string PhoneNumber { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string TaxId { get; set; } = string.Empty;
            public string VATStatus { get; set; } = string.Empty;
            public string LegalName { get; set; } = string.Empty;
            public DateTime StartOfActivities { get; set; }
            public int YearsInIndustry { get; set; }
            public string Street { get; set; } = string.Empty;
            public string City { get; set; } = string.Empty;
            public string State { get; set; } = string.Empty;
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int businessId = 4; // valor por defecto
                if (Request.QueryString["idBusiness"] != null)
                    int.TryParse(Request.QueryString["idBusiness"], out businessId);

                ViewState["idBusiness"] = businessId; // guardamos en ViewState, para reenviarlo correctamente

                await LoadEmployeesAsync(businessId);
                await LoadBusinessData(businessId);
            }
            else
            {
                // recuperar el valor durante postbacks
                idBusiness = (int)(ViewState["idBusiness"] ?? 1);
            }

            ConfirmDeleteModal1.OnDeleteConfirmed += ConfirmDeleteModal1_OnDeleteConfirmed;
        }

        protected async Task LoadEmployeesAsync(int idBusiness)
        {
            var client = new HttpClient();
            var res = await client.GetAsync($"http://localhost:5002/api/Employee/business/{idBusiness}");
            if (!res.IsSuccessStatusCode)
            {
                // Si la API devuelve error, porque no hay empleados por ej
                gvEmployees.DataSource = null;
                gvEmployees.DataBind();
                return;
            }

            var json = await res.Content.ReadAsStringAsync();

            var employees = JsonConvert.DeserializeObject<List<Employee>>(json);
            gvEmployees.DataSource = employees;
            gvEmployees.DataBind();
        }

        protected async void gvEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                int idEmployee = Convert.ToInt32(e.CommandArgument);

                // Redirigir a la página de edición con ambos IDs
                Response.Redirect($"~/Employees/EditEmployee.aspx?idEmployee={idEmployee}&idBusiness={idBusiness}", false);
            }
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect($"CreateEmployee.aspx?idBusiness={idBusiness}", false);
        }

        protected async void ConfirmDeleteModal1_OnDeleteConfirmed(object sender, string objectId)
        {
            if (int.TryParse(objectId, out var id))
            {
                await DeleteEmployeeAsync(id);
            }
        }

        private async Task LoadBusinessData(int businessId)
        {
            var client = new HttpClient();
            var res = await client.GetAsync($"https://localhost:7038/api/Business/{businessId}");
            if (!res.IsSuccessStatusCode)
            {
                // Si la API devuelve error, porque no encuentra el business
                return;
            }

            var json = await res.Content.ReadAsStringAsync();

            var business = JsonConvert.DeserializeObject<Business>(json);
            ViewState["BusinessName"] = $"{business.Id} - {business.Name}";
        }


        private async Task DeleteEmployeeAsync(int id)
        {
            using (var client = new HttpClient())
            {
                var res = await client.DeleteAsync($"https://localhost:7199/api/Employee/{id}");
            }
            int businessId = 4; // valor por defecto
            if (Request.QueryString["idBusiness"] != null)
                int.TryParse(Request.QueryString["idBusiness"], out businessId);
            await LoadEmployeesAsync(businessId);
        }
    }
}