using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.API.Data;
using Movies.API.Models;

namespace Movies.API.Controllers
{
    [Route("api/Controller")]
    [ApiController]
    [Authorize("ClientIdPolicy")]
    public class MoviesController : ControllerBase
    {
        public readonly MovieDbContext _context;
        public MoviesController(MovieDbContext context)
        {
            _context = context;
            MoviesContextSeed.SeedAsync(_context);
        }
        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetAll(CancellationToken token)
        {
           return  await _context.Movies.ToListAsync(token);
        }

        // GET: MoviesController/Details/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Movie?>> Get(int id,CancellationToken token)
        {
            return await _context.Movies.FirstOrDefaultAsync(x => x.Id == id,token);
        }

        // GET: MoviesController/Create
        [HttpPost]
        public async Task Create([FromBody] Movie movie,CancellationToken token)
        {
           await _context.Movies.AddAsync(movie,token);
        }

        // GET: MoviesController/Edit/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Movie movie,CancellationToken token)
        {
            var entity = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id, token);
            return default;
        }

        // GET: MoviesController/Delete/5
        [HttpDelete("{id:int}")]
        public async Task Delete(int id,CancellationToken token)
        {
            var entity = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id, token);
            _context.Remove(entity);
        }
    }
}

