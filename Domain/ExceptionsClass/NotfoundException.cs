﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExceptionsClass
{
    public abstract class NotfoundException : Exception
    {
        protected NotfoundException(string? message) : base(message)
        {
        }
    }
}
