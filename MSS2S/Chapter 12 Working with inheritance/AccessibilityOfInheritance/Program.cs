using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Example example = new Example();

            //可以访问公共字段
            example.publicField = 5;
            Console.WriteLine("Accessing public field " + example.publicField);

            //无法访问私有字段
            //example.privateField = 10;
            //Console.WriteLine("Accessing private field");

            //无法访问受保护字段
            //example.protectedField = 15;
            //Console.WriteLine("Accessing protected field" + example.protectedField);

            //可以访问内部字段
            example.internalField = 20;
            Console.WriteLine("Accessing internal field " + example.internalField);

            //可以访问受保护的内部字段
            example.protectedInternalField = 25;
            Console.WriteLine("Accessing protected internal field " + example.protectedInternalField);

            //无法访问受保护的私有字段
            //example.privateProtectedField = 30;
            //Console.WriteLine("Accessing private protected field " + example.privateProtectedField);

            example.PublicMethod();     //可以调用公共方法

           // example.PrivateMethod();    //无法调用私有方法

            example.InternalMethod();   //可以调用内部方法

            example.ProtectedInternalMethod();  //可以调用受保护的内部方法

            //example.privateProtectedMethod(); //无法调用私有受保护方法


            Derived deriveExample = new Derived();

            deriveExample.publicField = 40;

            //deriveExample.privateField = 35;

            //deriveExample.protectedField = 40;

            deriveExample.protectedInternalField = 40;      

            //deriveExample.privateProtectedField = 45;


            deriveExample.printProtectedField(50);

            Console.ReadLine();


        }
    }

    
}
