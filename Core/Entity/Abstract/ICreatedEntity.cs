﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enttity.Abstract
{
   public interface ICreatedEntity
    {
        int CreatedUserId { get; set; }
        DateTime CreatedDate { get; set; }
    }
}