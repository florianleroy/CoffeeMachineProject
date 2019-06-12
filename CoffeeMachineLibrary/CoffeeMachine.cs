using CoffeeMachineLibrary.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineLibrary
{
    public class CoffeeMachine: ICoffeeMachine
    {
        public string Order(ICommand command)
        {
            return command.CommandString();
        }
    }
}
