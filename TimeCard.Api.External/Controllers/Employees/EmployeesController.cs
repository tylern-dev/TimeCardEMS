using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace TimeCard.Api.External.Controllers.Employees {
  [Produces("application/json")]
  [Route("[controller]")]
  public class EmployeesController : Controller {
    public EmployeesController() {

    }

    [HttpGet("{name}")]
    [ProducesResponseType(200)]
    public EmployeeResponse getEmployees(string name){
      return new EmployeeResponse{
        Name = name
      };
    }

    public class EmployeeResponse {
      public string Name { get; set; }

    }


  }

}