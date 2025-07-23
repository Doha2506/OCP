using OCP.Interfaces;
using OCP.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP.Services
{
    internal class DiscountFactory : IDiscountFactory
    {
        private readonly Dictionary<UserType, Func<IDiscountCalculator>> _strategies;

        public DiscountFactory()
        {
            _strategies = new Dictionary<UserType, Func<IDiscountCalculator>>();
            RegisterDefault();
        }

        private void RegisterDefault()
        {
            _strategies.Add(UserType.Standard, () => new StandardDiscount());
            _strategies.Add(UserType.Premium, () => new PremiumDiscount());
            _strategies.Add(UserType.VIP, () => new VIPDiscount());
        }

        /// <summary>
        /// You're looking up the userType (like "Standard" or "Premium") 
        /// in the dictionary Getting the corresponding function(i.e., Func<IDiscountCalculator>) 
        /// Calling that function(()) to instantiate the appropriate discount calculator
        /// All without any if, switch, or changing existing code — 
        /// that’s the spirit of the Open/Closed Principle
        /// </summary>
        /// <param name="userType">Could be Premium, VIP, Standard, etc..</param>
        /// <returns>the function from dictionary where its key = userType</returns>
        public IDiscountCalculator? GetCalculator(UserType userType)
        {
            if (!_strategies.ContainsKey(userType))
            {
                throw new ArgumentException($"No discount strategy found for user type: {userType}");
            }

            return _strategies[userType]();
        }

        /// <summary>
        /// Ensure adding new types in the dictionary without violating OCP 
        /// </summary>
        /// <param name="userType">string variable e.g. Student </param>
        /// <param name="factory">function contains the new Service</param>
        public void Register(UserType userType, Func<IDiscountCalculator> factory)
        {
            _strategies.Add(userType, factory);

            Console.WriteLine("Registering new type : " + userType);
        }
    }
}
