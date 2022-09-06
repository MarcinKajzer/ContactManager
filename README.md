# ContactManager

![image](https://user-images.githubusercontent.com/44943281/188713727-2e7d640c-3d98-4565-93d6-a34ce0b69900.png)

An application that performs the following functions: 

1. New user registratio.
2. Login existing user.
3. CRUD of contacts.
4. Creating, updating, deleting available for authorized users only. 

## Technologies:

1.	ASP.NET 6 Web API
2.	Angular 14

## Used libraries: 

1.	Entity Framework
2.	Identity 

## Prerequisites: 

1. Node.js installed. 
2. Angular 14 installed. 
3. .NET 6 installed.

## How to run: 

1. Go to appsettings.json file in API project and set appropriate database connection string.
2. Open ContactManagerAPI solution in Visual Studio 2022 
3. Open Package Manager Console and run "update-database" command.
4. Run project. 
5. Go to CLIENT directory and execute command "ng serve" in order to run SPA project.

## API structure: 

1. Controllers: 
- AuthController - responsible for creating new and authenticating existing users.
- ContactController - composed of contacts CRUD actions.
2. Entities - c# representation of database tables.
3. DTOs - objects responsible for transfering data from and to the client app and hide database entities details.
4. Helpers: 
- TokenGenerator - class responsible for generating JWT.
5. DbContext - class containing configuration of database like column definitions, default values etc.
5. Migrations - the piece of code responsible for creating the database based on the configuration in dbcontext.
