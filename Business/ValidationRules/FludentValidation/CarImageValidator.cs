using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FludentValidation
{
    public class CarImageValidator: AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(p => p.CarId).NotEmpty().WithMessage("Id alanı boş bırakılamaz.");
            RuleFor(p => p.ImagePath).NotEmpty().WithMessage("Fotoğraf yüklemek zorunludur.");

        }
    }
}
