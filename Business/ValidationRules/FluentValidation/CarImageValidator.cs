﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(ci => ci.CarId).NotEmpty();
            RuleFor(ci => ci.ImagePath).NotEmpty();
            RuleFor(ci => ci.ImageUploadDate).NotEmpty();
        }
    }
}
