// --------------------------------------------------------------------------------------
// <copyright file="ProjectionDemo.cs" company="André Krämer - Software, Training & Consulting">
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
    public class ProjectionDemo : IDemo
    {
        public void Problem()
        {
            Console.WriteLine("ProjectionDemo");
            using (var db = new NorthwindDb())
            {
                var products = db.Products;

                foreach (var product in products)
                {
                    Console.WriteLine("{0}", product.ProductName);
                }
            }
        }

        public void Solution()
        {
            Console.WriteLine("ProjectionDemo - Solution");
            using (var db = new NorthwindDb())
            {
                var products = db.Products.Select(p => new {p.ProductName});

                foreach (var product in products)
                {
                    Console.WriteLine("{0}", product.ProductName);
                }

            }
        }
    }
}