using System;
using System.Data.Common;

namespace MyApplication
{
    class Program
    {
        static void MyMethod(int age, int phone, bool operato)
        {
            Console.WriteLine("your age is " + age + "and phone number is" + phone + " " + operato );
        }

        static void Main(string[] args)
        {
            MyMethod(int age, int phone, bool operato);
        }
    }
}