using FluentValidation;
using FluentValidation.Attributes;

namespace SportBets.API.Models
{
    [Validator(typeof(BasketballTeamValidator))]
    public class BasketballTeamModel
    {
        public string TeamName { get; set; }
        public int WinsCount { get; set; }
        public int LossesCount { get; set; }
    }

    public class BasketballTeamValidator : AbstractValidator<BasketballTeamModel>
    {
        public BasketballTeamValidator()
        {
            RuleFor(x => x.TeamName).NotEmpty().WithMessage("Id can't be blank")
                .Length(4, 15).WithMessage("Incorrect name length");

            RuleFor(x => x.WinsCount).Must(x => x > 0 || x == 0).WithMessage("Incorrect wins amount");

            RuleFor(x => x.LossesCount).Must(x => x > 0 || x == 0).WithMessage("incorrect losses amount");
        }
    }
}