using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Viagogo
{
    public class Event
    {
        public string Name { get; set; }
        public string City { get; set; }
    }
    public class Customer
    {
        public string Name { get; set; }
        public string City { get; set; }
    }
    public class Solution
    {
        static void Main(string[] args)
        {
            var events = new List<Event>{
                new Event{ Name = "Phantom of the Opera", City = "New York"},
                new Event{ Name = "Metallica", City = "Los Angeles"},
                new Event{ Name = "Metallica", City = "New York"},
                new Event{ Name = "Metallica", City = "Boston"},
                new Event{ Name = "LadyGaGa", City = "New York"},
                new Event{ Name = "LadyGaGa", City = "Boston"},
                new Event{ Name = "LadyGaGa", City = "Chicago"},
                new Event{ Name = "LadyGaGa", City = "San Francisco"},
                new Event{ Name = "LadyGaGa", City = "Washington"}
                };
            //1. find out all events that arein cities of customer
            // then add to email.
            var customer = new Customer { 
                Name = "Mr. Fake", 
                City = "New York" 
            };

            //Retrieve from events using customer object
            

            //var query = from result in customer
            //            where result.Contains("New York")
            //            select result;

            var nearCities = GetDistance("New York", "Boston");

            if (nearCities == 0)
            {
                var cityEvents = events.Where(e => e.City == customer.City).ToList();

                foreach (var item in cityEvents)
                {
                    AddToEmail(customer, item);
                }
            }

            // 1. TASK

            var store_dict = new Dictionary<string, string>() { };

            var Cities = events.Select(x => x.City).ToList();

            foreach (var city in Cities)
            {
                var k = GetDistance("New York", city).ToString();
                store_dict[city] = k;
            }

            

            Console.Out.WriteLine(store_dict);



            //Improvement: Send a single email with all events rather than multiple emails for each event.

            /*
            * We want you to send an email to this customer with all events in their city
            * Just call AddToEmail(customer, event) for each event you think they should get
            */

            
        }
        // You do not need to know how these methods work
        static void AddToEmail(Customer c, Event e, int? price = null)
        {
            var distance = GetDistance(c.City, e.City);
            Console.Out.WriteLine($"{c.Name}: {e.Name} in {e.City}"
            + (distance > 0 ? $" ({distance} miles away)" : "")
            + (price.HasValue ? $" for ${price}" : ""));
        }
        static int GetPrice(Event e)
        {
            return (AlphebiticalDistance(e.City, "") + AlphebiticalDistance(e.Name, "")) / 10;
        }
        static int GetDistance(string fromCity, string toCity)
        {
            return AlphebiticalDistance(fromCity, toCity);
        }
        private static int AlphebiticalDistance(string s, string t)
        {
            var result = 0;
            var i = 0;
            for (i = 0; i < Math.Min(s.Length, t.Length); i++)
            {
                // Console.Out.WriteLine($"loop 1 i={i} {s.Length} {t.Length}");
                result += Math.Abs(s[i] - t[i]);
            }
            for (; i < Math.Max(s.Length, t.Length); i++)
            {
                // Console.Out.WriteLine($"loop 2 i={i} {s.Length} {t.Length}");
                result += s.Length > t.Length ? s[i] : t[i];
            }
            return result;
        }
    }
}
/*
var customers = new List<Customer>{
new Customer{ Name = "Nathan", City = "New York"},
new Customer{ Name = "Bob", City = "Boston"},
new Customer{ Name = "Cindy", City = "Chicago"},
new Customer{ Name = "Lisa", City = "Los Angeles"}
};
*/