using CoffeeMachineLibrary.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachineLibrary.Services;

namespace CoffeeMachineLibrary
{
    public class CoffeeMachine: ICoffeeMachine
    {
        public Report Report;

        /// <summary>
        /// Services
        /// </summary>
        private readonly IEmailNotifier _emailNotifier;
        private readonly IBeverageQuantityChecker _beverageQuantityChecker;

        public CoffeeMachine(IEmailNotifier emailNotifier = null, IBeverageQuantityChecker beverageQuantityChecker = null)
        {
            Report = new Report();
            _emailNotifier = emailNotifier;
            _beverageQuantityChecker = beverageQuantityChecker;
        }

        public string Order(DrinkCommand command, double credits = 0)
        {
            if (command != null) {
                if (_beverageQuantityChecker != null && _emailNotifier != null
                    && _beverageQuantityChecker.IsEmpty(command.GetType().ToString()))
                {
                    _emailNotifier.NotifyMissingDrink(command.GetType().ToString());
                    return new MessageCommand(
                        String.Format("The drink is missing, a notification has been sent.")
                    ).CommandString();
                }
                else if (credits >= command.Price)
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
                ++Report.CoffeeSold;
            else if ((command as ChocolateCommand) != null)
                ++Report.ChocolateSold;
            else if ((command as TeaCommand) != null)
                ++Report.TeaSold;
            else
                ++Report.OrangeJuiceSold;
        }

        private void IncreaseCreditCounter(double credits)
        {
            Report.Credits += credits;
        }

        public void PrintReport()
        {
            Report.Print();
        }
    }
}
