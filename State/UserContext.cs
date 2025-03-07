using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class UserContext
    {
        private IState _state;

        public int Attemps { get; set; } = 0;
        public IState State => _state;
        public UserContext()
        {
            _state = new NotLogged();
        }
        public void SetState(IState state) => _state = state;
        public void Request(string username, string password) => _state.Handle(this, username, password);
        public void ResetAttempts() => Attemps = 0;
        public void IncreaseAttempts() => Attemps++;
        public bool ValidateUser(string username, string password) => username == "admin" && password == "admin";
    }
}
