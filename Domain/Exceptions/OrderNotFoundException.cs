﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException(string id) : base($"{id} не найден") { } 
    }
}
