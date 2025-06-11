using FluentValidation;
using MovieStore.Models;

namespace MovieStore.API.Validators
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(m => m.Title)
                .NotEmpty().WithMessage("Заглавието е задължително.")
                .MaximumLength(100);

            RuleFor(m => m.Year)
                .InclusiveBetween(1900, DateTime.Now.Year)
                .WithMessage("Годината трябва да е валидна.");

            RuleForEach(m => m.Actors)
                .NotEmpty().WithMessage("ID на актьор не може да е празно.");
        }
    }
}
