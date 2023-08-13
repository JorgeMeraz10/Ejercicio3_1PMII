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
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace Ejercicio3_1PMII
{
   
    public partial class MainPage : ContentPage
    {
        private string imagenBase64;

        public MainPage()
        {
            InitializeComponent();
        }


        private async void TomarFoto_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                // La cámara no está disponible en este dispositivo
                return;
            }

            var opciones = new StoreCameraMediaOptions
            {
                SaveToAlbum = true,
                Directory = "SamplePhotos",  // Cambia el directorio a algo sin espacios
                Name = "miFoto.jpg"
            };

            var foto = await CrossMedia.Current.TakePhotoAsync(opciones);

            if (foto != null)
            {
                // Convertir la foto a Base64
                using (var stream = foto.GetStream())
                {
                    var memoryStream = new MemoryStream();
                    stream.CopyTo(memoryStream);
                    imagenBase64 = Convert.ToBase64String(memoryStream.ToArray());
                }

                // Mostrar la foto en el Image
                fotoImage.Source = ImageSource.FromStream(() => foto.GetStream());
            }
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
