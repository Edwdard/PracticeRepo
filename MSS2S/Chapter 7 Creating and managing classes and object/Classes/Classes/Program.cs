using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
     class Program
    {
        static void doWork()
        {
            var origin = new Point(0, 0);
            var bottomRight = new Point(4, 5);
            double distance = origin.DistanceTo(bottomRight);
            Console.WriteLine($"Distance is : {distance}");
            Console.WriteLine($"Number of Point Object: {Point.ObjectCount()}");

        }
        static void Main(string[] args)
        {
            try
            {
                doWork();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
