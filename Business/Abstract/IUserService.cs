using Core.Entitites.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IUserService
    {
        IDataResult<List<User>> GetAll();

        IDataResult<User> GetById(int Id);

        IResult Add(User user);

        IDataResult<User> Update(UserForRegisterDto userUpdateDto,int userId);

        IResult Delete(User user);

        List<OperationClaim> GetClaims(User user);
        IDataResult<User> GetByMail(string email);

        IResult UserUpdateExists(string email, int id);
    }
}
