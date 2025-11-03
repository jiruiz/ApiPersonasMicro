using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace ManageBusinessFront.Business
{
    public partial class BusinessEdit : Page
    {
        private int idBusiness;

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

                if (Request.QueryString["idBusiness"] != null)
                    int.TryParse(Request.QueryString["idBusiness"], out idBusiness);

                ViewState["idBusiness"] = idBusiness; // guardamos en ViewState, para reenviarlo correctamente

                await LoadBusinessDataAsync(idBusiness);
            }
            else
            {
                // recuperar el valor durante postbacks
                idBusiness = (int)(ViewState["idBusiness"] ?? 1);
            }
        }
        protected async Task LoadBusinessDataAsync(int idBusiness)
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync($"http://localhost:7038/api/Business/{idBusiness}");
                if (!response.IsSuccessStatusCode)
                {
                    lblMsg.Text = "Error el obtener los datos del empleado";
                    return;
                }
                var json = await response.Content.ReadAsStringAsync();
                var emp = JsonConvert.DeserializeObject<Business>(json);
                idTextBox.Text = emp.Id.ToString();
                nameTextBox.Text = emp.Name;
                industryTextBox.Text = emp.Industry;
                phoneNumberTextBox.Text = emp.PhoneNumber;
                emailTextBox.Text = emp.Email;
                taxIdTextBox.Text = emp.TaxId;
                VATStatusTextBox.Text = emp.VATStatus;
                legalNameTextBox.Text = emp.LegalName;
                startOfActivitiesCalendar.SelectedDate = emp.StartOfActivities;
                yearsInIndustryTextBox.Text = emp.YearsInIndustry.ToString();
                streetTextBox.Text = emp.Street;
                cityTextBox.Text = emp.City;
                stateTextBox.Text = emp.State;


            }
            catch (Exception ex)
            {
                lblMsg.Text = $"Error: {ex.Message}";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(UpdateBusinessAsync));
        }

        private async Task UpdateBusinessAsync()
        {
            var business = new
            {
                Id = idBusiness,
                Name = nameTextBox.Text,
                Industry = industryTextBox.Text,
                PhoneNumber = phoneNumberTextBox.Text,
                Email = emailTextBox.Text,
                TaxId = taxIdTextBox.Text,
                VATStatus = VATStatusTextBox.Text,
                LegalName = legalNameTextBox.Text,
                StartOfActivities = startOfActivitiesCalendar.SelectedDate,
                YearsInIndustry = yearsInIndustryTextBox.Text,
                Street = streetTextBox.Text,
                City = cityTextBox.Text,
                State = stateTextBox.Text,
            };

            var json = JsonConvert.SerializeObject(business);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PutAsync($"https://localhost:7038/api/Business/{idBusiness}", content);
                if (response.IsSuccessStatusCode)
                {
                    // 🔁 Volver al listado
                    Response.Redirect($"~/Business/BusinessList.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    lblMsg.Text = "Error al actualizar el negocio.";
                }
            }
        }

        // 🔹 Cancelar → volver al listado
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect($"~/Business/BusinessList.aspx", false);
        }
    }
}