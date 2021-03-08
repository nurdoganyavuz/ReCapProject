using Business.Constants;
using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserFirstName).NotEmpty();
            RuleFor(u => u.UserFirstName).MinimumLength(2).WithMessage(AspectMessages.InvalidParameters);
            RuleFor(u => u.UserLastName).NotEmpty();
            RuleFor(u => u.UserLastName).MinimumLength(2).WithMessage(AspectMessages.InvalidParameters);
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
            //RuleFor(u => u.Password).NotEmpty();
            //RuleFor(u => u.Password).Length(8,24).WithMessage(AspectMessages.InvalidPasswordLength);
            //RuleFor(u => u.Password).Matches("[a-z]").WithMessage(AspectMessages.PasswordNotInvolveLowercase)
            //    .Matches("[A-Z]").WithMessage(AspectMessages.PasswordNotInvolveUppercase)
            //    .Matches("[0-9]").WithMessage(AspectMessages.PasswordNotInvolveNumber)
            //    .Matches("[^a-zA-Z0-9]").WithMessage(AspectMessages.PasswordNotInvolveSpecialChar);
           
            //bu kısma bi çare bulunacak

        }

    }
}
