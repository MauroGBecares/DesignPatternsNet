using Singleton;

// PATRONES DE DISEÑO

// SINGLETON
// Es un patrón de diseño creacional que garantiza que una clase tenga una única instancia en toda la aplicación
// y proporciona un punto de acceso global a ella.
// Esto garantiza mejor redimiento ya que evita la creación de multiples instancias de la misma clase cuando no es necesario.

var log = Log.GetInstance();
log.Save("Se inicializo el programa");
log.Save("Se guardo un archivo");
log.Save("Se cerro el programa");