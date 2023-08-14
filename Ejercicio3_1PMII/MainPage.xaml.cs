using Ejercicio3_1PMII.Models;
using Ejercicio3_1PMII.Views;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.IO;
using Xamarin.Forms;

namespace Ejercicio3_1PMII
{
    public partial class MainPage : ContentPage
    {
        private string imagenBase64;

        private AlumnosService alumnosService;

        public MainPage()
        {
            InitializeComponent();
            alumnosService = new AlumnosService();
        }

        byte[] GuardarImagen;
        private async void TomarFoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Cámara", "La cámara no está disponible.", "OK");
                return;
            }

            var options = new StoreCameraMediaOptions
            {
                Directory = "MYAPP",
                    Name = DateTime.Now.ToString() + "_foto.jpg",
                    SaveToAlbum = true
            };

            var photo = await CrossMedia.Current.TakePhotoAsync(options);

            if (photo != null)
            {
                fotoImage.Source = ImageSource.FromStream(() => photo.GetStream());
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
