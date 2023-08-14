using Firebase.Database.Query;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio3_1PMII.Models
{
    public class AlumnosService

    {
        private const int V = 0;
        private FirebaseClient firebase;

        public AlumnosService()
        {
        
            // Reemplaza "tu-proyecto" con el nombre de tu proyecto Firebase
            firebase = new FirebaseClient("https://ejercicio3-1pmii-default-rtdb.firebaseio.com/");
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

        public async Task<int> GetCounterAsync()
        {
            var counterSnapshot = await firebase.Child("contador").OnceSingleAsync<int?>();
            return counterSnapshot ?? 0;
        }


        public async Task UpdateCounterAsync(int newCounterValue)
        {
            await firebase.Child("contador").PutAsync(newCounterValue);
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
