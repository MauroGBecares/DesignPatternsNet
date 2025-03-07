using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public interface IState
    {
        public void Handle(UserContext userContext, string username, string password);
    }
}
