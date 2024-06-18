namespace areyesS2T;

public partial class Ingreso : ContentPage
{   
    private EntryValidation _entryValidation;
	public Ingreso()
	{
		InitializeComponent();
        _entryValidation = new EntryValidation();
	}

    private void btnInicio_Clicked(object sender, EventArgs e)
    {
        Dictionary<string, string> usersBD = new Dictionary<string, string>
                {
                    {"Carlos", "carlos123" },
                    {"Ana", "ana123"},
                    {"José", "jose123" }
                };

        var nombre = txtUser.Text;
        var contrasena = txtPassword.Text;

        try
        {

            if (!string.IsNullOrEmpty(nombre) || !string.IsNullOrEmpty(contrasena))
            {
                Dictionary<string, string> credencialesEntry = new Dictionary<string, string>
                {
                    {"Nombre",txtUser.Text},
                    {"Contraseña",txtPassword.Text}
                };
            
            //validamos solo campos vacios
            _entryValidation.CamposVacios(credencialesEntry);

            if (usersBD.Keys.Contains(txtUser.Text) && usersBD.Values.Contains(txtPassword.Text))
            {
                Navigation.PushAsync(new MainPage(txtUser.Text));// solo abre la pagina Home
            }
            else
            {
                DisplayAlert("ALERTA", "NO EXISTE NINGÚN USUARIO CON ESE NOMBRE Y CLAVE", "OK");
            }


            }
        }
        catch (InputException ex)
        {
                DisplayAlert("Error: ", ex.Message, "OK");
        }
        
    }
}