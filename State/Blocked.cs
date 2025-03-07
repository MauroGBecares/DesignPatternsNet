using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class Blocked : IState
    {
        public void Handle(UserContext userContext, string username, string password)
        {
            Console.WriteLine("Usted se encuentra bloqueado");
        }
    }
}
