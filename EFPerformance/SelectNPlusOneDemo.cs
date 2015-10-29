// --------------------------------------------------------------------------------------
// <copyright file="SelectNPlusOneDemo.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 André Krämer http://andrekraemer.de
// </copyright>
// <summary>
//  Entity Framework Perfomance Demo.
//  This class demonstrates the classic select N+1 Issue.
// </summary>
// --------------------------------------------------------------------------------------
using System;
using System.Data.Entity;
using System.Linq;
using EFPerformance.Models;

namespace EFPerformance
{
    public class SelectNPlusOneDemo : IDemo 
    {
        public void Problem()
        {
            Console.WriteLine("Select NPlusOneDemo");
            using (var db = new NorthwindDb())
            {
                var orders = db.Orders.ToList();
                foreach (var order in orders)
                {
                    Console.WriteLine("{0} {1}", order.OrderID, order.Customers.CompanyName);
                }
            }
        }

        public void Solution()
        {
            Console.WriteLine("Select NPlusOneDemo - Solution");
            using (var db = new NorthwindDb())
            {
                var orders = db.Orders.Include(o=> o.Customers).ToList();
                foreach (var order in orders)
                {
                    Console.WriteLine("{0} {1}", order.OrderID, order.Customers.CompanyName);
                }
            }
        }
    }
}