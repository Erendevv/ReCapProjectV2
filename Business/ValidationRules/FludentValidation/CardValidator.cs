using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FludentValidation
{
    public class CardValidator : AbstractValidator<CreditCard>
    {
        public CardValidator()
        {
            RuleFor(c => c.CardCvv).Length(3);
            RuleFor(c => c.CardCvv).NotEmpty();
            RuleFor(c => c.CardNumber).NotEmpty();
            RuleFor(c => c.CardNumber).Length(16);
            RuleFor(c => c.ExpirationDate).Length(4);
            RuleFor(c => c.ExpirationDate).NotEmpty();
            RuleFor(c => c.NameOnTheCard).NotEmpty();
        }
    }
}
