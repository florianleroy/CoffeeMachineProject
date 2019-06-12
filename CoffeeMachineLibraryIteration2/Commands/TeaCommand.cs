using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineLibrary.Commands
{
    public class TeaCommand: DrinkCommand
    {
        public TeaCommand(int sugars = 0): base(sugars)
        {
            Price = 0.4;
        }
        
        public override string CommandString()
        {
            return String.Format("{0}:{1}:{2}",
                "T",
                Sugars > 0 ? Sugars.ToString() : "",
                HasStick ? "0" : ""
                );
        }
    }
}
