using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    // Concrete Product
    public class SalesReport : IReport
    {
        private decimal _total;
        public SalesReport(decimal total)
        {
            _total = total;
        }
        public void Generate(List<string> datos)
        {
            Console.WriteLine("Generando reporte de ventas...");
            Console.WriteLine(string.Join("\n", datos));
            Console.WriteLine($"Total de ventas: $ {_total}");
        }
    }
}
