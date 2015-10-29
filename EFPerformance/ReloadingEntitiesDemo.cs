// --------------------------------------------------------------------------------------
// <copyright file="ReloadingEntitiesDemo.cs" company="André Krämer - Software, Training & Consulting">
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
    public class ReloadingEntitiesDemo : IDemo  
    {
        public void Problem()
        {
            Console.WriteLine("Reloading Entities Demo");
            using (var db = new NorthwindDb())
            {

                var s1 = db.Shippers.SingleOrDefault(c => c.ShipperID == 1);
                Console.WriteLine("S1: {0} - {1}", s1.ShipperID, s1.CompanyName);

                var s2 = db.Shippers.SingleOrDefault(c => c.ShipperID == 1);
                Console.WriteLine("S2: {0} - {1}", s2.ShipperID, s2.CompanyName);
            }
        }

        public void Solution()
        {
            Console.WriteLine("Reloading Entities Demo - Solution");
            using (var db = new NorthwindDb())
            {
                var s1 = db.Shippers.Find(1);
                Console.WriteLine("S1: {0} - {1}", s1.ShipperID, s1.CompanyName);

                var s2 = db.Shippers.Find(1);
                Console.WriteLine("S2: {0} - {1}", s2.ShipperID, s2.CompanyName);
            }
        }
    }
}