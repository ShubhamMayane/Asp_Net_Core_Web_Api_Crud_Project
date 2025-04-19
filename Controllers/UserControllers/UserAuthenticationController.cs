using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {


        //api to get all data from the  Employee table 

        [HttpGet]
        [Route("all")]   //ya api chi url : localhost:3000/api/employees/all ashi hote aani all shevati takal jate url madhe 
        public IActionResult GetEmployees()
        {
           
            return Ok("got a response from the get api in UserAuhentication controller");
        }




    }
}
