
using System.Reflection;

namespace Builder
{
    public class PrepareComputerConcreteBuilder : IBuilderComputer
    {
        private PrepareComputer _prepareComputer;
        public PrepareComputerConcreteBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _prepareComputer = new PrepareComputer();
        }

        public void ArmComputer()
        {
            Console.WriteLine("Armando computadora...");
        }

        public void SetComputerCase(string model)
        {
            _prepareComputer.ComputerCase = model;
        }

        public void SetCoolingSystem(string model)
        {
            _prepareComputer.CoolingSystem = model;
        }

        public void SetCPU(string cpu)
        {
            _prepareComputer.CPU = cpu;
        }

        public void SetGPU(string model, bool rtx)
        {
            _prepareComputer.GPU = model + (rtx ? " Tiene RTX." : " No tiene RTX.");
        }

        public void SetMotherboard(string model)
        {
            _prepareComputer.MotherBoard = model;
        }

        public void SetRam(string model, int gigabyteQuantity)
        {
            _prepareComputer.RAM = $"{model} - Cantidad de GBs: {gigabyteQuantity}";
        }

        public void SetStorage(string model, int gigabyteQuantity)
        {
            _prepareComputer.Storage = $"{model} - Cantidad de GBs: {gigabyteQuantity}";
        }

        public void TimeToBuild(int time)
        {
            Thread.Sleep(time);
            Console.WriteLine("La computadora ha sido armada.");
            _prepareComputer.Result = @$"MotherBoard: {_prepareComputer.MotherBoard}, CPU: {_prepareComputer.CPU}, 
                RAM: {_prepareComputer.RAM}, Storage: {_prepareComputer.Storage}, GPU: {_prepareComputer.GPU}, 
                CoolingSystem: {_prepareComputer.CoolingSystem}, ComputerCase: {_prepareComputer.ComputerCase}";
        }

        public PrepareComputer GetComputer() => _prepareComputer;
    }
}
