﻿using System;
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
            Price = 0.5;
        }
        
        public override string CommandString()
        {
            return String.Format("{0}{1}:{2}:{3}",
                "H",
                IsExtraHot ? "h" : string.Empty,
                Sugars > 0 ? Sugars.ToString() : string.Empty,
                HasStick ? "0" : string.Empty
                );
        }
    }
}
