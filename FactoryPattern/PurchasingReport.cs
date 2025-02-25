using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class PurchasingReport : IReport
    {
        private decimal _total;
        private int _count;
        public PurchasingReport(decimal total, int count)
        {
            _total = total;
            _count = count;
        }
        public void Generate(List<string> datos)
        {
            Console.WriteLine("Generando reporte de compras...");
            Console.WriteLine(string.Join("\n", datos));
            Console.WriteLine($"Total de compras: $ {_total}");
            Console.WriteLine($"Cantidad de productos comprados: {_count}");
        }
    }
}
