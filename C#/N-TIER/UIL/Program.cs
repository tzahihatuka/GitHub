using BLL;
using System;

namespace UIL
{
    class Program
    {
        static void Main(string[] args)
        {
            BLL_Logic.print += (a => Console.WriteLine(a));
            BLL_Logic.Logic();
        }

    }

}
