using Singleton;
using FactoryMethod;
using System.Collections.Generic;
using Dependency_Injection;
using Repository;

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

// DEPENDENCY INJECTION
// Es un patrón de diseño estructural que nos permite inyectar dependencias en una clase.
// Esto significa que no creamos un objeto dentro de la clase, sino que lo pasamos como parámetro,
// osea le quito la responsabilidad a la clase de crear otras clases.
// Esto nos permite cambiar la implementación de la clase sin cambiar su código.
// Este problema puede suceder cuando por ejemplo,
// cuando la clase Vehicle en este caso,
// cambia su constructor entonces tenemos que ir a cambiar la clase VehicleWithWheels o las clases que dependan de la clase Vehicle.

Vehicle vehicle = new Vehicle("KTM", "Moto", "RC 200", 2);
VehicleWithWheels vehicleWithWheels = new VehicleWithWheels("Racing", "Pirelli", vehicle);
Console.WriteLine(vehicleWithWheels.GetVehicleInfo());

// REPOSITORY
// Es un patrón de diseño que abstrae la lógica de almacenamiento,
// lo que permite a la aplicación funcionar con una variedad de fuentes de datos.
// De esta forma, la lógica de negocio de la aplicación no tiene que preocuparse de cómo se almacenan los datos.

// Esto es hardcoded, pero en un escenario real, esto vendría de una base de datos.
List<Album> albums = [
    new Album { Id = 1, Title = "Album 1", Artist = "Artist 1"},
    new Album { Id = 2, Title = "Album 2", Artist = "Artist 2"},
    new Album { Id = 3, Title = "Album 3", Artist = "Artist 3"},
    new Album { Id = 4, Title = "Album 4", Artist = "Artist 4"},
    new Album { Id = 5, Title = "Album 5", Artist = "Artist 5"}
];

Repository<Album> albumRepository = new Repository<Album>(albums);
albumRepository.Add(new Album { Id = 6, Title = "Album 6", Artist = "Artist 6" });
albumRepository.Delete(0);
foreach (var album in albums)
{
    Console.WriteLine($"Album: {album.Id} - {album.Title}. Artista: {album.Artist}");
}
