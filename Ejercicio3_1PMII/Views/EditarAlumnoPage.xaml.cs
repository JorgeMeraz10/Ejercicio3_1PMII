using Ejercicio3_1PMII.Models;
using System;

using Xamarin.Forms;

namespace Ejercicio3_1PMII.Views
{
    public partial class EditarAlumnoPage : ContentPage
    {
        private Alumnos alumno;

        public EditarAlumnoPage(Alumnos alumnoSeleccionado)
        {
            InitializeComponent();
            alumno = alumnoSeleccionado;
            CargarDatos();
        }

        private void CargarDatos()
        {
            nombresEntry.Text = alumno.Nombres;
            apellidosEntry.Text = alumno.Apellidos;
            sexoEntry.Text = alumno.Sexo;
            direccionEntry.Text = alumno.Direccion;
        }

        private async void GuardarCambios_Clicked(object sender, EventArgs e)
        {
            // implementar la lógica para actualizar los datos del alumno en la base de datos (Firebase).
            // Por ejemplo, podrías usar Firebase Realtime Database o Firestore para esto.

            // Actualiza las propiedades del objeto alumno con los nuevos valores ingresados por el usuario.
            alumno.Nombres = nombresEntry.Text;
            alumno.Apellidos = apellidosEntry.Text;
            alumno.Sexo = sexoEntry.Text;
            alumno.Direccion = direccionEntry.Text;

            // la actualización en la base de datos, según la estructura de tu proyecto y el servicio de Firebase que estés utilizando.

            // Después de guardar los cambios, podrías mostrar un mensaje de éxito o navegar de regreso a la lista de alumnos.
            await DisplayAlert("Éxito", "Los cambios han sido guardados.", "Aceptar");
            await Navigation.PopAsync(); // Vuelve a la página anterior.
        }

        // ... otros métodos y controladores de eventos ...
    }
}
