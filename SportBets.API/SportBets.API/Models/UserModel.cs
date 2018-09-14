using System;
using FluentValidation;
using FluentValidation.Attributes;

namespace SportBets.API.Models
{
    [Validator(typeof(UserValidator))]
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }

    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id can't be blank");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage("A valid email is required");
        }
    }
}