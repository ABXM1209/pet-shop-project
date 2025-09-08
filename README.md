# Steps:

1. Create solution file
2. Create API project
3. Create test project
4. Add both to the solution and open with IDE
5. Commit it to git
6. Create 3 layers in API (data, service, controllers)
7. Add dependency injection and use controllers (Program.cs stuff)
8. Add models (Entity, Request DTOs)
9. Create controller method with HTTP verb, route, request model parameter and invoke service method
10. Create service method with data validation, object instantiation and appropriate return type
11. Make sure data layer has list of entity objects / other way or saving data.
12. Add validation to Request DTOs with data annotations
13. Return ProblemDetails object by using [ApiController] attribute for Controller classes
14. Test first in Swagger (manually) and then write a written test for each feature in the test project
