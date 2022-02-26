﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAcccess
{
    //deneme
    public interface IBaseRepository<T> where T :class,IEntity,new()
    {
        Task<IEnumerable<T>> GetListAsync();
    }
}
