using System;
using System.Collections.Generic;

namespace Screensaver
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> textList = new List<string>();
            addToList(textList);
            double x = getNumbers(textList[0]);
            double y = getNumbers(textList[1]);
            string color = getcolor(textList[2]);
            double radius = getNumbers(textList[3]);
            

            Circle circle = new Circle(x, y, color, radius);
            double LengthSide = getNumbers(textList[4]);
            Square square = new Square(x, y, color, LengthSide);
            print(circle, square);
        }

        private static void print(Circle circle, Square square)
        {

            Console.WriteLine($"circle Area { circle.getSetArea }");
            Console.WriteLine($"circle Scope { circle.getScope }");
            Console.WriteLine($"square Area { square.getSetArea }");
            Console.WriteLine($"square Scope { square.getScope }");
            Console.WriteLine("square");
            square.Printsquare();

        }

        private static string getcolor(string text)
        {
            showText(text);
            return Console.ReadLine();
        }

        private static void addToList(List<string> textList)
        {
            textList.Add("x");
            textList.Add("y");
            textList.Add("color");
            textList.Add("radius");
            textList.Add("LengthSide");
        }

        private static void showText(string text)
        {
            Console.WriteLine($"please enter your {text}");
        }

        private static double getNumbers(string text)
        {
            showText(text);
                do
                {
                double number;
                    
                    Boolean result = cheakeIfNumber(out number);
                    if (result)
                    {
                        return number;
                    }

                } while (true);
        }

        private static bool cheakeIfNumber(out double number)
        {
            Boolean result = double.TryParse(Console.ReadLine(), out number);
            return result;
        }


    }
}
