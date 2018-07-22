using System;

namespace calcHomeWork
{
     class calc
    {
        static calc()
        {
            Console.WriteLine($"this is the first time you useing this class {DateTime.Now}");
        }



        public static int GetSub(int num1,int num2)
        {
            return num1 + num2;
        }
        public static int GetSub(int num1, int num2, int num3)
        {
            return num1 + num2+ num3;
        }
       public static double GetSub(double num1, double num2)
        {
            return num1 + num2;
        }
    }
}