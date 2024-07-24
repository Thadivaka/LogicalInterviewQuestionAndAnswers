using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldmanSachsInterviewQuestions
{
    public static class Sainsburys
    {
        public static string Foo<T>(T x)
        {
            return "generic Foo";
        }

        public static string Foo(int x)
        {
            return "int Foo";
        }

        public static string Bar<T>(T x)
        {
            return "generic Foo";
        }

        public static string Bar<T>(int x)
        {
            return "int Bar";
        }

        //public static void Main()
        //{
        //    Console.WriteLine("{0} {1}", Foo(10), Bar(10));
        //}
    }
}
