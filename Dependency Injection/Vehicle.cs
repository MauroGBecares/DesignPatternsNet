using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{
    public class Vehicle
    {
        private string _name;
        private string _type;
        private string _model;
        private int _wheelsQuantity;

        public string Name
        {
            get { return _name; }
        }

        public int WheelsQuantity
        {
            get { return _wheelsQuantity; }
        }

        public Vehicle(string name, string type, string model, int wheelsQuantity)
        {
            _name = name;
            _type = type ;
            _model = model;
            _wheelsQuantity = wheelsQuantity;
        }
    }
}
