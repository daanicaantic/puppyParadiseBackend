using DomainLayer.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Helpers
{
    public static class StatusValidator
    {
        private static readonly HashSet<string> ValidStatuses = new()
        {
            ConstStatus.Pending,
            ConstStatus.Approved,
            ConstStatus.Rejected
        };

        public static bool IsValid(string status)
        {
            return ValidStatuses.Contains(status);
        }
    }
}
