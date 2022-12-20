using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IDbService _db;

        public CompaniesController(IDbService db)
        {
            _db = db;
        }
        // GET: api/<CompaniesController>
        [HttpGet]
        public async Task<IResult> Get() => await _db.HttpGetAsync<Company, CompanyDTO>();

        // GET api/<CompaniesController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id) => await _db.HttpGetAsync<Company, CompanyDTO>(id);

        // POST api/<CompaniesController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] CompanyDTO dto) => await _db.HttpPostAsync<Company, CompanyDTO>(dto);

        // PUT api/<CompaniesController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] CompanyDTO dto) => await _db.HttpPutAsync<Company, CompanyDTO>(id, dto);

        // DELETE api/<CompaniesController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> HttpDeleteAsync(int id) => await _db.HttpDeleteAsync<Company>(id);
    }
}
