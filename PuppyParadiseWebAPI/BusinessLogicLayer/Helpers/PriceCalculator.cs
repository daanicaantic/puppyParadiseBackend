using BusinessLogicLayer.Constants.ExceptionsConstants;
using DomainLayer.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Helpers
{
    public static class PriceCalculator
    {
        public static double CalculatePrice(double basePrice,string dogSize)
        {
            if (string.IsNullOrWhiteSpace(dogSize))
                throw new Exception(DogExceptionsConstants.RequiredDogSize);

            switch (dogSize)
            {
                case ConstDogSizes.Small:
                    return basePrice * 0.8;
                case ConstDogSizes.Large:
                    return basePrice * 1.2;
                case ConstDogSizes.Medium:
                    return basePrice;
                default:
                    throw new Exception(DogExceptionsConstants.UnknownDogSize);
            }
        }
    }
}
