using Ejercicio3_1PMII.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Forms;

namespace Ejercicio3_1PMII.Views
{
    public partial class ListaAlumnosPage : ContentPage
    {
        private ObservableCollection<Alumnos> alumnosList = new ObservableCollection<Alumnos>();
        private AlumnosService alumnosService;

        public ListaAlumnosPage()
        {
            InitializeComponent();
            alumnosService = new AlumnosService();
            lstAlumnos.ItemsSource = alumnosList;
            CargarAlumnos();
        }

        private async void CargarAlumnos()
        {
            alumnosList.Clear();
            var alumnos = await alumnosService.GetAlumnosAsync();
            foreach (var alumno in alumnos)
            {
                // Convertir la cadena Base64 en ImageSource
                if (!string.IsNullOrEmpty(alumno.ImagenBase64))
                {
                    byte[] imageBytes = Convert.FromBase64String(alumno.ImagenBase64);
                    ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(imageBytes));
                    alumno.Imagen = imageSource;
                }

                alumnosList.Add(alumno);
            }
        }

        private async void Editar_Clicked(object sender, EventArgs e)
        {
            var alumnoSeleccionado = (Alumnos)((Button)sender).CommandParameter;
            await Navigation.PushAsync(new EditarAlumnoPage(alumnoSeleccionado));
        }


        private async void Eliminar_Clicked(object sender, EventArgs e)
        {
            var alumnoSeleccionado = (Alumnos)((Button)sender).CommandParameter;

            bool respuesta = await DisplayAlert("Confirmación", "¿Estás seguro que deseas eliminar este alumno?", "Sí", "No");

            if (respuesta)
            {
                // Si el usuario selecciona "Sí", procede a eliminar el alumno
                try
                {
                    await alumnosService.DeleteAlumnoAsync(alumnoSeleccionado.Key);
                    alumnosList.Remove(alumnoSeleccionado);
                }
                catch (Exception ex)
                {
                    // Manejar cualquier error aquí
                    Console.WriteLine("Error al eliminar el alumno: " + ex.Message);
                }
            }
        }
    }
}

