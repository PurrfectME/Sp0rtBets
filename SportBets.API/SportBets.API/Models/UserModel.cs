using System;
using FluentValidation;
using FluentValidation.Attributes;

namespace SportBets.API.Models
{
    [Validator(typeof(UserValidator))]
    public class UserModel
    {
        public string Email { get; set; }
    }

    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage("A valid email is required");
        }
    }
}