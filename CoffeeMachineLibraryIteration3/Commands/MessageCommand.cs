using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineLibrary.Commands
{
    public class MessageCommand : ICommand
    {
        public string Message { get; }

        public MessageCommand(string message) => Message = message;
        
        public string CommandString()
        {
            return String.Format("M:{0}", Message);
        }
    }
}
