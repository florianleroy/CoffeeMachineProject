using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineLibrary.Commands
{
    public class ExtraHotChocolateCommand: ChocolateCommand
    {
        public ExtraHotChocolateCommand(int sugars = 0) : base(sugars)
        {
            IsExtraHot = true;
        }
    }
}
