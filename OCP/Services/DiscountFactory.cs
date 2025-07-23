using OCP.Interfaces;
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
        private readonly Dictionary<string, Func<IDiscountCalculator>> _strategies;

        public DiscountFactory()
        {
            _strategies = new Dictionary<string, Func<IDiscountCalculator>>();
            RegisterDefault();
        }

        private void RegisterDefault()
        {
            _strategies.Add("Standard", () => new StandardDiscount());
            _strategies.Add("Premium", () => new PremiumDiscount());
            _strategies.Add("VIP", () => new VIPDiscount());
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
        public IDiscountCalculator GetCalculator(string userType)
        {
            return _strategies[userType]();
        }

        /// <summary>
        /// Ensure adding new types in the dictionary without violating OCP 
        /// </summary>
        /// <param name="userType">string variable e.g. Student </param>
        /// <param name="factory">function contains the new Service</param>
        public void Register(string userType, Func<IDiscountCalculator> factory)
        {
            _strategies.Add(userType, factory);

            Console.WriteLine("Registering new type : " + userType);
        }
    }
}
