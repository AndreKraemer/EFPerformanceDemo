// --------------------------------------------------------------------------------------
// <copyright file="ColumnTypeDemo.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 André Krämer http://andrekraemer.de
// </copyright>
// <summary>
//  Entity Framework Perfomance Demo.
// </summary>
// --------------------------------------------------------------------------------------
using System;
using System.Linq;
using EFPerformance.Models;

namespace EFPerformance
{
    public class ColumnTypeDemo : IDemo
    {
        /// <summary>
        /// In Order to make this Demo work, you have to comment the IsUnicode Configuration 
        /// for the PreferedCommunication Column in the DB Context On Model Creating Method.
        /// This will cause code first to assume a wrong column type which will miss some index
        /// uses
        /// </summary>
        public void Problem()
        {
            Console.WriteLine("Column Type Demo");
            using (var db = new NorthwindDb())
            {
                var faxCustomers = db.Customers.Where(c => c.PreferedCommunication == "Fax").ToList();
                Console.WriteLine("{0} Customers", faxCustomers.Count);

            }
        }

        public void Solution()
        {
            Console.WriteLine("Change EF Model");
        }
    }
}