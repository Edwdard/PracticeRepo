using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsArray
{


    internal class Program
    {

        static void doWork()
        {
            Console.WriteLine(Utils.Sum(10,9,8));

        }

        static void Main(string[] args)
        {
            try
            {
                doWork();   
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);

            }
        }
    }
}
