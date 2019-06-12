using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineLibrary.Commands
{
    public class ChocolateCommand: DrinkCommand
    {
        public ChocolateCommand(int sugars = 0): base(sugars)
        {
        }
        
        public override string CommandString()
        {
            return String.Format("{0}:{1}:{2}",
                "H",
                Sugars > 0 ? Sugars.ToString() : "",
                HasStick ? "0" : ""
                );
        }
    }
}
