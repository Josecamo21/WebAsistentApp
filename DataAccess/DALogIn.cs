using Entidades;
using Google.Cloud.Firestore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DALogIn
    {
        FirestoreDb db;


        private void InicializarFirestore()
        {
            if (db == null)
            {
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"C:\Escritorio\Asistente\Credenciales\firebaseKey.json");
                db = FirestoreDb.Create("asistente-2a52e");
                System.Diagnostics.Debug.WriteLine("✅ Firestore inicializado");
            }
            ;
        }


        public async Task<LogIn> LogIn(string username, string password)
        {
            InicializarFirestore();

            try
            {
                CollectionReference usuariosRef = db.Collection("usuarios");

                Query query = usuariosRef
                    .WhereEqualTo("user", username)
                    .WhereEqualTo("password", password);

                QuerySnapshot snapshot = await query.GetSnapshotAsync();

                foreach (DocumentSnapshot doc in snapshot.Documents)
                {
                    return doc.ConvertTo<LogIn>(); // Encontrado
                }

                return null; // No encontrado
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("❌ Error en consulta filtrada: " + ex.Message);
                throw new UnauthorizedAccessException("Invalid user or password.");
            }
        }


    }
}
