// --------------------------------------------------------------------------------------
// <copyright file="ManyRowsDemo.cs" company="André Krämer - Software, Training & Consulting">
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
    public class ManyRowsDemo : IDemo
    {
        public void Problem()
        {
            Console.WriteLine("Many Rows Demo");
            using (var db = new NorthwindDb())
            {
                var shippers = db.Shippers.ToList();

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("{0} - {1}", shippers[i].ShipperID, shippers[i].CompanyName);
                }
            }
        }

        public void Solution()
        {
            Console.WriteLine("Many Rows Demo - Solution");
            using (var db = new NorthwindDb())
            {
                var shippers = db.Shippers.Take(10).ToList();

                foreach (var shipper in shippers)
                {
                    Console.WriteLine("{0} - {1}", shipper.ShipperID, shipper.CompanyName);
                }
               
            }
        }
    }
}