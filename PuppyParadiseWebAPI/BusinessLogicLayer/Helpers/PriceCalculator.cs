using BusinessLogicLayer.Constants.ExceptionsConstants;
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
                throw new Exception("Dog size is required");

            switch (dogSize.ToLower())
            {
                case "small":
                    return basePrice * 0.8;
                case "large":
                    return basePrice * 1.2;
                case "medium":
                    return basePrice;
                default:
                    throw new Exception(DogExceptionsConstants.UnknownDogSize);
            }
        }
    }
}
