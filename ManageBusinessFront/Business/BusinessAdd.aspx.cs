using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity; // Para DbContext si hace falta



namespace ManageBusinessFront.Business
{
    public partial class BusinessAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddBusiness_Click(object sender, EventArgs e)
        {
            try
            {
                NegociosDbEntities1 BusinessCtx = new NegociosDbEntities1();

                Negocios neg = new Negocios();

                neg.Nombre = nameTextBox.Text;
                neg.Rubro = industryTextBox.Text;
                neg.Telefono = phoneNumberTextBox.Text;
                neg.Correo = emailTextBox.Text;
                neg.CUIT = taxIdTextBox.Text;
                neg.CondicionIVA = VATStatusTextBox.Text;
                neg.RazonSocial = legalNameTextBox.Text;
                neg.FechaInicioActividades = startOfActivitiesCalendar.SelectedDate;
                neg.AntiguedadEnRubro = int.Parse(yearsInIndustryTextBox.Text);
                neg.Calle = streetTextBox.Text;
                neg.Localidad = cityTextBox.Text;
                neg.Provincia = stateTextBox.Text;

                BusinessCtx.Negocios.Add(neg);
                BusinessCtx.SaveChanges(); // ✅ Guarda en tu base local


                // 🔹 Enviar también a la API externa (sin alterar tu estructura)
                using (var client = new System.Net.Http.HttpClient())
                {
                    var businessDto = new
                    {
                        Name = neg.Nombre,
                        Industry = neg.Rubro,
                        PhoneNumber = neg.Telefono,
                        Email = neg.Correo,
                        TaxId = neg.CUIT,
                        VATStatus = neg.CondicionIVA,
                        LegalName = neg.RazonSocial,
                        StartOfActivities = neg.FechaInicioActividades,
                        YearsInIndustry = neg.AntiguedadEnRubro,
                        Street = neg.Calle,
                        City = neg.Localidad,
                        State = neg.Provincia
                    };

                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(businessDto);
                    var content = new System.Net.Http.StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    // Enviar POST a la API
                    var response = client.PostAsync("https://localhost:7038/api/Business", content).Result;

                    if (!response.IsSuccessStatusCode)
                    {
                        string err = response.Content.ReadAsStringAsync().Result;
                        Response.Write($"<script>alert('⚠️ Error al enviar a la API: {response.StatusCode}\\n{err}');</script>");
                    }
                }

                Response.Write("<script>alert('✅ Negocio guardado localmente y enviado a la API.');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

    }
}