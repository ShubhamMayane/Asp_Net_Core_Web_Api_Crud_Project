using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        [Route("all")]   //ya api chi url : localhost:3000/api/employees/all ashi hote aani all shevati takal jate url madhe 
        public IActionResult GetProducts()
        {
            
            return Ok("api i called successfully");
        }


    }
}
