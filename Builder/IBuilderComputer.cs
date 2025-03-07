using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public interface IBuilderComputer
    {
        void Reset();
        void SetMotherboard(string model);
        void SetCPU(string cpu);
        void SetRam(string model, int gigabyteQuantity);
        void SetStorage(string model, int gigabyteQuantity);
        void SetGPU(string model, bool rtx);
        void SetCoolingSystem(string model);
        void SetComputerCase(string model);
        void ArmComputer();
        void TimeToBuild(int time);
    }
}
