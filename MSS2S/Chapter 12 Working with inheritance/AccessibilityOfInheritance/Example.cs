using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Example     //Example的访问级别要比Derived的访问级别更宽松， 如Example是public， Derived是internal，否则报错：Inconsistent accessibility: base class 'Example' is less accessible than class 'Derived' 
    {
        public int publicField;
        private int privateField;
        protected int protectedField;
        internal int internalField;
        protected internal int protectedInternalField;
        private protected int privateProtectedField;

        public void PublicMethod()
        {
            Console.WriteLine("This is a public method.");
        }

        private void PrivateMethod()
        {
            Console.WriteLine("This is a private method.");
        }

        protected void ProtectedMethod()
        {
            Console.WriteLine("This is a protected method.");
        }

        internal void InternalMethod()
        {
            Console.WriteLine("This is a internal method.");
        }

        protected internal void ProtectedInternalMethod()
        {
            Console.WriteLine("This is a protected internal method.");
        }

        private protected  void privateProtectedMethod()
        {
            Console.WriteLine("This is a private protected method.");
        }
    }



      internal class Derived : Example
    {
        public void AccessProtectedField()
        {
            protectedField = 10;    //可以访问基类的受保护的字段
            Console.WriteLine("Accessing protected field from derived class");
            ProtectedMethod();  //可以访问基类的受保护的方法

            //privateField = 20; 无法访问基类的private字段
            //PrivateMethod(); 无法访问基类的private方法







        }

        public void printProtectedField(int protectedFieldParam)
        {
            protectedField = protectedFieldParam;
            Console.WriteLine("Print protected field from derived class " + protectedField);
        }
    }


}

