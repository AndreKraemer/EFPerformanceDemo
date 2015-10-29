// --------------------------------------------------------------------------------------
// <copyright file="ChangeTrackingDemo.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2014 André Krämer http://andrekraemer.de
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
    public class ChangeTrackingDemo : IDemo
    {
        public void Problem()
        {
            Console.WriteLine("ChangeTrackingDemo");
            using (var db = new NorthwindDb())
            {
                var shippers = db.Shippers.ToList();
                for (int i = 0; i < 200 && i < shippers.Count; i++)
                {
                    var shipper = shippers[i];
                    Console.WriteLine("{0} - {1}", shipper.ShipperID, shipper.CompanyName);

                }
            }
        }

        public void Solution()
        {
            Console.WriteLine("ChangeTrackingDemo - Solution");
            using (var db = new NorthwindDb())
            {
                var shippers = db.Shippers.AsNoTracking().ToList();
                for (int i = 0; i < 200 && i < shippers.Count; i++)
                {
                    var shipper = shippers[i];
                    Console.WriteLine("{0} - {1}", shipper.ShipperID, shipper.CompanyName);
                }
            }
        }
    }
}