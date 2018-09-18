using FluentValidation;
using FluentValidation.Attributes;

namespace SportBets.API.Models
{
    [Validator(typeof(FootballTeamValidator))]
    public class FootballTeamModel
    {
        public string TeamName { get; set; }
        public int WinsCount { get; set; }
        public int LossesCount { get; set; }

    }

    public class FootballTeamValidator : AbstractValidator<FootballTeamModel>
    {
        public FootballTeamValidator()
        {
            RuleFor(x => x.TeamName).NotEmpty().WithMessage("Name can't be blank")
                .Length(4, 15).WithMessage("Use correct name length");

            RuleFor(x => x.WinsCount).Must(x => x > 0 || x == 0).WithMessage("Incorrect wins count");

            RuleFor(x => x.LossesCount).Must(x => x > 0 || x == 0).WithMessage("Incorrect losses count");
        }
    }
}