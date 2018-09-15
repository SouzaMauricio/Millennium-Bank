using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Millennium_Bank_DTO;
using System.Data;
using MySql.Data.MySqlClient;

namespace Millennium_Bank_DAL
{
    public class DAL_Sacar
    {
        public static DTO_Saque Sacar(DTO_Saque obj, string numero)
        {
            try
            {
                
                // script = "UPDATE CONTA SET SALDO = SALDO - CAST ((SELECT REPLACE ('" + obj.Valor_Saque + "', ',', '.')) AS DECIMAL(8,2)) WHERE NUMERO = " + numero;
                //string script = "UPDATE CONTA SET SALDO = " + obj.Saldo + " WHERE NUMERO = " + numero;
                string script = "UPDATE CONTA SET SALDO = REPLACE ('" + obj.Saldo + "', ',', '.') WHERE NUMERO = " + numero;

                MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                cmd.ExecuteNonQuery();
                return obj;
            }
            catch
            {
                throw new Exception("Erro na atualização!");
            }
            finally
            {
                if (Conexao.DAL_Conexao().State != ConnectionState.Closed)
                {
                    Conexao.DAL_Conexao().Close();
                }
            }
        }

        public static DTO_Operacoes Dados(string conta)
        {
            DTO_Operacoes dados = new DTO_Operacoes();

            try
            {
                string script = "SELECT CLI.NOME AS CLIENTE, BAN.COD_BANCO, AGE.NUMERO AS AGENCIA, CON.TIPO_CONTA, CON.SALDO FROM CONTA CON  " +
                                "INNER JOIN CLIENTE CLI ON CLI.COD = CON.COD_CLIENTE " +
                                "INNER JOIN AGENCIA AGE ON CON.COD_AGENCIA = AGE.COD " +
                                "INNER JOIN BANCO BAN ON AGE.COD_BANCO = BAN.COD WHERE CON.NUMERO = " + conta;
                MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                dados.Banco = Convert.ToString(dr["COD_BANCO"]);
                dados.Agencia = Convert.ToString(dr["AGENCIA"]);
                dados.Saldo = Convert.ToString(dr["SALDO"]);
                dados.Cliente = Convert.ToString(dr["CLIENTE"]);
                dados.Tipo_Conta = Convert.ToString(dr["TIPO_CONTA"]);
                

                return dados;
            }
            catch
            {
                throw new Exception("Erro ao buscar dados");
            }
            finally
            {
                if (Conexao.DAL_Conexao().State != ConnectionState.Closed)
                {
                    Conexao.DAL_Conexao().Close();
                }
            }
        }
    }
}
