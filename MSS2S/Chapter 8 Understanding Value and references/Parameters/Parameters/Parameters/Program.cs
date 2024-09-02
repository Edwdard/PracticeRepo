﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters
{
  
    internal class Program
    {
        static void doWork()
        {
            //TODO: test value and reference types
            int i = 0;
            Console.WriteLine(i);
            Pass.Value(ref i);  
            Console.WriteLine(i);

            var wi = new WrappedInt();
            Console.WriteLine(wi.Number);
            Pass.Reference(wi);
            Console.WriteLine(wi.Number);


        }
       

        static void Main(string[] args)
        {
            try
            {
                doWork();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);  
            }

        }
    }
}
