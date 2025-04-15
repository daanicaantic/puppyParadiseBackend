﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories.Implementations;
using DomainLayer.Models;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface ISittingPackageRepository : IRepository<SittingPackage>
    {
        void UpdateSittingPackage(SittingPackage spOld, SittingPackage spNew);
    }
}
