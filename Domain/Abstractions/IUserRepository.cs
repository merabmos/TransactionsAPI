﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByEmailAsync(string email);
        Task<bool> IsEmailUniqueAsync(string email);
    }
}
