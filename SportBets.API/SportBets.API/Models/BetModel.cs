using FluentValidation;
using FluentValidation.Attributes;
using SportBets.BLL.Entities;

namespace SportBets.API.Models
{
    [Validator(typeof(BetValidator))]
    public class BetModel
    {
        public double Coefficient { get; set; }
        public ItemType BetType { get; set; }
    }

    public class BetValidator : AbstractValidator<BetModel>
    {
        public BetValidator()
        {
            RuleFor(x => x.Coefficient).NotEmpty().WithMessage("Coefficient can't be blank");
            RuleFor(x => x.BetType).NotEmpty().WithMessage("Bet type can't be blank");

        }
    }
}