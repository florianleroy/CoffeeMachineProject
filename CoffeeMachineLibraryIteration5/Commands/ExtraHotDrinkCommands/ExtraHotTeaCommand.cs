using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineLibrary.Commands
{
    public class ExtraHotTeaCommand: TeaCommand
    {
        public ExtraHotTeaCommand(int sugars = 0) : base(sugars)
        {
            IsExtraHot = true;
        }
    }
}
