using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachineLibrary;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var machine = new CoffeeMachineLibrary.CoffeeMachine();

            var message = new CoffeeMachineLibrary.Commands.MessageCommand(
                "Coffee Machine is up to start.");
            var coffee = new CoffeeMachineLibrary.Commands.CoffeeCommand(3);
            var tea = new CoffeeMachineLibrary.Commands.TeaCommand();

            CoffeeMachineLibrary.Commands.MessageCommand nullCommand = null;

            Console.WriteLine(machine.Order(message));
            Console.WriteLine(machine.Order(coffee));
            Console.WriteLine(machine.Order(tea));
            Console.WriteLine(machine.Order(nullCommand));

            var coffeeExtraHotCredited = new CoffeeMachineLibrary.Commands.ExtraHotCoffeeCommand(1);
            Console.WriteLine(machine.Order(coffeeExtraHotCredited, 1));

            Console.WriteLine(machine.Order(tea, 1));
            Console.WriteLine(machine.Order(tea, 1));
            Console.WriteLine(machine.Order(tea, 1));

            var oj = new CoffeeMachineLibrary.Commands.OrangeJuiceCommand();
            Console.WriteLine(machine.Order(oj, 1));
            
            machine.PrintReport();

            Console.WriteLine(oj.GetType().ToString());

            Console.ReadLine();
        }
    }
}
