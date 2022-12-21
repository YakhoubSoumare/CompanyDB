using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
    private readonly IDbService _db;

    public PositionsController(IDbService db)
    {
        _db = db;
    }
        // GET: api/<PositionsController>
        [HttpGet]
    public async Task<IResult> Get() => await _db.HttpGetAsync<Position, PositionDTO>();

        // GET api/<PositionsController>/5
        [HttpGet("{id}")]
    public async Task<IResult> Get(int id) => await _db.HttpGetAsync<Position, PositionDTO>(id);

        // POST api/<PositionsController>
        [HttpPost]
    public async Task<IResult> Post([FromBody] PositionDTO dto) => await _db.HttpPostAsync<Position, PositionDTO>(dto);

        // PUT api/<PositionsController>/5
        [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] PositionDTO dto) => await _db.HttpPutAsync<Position, PositionDTO>(id, dto);

        // DELETE api/<PositionsController>/5
        [HttpDelete("{id}")]
    public async Task<IResult> HttpDeleteAsync(int id) => await _db.HttpDeleteAsync<Position>(id);
    }
}
