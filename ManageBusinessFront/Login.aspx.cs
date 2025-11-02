using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using Newtonsoft.Json;

namespace ManageBusinessFront { 
public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblMensaje.Text = ""; // Limpia mensajes al cargar
        }
    }

    protected async void btnIniciarSesion_Click(object sender, EventArgs e)
    {
        var email = txtUser.Text.Trim();
        var password = txtPassword.Text.Trim();

        var loginDto = new { Email = email, Password = password };
        var json = JsonConvert.SerializeObject(loginDto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://localhost:7034/api/Users/");
            var response = await client.PostAsync("login", content);

                if (response.IsSuccessStatusCode)
                {
                    // Paso 1: leer el ID del usuario que devolvió la API
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(jsonRespuesta);
                    int idUsuario = result.idUser; // depende del nombre que devuelva tu API

                    // Paso 2: guardarlo en sesión
                    Session["IdUsuario"] = idUsuario;

                    // Paso 3: redirigir a la página privada
                    Response.Redirect("~/Business/BusinessList.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    lblMensaje.Text = "Credenciales incorrectas.";
                }
            }
    }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect($"~/Users/CreateUser.aspx", false);
        }
    }


}