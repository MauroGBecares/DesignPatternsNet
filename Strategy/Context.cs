namespace Strategy
{
    public class Context
    {
        private ISaveReportStrategy _strategy;
        public Context(ISaveReportStrategy strategy)
        {
            _strategy = strategy;
        }

        // Esto sirve para cambiar el comportamiento de la clase en tiempo de ejecución
        public ISaveReportStrategy Strategy
        {
            set { _strategy = value; }
        }

        public void SaveReport()
        {
            _strategy.Save();
        }
    }
}
