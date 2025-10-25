﻿using Newtonsoft.Json;
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

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int business = 1; // valor por defecto
                if (Request.QueryString["idBusiness"] != null)
                    int.TryParse(Request.QueryString["idBusiness"], out business);

                ViewState["idBusiness"] = business; // guardamos en ViewState, para reenviarlo correctamente
                ViewState["BusinessName"] = "Test HardCode"; // dato a recuperar


                await LoadEmployeesAsync(business);
            }
            else
            {
                // recuperar el valor durante postbacks
                idBusiness = (int)(ViewState["idBusiness"] ?? 1);
            }
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
                Response.Redirect($"~/Employees/EditEmployee.aspx?idEmployee={idEmployee}&idBusiness={idBusiness}");
            }

            if (e.CommandName == "DeleteRow")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                await DeleteEmployeeAsync(id);
                Response.Redirect(Request.RawUrl, false);
            }
        }


        private async Task DeleteEmployeeAsync(int id)
        {
            using (var client = new HttpClient())
            {
                var res = await client.DeleteAsync($"https://localhost:7199/api/Employee/{id}");
            }
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect($"CreateEmployee.aspx?idBusiness={idBusiness}");
        }

    }
}