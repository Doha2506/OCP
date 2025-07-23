✅ Week 2: Open/Closed Principle Task
--------------------
🧠 Goal:
Your classes should be open for extension but closed for modification.
That means when adding new functionality, you don’t change existing code, but extend it using abstraction.

🧩 Task Scenario:
You're building a discount system for an e-commerce platform.
Different types of users get different discounts:

Standard users get 5%

Premium users get 10%

VIP users get 20%

Your job is to calculate discounts without violating OCP — so that when a new user type is added (e.g., StudentUser or AdminUser), you don’t modify existing code.

🔧 Your Starting Point:
Create a file DiscountService.cs and start with this bad design:

public class DiscountService
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
🎯 Your Task:
✅ Task 1:
Refactor this class to follow Open/Closed Principle using polymorphism.

Create a base class or interface: IDiscountCalculator

Implement separate classes for each user type:

StandardDiscount

PremiumDiscount

VIPDiscount

✅ Task 2:
Build a DiscountFactory (or similar logic) that selects the appropriate calculator based on user type — without if or switch statements.

✅ Task 3:
Write a Main method or test that:

Passes different user types

Prints out their discounts

🧠 Bonus Challenge (Optional)
Add a new type:

StudentUser gets 15%

Show that you only add a new class and make no changes to existing ones.

📁 Suggested Structure
/Week2-OCP/
│
├── IDiscountCalculator.cs
├── StandardDiscount.cs
├── PremiumDiscount.cs
├── VIPDiscount.cs
├── DiscountFactory.cs
├── DiscountService.cs
└── Program.cs

------------------
Comments 
------------------

Open/Closed Principle:
Your classes should be open for extension but closed for modification.
That means when adding new functionality, you don’t change existing code, but extend it using abstraction

How is the code now follows OCP ?

when i try to add new type of user ,  won't change the code .. just add new service wit new implementation and call it in the main to regitser it.
before OCP i would edit the dictionary by myself to add the new type .. and this will violate the OCP as i would edit the file.
