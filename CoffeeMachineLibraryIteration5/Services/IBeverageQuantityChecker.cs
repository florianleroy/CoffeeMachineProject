using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineLibrary.Services
{
    public interface IBeverageQuantityChecker
    {
        bool IsEmpty(string drink);
    }
}
