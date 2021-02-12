using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<Color> GetById(int id);

        IDataResult<List<Color>> GetAllColors();

        IResult Add(Color color);

        IResult Delete(Color color);
    }
}
