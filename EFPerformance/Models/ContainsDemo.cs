using System;
using System.Linq;

namespace EFPerformance.Models
{
    public class ContainsDemo : IDemo
    {
        public void Problem()
        {
            Console.WriteLine("Contains Demo");
            using (var db = new NorthwindDb())
            {
                var customers = db.Customers.Where(c => c.PreferedCommunication.Contains("Pho")).ToList();
                Console.WriteLine("{0} Customers", customers.Count);

            }
        }

        public void Solution()
        {
            Console.WriteLine("Contains Demo - Solution");
            using (var db = new NorthwindDb())
            {
                var customers = db.Customers.Where(c => c.PreferedCommunication.StartsWith("Pho")).ToList();
                Console.WriteLine("{0} Customers", customers.Count);

            }
        }
    }
}