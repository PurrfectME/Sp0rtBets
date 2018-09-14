using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidation.Attributes;

namespace SportBets.API.Models
{
    [Validator(typeof(HorseValidator))]
    public class HorseModel
    {
        public int Id { get; set; }
        public string HorseName { get; set; }
        public float Weight { get; set; }
    }

    public class HorseValidator : AbstractValidator<HorseModel>
    {
        public HorseValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id can't be blank");

            RuleFor(x => x.HorseName).NotEmpty().WithMessage("Name can't be blank")
                .Length(1, 15).WithMessage("Horse name must be between 1 - 15");

            RuleFor(x => x.Weight).NotEmpty().WithMessage("Weight can't be blank");

        }
    }
}