﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class TrainingPackage
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TimeSpan Duration { get; set; } // trajanje kursa (npr. 2 weeks)

        public int SessionsPerWeek { get; set; }

        public TimeSpan SessionDuration { get; set; }

        public double PriceSmall { get; set; }

        public double PriceMedium { get; set; }

        public double PriceLarge { get; set; }
    }
}
