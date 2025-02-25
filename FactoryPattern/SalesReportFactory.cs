using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    // Concrete Creator
    public class SalesReportFactory : ReportFactory
    {
        private decimal _total;
        public SalesReportFactory(decimal total)
        {
            _total = total;
        }
        public override IReport GetReport()
        {
            return new SalesReport(_total);
        }
    }
}
