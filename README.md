# Parks API
By Cassandra Copp

## Description
This API allows the user to get, post, update, and delete parks from a database. The API can be accessed from an MVC or can be accessed using Postman. . It also includes Swagger for documentation.

## Technologies Used

* C#
* ASP.NET Core
* Entity Framework
* MySQL
* Swagger
* Postman

### System Requirements 
1. [.NET 5.0](https://dotnet.microsoft.com/download)  
1. [MySQL Community Server](https://dev.mysql.com/downloads/file/?id=484914)
1. [MySQL Workbench](https://dev.mysql.com/downloads/file/?id=484391) (optional, can be used to view and edit the database outside of the application)
1. [Postman](https://www.postman.com/downloads/)

### Installation
1. Clone the [ParksAPI.Solution](https://github.com/cass1618/ParksAPI.Solution) Repository

    ### Set Up Required Database
    1. To update the database, dotnet-ef must be installed.  Run the following command in terminal, in any directory:
    ```sh
    dotnet tool install --global dotnet-ef
    ```
    2. To create the database, run the following command in the ParksAPI.Solution/ParksAPI directory:
    ```sh
    dotnet ef database update
    ```
    3. If you would like to view the database you may do so in MySQL Workbench.  The database will be titled parks_api (or whatever the database name in appsettings.json)

2. Add an `appsettings.json` file to the `ParksAPI.Solution/ParksAPI` directory and add the following:
```json
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=parks_api;uid=root;pwd=YourPassword;"
  }
}
```
3. Replace YourPassword with your own MySQL password
4. To run the app in terminal, navigate to `ParksAPI.Solution/ParksAPI` directory and enter the command:
```cs
$ dotnet run
```
5. To test the API, open up Postman and Create New Workspace.

    * Select New HTTP Request
    * To view current parks, enter `localhost:5000/api/parks` into the address bar and select GET and click Send
    * To add a new park, select POST, select Body tab, select raw, and change Text to JSON.
      - Enter the park in the following format, then click Send
  ```json
  {
      "parkName": "Name of your park",
      "size": "Size of your park",
      "description": "Description of your park"
  }
  ```

  * To update a park, select PUT and enter the park in the same format, including the parkId as well.  In the address bar, add the id to the end of the address for example `localhost:5000/api/parks/1`
  * To delete a park, select DELETE and enter the address with the id you would like to delete at the end

6. To check the Swagger documentation, go to `http://localhost:5000/swagger` while the program is still running

## Known bugs

This application has no known bugs.

## License

[MIT](https://opensource.org/licenses/MIT)

Copywrite (c) Cassandra Copp 2021.

## Contact Information

[github.com/cass1618](http://github.com/cass1618)