using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP.Interfaces
{
    internal interface IDiscountFactory
    {
        IDiscountCalculator GetCalculator(string userType);
        void Register(string userType, Func<IDiscountCalculator> factory);
    }
}
