using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyATM.Domain.Core.Entities
{
    /// <summary>
    /// Representa a tela do caixa eletrônico
    /// </summary>
    public class Screen
    {
        public void DisplayMessage(string message)
        {
            Console.Write(message);
        }


        public void DisplayMessageLine(string message)
        {
            Console.WriteLine(message);
        }


        public void DisplayDollarAmount(decimal amount)
        {
            Console.Write("{0:C}", amount);
        }
    }
}
