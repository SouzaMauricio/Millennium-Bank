using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Millennium_Bank_DTO;
using Millennium_Bank_DAL;

namespace Millennium_Bank_BLL
{
    public class BLL_Validar_Conta
    {
        public static string ValidarConta(DTO_Nova_Conta obj)
        {
            string msg = "";
            try
            {
                string[] aux = new string[2];
                aux = obj.Cod_Cliente.Split('-');
                obj.Cod_Cliente = aux[0].TrimEnd().TrimStart();
                obj.Cpf = aux[1].Trim();
            }
            catch
            {
                throw new Exception("Cliente Inválido");
            }

            if (string.IsNullOrWhiteSpace(obj.Banco) || string.IsNullOrWhiteSpace(obj.Cod_Agencia) || string.IsNullOrWhiteSpace(obj.Cod_Cliente)
                || string.IsNullOrWhiteSpace(obj.Tipo_Conta) || string.IsNullOrWhiteSpace(obj.Numero) || string.IsNullOrWhiteSpace(obj.Saldo_Inicial))
            {
                if (string.IsNullOrWhiteSpace(obj.Banco))
                {
                    msg = "\n\tBanco";
                }
                if (string.IsNullOrWhiteSpace(obj.Cod_Agencia))
                {
                    msg = msg + "\n\tAgencia";
                }
                if (string.IsNullOrWhiteSpace(obj.Cod_Cliente))
                {
                    msg = msg + "\n\tCliente";
                }
                if (string.IsNullOrWhiteSpace(obj.Tipo_Conta))
                {
                    msg = "\n\tTipo de Conta";
                }
                if (string.IsNullOrWhiteSpace(obj.Numero))
                {
                    msg = msg + "\n\tNumero";
                }
                if (string.IsNullOrWhiteSpace(obj.Saldo_Inicial))
                {
                    msg = msg + "\n\tSaldo Inicial";
                }

                throw new Exception("Os seguintes campos estão vazios: \n" + msg);
            }

            if (string.IsNullOrWhiteSpace(obj.Cpf))
            {
                throw new Exception("Falta o CPF na descrição do cliente!");
            }

            try
            {
                Convert.ToInt32(obj.Numero);
                Convert.ToDouble(obj.Saldo_Inicial);
                Convert.ToInt64(obj.Cpf);
            }
            catch
            {
                throw new Exception("Verifique as Informações!");
            }

            try
            {
                return DAL_Nova_Conta.Cadastrar(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DTO_Nova_Conta BuscarConta(string num)
        {
            DTO_Nova_Conta dados = new DTO_Nova_Conta();

            if (string.IsNullOrWhiteSpace(num))
            {
                throw new Exception("Campo 'Número' está vazio!");
            }
            try
            {
                Convert.ToInt32(num);
            }
            catch
            {
                throw new Exception("O Número da Conta deve ser um Número Inteiro!");
            }

            dados = DAL_Nova_Conta.BuscarConta(num);

            return dados;

        }

        public static DataTable BuscarTipo(string ban, string cliente)
        {
            string cpf;
            try
            {
                string[] aux = new string[2];
                aux = cliente.Split('-');
                cliente = aux[0].TrimEnd().TrimStart();
                cpf = aux[1].Trim();
            }
            catch
            {
                throw new Exception("Cliente Inválido");
            }
            DataTable tipos = new DataTable();
            tipos = DAL_Nova_Conta.BuscarTipo(ban, cliente, cpf);
            return tipos;
        }

        public static string Atualizar(DTO_Nova_Conta obj)
        {
            string msg = "";
            try
            {
                string[] aux = new string[2];
                aux = obj.Cod_Cliente.Split('-');
                obj.Cod_Cliente = aux[0].TrimEnd().TrimStart();
                obj.Cpf = aux[1].Trim();
            }
            catch
            {
                throw new Exception("Cliente Inválido");
            }

            if (string.IsNullOrWhiteSpace(obj.Banco) || string.IsNullOrWhiteSpace(obj.Cod_Agencia) || string.IsNullOrWhiteSpace(obj.Cod_Cliente)
                || string.IsNullOrWhiteSpace(obj.Tipo_Conta) || string.IsNullOrWhiteSpace(obj.Numero) || string.IsNullOrWhiteSpace(obj.Saldo_Inicial))
            {
                if (string.IsNullOrWhiteSpace(obj.Banco))
                {
                    msg = "\n\tBanco";
                }
                if (string.IsNullOrWhiteSpace(obj.Cod_Agencia))
                {
                    msg = msg + "\n\tAgencia";
                }
                if (string.IsNullOrWhiteSpace(obj.Cod_Cliente))
                {
                    msg = msg + "\n\tCliente";
                }
                if (string.IsNullOrWhiteSpace(obj.Tipo_Conta))
                {
                    msg = "\n\tTipo de Conta";
                }
                if (string.IsNullOrWhiteSpace(obj.Numero))
                {
                    msg = msg + "\n\tNumero";
                }
                if (string.IsNullOrWhiteSpace(obj.Saldo_Inicial))
                {
                    msg = msg + "\n\tSaldo Inicial";
                }

                throw new Exception("Os seguintes campos estão vazios: \n" + msg);
            }

            try
            {
                Convert.ToInt32(obj.Numero);
                Convert.ToDouble(obj.Saldo_Inicial);
            }
            catch
            {
                throw new Exception("O código deve ser um número inteiro");
            }

            try
            {
                return DAL_Nova_Conta.Alterar(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
