// using System;
// using System.Collections.Generic;

// Console.WriteLine("My Enemies List!");
// Console.WriteLine("----------------");
// List<Enemy> enemies = GetEnemies();

// foreach (Enemy myEnemy in enemies)
// {
//     if (myEnemy.IsReallyHated)
//     {
//         Console.WriteLine($"{myEnemy.FirstName} {myEnemy.LastName} (Really, really dislike!)");
//     }
//     else
//     {
//         Console.WriteLine($"{myEnemy.FirstName} {myEnemy.LastName}");
//     }
// }


// // A function to make and return list of enemies
// List<Enemy> GetEnemies()
// {
//     // Make a list of Enemy objects
//     //  How would you create a collection of enemy objects in JavaScript?
//     List<Enemy> enemies = new List<Enemy> {
//         new Enemy {
//             FirstName = "Joshua",
//             LastName = "Flowers",
//             Offenses = new List<string> {
//                 "Being a jerk to me in elementary school",
//                 "Not being nice to me in elementary school"
//             },
//             IsReallyHated = true
//         },
//         new Enemy {
//             FirstName = "Darth",
//             LastName = "Vader",
//             Offenses = new List<string> {
//                 "Cut off Luke's hand",
//                 "Murdered all those kids",
//                 "Unkind management practices"
//             },
//             IsReallyHated = false
//         },
//         new Enemy {
//             FirstName = "Betty",
//             LastName = "Rudelady",
//             Offenses = new List<string> {
//                 "Phone calls in the theater",
//                 "Phone calls on the bus",
//                 "Phone calls in line at the grocery store",
//                 "Poor conversationalist"
//             },
//             IsReallyHated = true
//         },
//         new Enemy {
//             FirstName = "Leon",
//             LastName = "Peck",
//             Offenses = new List<string> {
//                 "Keeps giving me a hotplate"
//             },
//             IsReallyHated = false
//         }
//     };

//     return enemies;
// }

// // Classes are how we define objects in C#. They help us ensure that our objects always have
// //  the correct properties and methods.
// // JavaScript is more flexible (but also more error-prone), so you will not need to translate
// //  this class into JavaScript
// public class Enemy
// {
//     public string FirstName { get; set; }
//     public string LastName { get; set; }
//     public bool IsReallyHated { get; set; }
//     public List<string> Offenses { get; set; }
// }


// example from chapter 12

using System;
using System.Collections.Generic;

namespace Classes
{
    public class Customer
    {
        // Public Properties
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsLocal { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }

    public class DeliveryService
    {
        /*
          Properties
        */
        public string Name { get; set; }

        public string TransitType { get; set; }

        /*
          Methods:
          
          Deliver=>takes a Product and a Customer as parameters
          Print a message indicating that the product has been delivered by the specified transit type to the specified customer.
        */
        public void Deliver(Product product, Customer customer)
        {
            Console.WriteLine($"Product delivered by {TransitType} to {customer.FullName}");
        }
    }

    public class Product
    {
        /*
          Properties
        */
        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        /*
          Methods
          Ship=> takes a Customer and a DeliveryService as parameters
          If the customer is not local=> calls the Deliver method of the specified delivery service, passing itself (this) and the customer as arguments.
        */
        public void Ship(Customer customer, DeliveryService service)
        {
            if (!customer.IsLocal)
            {
                service.Deliver(this, customer);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)// create several instances of the classes above w/in Main method
        {
            Product tinkerToys = new Product()
            {
                Title = "Tinker Toys",
                Description = "You can build anything you want",
                Price = 32.49,
                Quantity = 25
            };

            Customer marcus = new Customer()
            {
                FirstName = "Marcus",
                LastName = "Fulbright",
                IsLocal = false
            };

            DeliveryService UPS = new DeliveryService()
            {
                Name = "UPS",
                TransitType = "train"
            };

            /*
            - Called class Ship(Customer customer, DeliveryService service)...requires 2 parameters (marcus, UPS)
            - Inside the Ship class checks if customer is not local
            - If not local=> calls the Deliver method of the specified delivery service, passing itself (this) and the customer as arguments:
            
                             UPS.Deliver(this, customer) 
            - which goes to the deliver method inside class DeliveryService to access:
                            Console.WriteLine($"Product delivered by {TransitType} to {customer.FullName}");
                            ~~~Product delivered by train to Marcus Fulbright~~~
            */
            tinkerToys.Ship(marcus, UPS);
        }
    }
}