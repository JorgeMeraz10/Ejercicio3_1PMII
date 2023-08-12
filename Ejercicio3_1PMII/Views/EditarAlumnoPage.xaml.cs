using Ejercicio3_1PMII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio3_1PMII.Views
{
    public partial class EditarAlumnoPage : ContentPage
    {
        private Alumnos alumno;

        public EditarAlumnoPage()
        {
            InitializeComponent();
            
            CargarDatos();
        }

        private void CargarDatos()
        {
            nombresEntry.Text = alumno.Nombres;
            apellidosEntry.Text = alumno.Apellidos;
            sexoEntry.Text = alumno.Sexo;
            direccionEntry.Text = alumno.Direccion;
        }

        private void GuardarCambios_Clicked(object sender, EventArgs e)
        {
            // Inserta el código para actualizar los datos del alumno en la base de datos (Firebase).
        }

        
    }
}
