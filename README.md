# CompanyDB
Implementation of database with Entity Framework and code-first. Also a generic data warehouse service that performs CRUD operations in the database and that can be injected into the API project's controllers Since the API uses Data Transfer Objects (DTOs) to communicate with the outside world, the data warehouse is able to convert between DTO and EF Entity using AutoMapper when data is fetched, changed, added, or removed.
There is also an implemention of a generic http layer in the API project, which reduces the code in the API's controllers.
