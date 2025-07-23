using OCP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP.Interfaces
{
    internal interface IDiscountFactory
    {
        IDiscountCalculator GetCalculator(UserType userType);
        void Register(UserType userType, Func<IDiscountCalculator> factory);
    }
}
