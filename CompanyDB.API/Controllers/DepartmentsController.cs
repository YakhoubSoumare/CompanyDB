using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDbService _db;

        public DepartmentsController(IDbService db)
        {
            _db = db;
        }
        // GET: api/<DepartmentsController>
        [HttpGet]
        public async Task<IResult> Get() => await _db.HttpGetAsync<Department, DepartmentDTO>();

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id) => await _db.HttpGetAsync<Department, DepartmentDTO>(id);

        // POST api/<DepartmentsController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] DepartmentDTO dto) => await _db.HttpPostAsync<Department, DepartmentDTO>(dto);

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] DepartmentDTO dto) => await _db.HttpPutAsync<Department, DepartmentDTO>(id, dto);

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> HttpDeleteAsync(int id) => await _db.HttpDeleteAsync<Department>(id);
    }
}
