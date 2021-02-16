using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetById(int id);

        IDataResult<List<User>> GetAllUsers();

        IResult Add(User user);

        IResult Delete(User user);

        IResult Update(User user);
    }
}
