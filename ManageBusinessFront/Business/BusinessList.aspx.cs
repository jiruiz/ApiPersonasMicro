﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ManageBusinessFront.Business
{
    public partial class BusinessList : System.Web.UI.Page
    {
        public class Busine
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Industry { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string TaxId { get; set; }
            public string VATStatus { get; set; }
            public string LegalName { get; set; }
            public DateTime StartOfActivities { get; set; }
            public int YearsInIndustry { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
        }


        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // solo la primera vez que se carga la página
            {
                await LoadBusinessAsync();
            }

        }
        protected async Task LoadBusinessAsync()
        {
            using (var client = new HttpClient())
            {
                // hay que crear esta url con el get de todos los negocios para listarlos
                var res = await client.GetAsync("http://localhost:5168/api/Business");
                if (res.IsSuccessStatusCode)
                {
                    var json = await res.Content.ReadAsStringAsync();
                    var businesses = JsonConvert.DeserializeObject<List<Busine>>(json);
                    gvBusiness.DataSource = businesses;
                    gvBusiness.DataBind();
                }
            }
        }

    }
}