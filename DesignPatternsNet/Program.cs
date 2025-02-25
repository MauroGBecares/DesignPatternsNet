using Singleton;
using FactoryMethod;
using System.Collections.Generic;

// PATRONES DE DISEÑO

// SINGLETON
// Es un patrón de diseño creacional que garantiza que una clase tenga una única instancia en toda la aplicación
// y proporciona un punto de acceso global a ella.
// Esto garantiza mejor redimiento ya que evita la creación de multiples instancias de la misma clase cuando no es necesario.

var log = Log.GetInstance();
log.Save("Se inicializo el programa");
log.Save("Se guardo un archivo");
log.Save("Se cerro el programa");


// FACTORY METHOD
// Es un patrón de diseño creacional que proporciona una interfaz para crear objetos en una superclase,
// pero permite a las subclases alterar el tipo de objetos que se crearán.
// La clase abstracta ReportFactory es la clase base para las fabricas concretas de reportes. (Creator)

// Compras
List<string> compras = new List<string> { "1. Beer", "2. Suggar", "3. Oil", "4. Wine" };
ReportFactory reportFactoryPurchasing = new PurchasingReportFactory(100, 4);
IReport reportPurchasing = reportFactoryPurchasing.GetReport();

reportPurchasing.Generate(compras);

// Ventas
List<string> ventas = new List<string> { "1. Pepsi", "2. Cookies", "3. Beef", "4. Milk", "5. Chicken" };
ReportFactory reportFactorySales = new SalesReportFactory(200);
IReport reportSales = reportFactorySales.GetReport();

reportSales.Generate(ventas);