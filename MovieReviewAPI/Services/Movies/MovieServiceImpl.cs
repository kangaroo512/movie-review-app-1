using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie_Review_API.Data;
using Movie_Review_API.DTOs.Movies;
using Movie_Review_API.Models;
using Movie_Review_API.Repositories;
using System.Net.WebSockets;

namespace Movie_Review_API.Services.Movies
{
    public class MovieServiceImpl : IMovieService
    {
        private IMovieRepository<Movie> _movieRepository;

        private IMapper _mapper;

        public MovieServiceImpl(IMovieRepository<Movie> movieRepository, IMapper mapper)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }
        public async Task<MovieGetDTO> Add(MovieInsertDTO movieInsertDto)
        {
            var movie = _mapper.Map<Movie>(movieInsertDto);

            await _movieRepository.Add(movie);
            await _movieRepository.Save();

            var movieGetDto = _mapper.Map<MovieGetDTO>(movie);

            return movieGetDto;
        }

        public async Task<MovieGetDTO> Delete(int id)
        {
            var movie = await _movieRepository.GetById(id);

            if (movie == null)
            {
                return null;
            }

            var movieGetDto = _mapper.Map<MovieGetDTO>(movie);

            _movieRepository.Delete(movie);
            await _movieRepository.Save();

            return movieGetDto;

            
        }

        public async Task<IEnumerable<MovieGetDTO>> Get()
        {
            var movies = await _movieRepository.Get();

            if(movies == null)
            {
                return null;
            }

            return movies.Select(m => _mapper.Map<MovieGetDTO>(m));


        }
            
        

        public async Task<MovieGetDTO> GetById(int id)
        {
            var movie = await _movieRepository.GetById(id);

            if (movie == null)
            {
                return null;
            }

            var movieGetDto = _mapper.Map<MovieGetDTO>(movie);

            return movieGetDto;
        }

        public async Task<MovieGetDTO> Update(int id, MovieUpdateDTO movieUpdateDTO)
        {
            var movie = await _movieRepository.GetById(id);

            if(movie != null)
            {
                movie = _mapper.Map<MovieUpdateDTO, Movie>(movieUpdateDTO, movie);

                await _movieRepository.Update(movie);
                await _movieRepository.Save();

                var movieGetDto = _mapper.Map<MovieGetDTO>(movie);

                return movieGetDto;
            }

            return null;






        }
    }
}
