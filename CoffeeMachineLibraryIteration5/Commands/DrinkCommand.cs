using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineLibrary.Commands
{
    /// <summary>
    /// Abstract class DrinkCommand, this class cannot be instantiate.
    /// </summary>
    public abstract class DrinkCommand : ICommand
    {
        private readonly int _sugars;

        /// <summary>
        /// Number of sugar pieces.
        /// </summary>
        public int Sugars
        {
            get
            {
                return _sugars > 2 ? 2
                    : _sugars < 0 ? 0
                    : _sugars;
            }
        }

        /// <summary>
        /// Does the command handle a stick ?
        /// </summary>
        public bool HasStick
        {
            get
            {
                return Sugars > 0;
            }
        }

        /// <summary>
        /// Price of the command.
        /// </summary>
        public double Price { protected set; get; } = 0;

        /// <summary>
        /// Is extra hot drink ?
        /// </summary>
        public bool IsExtraHot { protected set; get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sugars"></param>
        public DrinkCommand(int sugars) => _sugars = sugars;

        /// <summary>
        /// Return command as a string in the protocol format like.
        /// </summary>
        /// <returns></returns>
        abstract public string CommandString();
    }
}
