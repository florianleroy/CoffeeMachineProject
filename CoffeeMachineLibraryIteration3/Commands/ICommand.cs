using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineLibrary.Commands
{
    public interface ICommand
    {
        /// <summary>
        /// Return command as a string in the protocol format like.
        /// </summary>
        /// <returns></returns>
        string CommandString();
    }
}
