using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IDbService _db;

        public EmployeesController(IDbService db)
        {
            _db = db;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IResult> Get() => await _db.HttpGetAsync<Employee, EmployeeDTO>();

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id) => await _db.HttpGetAsync<Employee, EmployeeDTO>(id);

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] EmployeeDTO dto) => await _db.HttpPostAsync<Employee, EmployeeDTO>(dto);

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] EmployeeDTO dto) => await _db.HttpPutAsync<Employee, EmployeeDTO>(id, dto);

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> HttpDeleteAsync(int id) => await _db.HttpDeleteAsync<Employee>(id);
    }
}
