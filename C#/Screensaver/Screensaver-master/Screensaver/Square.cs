using System;

namespace Screensaver
{
    internal class Square
    {
        private double x;
        private double y;
        private string color;
        private double lengthSide;

        public Square(double x, double y, string color, double lengthSide)
        {
            this.x = x;
            this.y = y;
            this.lengthSide = lengthSide;
            this.color = color;
            Console.WriteLine("the Square has been created");
            Console.WriteLine($"the X is {x}");
            Console.WriteLine($"the Y is {y}");
            Console.WriteLine($"the Color is {color}");
            Console.WriteLine($"the LengthSide is {lengthSide}");
        }
        

        public double getSetArea
        {
            get { return (lengthSide* lengthSide); }
        }
        public double getScope
        {
            get { return (lengthSide * 4); }
        }

        public void Printsquare()
        {

            for (int Y = 0; Y < y; Y++)
            {
                Console.WriteLine();
            }
            for (int i = 0; i < lengthSide; i++)
            {
                for (int X = 0; X < x; X++)
                {
                    Console.Write(" ");
                }
                for (int LengthSide = 0; LengthSide < lengthSide; LengthSide++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();

            }
         

        }

    }
}