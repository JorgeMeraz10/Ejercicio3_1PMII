using Ejercicio3_1PMII.Models;
using Ejercicio3_1PMII.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio3_1PMII
{
   
    public partial class MainPage : ContentPage
    {
        private string imagenBase64;

        public MainPage()
        {
            InitializeComponent();
        }

        private void TomarFoto_Clicked(object sender, EventArgs e)
        {
            // Lógica para tomar una foto y convertirla a Base64
            // imagenBase64 = ...;
            fotoImage.Source = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(imagenBase64)));
        }

        private void Guardar_Clicked(object sender, EventArgs e)
        {
            Alumnos alumnos = new Alumnos
            {
                Nombres = nombresEntry.Text,
                Apellidos = apellidosEntry.Text,
                Sexo = sexoEntry.Text,
                Direccion = direccionEntry.Text,
                ImagenBase64 = imagenBase64
            };

            // Aqui el Codigo dela conexion de Firebase.
        }

        private async void ver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaAlumnosPage());
        }

    }
}
