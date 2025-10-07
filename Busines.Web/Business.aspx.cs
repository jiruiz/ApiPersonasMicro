using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace Business.Web
{
    public partial class Business : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarNegocios();
            }
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            CargarNegocios();
        }

        private void CargarNegocios()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7038/");
                var response = client.GetAsync("api/Business").Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var businesses = JsonConvert.DeserializeObject<List<BusinessDto>>(json);

                    GridView1.DataSource = businesses;
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('No se pudieron obtener los datos de la API');</script>");
                }
            }
        }
    }

    // 👇 DTO mínimo (podés moverlo a un archivo aparte o referenciar el del proyecto API)
    public class BusinessDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
