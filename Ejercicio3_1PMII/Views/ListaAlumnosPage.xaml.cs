using Ejercicio3_1PMII.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio3_1PMII.Views
{
    
    public partial class ListaAlumnosPage : ContentPage
    {
        private ObservableCollection<Alumnos> alumnosList = new ObservableCollection<Alumnos>();

        public ListaAlumnosPage()
        {
            InitializeComponent();
            lstAlumnos.ItemsSource = alumnosList;
             CargarAlumnos();
        }

        private void CargarAlumnos()
        {
            //  insertar el código para cargar la lista de alumnos desde la base de datos (Firebase)
            // y agregarlos a la colección alumnosList.
        }

        private async void Editar_Clicked(object sender, EventArgs e)
        {
            var alumnoSeleccionado = (Alumnos)((Button)sender).CommandParameter;
           // await Navigation.PushAsync(new EditarAlumnoPage(alumnoSeleccionado));
        }

        private void Eliminar_Clicked(object sender, EventArgs e)
        {
            var alumnoSeleccionado = (Alumnos)((Button)sender).CommandParameter;
            //  insertar el código para eliminar el alumno seleccionado de la base de datos (Firebase).
            // También debes remover el alumno de la colección alumnosList.
        }

    }
}