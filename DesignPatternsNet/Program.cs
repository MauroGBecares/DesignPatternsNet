using Singleton;
using FactoryMethod;
using System.Collections.Generic;
using Dependency_Injection;
using Repository;
using UnitOfWork;
using UnitOfWork.Models;
using Strategy;
using Builder;
using State;

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

// Esto es hardcoded, pero en un escenario real, esto vendría de una base de datos o otra fuente de datos.
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

// UNIT OF WORK
// Lo que hace es agrupar todas las operaciones de lectura y escritura en una sola clase (como los repositorios).
// De esta forma, se asegura que todas las operaciones se realicen de forma correcta y se garantiza la integridad de los datos.
// Ademas, esto permite que cada cambio que se realice lo haga en una sola transacción.
// Y no va a ser hasta que se llame al método Save a cada rato para que se guarden los cambios en la base de datos (este en el caso de EF).
// Tambien, lo que permite es desacoplar la lógica de negocio de la lógica de acceso a datos aun mas.

// Esto es hardcoded, pero en un escenario real, esto vendría de una base de datos o otra fuente de datos.
List<MovieGenre> movieGenres = [
    new MovieGenre { Id = 1, Name = "Action" },
    new MovieGenre { Id = 2, Name = "Comedy" },
    new MovieGenre { Id = 3, Name = "Drama" },
    new MovieGenre { Id = 4, Name = "Horror" },
    new MovieGenre { Id = 5, Name = "Sci-Fi" }
];
List<Movie> movies = [
    new Movie { Id = 1, Title = "Movie 1", GenreId = 1 },
    new Movie { Id = 2, Title = "Movie 2", GenreId = 2 },
    new Movie { Id = 3, Title = "Movie 3", GenreId = 3 },
    new Movie { Id = 4, Title = "Movie 4", GenreId = 4 },
    new Movie { Id = 5, Title = "Movie 5", GenreId = 5 }
];
var unitOfWork = new UnitOfWork.UnitOfWork(movies, movieGenres);

var movieGenreRepository = unitOfWork.MovieGenres;
var movieGenre = new MovieGenre { Id = 6, Name = "Adventure" };
movieGenreRepository.Add(movieGenre);

var moviesRepository = unitOfWork.Movies;
var movie = new Movie { Id = 6, Title = "Movie 6", GenreId = 6 };
moviesRepository.Add(movie);

// Finalmente se guardan los cambios en la base de datos
unitOfWork.Save();

// STRATEGY
// Es un patrón de diseño de comportamiento que define una familia de algoritmos, los encapsula y los hace intercambiables.
// Esto permite que el algoritmo varíe independientemente de lo que quiera hacer el usuario.
// Ejemplo si por ejemplo el usuario quiere generar un reporte en PDF o en Excel, el usuario puede elegir el formato que desee.
// Respeta el principio de Single Responsibility, ya que cada clase tiene una sola responsabilidad.
// Tambien, respeta el principio de Open/Closed, ya que se puede agregar nuevos formatos de reportes sin tener que modificar el código existente.

// Aca se guarda el reporte en PDF
var context = new Context(new SaveReportPdf());
context.SaveReport();

// Aca cambio el comportamiento de la clase en tiempo de ejecución y ahora guardara un Excel del reporte tambien.
context.Strategy = new SaveReportExcel();
context.SaveReport();

// BUILDER
// Es un patrón de diseño creacional que nos permite construir objetos complejos paso a paso.
// El patrón nos permite producir diferentes tipos y representaciones de un objeto usando el mismo código de construcción.

var builder = new PrepareComputerConcreteBuilder();
var director = new Director(builder);
director.BuildGamingComputer();
var computer = builder.GetComputer();
Console.WriteLine(computer.Result);

// STATE
// Es un patrón de diseño de comportamiento que permite a un objeto cambiar su comportamiento cuando su estado interno cambia.
// Con esto, se puede cambiar el comportamiento de un objeto sin cambiar su clase.
// Esto es útil cuando se tiene un objeto que puede cambiar de estado en tiempo de ejecución.

UserContext userContext = new UserContext();
Console.WriteLine(userContext.State);

// Para que se bloquee
userContext.Request("123", "123");
userContext.Request("123", "123");
userContext.Request("123", "123");
Console.WriteLine(userContext.State);

// Para loguearse
userContext.Request("admin", "admin");
Console.WriteLine(userContext.State);

