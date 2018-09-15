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
    public class BLL_Validar_Agencia
    {
        public static string ValidarAgencia(DTO_Nova_Agencia obj)
        {
            string msg = "";

            if (string.IsNullOrWhiteSpace(obj.Cod_Banco) || string.IsNullOrWhiteSpace(obj.Numero_Agencia) || string.IsNullOrWhiteSpace(obj.Bairro))
            {
                if (string.IsNullOrWhiteSpace(obj.Cod_Banco))
                {
                    msg = "\n\tCódigo Banco";
                }
                if (string.IsNullOrWhiteSpace(obj.Numero_Agencia))
                {
                    msg = msg + "\n\tNumero";
                }
                if (string.IsNullOrWhiteSpace(obj.Bairro))
                {
                    msg = msg + "\n\tBairro";
                }

                throw new Exception("Os seguintes campos estão vazios: \n" + msg);
            }    

            try
            {
                Convert.ToInt32(obj.Numero_Agencia);
            }
            catch
            {
                throw new Exception("O número da agência deve ser um número inteiro");
            }

            try
            {
                return DAL_Nova_Agencia.Cadastrar(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*
        public static string Selecionar_Agen(string age, DataTable agencias)
        {

            string busca = string.Format("NUMERO = '{0}'", age);
            DataRow[] result = agencias.Select(busca);
            age = result.ToString();
            foreach (DataRow row in result)
            {
                age = Convert.ToString(row["COD"]);
            }

            return age;

        }*/

        /*public static DataTable Agencias(string ban)
        {
            DataTable age = new DataTable();
            age = DAL_Nova_Agencia.Agencias(ban);
            return age;
        }*/

        public static DTO_Nova_Agencia BuscarAgencia(string num)
        {
            DTO_Nova_Agencia dados = new DTO_Nova_Agencia();

            if (string.IsNullOrWhiteSpace(num))
            {
                throw new Exception("O Campo 'Número' está vazio!");
            }
            try
            {
                Convert.ToInt64(num);
            }
            catch
            {
                throw new Exception("O Campo 'Número da Agência' deve ser um número inteiro!");
            }
            dados = DAL_Nova_Agencia.BuscarAgencia(num);

            return dados;
        }

        public static string Atualizar(DTO_Nova_Agencia obj)
        {
            string msg = "";

            if (string.IsNullOrWhiteSpace(obj.Cod_Banco) || string.IsNullOrWhiteSpace(obj.Numero_Agencia) || string.IsNullOrWhiteSpace(obj.Bairro))
            {
                if (string.IsNullOrWhiteSpace(obj.Cod_Banco))
                {
                    msg = "\n\tCódigo Banco";
                }
                if (string.IsNullOrWhiteSpace(obj.Numero_Agencia))
                {
                    msg = msg + "\n\tNumero";
                }
                if (string.IsNullOrWhiteSpace(obj.Bairro))
                {
                    msg = msg + "\n\tBairro";
                }

                throw new Exception("Os seguintes campos estão vazios: \n" + msg);
            }

            try
            {
                Convert.ToInt32(obj.Numero_Agencia);
            }
            catch
            {
                throw new Exception("O Campo 'Número da Agência' deve ser um número inteiro!");
            }

            try
            {
                return DAL_Nova_Agencia.Alterar(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static AutoCompleteStringCollection Agencias(string banco)
        {
            AutoCompleteStringCollection con = new AutoCompleteStringCollection();

            if (string.IsNullOrWhiteSpace(banco))
            {
                throw new Exception("Campo 'Banco' vazio!");
            }

            banco = banco.Trim();

            con = DAL_Nova_Agencia.Agencias(banco);

            return con;
        }
    }
}
