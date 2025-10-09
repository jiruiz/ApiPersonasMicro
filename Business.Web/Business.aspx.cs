using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.UI;
using Business.Api.Dto; // Asegúrate que BusinessDto está en este namespace

namespace Business.Web
{
    public partial class Business : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarNegocios();
            }
        }

        private void CargarNegocios()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("api/Business").Result;

                if (response.IsSuccessStatusCode)
                {
                    // Necesitas el paquete Microsoft.AspNet.WebApi.Client instalado
                    var businesses = response.Content
                        .ReadAsAsync<List<BusinessDto>>().Result;

                    GridView1.DataSource = businesses;
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Error al obtener datos de la API');</script>");
                }
            }
        }
    }
}
