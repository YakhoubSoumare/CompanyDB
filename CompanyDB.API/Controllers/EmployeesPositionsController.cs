using CompanyDB.Data.Entities;
using CompanyDB.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyDB.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesPositionsController : ControllerBase
    {
        private readonly IDbService _db;

        public EmployeesPositionsController(IDbService db)
        {
            _db = db;
        }

        // GET: api/<EmployeesPositionsController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<EmployeesPositionsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<EmployeesPositionsController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] EmployeePositionDTO dto) => await _db.HttpPost<EmployeePosition, EmployeePositionDTO>(dto);

       
        [HttpDelete]
        public async Task<IResult> Delete(EmployeePositionDTO dto) => await _db.HttpDeleteAsync<EmployeePosition, EmployeePositionDTO>(dto);
    }
}
