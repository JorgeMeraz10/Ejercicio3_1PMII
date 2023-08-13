using Ejercicio3_1PMII.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Ejercicio3_1PMII.Views;

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
                Directory = "Pictures", // Cambia el directorio a algo sin espacios
                Name = "miFoto.jpg"
            };

            try
            {
                var foto = await CrossMedia.Current.TakePhotoAsync(opciones);

                if (foto != null)
                {
                    using (var stream = foto.GetStream())
                    {
                        var memoryStream = new MemoryStream();
                        stream.CopyTo(memoryStream);
                        imagenBase64 = Convert.ToBase64String(memoryStream.ToArray());
                    }

                    fotoImage.Source = ImageSource.FromStream(() => foto.GetStream());
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "La camara no funciona.", "Aceptar");
            
                // Manejar la excepción (mostrar un mensaje de error, registrar detalles, etc.).
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

            // Código para guardar alumnos en Firebase
        }

        private async void ver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaAlumnosPage());
        }
    }
}
