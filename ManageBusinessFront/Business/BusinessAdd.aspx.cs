using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Web.UI;

namespace ManageBusinessFront.Business
{
    public partial class BusinessAdd : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnAddBusiness_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            var dto = new
            {
                Name = nameTextBox.Text,
                Industry = industryTextBox.Text,
                PhoneNumber = phoneNumberTextBox.Text,
                Email = emailTextBox.Text,
                TaxId = taxIdTextBox.Text,
                VATStatus = VATStatusDropDown.SelectedValue,
                LegalName = legalNameTextBox.Text,
                StartOfActivities = DateTime.Parse(startOfActivitiesTextBox.Text),
                YearsInIndustry = yearsInIndustryTextBox.Text,
                Street = streetTextBox.Text,
                City = cityTextBox.Text,
                State = stateTextBox.Text,
            };

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var resp = await client.PostAsync("https://localhost:7038/api/business", content);
                if (resp.IsSuccessStatusCode)
                {
                    // Volver al listado
                    Response.Redirect($"~/Business/BusinessList.aspx", false);
                    return;
                }

                lblMsg.Text = $"Error al guardar: {(int)resp.StatusCode} {resp.ReasonPhrase}";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect($"~/Business/BusinessList.aspx", false);
        }
    }
}