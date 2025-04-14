using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.UnitOfWork;

namespace BusinessLogicLayer.Services.Implementations
{
    public class WalkingPackageService : IWalkingPackageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WalkingPackageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
