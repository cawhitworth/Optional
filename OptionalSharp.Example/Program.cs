using System;
using OptionSharp;

namespace OptionalSharp.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Optional.Of(10);
            var b = Optional.AbsentOf<int>();
            a.Map(i => i + 1).Map(ToDec).Map(DollarsToPounds).MapThrough(PrintAsCurrency);
            b.Map(i => i + 1).Map(ToDec).Map(DollarsToPounds).MapThrough(PrintAsCurrency);
        }

        static decimal ToDec(int i)
        {
            return i;
        }

        const decimal ExchangeRate = 0.64m;
        static decimal DollarsToPounds(decimal arg)
        {
            return arg * ExchangeRate;
        }

        static void PrintAsCurrency(decimal arg)
        {
            Console.WriteLine(arg.ToString("C"));
        }

    }
}
