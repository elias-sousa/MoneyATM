using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyATM.Domain.Core.Entities
{
    /// <summary>
    /// Representa o slot de depósito do caixa eletrônico
    /// </summary>
    public class DepositSlot
    {
        // indica se o envelope foi recebido (sempre retorna true,
        // porque esta é apenas uma simulação de software de um slot de depósito real)
        public bool IsDepositEnvelopeReceived()
        {
            return true;
        } 
    }
}
