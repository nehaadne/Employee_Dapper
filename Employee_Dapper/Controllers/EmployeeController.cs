using Employee_Dapper.Models;
using Employee_Dapper.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Dapper.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController: Controller
    {
        private readonly IEmployeeRepository _employeeRepo;
        public EmployeeController(IEmployeeRepository _employeeRepo)
        {
            this._employeeRepo = _employeeRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployes()
        {
            try
            {
                var employees = await _employeeRepo.GetToemployee();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEmployeebyId(int Id)
        {
            try
            {
                var employee = await _employeeRepo.GetEmployee(Id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            try
            {
                var result = await _employeeRepo.CreateEmployee(employee);

                if (result == 0)
                {
                    return StatusCode(409, "The request could not be processed because of conflict in the request");
                }
                else
                {
                    return StatusCode(200, string.Format("Record Inserted Successfuly with compnay Id {0}", result));
                }
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            try
            {
                var result = await _employeeRepo.UpdateEmployee(employee);
                if (result == 0)
                {
                    return StatusCode(409, "The request could not be processed because of conflict in the request");
                }
                else
                {
                    return StatusCode(200, string.Format("Record Updated Successfuly"));
                }
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteemployeeAsync(int id)
        {
            try
            {
                var result = await _employeeRepo.DeleteEmployee(id);
                if (result == 0)
                {
                    return StatusCode(409, "The request could not be processed because of conflict in the request");
                }
                else
                {
                    return StatusCode(200, string.Format("Record Deleted Successfuly"));
                }
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

    }
}

