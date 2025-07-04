using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entidades;

namespace BusinessLogic
{
    public class BLLogIn
    {
        public async Task<LogIn> LogIn(LogIn logIn)
        {
            if (string.IsNullOrEmpty(logIn.user) || string.IsNullOrEmpty(logIn.password))
            {
                throw new ArgumentException("User and password cannot be empty.");
            }

            DALogIn daLogIn = new DALogIn();

            try
            {
                LogIn usuarioEncontrado = await daLogIn.LogIn(logIn.user, logIn.password);

                if (usuarioEncontrado != null)
                {
                    return usuarioEncontrado;
                }
                else
                {
                    return null; // No encontrado
                }
            }
            catch
            {
                throw new UnauthorizedAccessException("Invalid user or password.");
            }
        }
    }
}
