﻿using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class UserManager : IUserService
{
    private readonly IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public IResult Add(User user)
    {
        _userDal.Add(user);
        return new SuccessResult(Messages.UserAdded);
    }

    public IResult Delete(User user)
    {
        _userDal.Delete(user);
        return new SuccessResult(Messages.UserDeleted);
    }

    public IDataResult<List<User>> GetAll()
    {
        return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
    }

    public IDataResult<User> GetById(int id)
    {
        return new SuccessDataResult<User>(_userDal.GetById(id), Messages.UserListed);
    }

    public IResult Update(User user)
    {
        _userDal.Update(user);
        return new SuccessResult(Messages.UserUpdated);
    }
}
