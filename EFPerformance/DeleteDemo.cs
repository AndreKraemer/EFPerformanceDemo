// --------------------------------------------------------------------------------------
// <copyright file="DeleteDemo.cs" company="André Krämer - Software, Training & Consulting">
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
    public class DeleteDemo : IDemo
    {
        public void Problem()
        {
            Console.WriteLine("Delete Demo");
            using (var db = new NorthwindDb())
            {
                var maxShipperId = db.Shippers.Max(s => s.ShipperID);
                var shipper = db.Shippers.Find(maxShipperId);
                db.Shippers.Remove(shipper);
                db.SaveChanges();
            }

        }

        public void Solution()
        {
            Console.WriteLine("Delete Demo - Solution");
            using (var db = new NorthwindDb())
            {
                var maxShipperId = db.Shippers.Max(s => s.ShipperID);
                // db.Shippers.Find(maxShipperId);
                var shipper = new Shippers {ShipperID = maxShipperId};
                db.Shippers.Attach(shipper);
                db.Shippers.Remove(shipper);
                db.SaveChanges();
            }
        }
    }
}