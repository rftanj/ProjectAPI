using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Models;
using ProjectAPI.Models.DB;
using ProjectAPI.Models.DTO;
using ProjectAPI.Services;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly CustomerService _customerService;
        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var datas = _customerService.GetListCustomers();
                if (datas.Count == 0)
                {
                    var responseNotFound = new GeneralResponse<CustomerDTO>
                    {
                        StatusCode = "404",
                        StatusDescription = "Data not found",
                        Data = new List<CustomerDTO>()
                    };

                    return NotFound(responseNotFound);
                }

                var response = new GeneralResponse<CustomerDTO>
                {
                    StatusCode = "200",
                    StatusDescription = "Success",
                    Data = _customerService.GetListCustomers()
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Message = ex.Message.ToString()});
            }
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var data = _customerService.GetCustomer(id);
                if (data.Count == 0)
                {
                    var responseNotFound = new GeneralResponse<CustomerDTO>
                    {
                        StatusCode = "404",
                        StatusDescription = "Data not found",
                        Data = new List<CustomerDTO>()
                    };

                    return NotFound(responseNotFound);
                }

                var response = new GeneralResponse<CustomerDTO>
                {
                    StatusCode = "200",
                    StatusDescription = "Success",
                    Data = data
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Message = ex.Message.ToString() });
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
