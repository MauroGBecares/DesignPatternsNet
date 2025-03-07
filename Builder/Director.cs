using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Director
    {
        private IBuilderComputer _builderComputer;
        public Director(IBuilderComputer builderComputer)
        {
            _builderComputer = builderComputer;
        }

        // Para cambiar el builder en tiempo de ejecución
        public void SetBuilder(IBuilderComputer builderComputer)
        {
            _builderComputer = builderComputer;
        }

        public void BuildGamingComputer()
        {
            _builderComputer.Reset();
            _builderComputer.SetMotherboard("MSI B450 Gaming Plus Max");
            _builderComputer.SetCPU("AMD Ryzen 5 3600");
            _builderComputer.SetRam("Corsair Vengeance LPX", 16);
            _builderComputer.SetStorage("Kingston A2000", 500);
            _builderComputer.SetGPU("Nvidia RTX 3060", true);
            _builderComputer.SetCoolingSystem("Cooler Master Hyper 212 RGB Black Edition");
            _builderComputer.SetComputerCase("NZXT H510");
            _builderComputer.ArmComputer();
            _builderComputer.TimeToBuild(5000);
        }

        public void BuildOfficeComputer()
        {
            _builderComputer.Reset();
            _builderComputer.SetMotherboard("ASUS Prime B450M-A");
            _builderComputer.SetCPU("AMD Ryzen 3 3200G");
            _builderComputer.SetRam("Corsair Vengeance LPX", 8);
            _builderComputer.SetStorage("Kingston A2000", 250);
            _builderComputer.SetGPU("No tiene GPU", false);
            _builderComputer.SetCoolingSystem("Cooler Master Hyper 212 RGB Black Edition");
            _builderComputer.SetComputerCase("NZXT H510");
            _builderComputer.ArmComputer();
            _builderComputer.TimeToBuild(3000);
        }
    }
}
