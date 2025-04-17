using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        //api to get all data from the  Employee table 

        [HttpGet]
        [Route("all")]   //ya api chi url : localhost:3000/api/employees/all ashi hote aani all shevati takal jate url madhe 
        public IActionResult GetEmployees()
        {
            var allEmployees = dbContext.Employees.ToList();
            return Ok(allEmployees);
        }


        [HttpGet]
        [Route("byname")] //ya api chi url : localhost:3000/api/employees/byname?firstname=John&lastname=Doe ashi hote aani all shevati byname takal jate url madhe 
        public IActionResult GetByName([FromQuery] string firstname, [FromQuery] string lastname)
        {
            // Example logic — just returning a formatted string for now
            var fullName = $"{firstname} {lastname}";
            return Ok($"Hello, {fullName}!");
        }



        //api to add the new employee  in Employee table 


        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {

            //logic to access the body parameters
            var employeeEntity = new Models.Entities.Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary


            };


            // logic to insert a record in the Employee table.
            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();

            //logic to send a response to the client
            return Ok(employeeEntity);
        }



        //api to get a data of employee of specific id from the  Employee table 

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            Console.WriteLine(id); //to print a path paramert named as id

            //logic to get a Employee row if specific id 
           var emp= dbContext.Employees.Find(id);

            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(emp);

            }


        }



       



        //api for update the employee of specific id

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id,UpdateEmloyeeDto updateEmloyeeDto)
        {

            //first we have to get employee of specific id
            var employee=dbContext.Employees.Find(id);

            if (employee == null) //if employee of this id is doesn't exist in employee table
            {
                return NotFound();
            }
            else
            {
                //logic to update the employee details in the employee table 

                employee.Name = updateEmloyeeDto.Name;
                employee.Email = updateEmloyeeDto.Email;
                employee.Phone = updateEmloyeeDto.Phone;
                employee.Salary = updateEmloyeeDto.Salary;

                dbContext.SaveChanges();

                return Ok(employee);
               


            }

        }


        //api for delete the employee of specific id

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id) 
        {

            //first we have to get employee reference of specific id
            var employee = dbContext.Employees.Find(id);

            if (employee == null) //if employee of this id is doesn't exist in employee table
            {
                return NotFound(); //sendig a errornomous 
            }

            else
            {
                    //logic to delete a row of specific id from employee in table
                    dbContext.Employees.Remove(employee);
                    dbContext.SaveChanges();

                return Ok(employee);


            }

        }


        /* 
    ***Sending User defiend resposne:
    //e.g. lets define or implement a api which sends a following js object as a response

    {   
        message:"user details is fetched successfully",
        data:{
                firstName:"shubham",
                lastName:"mayane"
            }
    }

    solution:
*/
        [HttpGet]
        [Route("getUserDefinedResponse")] //ya api chi url : localhost:3000/api/employees/getUserDefinedResponse

        public IActionResult GetByName()
        {

            var resObj = new
            {
                message = "user details is fetched successfully",
                data = new
                {
                    firstName = "shubham",
                    lastName = "mayane"
                }
            };

            return Ok(resObj);
    }







}
}
