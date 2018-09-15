using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Millennium_Bank_DTO;
using System.Windows.Forms;

namespace Millennium_Bank_DAL
{
    public class DAL_Operacoes
    {
        public static DTO_Operacoes Dados(string cli, string ban, string tipo, string cpf)
        {
            DTO_Operacoes dados = new DTO_Operacoes();

            try
            {
                string script = "SELECT CLI.RG, CLI.CPF, CON.NUMERO AS CONTA, BAN.COD_BANCO, AGE.NUMERO, CON.SALDO FROM CLIENTE CLI " +
                                "INNER JOIN CONTA CON ON CLI.COD = CON.COD_CLIENTE " +
                                "INNER JOIN AGENCIA AGE ON CON.COD_AGENCIA = AGE.COD " +
                                "INNER JOIN BANCO BAN ON AGE.COD_BANCO = BAN.COD " +
                                "WHERE CLI.NOME = '" + cli + "' AND CLI.CPF = '" + cpf + "' " +
                                "AND BANCO = '" + ban + "' AND CON.TIPO_CONTA = '" + tipo + "'";
                MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                dados.RG = Convert.ToString(dr["RG"]);
                dados.CPF = Convert.ToString(dr["CPF"]);
                dados.Banco = Convert.ToString(dr["COD_BANCO"]);
                dados.Agencia = Convert.ToString(dr["NUMERO"]);
                dados.Conta = Convert.ToString(dr["CONTA"]);
                dados.Saldo = Convert.ToString(dr["SALDO"]);

                return dados;
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Conexao.DAL_Conexao().State != ConnectionState.Closed)
                {
                    Conexao.DAL_Conexao().Close();
                }
            }
        }

        public static AutoCompleteStringCollection Clientes()
        {
            string nome, cpf;
            AutoCompleteStringCollection con = new AutoCompleteStringCollection();

            try
            {
                //string script = "SELECT NOME FROM CLIENTE";

                //MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                //MySqlDataReader dr = cmd.ExecuteReader();

                //while (dr.Read())
                //{
                //    con.Add(dr.GetString(0));
                //}

                string script = "SELECT NOME, CPF FROM CLIENTE";

                MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    nome = Convert.ToString(dr["NOME"]);
                    cpf = Convert.ToString(dr["CPF"]);
                    con.Add(nome + " - " + cpf);
                    //con.Add(dr.GetString(0));
                }

                return con;
            }
            catch
            {
                throw new Exception("O Cliente não possui uma conta ainda!");
            }
            finally
            {
                if (Conexao.DAL_Conexao().State != ConnectionState.Closed)
                {
                    Conexao.DAL_Conexao().Close();
                }
            }
        }

        public static AutoCompleteStringCollection Bancos(string cli, string cpf)
        {
            AutoCompleteStringCollection con = new AutoCompleteStringCollection();

            try
            {
                string script = "SELECT BAN.NOME FROM BANCO BAN " +
                                "INNER JOIN AGENCIA AGE ON AGE.COD_BANCO = BAN.COD " +
                                "INNER JOIN CONTA CON ON CON.COD_AGENCIA = AGE.COD " +
                                "INNER JOIN CLIENTE CLI ON CON.COD_CLIENTE = CLI.COD " +
                                "WHERE CLI.NOME = '" + cli + "' AND CLI.CPF = '" + cpf + "'" +
                                "GROUP BY BAN.NOME;";
                MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    con.Add(dr.GetString(0));
                }

                return con;
            }
            catch
            {
                throw new Exception("O Cliente não possui uma conta em nenhum banco!");
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
