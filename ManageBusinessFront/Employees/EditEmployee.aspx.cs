using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManageBusinessFront.Employees
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        private int idEmployee;
        private int idBusiness;
        public class Employee
        {
            public int Id { get; set; }
            public string EmployeeCode { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Document {  get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }

            public string BirthdayDate { get; set; }
            public string Departament { get; set; }
            public string Range { get; set; }

            public string HireDate { get; set; }
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            // Desactivar validación unobtrusive (usa el modo clásico de WebForms)
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                if (int.TryParse(Request.QueryString["idBusiness"], out int businessId))
                {
                    idBusiness = businessId;
                }
                else
                {
                    Response.Redirect($"~/Business/BusinessList.aspx", false);
                    return;
                }

                if (Request.QueryString["idEmployee"] != null)
                    int.TryParse(Request.QueryString["idEmployee"], out idEmployee);

                ViewState["idBusiness"] = idBusiness; // guardamos en ViewState, para reenviarlo correctamente
                ViewState["idEmployee"] = idEmployee;
                 
                await LoadEmployeeDataAsync(idEmployee);
            }
            else
            {
                // recuperar el valor durante postbacks
                idBusiness = (int)(ViewState["idBusiness"] ?? 1);
                idEmployee = (int)(ViewState["idEmployee"]);
            }
        }
        protected async Task LoadEmployeeDataAsync(int idEmployee)
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync($"http://localhost:5002/api/Employee/{idEmployee}");
                if (!response.IsSuccessStatusCode)
                {
                    lblMsg.Text = "Error el obtener los datos del empleado";
                    return;
                }
                var json = await response.Content.ReadAsStringAsync();
                var emp = JsonConvert.DeserializeObject<Employee>(json);
                txtFirst.Text = emp.FirstName;
                txtLast.Text = emp.LastName;
                txtDocument.Text = emp.Document;
                txtEmail.Text = emp.Email;
                txtPhone.Text = emp.Phone;
                txtBirth.Text = DateTime.Parse(emp.BirthdayDate.ToString()).ToString("dd/MM/yyyy");
                txtDept.Text = emp.Departament;
                txtRange.Text = emp.Range;

            }
            catch (Exception ex)
            {
                lblMsg.Text = $"Error: {ex.Message}";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(UpdateEmployeeAsync));
        }

        private async Task UpdateEmployeeAsync()
        {
            var employee = new
            {
                Id = idEmployee,
                FirstName = txtFirst.Text,
                LastName = txtLast.Text,
                Document = txtDocument.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Departament = txtDept.Text,
                Range = txtRange.Text,
                BirthdayDate = ParseToIsoDate(txtBirth.Text),
                BusinessId = idBusiness
            };

            var json = JsonConvert.SerializeObject(employee);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PutAsync($"https://localhost:7199/api/Employee/{idEmployee}", content);
                if (response.IsSuccessStatusCode)
                {
                    // 🔁 Volver al listado
                    Response.Redirect($"~/Employees/EmployeesList.aspx?idBusiness={idBusiness}", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    lblMsg.Text = "Error al actualizar el empleado.";
                }
            }
        }

        private string ParseToIsoDate(string input)
        {
            if (DateTime.TryParseExact(input, "dd/MM/yyyy", null,
                System.Globalization.DateTimeStyles.None, out var dt))
                return dt.ToString("yyyy-MM-dd");
            return DateTime.Today.ToString("yyyy-MM-dd");
        }



        // 🔹 Cancelar → volver al listado
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect($"~/Employees/EmployeesList.aspx?idBusiness={idBusiness}", false);
        }
    }
}