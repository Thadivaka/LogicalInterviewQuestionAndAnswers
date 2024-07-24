using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldmanSachsInterviewQuestions
{
    public interface I1
    {
        void foo();
    }

    public interface I2
    {
        void foo();
    }

    public abstract class AC
    {
        public abstract void foo();
    }

    public class C : AC, I1, I2
    {
        void I1.foo()
        {
            Console.WriteLine("I1.foo");
        }

        void I2.foo()
        {
            Console.WriteLine("I2.foo");
        }

        public override void foo()
        {
            Console.WriteLine("foo");
        }
    }
}
