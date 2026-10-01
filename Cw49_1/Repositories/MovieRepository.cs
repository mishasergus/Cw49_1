using Cw49_1.Models;
using Cw49_1.Db;
using Microsoft.EntityFrameworkCore;

namespace Cw49_1.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<MovieEntity?> GetMovieAsync(string name)
        {
            return await _context.Movies.FirstOrDefaultAsync(m => m.Name.Contains(name));
        }
        public async Task<List<MovieEntity>> GetMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }
    }
}
