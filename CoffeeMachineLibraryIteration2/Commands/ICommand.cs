using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineLibrary.Commands
{
    public interface ICommand
    {
        string CommandString();
    }
}
