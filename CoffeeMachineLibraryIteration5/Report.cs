using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineLibrary
{
    public class Report
    {
        public int CoffeeSold;
        public int ChocolateSold;
        public int TeaSold;
        public int OrangeJuiceSold;
        public double Credits;
        public string Resume
        {
            get
            {
                return @""
                   + "Number of coffee sold : " + CoffeeSold + ".\n"
                   + "Number of chocolate sold : " + ChocolateSold + ".\n"
                   + "Number of tea sold : " + TeaSold + ".\n"
                   + "Number of orange juice sold : " + OrangeJuiceSold + ".\n"
                   + "Total credits : " + Credits;
            }
        }

        public void Print()
        {
            Console.WriteLine(Resume);
        }
    }
}
