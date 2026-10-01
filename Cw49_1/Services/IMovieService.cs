using Cw49_1.Models;

namespace Cw49_1.Services
{
    public interface IMovieService
    {
        Task<MovieEntity?> GetMovieAsync(string name);
        Task<List<MovieEntity>> GetMoviesAsync();
    }
}
