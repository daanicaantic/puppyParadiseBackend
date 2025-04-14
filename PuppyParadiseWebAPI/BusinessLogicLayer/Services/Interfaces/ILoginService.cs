﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ILoginService
    {
        string GenerateToken(User user);
    }
}
