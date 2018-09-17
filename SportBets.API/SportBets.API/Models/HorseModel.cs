using FluentValidation;
using FluentValidation.Attributes;

namespace SportBets.API.Models
{
    [Validator(typeof(HorseValidator))]
    public class HorseModel
    {
        public string HorseName { get; set; }
        public float Weight { get; set; }
        public int Age { get; set; }
        public int WinsCount { get; set; }
        public int LossesCount { get; set; }
    }

    public class HorseValidator : AbstractValidator<HorseModel>
    {
        public HorseValidator()
        {
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age can't be blank")
                .GreaterThanOrEqualTo(3).WithMessage("Age must be greater than 3");

            

            RuleFor(x => x.HorseName).NotEmpty().WithMessage("Name can't be blank")
                .Length(1, 15).WithMessage("Horse name must be between 1 - 15");

            RuleFor(x => x.Weight).NotEmpty().WithMessage("Weight can't be blank");

        }
    }
}