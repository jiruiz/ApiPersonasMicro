﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace ManageBusinessFront.Employees
{
    public partial class CreateEmployee : System.Web.UI.Page
    {
        private int idBusiness;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Desactivar validación unobtrusive (usa el modo clásico de WebForms)
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            idBusiness = int.Parse(Request.QueryString["idBusiness"]);
        }
        protected async void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            var dto = new
            {
        
                FirstName = txtFirst.Text,
                LastName = txtLast.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                BusinessId = idBusiness, // parametro del contexto
                BirthdayDate = ParseToIsoDate(txtBirth.Text),
                Departament = txtDept.Text,
                Range = txtRange.Text
                
            };

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var resp = await client.PostAsync("https://localhost:7199/api/Employee", content);
                if (resp.IsSuccessStatusCode)
                {
                    // Volver al listado
                    Response.Redirect($"~/Employees/EmployeesList.aspx?idBusiness={idBusiness}");
                    return;
                }

                lblMsg.Text = $"Error al guardar: {(int)resp.StatusCode} {resp.ReasonPhrase}";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect($"~/Employees/EmployeesList.aspx?idBusiness={idBusiness}");
        }

        private string ParseToIsoDate(string input)
        {
            // Acepta "dd/MM/yyyy" y lo convierte a "yyyy-MM-dd"
            if (DateTime.TryParseExact(input, "dd/MM/yyyy", null,
                    System.Globalization.DateTimeStyles.None, out var dt))
            {
                return dt.ToString("yyyy-MM-dd");
            }
            // fallback: hoy
            return DateTime.Today.ToString("yyyy-MM-dd");
        }
    }
}
