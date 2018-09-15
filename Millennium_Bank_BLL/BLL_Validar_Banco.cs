using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Millennium_Bank_DAL;
using Millennium_Bank_DTO;
using System.Data;
using System.Windows.Forms;

namespace Millennium_Bank_BLL
{
    public class BLL_Validar_Banco
    {
        
        public static string ValidarBanco(DTO_Novo_Banco obj)
        {
            string msg = "";

            if (string.IsNullOrWhiteSpace(obj.Codigo) || string.IsNullOrWhiteSpace(obj.Nome) || string.IsNullOrWhiteSpace(obj.CNPJ))
            {
                if (string.IsNullOrWhiteSpace(obj.Codigo))
                {
                    msg = "\n\tCódigo";
                }
                if (string.IsNullOrWhiteSpace(obj.Nome))
                {
                    msg = msg + "\n\tNome";
                }
                if (string.IsNullOrWhiteSpace(obj.CNPJ))
                {
                    msg = msg +"\n\tCNPJ";
                }

                throw new Exception("Os seguintes campos estão vazios: \n" + msg);
            }

            try
            {
                Convert.ToInt32(obj.Codigo);
            }
            catch
            {
                throw new Exception("O código deve ser um número inteiro");
            }
            try
            {
                Convert.ToInt64(obj.CNPJ);

                if (obj.CNPJ.Length != 14)
                {
                    throw new Exception("CNPJ inválido! \nO CNPJ deve conter 14 números!");
                }
            }
            catch
            {
                throw new Exception("CNPJ inválido! \nO CNPJ deve conter 14 números!");
            }
            try
            {
                return DAL_Novo_Banco.Cadastrar(obj);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*
        public static string Selecionar_Ban(string age, DataTable agencias)
        {

            string busca = string.Format("COD_BANCO = '{0}'", age);
            DataRow[] result = agencias.Select(busca);
            age = result.ToString();
            foreach (DataRow row in result)
            {
                age = Convert.ToString(row["COD"]);
            }

            return age;

        }

        public static DataTable Bancos()
        {
            DataTable ban = new DataTable();
            ban = DAL_Novo_Banco.Bancos(ban);
            return ban;
        }*/

        public static DTO_Novo_Banco BuscarBanco(string cod)
        {
            DTO_Novo_Banco dados = new DTO_Novo_Banco();

            if (string.IsNullOrWhiteSpace(cod))
            {
                throw new Exception("O Campo 'Código' está vazio!");
            }

            dados = DAL_Novo_Banco.BuscarBanco(cod);

            return dados;
        }

        public static string Atualizar(DTO_Novo_Banco dados)
        {
            string msg = "";

            if (string.IsNullOrWhiteSpace(dados.Codigo) || string.IsNullOrWhiteSpace(dados.Nome) || string.IsNullOrWhiteSpace(dados.CNPJ))
            {
                if (string.IsNullOrWhiteSpace(dados.Codigo))
                {
                    msg = "\n\tCódigo";
                }
                if (string.IsNullOrWhiteSpace(dados.Nome))
                {
                    msg = msg + "\n\tNome";
                }
                if (string.IsNullOrWhiteSpace(dados.CNPJ))
                {
                    msg = msg + "\n\tCNPJ";
                }

                throw new Exception("Os seguintes campos estão vazios: \n" + msg);
            }

            dados.CNPJ = dados.CNPJ.Replace(".", "");
            dados.CNPJ = dados.CNPJ.Replace("/", "");
            dados.CNPJ = dados.CNPJ.Replace(" ", "");

            try
            {
                Convert.ToInt32(dados.Codigo);
            }
            catch
            {
                throw new Exception("O código deve ser um número inteiro");
            }
            try
            {
                Convert.ToInt64(dados.CNPJ);

                if (dados.CNPJ.Length != 14)
                {
                    throw new Exception("CNPJ inválido! \nO CNPJ deve conter 14 números!");
                }
            }
            catch
            {
                throw new Exception("CNPJ inválido! \nO CNPJ deve conter 14 números!");
            }

            return DAL_Novo_Banco.Alterar(dados);
        }

        public static AutoCompleteStringCollection Bancos()
        {
            AutoCompleteStringCollection con = new AutoCompleteStringCollection();

            con = DAL_Novo_Banco.Bancos();

            return con;
        }
    }
}