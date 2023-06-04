using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CodePryfer.StartDecode();
            //CodePryfer.StartCode();
            MethodMonteCarlo.FindNumberPi();
            MethodMonteCarlo.FindSquare();
            Console.ReadLine();
        }
    }
}
