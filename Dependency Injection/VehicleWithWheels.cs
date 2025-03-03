using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{
    public class VehicleWithWheels
    {
        // Esto es mala practica, ya que estamos instanciando una clase dentro de otra clase (no respesta el principio de Inyección de Dependencias)
        // private Vehicle _vehicle = new Vehicle("KTM", "Moto", "RC 200", 2);
        // Entonces, para respetar el principio de Inyección de Dependencias, debemos hacer lo siguiente
        private Vehicle _vehicle;
        private string _wheelsType;
        private string _wheelsBrand;
        // Debemos inyectar la dependencia de la clase Vehicle dentro del constructor de la clase VehicleWithWheels
        public VehicleWithWheels(string wheelsType, string wheelsBrand, Vehicle vehicle)
        {
            _wheelsType = wheelsType;
            _wheelsBrand = wheelsBrand;
            _vehicle = vehicle;
        }

        public string GetVehicleInfo()
        {
            return $"Vehiculo: {_vehicle.Name}, Tiene una cantidad de ruedas: {_vehicle.WheelsQuantity}, Tipo de Rueda: {_wheelsType}, de marca: {_wheelsBrand}";
        }
    }
}
