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
        public string Order(DrinkCommand command, double credits = 0)
        {
            if (command != null) {
                if (credits >= command.Price)
                {
                    return command.CommandString();
                }
                return new MessageCommand(
                    String.Format("Missing {0} credits.", command.Price - credits)
                ).CommandString();
            }
            return null;
        }

        public string Order(MessageCommand command)
        {
            return command?.CommandString();
        }
    }
}
