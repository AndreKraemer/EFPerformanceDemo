// --------------------------------------------------------------------------------------
// <copyright file="LateFilterDemo.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2014 André Krämer http://andrekraemer.de
// </copyright>
// <summary>
//  Entity Framework Perfomance Demo.
// </summary>
// --------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using EFPerformance.Models;

namespace EFPerformance
{
    public class LateFilterDemo : IDemo
    {
        public void Problem()
        {
            Console.WriteLine("LateFilterDemo");
            using (var db = new NorthwindDb())
            {
                var customers = GetCustomers(db).Where(c => c.Country == "Germany");
                foreach (var customer in customers)
                {
                    Console.WriteLine("{0} - {1}", customer.CustomerID, customer.CompanyName);
                }
            }
        }

        private IEnumerable<Customers> GetCustomers(NorthwindDb db)
        {
            return db.Customers;
        }

        public void Solution()
        {
            Console.WriteLine("LateFilterDemo");
            using (var db = new NorthwindDb())
            {
                var customers = GetCustomersQry(db).Where(c => c.Country == "Germany");
                foreach (var customer in customers)
                {
                    Console.WriteLine("{0} - {1}", customer.CustomerID, customer.CompanyName);
                }
            }
        }




        private IQueryable<Customers> GetCustomersQry(NorthwindDb db)
        {
            return db.Customers;
        }
    }
}