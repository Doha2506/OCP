using OCP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP.Services
{
    internal class StudentDiscount : IDiscountCalculator
    {
        public decimal GetDiscount()
        {
            return 0.15m;
        }
    }
}
