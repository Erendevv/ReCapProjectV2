using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult VerifyCard(CreditCard creditCard);

        IDataResult<List<CreditCard>> GetAll();

        IDataResult<List<CreditCard>> GetByCardNumber(string cardNumber);

        IResult Update(CreditCard creditCard);

        IResult Add(CreditCard creditCard);

        IResult Delete(CreditCard creditCard);

    }
}
