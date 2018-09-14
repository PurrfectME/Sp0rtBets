using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidation.Attributes;
using SportBets.BLL.Entities;

namespace SportBets.API.Models
{
    [Validator(typeof(BetValidator))]
    public class BetModel
    {
        public int Id { get; set; }
    }

    public class BetValidator : AbstractValidator<BetModel>
    {
        public BetValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id can't be blank");

        }
    }
}