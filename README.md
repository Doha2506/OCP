Open/Closed Principle:
Your classes should be open for extension but closed for modification.
That means when adding new functionality, you don’t change existing code, but extend it using abstraction

How is the code now follows OCP ?

when i try to add new type of user ,  won't change the code .. just add new service wit new implementation and call it in the main to regitser it.
before OCP i would edit the dictionary by myself to add the new type .. and this will violate the OCP as i would edit the file.
