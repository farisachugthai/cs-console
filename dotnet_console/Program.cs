// Believe it or not this is the original Program.cs you get when you
// run dotnet new console on the cmdline....
// Only difference is that this is what happens when you mindlessly hit
// <C-.> to run all quickfixes over and over....
using System;

namespace dotnet_console
{
    internal class Program : IProgram
    {
        public Program()
        {
        }

        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Console.WriteLine("Hello World!");
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
