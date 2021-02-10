﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        void Add(Brand brand);

        void Delete(Brand brand);

        Brand GetById(int id);

        List<Brand> GetAllBrands();
    }
}