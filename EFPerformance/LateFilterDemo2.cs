// --------------------------------------------------------------------------------------
// <copyright file="LateFilterDemo2.cs" company="André Krämer - Software, Training & Consulting">
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
    public class LateFilterDemo2 : IDemo
    {
        public void Problem()
        {
            Console.WriteLine("Late Filter Demo 2");
            using (var db = new NorthwindDb())
            {
                var shippers = db.Shippers.ToList().Take(10);

                foreach (var shipper in shippers)
                {
                    Console.WriteLine("{0} - {1}", shipper.ShipperID, shipper.CompanyName);
                }
            }
        }

        public void Solution()
        {
            Console.WriteLine("Late Filter Demo 2 - Solution");
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