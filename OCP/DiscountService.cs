using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP
{
    internal class DiscountService
    {
        public decimal GetDiscount(string userType)
        {
            if (userType == "Standard")
                return 0.05m;
            else if (userType == "Premium")
                return 0.10m;
            else if (userType == "VIP")
                return 0.20m;
            else
                return 0.0m;
        }
    }
}
