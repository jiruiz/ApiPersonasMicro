using Newtonsoft.Json;
using System;
using System.Net.Http;
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
            public string Name { get; set; } = "";
            public string Industry { get; set; } = "";
            public string PhoneNumber { get; set; } = "";
            public string Email { get; set; } = "";
            public string TaxId { get; set; } = "";
            public string VATStatus { get; set; } = "";
            public string LegalName { get; set; } = "";
            public DateTime StartOfActivities { get; set; }
            public int YearsInIndustry { get; set; }
            public string Street { get; set; } = "";
            public string City { get; set; } = "";
            public string State { get; set; } = "";
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                if (!int.TryParse(Request.QueryString["idBusiness"], out idBusiness))
                {
                    Response.Redirect("~/Business/BusinessList.aspx", false);
                    return;
                }

                ViewState["idBusiness"] = idBusiness;
                await LoadBusinessAsync(idBusiness);
            }
            else
            {
                idBusiness = (int)(ViewState["idBusiness"] ?? 0);
            }
        }

        private async Task LoadBusinessAsync(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var res = await client.GetAsync($"https://localhost:7038/api/Business/{id}");
                    if (!res.IsSuccessStatusCode)
                    {
                        lblMsg.Text = "❌ Error al obtener los datos del negocio.";
                        return;
                    }

                    var json = await res.Content.ReadAsStringAsync();
                    var b = JsonConvert.DeserializeObject<Business>(json);

                    idTextBox.Text = b.Id.ToString();
                    nameTextBox.Text = b.Name;
                    industryTextBox.Text = b.Industry;
                    phoneNumberTextBox.Text = b.PhoneNumber;
                    emailTextBox.Text = b.Email;
                    taxIdTextBox.Text = b.TaxId;
                    VATStatusDropDown.SelectedValue = b.VATStatus;
                    legalNameTextBox.Text = b.LegalName;
                    startOfActivitiesTextBox.Text = b.StartOfActivities.ToString("yyyy-MM-dd");
                    yearsInIndustryTextBox.Text = b.YearsInIndustry.ToString();
                    streetTextBox.Text = b.Street;
                    cityTextBox.Text = b.City;
                    stateTextBox.Text = b.State;
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = $"❌ Error: {ex.Message}";
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
                VATStatus = VATStatusDropDown.SelectedValue,
                LegalName = legalNameTextBox.Text,
                StartOfActivities = DateTime.Parse(startOfActivitiesTextBox.Text),
                YearsInIndustry = int.Parse(yearsInIndustryTextBox.Text),
                Street = streetTextBox.Text,
                City = cityTextBox.Text,
                State = stateTextBox.Text
            };

            var json = JsonConvert.SerializeObject(business);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PutAsync($"https://localhost:7038/api/Business/{idBusiness}", content);
                if (response.IsSuccessStatusCode)
                {
                    Response.Redirect("~/Business/BusinessList.aspx", false);
                }
                else
                {
                    lblMsg.Text = "❌ Error al actualizar el negocio.";
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Business/BusinessList.aspx", false);
        }
    }
}
