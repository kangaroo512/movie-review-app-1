using FluentValidation;
using Movie_Review_API.DTOs.Movies;

namespace Movie_Review_API.Validators.Movies
{
    public class MovieUpdateValidator : AbstractValidator<MovieUpdateDTO>
    {
        public MovieUpdateValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("You must provide an ID for this movie");
            RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("The title must not be empty");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("The description must not be empty")
                .Length(100, 250)
                .WithMessage("The description must be between 100 and 250 characters long");
            RuleFor(x => x.Director)
                .NotEmpty()
                .WithMessage("You must provide a director");
            RuleFor(x => x.DurationMinutes)
                .NotNull()
                .WithMessage("You must provide a duration in minutes for this movie")
                .GreaterThan(0)
                .WithMessage("The duration in minutes must be greater than 0");
            RuleFor(x => x.ReleaseDate)
                .NotEmpty()
                .WithMessage("You must provide a release date")
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now))
                .WithMessage("the release date must be a correct date");
            RuleFor(x => x.Rating)
                .IsInEnum()
                .WithMessage("Rating must be a valid MovieRating value.");
        }
    }
}
