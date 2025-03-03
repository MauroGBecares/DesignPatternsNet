using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class SaveReportPdf : ISaveReportStrategy
    {
        public void Save()
        {
            Console.WriteLine("Se guardo el reporte como PDF");
        }
    }
}
