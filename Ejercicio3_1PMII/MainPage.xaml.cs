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

        private string ConvertToBase64(Stream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                byte[] imageBytes = ms.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

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
                Name = DateTime.Now.ToString("yyyyMMddHHmmss") + "_foto.jpg",
                SaveToAlbum = true
            };

            var photo = await CrossMedia.Current.TakePhotoAsync(options);

            if (photo != null)
            {
                imagenBase64 = ConvertToBase64(photo.GetStream());
                fotoImage.Source = ImageSource.FromStream(() => photo.GetStream());
            }
            else
            {
                await DisplayAlert("Foto no tomada", "Por favor tome una foto antes de intentar guardar.", "Ok");
            }
        }

        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nombresEntry.Text) ||
                string.IsNullOrWhiteSpace(apellidosEntry.Text) ||
                string.IsNullOrWhiteSpace(direccionEntry.Text) ||
                string.IsNullOrWhiteSpace(imagenBase64))
            {
                await DisplayAlert("Campos Incompletos", "Por favor complete todos los campos y tome una foto antes de guardar.", "Ok");
                return;
            }

            int currentCounter = await alumnosService.GetCounterAsync();
            int newId = currentCounter + 1;

            Alumnos alumnos = new Alumnos
            {
                Id = newId,
                Nombres = nombresEntry.Text,
                Apellidos = apellidosEntry.Text,
                Sexo = sexoPicker.SelectedItem.ToString(),
                Direccion = direccionEntry.Text,
                ImagenBase64 = imagenBase64
            };

            await alumnosService.AddAlumnoAsync(alumnos);
            await alumnosService.UpdateCounterAsync(newId);

            await DisplayAlert("Info", "Alumno guardado correctamente", "Ok");

            nombresEntry.Text = "";
            apellidosEntry.Text = "";
            direccionEntry.Text = "";
            fotoImage.Source = null;
        }

        private async void ver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaAlumnosPage());
        }
    }
}

