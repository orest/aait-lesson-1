using FamilyStats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyStats.Data;
using System.Diagnostics;
using FamilyStats.Extentions;

namespace FamilyStats
{
    class Program
    {
        static void Main(string[] args)
        {



            Action<int> printNumber = x => Console.WriteLine(x);

            printNumber(5);

            Func<int, int> sqaure = x => x * x;
            Func<int, bool> test = x => x == 4;

            var result = sqaure(5);

            var context = new DataContext();

            var myTest = new MyTester(context.Families);
            var fm = context.Families.OrderBy(p => p.AvgAge).ThenBy(p=>p.Father.Name);


            var myName = "Orest";
            Console.WriteLine(myName.SayHello());

            var zip = "12G45";
            Console.WriteLine(zip.IsValidZip());

            //List<Family> families = myTest.GetFamilyWithMostKids();

            List<Family> f = myTest.GetFamilyWithNoKids();
            Console.WriteLine("--- GetFamilyWithNoKids ---");
            PrintFamilies(f);

            f = myTest.GetFamilyWithMostKids();
            Console.WriteLine("--- GetFamilyWithMostKids ---");
            PrintFamilies(f);

            foreach (var family in context.Families)
            {
                Console.WriteLine($"{family.Father.Name} - {family.Father.Age}");
            }

            Console.ReadLine();
        }

        public static void PrintFamily(Family family)
        {
            Console.WriteLine(family);
        }

        public static void PrintFamilies(List<Family> families)
        {
            foreach (var family in families)
            {
                PrintFamily(family);
            }
        }

    }
}
