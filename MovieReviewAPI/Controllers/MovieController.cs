using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Review_API.Data;
using Movie_Review_API.DTOs.Movies;
using Movie_Review_API.Models;
using Movie_Review_API.Repositories;
using Movie_Review_API.Services.Movies;
using Movie_Review_API.Validators.Movies;
using System.ComponentModel.DataAnnotations;

namespace Movie_Review_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        

        private IValidator<MovieInsertDTO> _movieInsertValidator;

        private IValidator<MovieUpdateDTO> _movieUpdateValidator;

        private IMovieService _movieService;
        public MovieController(AppDbContext context,
            IValidator<MovieInsertDTO> movieInsertValidator,
            IValidator<MovieUpdateDTO> movieUpdateValidator,
            IMovieService movieService)
        { 
            _movieService = movieService;
            _movieUpdateValidator = movieUpdateValidator;
            _movieInsertValidator = movieInsertValidator;

        }


        [HttpGet]
        public async Task<IEnumerable<MovieGetDTO>> Get() =>
            await _movieService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieGetDTO>> GetById(int id)
        {
            var movie = await _movieService.GetById(id);

            return movie == null ? NotFound() : Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<MovieGetDTO>> Add(MovieInsertDTO movieInsertDto)
        {

            var validationResult = await _movieInsertValidator.ValidateAsync(movieInsertDto);

            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var movieGetDto = _movieService.Add(movieInsertDto);

            return CreatedAtAction(nameof(GetById), new { id = movieGetDto.Id}, movieGetDto);
        }

        [HttpPut]
        public async Task<ActionResult<MovieGetDTO>> Update(int id, MovieUpdateDTO movieUpdateDTO)
        {

            var validationResult = await _movieUpdateValidator.ValidateAsync(movieUpdateDTO);

            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var movie = _movieService.Update(id, movieUpdateDTO);

            return movie == null ? NotFound() : Ok(movie);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieGetDTO>> Delete(int id)
        {
            var movieGetDto = await _movieService.Delete(id);

            return movieGetDto == null ? NotFound() : Ok(movieGetDto);
        }




    }





}
