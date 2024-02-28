# SearchTransport
Test from Browser Travel
Project created from the statement of the Browser Travel development test, which requests an advanced search system that allows its clients to efficiently and accurately find available vehicles. They request to search for the vehicle according to the client's location and the vehicle's location. For this, a SQL SERVER database was created and a Restful API with .Net Core 8 was created, which has a layered architecture, following SOLID principles, with Dependency Injection, uses Entity Framework as an ORM, and tests were created with MSTest.

## Installation
1. Clone the repository: git clone https://github.com/samaelcardona/SearchTransport.git
2. Open the project with VisualStudio and in the scripts folder you will find a script to create the database.
3. Execute the script in two steps:
   - Execute the script in two steps:
   - Execute the first line to create the database,
   - Execute the rest of the code to create the tables and the test records.   
5. Run the solution.
6. Test with SWAGGER the API.
7. You can run the unit tests through the test explorer.
8. If you encounter problems, it may be due to the connection string, to validate the connection string, check the file (appsettings.json).

## Usage
When you run the solution, you can test it with the Swagger UI (In the Models/ApiModels folder and the JsonRequestBodySchemaFilter class, you can change the parameters to test it with swagger), or you can make requests with postman or the application of preference for testing and API documentation.

The API request path is as follows:
PUT api/Vehicles
and the request Json is:
{
"LocationName": "locacion 1",
"ClientLocationName": "locacion 2"
}
LocationName refers to the location of vehicle pickup and
ClientLocationName refers to the location of the client who will pick up the vehicle.
Any additional questions: samaelcardonaclavijo@outlook.com

--------------------------------------------------------------------------------------

# SearchTransport
Test from Browser Travel
Proyecto creado apartir del enunciado de la prueba de desarrollo de Browser Travel,
La cual solicita un un sistema de búsqueda avanzado que permita a sus 
clientes encontrar vehículos disponibles de manera eficiente y precisa,
Solicitan realizar la busqueda del vehiculo de acuerdo a la localidad del cliente y del vehiculo, Para ello se creo una base de datos en SQL SERVER y se creo una
Api Restful con .Net core 8, la cual Tiene una arquitectura por capas, siguiendo principios SOLID, con Inyeccion de dependencias, utiliza entityframework como orm, y se crearon test con MSTest.

## Instalación

1. Clone el repositorio: `git clone https://github.com/samaelcardona/SearchTransport.git`
2. Abra el proyecto con VisualStudio y en al carpeta scripts encontrara un script para crear la base de datos.
3. Ejecute el script en dos pasos:
	- ejecute la primera linea para crear la base de datos,
	- ejecute el resto de codigo para crear las tablas y los registros de prueba. 
4. Ejecute la solucion.
5. pruebe con SWAGGER la api.
6. puede correr los test unitarios por medio del test explorer.
7. Si presenta problemas puede ser por la cadena de conexion para validar la cadena de conexion revise el archivo (appsettings.json) 

## Uso

Cuando ejecute la solucion puede probarlo con el UI de swagger 
(En la carpeta Models/ApiModels y la clase JsonRequestBodySchemaFilter 
podra cambiar los parametros para probarla con swagger), 
o puede realizar peticiones con postman o la aplicacion de preferencia
para pruebas y documentacion de API's.

la ruta de peticion de la api es la siguiente: 
PUT api/Vehicles
y el Json de peticion es: 
{
   "LocationName": "locacion 1",
   "ClientLocationName": "locacion 2"
}
LocationName hace referencia a la localizacion de recogida del vehiculo y
ClientLocationName hace referencia a la localizacion del cliente que va a recoger el vehiculo. 
Cualquier duda adicional: samaelcardonaclavijo@outlook.com

