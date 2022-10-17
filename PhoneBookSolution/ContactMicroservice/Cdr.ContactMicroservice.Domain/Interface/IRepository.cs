﻿using Ardalis.Specification;
using Cdr.ContactMicroservice.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ContactMicroservice.Domain.Services
{
    public interface IRepository<T>  : IRepositoryBase<T> where T : class, IAggregateRoot
    { 
    }
}