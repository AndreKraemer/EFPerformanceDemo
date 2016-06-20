// --------------------------------------------------------------------------------------
// <copyright file="Program.c5" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2014 André Krämer http://andrekraemer.de
// </copyright>
// <summary>
//  Entity Framework Perfomance Demo.
//  This application demonstrates 10 typical performance issues. Just uncomment the demo 
//  that you want to try. You need the Northwind SQL Server DB in order to make it work.
// </summary>
// --------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFPerformance.Models;

namespace EFPerformance
{
    class Program
    {
        static void Main(string[] args)
        {

            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();

            var sw = new Stopwatch();
            Console.WriteLine("Starte Warmup");
            sw.Start();
            Warmup();
            sw.Stop();
            Console.WriteLine("Dauer: {0} ms", sw.ElapsedMilliseconds);

            IDemo demo;

             demo = new ProjectionDemo();
            // demo = new ChangeTrackingDemo();
            // demo = new ManyRowsDemo();

            // demo = new LateFilterDemo();
            // demo = new LateFilterDemo2();

            // demo = new ReloadingEntitiesDemo();
            // demo = new DeleteDemo();
            //demo = new ColumnTypeDemo();
            //demo = new ContainsDemo();
            //demo = new SelectNPlusOneDemo();

            Console.WriteLine("Start Demo ...");
            Console.ReadLine();
            sw.Restart();
            demo.Problem();
            sw.Stop();
            Console.WriteLine("Dauer: {0} ms", sw.ElapsedMilliseconds);
            Console.ReadLine();
            sw.Restart();
            demo.Solution();
            sw.Stop();
            Console.WriteLine("Dauer: {0} ms", sw.ElapsedMilliseconds);
            Console.ReadLine();
        }

        private static void Warmup()
        {
            using (var db = new NorthwindDb())
            {
                db.Customers.Where(c => c.CustomerID == "-1").ToList();
            }
        }
    }
}
