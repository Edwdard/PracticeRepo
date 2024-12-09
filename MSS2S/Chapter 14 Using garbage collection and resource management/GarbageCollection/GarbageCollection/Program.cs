using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollection
{
    internal class Program
    { 
    
        static void doWork()
        {
            using (Calculator calculator = new Calculator())
            {
                Console.WriteLine($"120 / 15 = {calculator.Divide(120, 0)}");
            }
            Console.WriteLine("Program finishing");

            //var calculator = new Calculator();
            //Console.WriteLine($"120 /15 ={calculator.Divide(120, 15)}");
            //calculator = null;
            //Console.WriteLine("Program finishing"); 

        }
        static void Main(string[] args)
        {
            try
            {
                doWork();
            }
            catch (InvalidOperationException ex)
            //catch (Exception ex)
            {
                 Console.WriteLine(ex.Message);
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }
    }
}
