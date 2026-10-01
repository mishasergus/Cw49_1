using Cw49_1.Models;
namespace Cw49_1.Repositories
{
    public interface IMovieRepository
    {
        Task<MovieEntity?> GetMovieAsync(string name);
        Task<List<MovieEntity>> GetMoviesAsync();
    }
}
