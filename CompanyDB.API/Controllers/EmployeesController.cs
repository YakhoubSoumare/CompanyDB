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
        public async Task<IResult> Get()
        {
            return Results.Ok(await _db.GetAsync<Employee, EmployeeDTO>());
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            var result = await _db.SingleAsync<Employee, EmployeeDTO>(e => e.Id.Equals(id));
            if(result== null) { return Results.NotFound(); }
            return Results.Ok(result);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] EmployeeDTO dto)
        {
            if(dto==null) return Results.BadRequest();
            
            try 
            {
                var entity = await _db.AddAsync<Employee, EmployeeDTO>(dto);
                if (await _db.SaveChangesAsync())
                {
                    var node = typeof(Employee).Name.ToLower();
                    string URI = $"{node}s/{entity.Id}";
                    return Results.Created(URI, entity);
                }   
            }
            catch { }

            return Results.BadRequest();
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
