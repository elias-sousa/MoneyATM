using MoneyATM.Domain.Core.Entities;
using System;

namespace MoneyATM.Aplicacao.Console
{
   public class Program
    {
       public static void Main(string[] args)
        {
            Atm theATM = new Atm();
            theATM.Run();
        }
    }
}
