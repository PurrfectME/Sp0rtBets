using FluentValidation;
using FluentValidation.Attributes;

namespace SportBets.API.Models
{
    [Validator(typeof(FootballTeamValidator))]
    public class FootballTeamModel
    {
        public int Id { get; set; }

    }

    public class FootballTeamValidator : AbstractValidator<FootballTeamModel>
    {
        public FootballTeamValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id can't be blank");
        }
    }
}