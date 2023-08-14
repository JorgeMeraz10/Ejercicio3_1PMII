//using Firebase.Database;
//using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio3_1PMII.Models
{
    public class AlumnosService
    {
        private FirebaseClient firebase;

        public AlumnosService()
        {
            // Reemplaza "tu-proyecto" con el nombre de tu proyecto Firebase
            firebase = new FirebaseClient("");
        }

        public async Task<List<Alumnos>> GetAlumnosAsync()
        {
            return (await firebase.Child("alumnos").OnceAsync<Alumnos>()).Select(item => new Alumnos
            {
                Key = item.Key,
                Nombres = item.Object.Nombres,
                Apellidos = item.Object.Apellidos,
                Sexo = item.Object.Sexo,
                Direccion = item.Object.Direccion,
                ImagenBase64 = item.Object.ImagenBase64
            }).ToList();
        }

        public async Task AddAlumnoAsync(Alumnos alumno)
        {
            await firebase.Child("alumnos").PostAsync(alumno);
        }

        public async Task UpdateAlumnoAsync(Alumnos alumno)
        {
            await firebase.Child("alumnos").Child(alumno.Key).PutAsync(alumno);
        }

        public async Task DeleteAlumnoAsync(string alumnoKey)
        {
            await firebase.Child("alumnos").Child(alumnoKey).DeleteAsync();
        }
    }
}
