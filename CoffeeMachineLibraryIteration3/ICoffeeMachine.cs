using CoffeeMachineLibrary.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineLibrary
{
    interface ICoffeeMachine
    {
        string Order(DrinkCommand command, double credits = 0);
        string Order(MessageCommand command);
        string Report();
    }
}
