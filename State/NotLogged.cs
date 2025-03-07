using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class NotLogged : IState
    {
        public void Handle(UserContext userContext, string username, string password)
        {
            if (userContext.ValidateUser(username, password))
            {
                Console.WriteLine("Usted se logueo correctamente");
                userContext.SetState(new Logged());
                userContext.ResetAttempts();
            }
            else
            {
                userContext.IncreaseAttempts();
                if (userContext.Attemps >= 3)
                {
                    Console.WriteLine("El usuario y la contraseña son incorrectas, Usted ha sido bloqueado.");
                    userContext.SetState(new Blocked());
                }
                else
                {
                    Console.WriteLine($"El usuario y la contraseña son incorrectas. Tiene {3 - userContext.Attemps} intentos");
                    userContext.SetState(new NotLogged());
                }
            }
        }
    }
}
