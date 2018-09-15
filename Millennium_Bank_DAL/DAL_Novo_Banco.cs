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
    public class DAL_Novo_Banco
    {
        public static string Cadastrar(DTO_Novo_Banco obj)
        {
            try
            {
                string script = "INSERT INTO BANCO (COD_BANCO, NOME, CNPJ) VALUES (@Cod, @Nome, @CNPJ)";
                MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                cmd.Parameters.AddWithValue("@Cod", Convert.ToInt32(obj.Codigo));
                cmd.Parameters.AddWithValue("@Nome", obj.Nome);
                cmd.Parameters.AddWithValue("@CNPJ", obj.CNPJ);
                cmd.ExecuteNonQuery();
                return ("Cadastro realizado com sucesso!");
            }
            catch
            {
                throw new Exception("O Banco já esta cadastrado");
            }
            finally
            {
                if (Conexao.DAL_Conexao().State != ConnectionState.Closed)
                {
                    Conexao.DAL_Conexao().Close();
                }
            }
        }
        
        public static DTO_Novo_Banco BuscarBanco(string cod)
        {
            DTO_Novo_Banco dados = new DTO_Novo_Banco();

            try
            {
                string script = "SELECT * FROM BANCO WHERE COD_BANCO = '" + cod + "'";
                MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                dados.Nome = Convert.ToString(dr["NOME"]);
                dados.CNPJ = Convert.ToString(dr["CNPJ"]);
                return dados;
            }
            catch
            {
                throw new Exception("Banco ainda não Cadastrado!");
            }
            finally
            {
                if (Conexao.DAL_Conexao().State != ConnectionState.Closed)
                {
                    Conexao.DAL_Conexao().Close();
                }
            }
        }

        public static string Alterar(DTO_Novo_Banco dados)
        {
            try
            {
                string script = "UPDATE BANCO SET NOME = '" + dados.Nome + "', CNPJ = '" + dados.CNPJ + "' WHERE COD_BANCO = " + dados.Codigo;
                MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                cmd.Parameters.AddWithValue("@Cod", Convert.ToInt32(dados.Codigo));
                cmd.Parameters.AddWithValue("@Nome", dados.Nome);
                cmd.Parameters.AddWithValue("@CNPJ", dados.CNPJ);
                cmd.ExecuteNonQuery();
                return ("Alteração realizado com sucesso!");
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

        public static AutoCompleteStringCollection Bancos()
        {
            AutoCompleteStringCollection con = new AutoCompleteStringCollection();

            try
            {
                string script = "SELECT NOME FROM BANCO";

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
                throw new Exception("Não existem bancos cadastrados");
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
