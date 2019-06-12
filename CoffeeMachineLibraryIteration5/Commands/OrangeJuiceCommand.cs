using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineLibrary.Commands
{
    public class OrangeJuiceCommand: DrinkCommand
    {
        public OrangeJuiceCommand(int sugars = 0) : base(sugars)
        {
            Price = 0.6;
        }

        public override string CommandString()
        {
            return String.Format("{0}:{1}:{2}",
                "O",
                Sugars > 0 ? Sugars.ToString() : "",
                HasStick ? "0" : ""
                );
        }

        /// <summary>
        /// Should Orange Juice avoid sugars and stick ?
        /// This way maybe OJ should derived from another type of drink ...
        /// </summary>
        /// <returns></returns>
        //public override string CommandString()
        //{
        //    return "O::";
        //}


    }
}
