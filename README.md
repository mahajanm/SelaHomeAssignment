This is a .NET Core 7 Web API Repository. 

Contain all the logic to handle Crud Operations on TaskDetail entity. I have tried to implement below functionalities 

Asynchronous Operation.

Data Validations using Data Annotations.

Authentication (Bearer JWT Token)

Repository Design Pattern, Dependancy Inject Pattern.

DTO’s as a standard practice to avoid disclosing domain model to the client. 

Auto Mapper to handle Mapping between DTO’s and Domain Model.

Custom Action Filter to validate Model State at one place rather than validating it at all the required places to remove the duplicate and redundant code. 

Implemented custom exception to check if duplicate title already exists to avoid creating duplicate records. 

Implemented custom middleware for global exception handling.

Instructions on how to run the application locally

Clone this repository on local

1 (Via Command line) Navigate to ASP.NET Core project directory (Selo.Task.API) and run "dotnet run". Ensure your API is accessible (typically on http://localhost:7209)

2 Or Open solution in visual studio and build and run.
