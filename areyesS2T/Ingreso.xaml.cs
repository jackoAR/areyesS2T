namespace areyesS2T;

public partial class Ingreso : ContentPage
{
	public Ingreso()
	{
		InitializeComponent();
	}

    private void btnInicio_Clicked(object sender, EventArgs e)
    {
        Dictionary<string, string> usersBD = new Dictionary<string, string>
                {
                    {"Carlos", "carlos123" },
                    {"Ana", "ana123"},
                    {"José", "jose123" }
                };

        string[] userEntry = { txtUser.Text, txtPassword.Text };

        foreach (var registro in usersBD) {

            if (registro.Key == userEntry[0] && registro.Value == userEntry[1])
            {
                Navigation.PushAsync(new MainPage(userEntry[0]));// solo abre la pagina Home
            }
            else 
            {
                DisplayAlert("ALERTA", "No existe ningún usuario con esa contraseña", "OK");
            }
        }
    }
}