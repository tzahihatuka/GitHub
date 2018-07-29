using System;

namespace Screensaver
{
    internal class Circle
    {
        private double x;
        private double y;
        private string color;
        private double radius;

        public Circle(double x, double y, string color, double radius)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.radius = radius;
            Console.WriteLine("the Circle has been created");
            Console.WriteLine($"the X is {x}");
            Console.WriteLine($"the Y is {y}");
            Console.WriteLine($"the Color is {color}");
            Console.WriteLine($"the radius is {radius}");
        }


        public double getSetArea
        {
            get { return (Math.PI * (radius * radius)); }
        }
        public double getScope
        {
            get { return (2 * Math.PI * radius); }
        }
    }
}