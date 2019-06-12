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
        private int _coffeeSold = 0;
        private int _chocolateSold = 0;
        private int _teaSold = 0;
        private int _ojSold = 0;
        private double _creditCounter = 0;

        public string Order(DrinkCommand command, double credits = 0)
        {
            if (command != null) {
                if (credits >= command.Price)
                {
                    IncreaseCounter(command);
                    IncreaseCreditCounter(command.Price);
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
        
        private void IncreaseCounter(DrinkCommand command)
        {
            if ((command as CoffeeCommand) != null)
                ++_coffeeSold;
            else if ((command as ChocolateCommand) != null)
                ++_chocolateSold;
            else if ((command as TeaCommand) != null)
                ++_teaSold;
            else
                ++_ojSold;
        }

        private void IncreaseCreditCounter(double credits)
        {
            _creditCounter += credits;
        }

        public string Report()
        {
            return @""
                + "Number of coffee sold : " + _coffeeSold + ".\n"
                + "Number of chocolate sold : " + _chocolateSold + ".\n"
                + "Number of tea sold : " + _teaSold + ".\n"
                + "Number of orange juice sold : " + _ojSold + ".\n"
                + "For a total of " + _creditCounter + " credits.";
        }
    }
}
