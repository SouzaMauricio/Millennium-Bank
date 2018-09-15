using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Millennium_Bank_DTO;
using Millennium_Bank_DAL;

namespace Millennium_Bank_BLL
{
    public class BLL_Depositar
    {
        public static DTO_Deposito Validar_Deposito(DTO_Deposito dados, string conta)
        {
            if (string.IsNullOrWhiteSpace(dados.Valor_Deposito))
            {
                throw new Exception("Digite o Valor de Despósito!");
            }

            try
            {
                Convert.ToDouble(dados.Valor_Deposito);
            }
            catch
            {
                throw new Exception("Valor de depósito inválido!");
            }

            dados.Saldo = dados.Saldo + Convert.ToDouble(dados.Valor_Deposito);

            return DAL_Depositar.Depositar(dados, conta);            
        }
    }
}
