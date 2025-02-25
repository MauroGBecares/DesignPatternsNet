using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    // La clase abstracta ReportFactory es la clase base para las fabricas concretas de reportes. (Creator)
    public abstract class ReportFactory
    {
        public abstract IReport GetReport();
    }
}
