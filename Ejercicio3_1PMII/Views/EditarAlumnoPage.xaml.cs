using Ejercicio3_1PMII.Models;
using System;

using Xamarin.Forms;

namespace Ejercicio3_1PMII.Views
{
    public partial class EditarAlumnoPage : ContentPage
    {
        private Alumnos alumno;
        private AlumnosService alumnosService;

        public EditarAlumnoPage(Alumnos alumnoSeleccionado)
        {
            InitializeComponent();
            this.alumno = alumnoSeleccionado;
            alumnosService = new AlumnosService();
            CargarDatos();
        }

        private void CargarDatos()
        {
            nombresEntry.Text = alumno.Nombres;
            apellidosEntry.Text = alumno.Apellidos;
            sexoEntry.Text = alumno.Sexo;
            direccionEntry.Text = alumno.Direccion;
        }

        // En EditarAlumnoPage.xaml.cs
        private async void GuardarCambios_Clicked(object sender, EventArgs e)
        {
            // Actualiza las propiedades del objeto alumno con los nuevos valores ingresados por el usuario.
            alumno.Nombres = nombresEntry.Text;
            alumno.Apellidos = apellidosEntry.Text;
            alumno.Sexo = sexoEntry.Text;
            alumno.Direccion = direccionEntry.Text;

            // Actualiza el alumno en la base de datos.
            await alumnosService.UpdateAlumnoAsync(alumno);

            // Muestra un mensaje de éxito.
            await DisplayAlert("Éxito", "Los cambios han sido guardados.", "Aceptar");

            // Vuelve a la página anterior.
            await Navigation.PopAsync();
        }


    }
}