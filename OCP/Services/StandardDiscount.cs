using OCP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP.Services
{
    internal class StandardDiscount : IDiscountCalculator
    {
        public decimal GetDiscount()
        {
            return 0.05m; // Standard users get 5%

        }
    }
}
