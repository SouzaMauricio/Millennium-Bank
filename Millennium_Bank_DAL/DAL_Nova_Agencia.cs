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
    public class DAL_Nova_Agencia
    {
        public static string Cadastrar(DTO_Nova_Agencia obj)
        {
            try
            {
                string script1 = "SELECT * FROM BANCO WHERE NOME = @Banco";
                MySqlCommand cmd1 = new MySqlCommand(script1, Conexao.DAL_Conexao());
                cmd1.Parameters.AddWithValue("@Banco", obj.Cod_Banco);
                MySqlDataReader read = cmd1.ExecuteReader();

                if (!read.HasRows)
                {
                    throw new Exception("Este Banco não existe!");
                }
                else
                {
                    string script2 = "SELECT * FROM AGENCIA WHERE NUMERO = @num";
                    MySqlCommand cmd2 = new MySqlCommand(script2, Conexao.DAL_Conexao());
                    cmd2.Parameters.AddWithValue("@num", obj.Numero_Agencia);
                    MySqlDataReader read2 = cmd2.ExecuteReader();

                    if (read2.HasRows)
                    {
                        throw new Exception("Este número de agência já existe!");
                    }
                    else
                    {
                        string script = "INSERT INTO AGENCIA (COD_BANCO, NUMERO, BAIRRO) VALUES ((SELECT COD FROM BANCO WHERE NOME = @Nome_B), @Numero, @Bairro)";
                        MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                        cmd.Parameters.AddWithValue("@Nome_B", obj.Cod_Banco);
                        cmd.Parameters.AddWithValue("@Numero", Convert.ToInt32(obj.Numero_Agencia));
                        cmd.Parameters.AddWithValue("@Bairro", obj.Bairro);
                        cmd.ExecuteNonQuery();
                        return ("Cadastro realizado com sucesso!");
                    }                    
                }
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

        /*public static DataTable Agencias(string ban)
        {
            DataTable age = new DataTable();
            try
            {
                string script = "SELECT * FROM AGENCIA WHERE COD_BANCO = (SELECT COD FROM BANCO WHERE COD_BANCO = @Ban)";
                SqlCommand cmd = new SqlCommand(script, Conexao.DAL_Conexao());
                cmd.Parameters.AddWithValue("@Ban", Convert.ToInt32(ban));
                SqlDataReader dr = cmd.ExecuteReader();
                age.Load(dr);
                return age;
            }
            catch (Exception ex)
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
        }*/
        
        /*public static DataTable TodasAgencias()
        {
            DataTable age = new DataTable();
            try
            {
                string script = "SELECT * FROM AGENCIA";
                SqlCommand cmd = new SqlCommand(script, Conexao.DAL_Conexao());
                SqlDataReader dr = cmd.ExecuteReader();
                age.Load(dr);
                return age;
            }
            catch (Exception ex)
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
        }*/

        public static DTO_Nova_Agencia BuscarAgencia(string age)
        {
            DTO_Nova_Agencia dados = new DTO_Nova_Agencia();

            try
            {
                string script = "SELECT BAN.NOME, AGE.BAIRRO FROM AGENCIA AGE " +
                                "INNER JOIN BANCO BAN ON AGE.COD_BANCO = BAN.COD " +
                                " WHERE AGE.NUMERO = " + age;
                MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                dados.Cod_Banco = Convert.ToString(dr["NOME"]);
                dados.Bairro = Convert.ToString(dr["BAIRRO"]);
                return dados;
            }
            catch
            {
                throw new Exception("Este Número de Agência não esta cadastrado");
            }
            finally
            {
                if (Conexao.DAL_Conexao().State != ConnectionState.Closed)
                {
                    Conexao.DAL_Conexao().Close();
                }
            }
        }

        public static string Alterar(DTO_Nova_Agencia obj)
        {
            try
            {
                string script1 = "SELECT * FROM BANCO WHERE NOME = @Banco";
                MySqlCommand cmd1 = new MySqlCommand(script1, Conexao.DAL_Conexao());
                cmd1.Parameters.AddWithValue("@Banco", obj.Cod_Banco);
                MySqlDataReader read1 = cmd1.ExecuteReader();

                if (!read1.HasRows)
                {
                    throw new Exception("Este Banco não existe!");
                }
                else
                {
                    string script = "UPDATE AGENCIA SET COD_BANCO = (SELECT COD FROM BANCO WHERE NOME = '" + obj.Cod_Banco + "'), " +
                        "BAIRRO = '" + obj.Bairro + "' WHERE NUMERO = " + obj.Numero_Agencia + "; " +
                        "UPDATE CONTA SET BANCO = '" + obj.Cod_Banco + "' " +
                        "WHERE COD_AGENCIA = (SELECT COD FROM AGENCIA WHERE NUMERO = " + obj.Numero_Agencia + ");";
                    MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                    cmd.ExecuteNonQuery();
                    return ("Atualização realizada com sucesso!");
                }
            }

            catch (MySqlException)
            {
                throw new Exception("Não é possível concluir a alteração pois já existe(m)\nalgum(uns) cliente(s) com conta(s) nesse banco!");
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

        public static AutoCompleteStringCollection Agencias(string banco)
        {
            AutoCompleteStringCollection con = new AutoCompleteStringCollection();

            try 
            {
                string script = "SELECT NUMERO FROM AGENCIA WHERE COD_BANCO = (SELECT COD FROM BANCO WHERE NOME = '" + banco + "');";

                MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.ToString();
                
                while (dr.Read())
                {
                    con.Add(dr.GetString(0));
                }
                
                return con;
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
    }
}
