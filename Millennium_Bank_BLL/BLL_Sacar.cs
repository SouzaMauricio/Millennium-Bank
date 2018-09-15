using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Millennium_Bank_DTO;
using Millennium_Bank_DAL;
using System.Windows.Forms;

namespace Millennium_Bank_BLL
{
    public class BLL_Sacar
    {
        public static DTO_Saque ValidarSaque(DTO_Saque obj, string conta)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(obj.Valor_Saque)))
            {
                throw new Exception("Digite o Valor de saque!");
            }
            
            try
            {
                Convert.ToDouble(obj.Valor_Saque);
            }
            catch
            {
                throw new Exception("Valor de saque inválido!");
            }

            if (obj.Limite == 0)
            {
                throw new Exception("Saldo insuficiente para saque!");
            }

            //double aux = Convert.ToDouble(obj.Valor_Saque);

            if (obj.Valor_Saque > obj.Limite)
            {
                throw new Exception("Digite um valor dentro do limite de saque!");
            }

            obj.Saldo = obj.Saldo - obj.Valor_Saque;

            //MessageBox.Show(obj.Saldo.ToString());

            /*string aux1 = obj.Saldo.ToString().Replace(",", ".");
            decimal aux2 = Convert.ToDecimal(obj.Saldo);
            //obj.Saldo = Convert.ToDecimal(aux1);
            obj.Saldo = Convert.ToDouble(aux2);
            MessageBox.Show(obj.Saldo.ToString());*/

            try
            {
                return DAL_Sacar.Sacar(obj, conta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DTO_Operacoes Dados(string conta)
        {
            DTO_Operacoes dados = new DTO_Operacoes();
            return dados = DAL_Sacar.Dados(conta);
        }
    }
}
