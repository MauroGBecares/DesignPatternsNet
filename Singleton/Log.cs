using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Log
    {
        private static Log _instance = null;

        private readonly static object _lock = new object();
        private string _path = "log.txt";

        public static Log GetInstance()
        {
            // El lock se utiliza para evitar que se creen multiples instancias de la clase en caso de que se llame al metodo
            // GetInstance() desde multiples hilos.
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Log();
                }
            }
            return _instance;
        }
        private Log()
        {

        }

        public void Save(string message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
            Console.WriteLine($"Se guardo el log a {_path}: " + message);
        }
    }
}
