using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class Logged : IState
    {
        public void Handle(UserContext userContext, string username, string password)
        {
            Console.WriteLine("Usted ya se encuentra logueado");
        }
    }
}
