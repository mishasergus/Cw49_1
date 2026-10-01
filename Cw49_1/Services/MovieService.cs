using Cw49_1.Models;
using Cw49_1.Repositories;

namespace Cw49_1.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<MovieEntity?> GetMovieAsync(string name)
        {
            return await _movieRepository.GetMovieAsync(name);
        }
        public async Task<List<MovieEntity>> GetMoviesAsync()
        {
            return await _movieRepository.GetMoviesAsync();
        }
    }
}
