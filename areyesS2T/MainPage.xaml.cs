namespace areyesS2T
{
    public partial class MainPage : ContentPage
    {

        private EntryValidation _entryValidation;
        public MainPage()
        {
            InitializeComponent();
            _entryValidation = new EntryValidation();
            
        }

        public MainPage(string user) {
            InitializeComponent();
            lblDocente.Text = "Docente Conectado: " + user;
            _entryValidation = new EntryValidation();
        }

        private void CalcularNotas(object sender, EventArgs e)
        {

            //Obtenemos el index seleccionado del Picker
            var elementoSeleccionado = SelectEstudiante.SelectedIndex;

            //guardamos el elemento como string en la variable local nombre
            var nombre = SelectEstudiante.Items[elementoSeleccionado].ToString();

            //creamos un diccionario con el texto y nombre del campo como clave
            Dictionary<string, string> notas = new Dictionary<string, string>
                {
                    {"Nota Seguimiento 1", NS1.Text },
                    {"Nota Examen 1", NE1.Text},
                    {"Nota Seguimiento 2", NS2.Text },
                    {"Nota Examen 2", NE2.Text }
                };
            
            //Manejo de Excepciones
            try
            {
                //evaluamos los campos antes de procesar los datos
                _entryValidation.GeneralEntryValidation(notas);

                //obtenemos fecha ingresada
                DateTime fechaIngresada = DPfecha.Date;
                
                //obtenemos los valores de MainPage
                double notaS1 = double.Parse(NS1.Text);
                double notaExamen1 = double.Parse(NE1.Text);

                //enviamos los valores a la clase que contiene los metodos y obtenemos un resultado
                double seguimiento1 = Core.Calificacion.NotaSeguimiento1(notaS1);
                double examen1 = Core.Calificacion.NotaExamen1(notaExamen1);

                double parcial1 = Core.Calificacion.NotaParcial1(seguimiento1, examen1);

                //obtenemos valores ingresados parcial 2
                double notaS2 = double.Parse(NS2.Text);
                double notaExamen2 = double.Parse(NE2.Text);

                //enviamos los valores a los metodos de la clase Calificacion
                double seguimiento2 = Core.Calificacion.NotaSeguimiento2(notaS2);
                double examen2 = Core.Calificacion.NotaExamen2(notaExamen2);

                double parcial2 = Core.Calificacion.NotaParcial2(seguimiento2, examen2);

                //enviamos las notas parciales obtenidas para la nota final
                double notaFinal = Core.Calificacion.NotaFinal(parcial1, parcial2);



                //Redondeamos las notas double con Math
                double p1 = Math.Round(parcial1, 3, MidpointRounding.AwayFromZero);
                double p2 = Math.Round(parcial2, 3, MidpointRounding.AwayFromZero);
                double nfinal = Math.Round(notaFinal, 3, MidpointRounding.AwayFromZero);


                //mostramos los resultados en el display
                DisplayAlert("Resultados",
                "Nombre: " + nombre + "\n"
                + "Fecha: " + fechaIngresada.Day + "/" + fechaIngresada.Month + "/" + "/" + fechaIngresada.Year + "\n"
                + "Nota Parcial 1: " + p1 + "\n"
                + "Nota Parcial 2: " + p2 + "\n"
                + "Nota Final: " + nfinal + "\n"
                + "Estado: " + Core.Calificacion.Estado(notaFinal), "Aceptar");

            }
            catch (InputException ex)//atrapamos las excepciones de los lanzadores
            {
                //Mostramos mensaje específico del error
                DisplayAlert("Error", ex.Message, "Aceptar");

            }

        }

        private void PickerSelectedIndexChanged(object sender, System.EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1) {

                LayoutParcial1.IsVisible = true;
                LayoutParcial2.IsVisible = true;

                CounterBtn.IsEnabled = true;

                DPfecha.IsVisible = true;

            }
            else
            {

                LayoutParcial1.IsVisible = false;
                LayoutParcial2.IsVisible = false;

                CounterBtn.IsEnabled = false;

                DPfecha.IsVisible = false;

            }

        }

    }

}
