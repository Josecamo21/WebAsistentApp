using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [FirestoreData]
    public class LogIn
    {

        public LogIn()
        {
            user = string.Empty;
            password = string.Empty;
        }

        public LogIn(string user, string password)
        {
            this.user = user;
            this.password = password;
        }


        [FirestoreProperty]
        public string user { get; set; }

        [FirestoreProperty]
        public string password { get; set; }
    }
}
