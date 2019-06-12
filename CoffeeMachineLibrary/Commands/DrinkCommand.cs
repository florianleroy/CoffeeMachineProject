using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineLibrary.Commands
{
    public abstract class DrinkCommand : ICommand
    {
        private int _sugars;
        public int Sugars
        {
            get
            {
                return _sugars > 2 ? 2
                    : _sugars < 0 ? 0
                    : _sugars;
            }
        }
        public bool HasStick
        {
            get
            {
                return Sugars > 0;
            }
        }

        public DrinkCommand(int sugars) => _sugars = sugars;

        abstract public string CommandString();
    }
}
