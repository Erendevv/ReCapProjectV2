using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FludentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal creditCardDal)
        {
            _paymentDal = creditCardDal;
        }

        [ValidationAspect(typeof(CardValidator))]
        public IResult Add(CreditCard creditCard)
        {
            _paymentDal.Add(creditCard);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CreditCard creditCard)
        {
            _paymentDal.Delete(creditCard);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_paymentDal.GetAll());
        }

        public IDataResult<List<CreditCard>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<CreditCard>>(_paymentDal.GetAll(c => c.CardNumber == cardNumber));
        }

        public IResult Update(CreditCard creditCard)
        {
            _paymentDal.Update(creditCard);
            return new SuccessResult(Messages.Updated);
        }

        public IResult VerifyCard(CreditCard creditCard)
        {
            var result = _paymentDal.Get(c => c.NameOnTheCard == creditCard.NameOnTheCard && c.CardNumber == creditCard.CardNumber && c.CardCvv == creditCard.CardCvv);
            if (result == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
