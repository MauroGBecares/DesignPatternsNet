using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class PurchasingReportFactory : ReportFactory
    {
        private decimal _total;
        private int _count;
        public PurchasingReportFactory(decimal total, int count)
        {
            _total = total;
            _count = count;
        }
        public override IReport GetReport()
        {
            return new PurchasingReport(_total, _count);    
        }
    }
}
