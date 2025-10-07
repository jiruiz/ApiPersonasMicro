using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ManageBusinessFront
{
    public partial class EmployeesList : System.Web.UI.Page
    {
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

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // solo la primera vez que se carga la página
            {
                await LoadEmployeesAsync();
            }
        }

        protected async Task LoadEmployeesAsync()
        {
            var client = new HttpClient();
            var res = await client.GetAsync("https://localhost:7199/api/Employee");
            var json = await res.Content.ReadAsStringAsync();

            var employees = JsonConvert.DeserializeObject<List<Employee>>(json);
            gvEmployees.DataSource = employees;
            gvEmployees.DataBind();
        }
    }
}