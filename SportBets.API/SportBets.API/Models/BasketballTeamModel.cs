using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidation.Attributes;

namespace SportBets.API.Models
{
    [Validator(typeof(BasketballTeamValidator))]
    public class BasketballTeamModel
    {
        public int Id { get; set; }
    }

    public class BasketballTeamValidator : AbstractValidator<BasketballTeamModel>
    {
        public BasketballTeamValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id can't be blank");
        }
    }
}