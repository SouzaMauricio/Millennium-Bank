using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Millennium_Bank_DTO;
using Millennium_Bank_DAL;
using System.Windows.Forms;

namespace Millennium_Bank_BLL
{
    public class BLL_Validar_Operacoes
    {
        public static DTO_Operacoes Dados_Conta(string cli, string ban, string tipo)
        {
            string cpf;
            try
            {
                string[] aux = new string[2];
                aux = cli.Split('-');
                cli = aux[0].TrimEnd().TrimStart();
                cpf = aux[1].Trim();            
            }
            catch
            {
                throw new Exception("Cliente Inválido");
            }

            DTO_Operacoes dados = new DTO_Operacoes();

            dados = DAL_Operacoes.Dados(cli, ban, tipo, cpf);

            return dados;
        }

        public static AutoCompleteStringCollection Clientes()
        {
            AutoCompleteStringCollection con = new AutoCompleteStringCollection();

            con = DAL_Operacoes.Clientes();

            return con;
        }

        public static AutoCompleteStringCollection Bancos(string cli)
        {
            string cpf;
            try
            {
                string[] aux = new string[2];
                aux = cli.Split('-');
                cli = aux[0].TrimEnd().TrimStart();
                cpf = aux[1].Trim();
            }
            catch
            {
                throw new Exception("Cliente Inválido");
            }

            AutoCompleteStringCollection con = new AutoCompleteStringCollection();

            return con = DAL_Operacoes.Bancos(cli, cpf);
        }
    }
}
