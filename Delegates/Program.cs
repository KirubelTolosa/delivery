using System;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SomeClass someClass = new SomeClass(5);
            someClass.sender = receiver;
            Thread t = new Thread(new ThreadStart(someClass.ComplicatedProcess));

            string x = "";
            string y;
            calculator(2, 4, ref x, out y);
            Console.WriteLine(x + " " + y);

            //var a = new SomeClass(10);
            //var b = new SomeClass(20);
            //var c = a + b;
            //Console.WriteLine(c._value);


        }

        public static void receiver(int x)
        {
            Console.WriteLine(x);
        }

        public static void calculator(int x, int y, ref string add, out string sub)
        {
            add = (x + y).ToString() + " Added";
            sub = (x - y).ToString() + " Subtracted";
        }
    }
    public class SomeClass
    {
        public delegate void Sender(int x);
        public Sender sender;
        public int _value;
        public SomeClass(int x)
        {
            _value = x;
        }
        public void ComplicatedProcess()
        {
            for(int i = 0; i < 1000; i++)
            {
                Thread.Sleep(1000);
                sender(i);
            }
        }
        public static SomeClass operator +(SomeClass s1, SomeClass s2)
        {
            return new SomeClass(s1._value + s2._value);
        }
    }
}
