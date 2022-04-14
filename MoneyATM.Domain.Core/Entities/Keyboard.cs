using MoneyATM.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyATM.Domain.Core.Entities
{
    /// <summary>
    /// Representa o teclado do caixa eletrônico.
    /// </summary>
    public class Keyboard : IKeyboard
    {
        public int GetInput()
        {
            return Convert.ToInt32(Console.ReadLine());
        } 
    }
}
