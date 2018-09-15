using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Millennium_Bank_DTO;

namespace Millennium_Bank_DAL
{
    public class DAL_Nova_Conta
    {
        public static string Cadastrar(DTO_Nova_Conta obj)
        {
            try
            {
                string script_ban = "SELECT * FROM BANCO WHERE NOME = @Banco";
                MySqlCommand cmd_ban = new MySqlCommand(script_ban, Conexao.DAL_Conexao());
                cmd_ban.Parameters.AddWithValue("@Banco", obj.Banco);
                MySqlDataReader read_ban = cmd_ban.ExecuteReader();

                if (!read_ban.HasRows)
                {
                    throw new Exception("Este Banco não existe!");
                }
                else
                {
                    string script_age = "SELECT * FROM AGENCIA WHERE COD_BANCO = (SELECT COD FROM BANCO WHERE NOME = @Banco) AND NUMERO = @Age";
                    MySqlCommand cmd_age = new MySqlCommand(script_age, Conexao.DAL_Conexao());
                    cmd_age.Parameters.AddWithValue("@Banco", obj.Banco);
                    cmd_age.Parameters.AddWithValue("@Age", obj.Cod_Agencia);
                    MySqlDataReader read_age = cmd_age.ExecuteReader();

                    if (!read_age.HasRows)
                    {
                        throw new Exception("Este Agencia não existe ou não \nfaz parte deste banco!");
                    }
                    else
                    {

                        string script1 = "SELECT * FROM CONTA WHERE BANCO = @Banco AND TIPO_CONTA = @Tipo AND COD_CLIENTE = (SELECT COD FROM CLIENTE WHERE NOME = @Cliente)";
                        MySqlCommand cmd1 = new MySqlCommand(script1, Conexao.DAL_Conexao());
                        cmd1.Parameters.AddWithValue("@Banco", obj.Banco);
                        cmd1.Parameters.AddWithValue("@Tipo", obj.Tipo_Conta);
                        cmd1.Parameters.AddWithValue("@Cliente", obj.Cod_Cliente);
                        MySqlDataReader read = cmd1.ExecuteReader();

                        if (read.HasRows)
                        {
                            throw new Exception("Esta conta já existe neste Banco!");
                        }
                        else
                        {
                            string script2 = "SELECT * FROM CONTA WHERE NUMERO = @Num";
                            MySqlCommand cmd2 = new MySqlCommand(script2, Conexao.DAL_Conexao());
                            cmd2.Parameters.AddWithValue("@Num", obj.Numero);
                            MySqlDataReader read2 = cmd2.ExecuteReader();

                            if (read2.HasRows)
                            {
                                throw new Exception("Este número de conta já existe!");
                            }
                            else
                            {
                                string script_cli = "SELECT * FROM CLIENTE WHERE NOME = @Nome AND CPF = @Cpf";
                                MySqlCommand cmd_cli = new MySqlCommand(script_cli, Conexao.DAL_Conexao());
                                cmd_cli.Parameters.AddWithValue("@Nome", obj.Cod_Cliente);
                                cmd_cli.Parameters.AddWithValue("@Cpf", obj.Cpf);
                                MySqlDataReader read_cli = cmd_cli.ExecuteReader();

                                if (!read_cli.HasRows)
                                {
                                    throw new Exception("Cliente não cadastrado, verifique os dados!");
                                }
                                else
                                {
                                    string script = "INSERT INTO CONTA (BANCO, COD_AGENCIA, COD_CLIENTE, TIPO_CONTA, NUMERO, SALDO) VALUES (@Banco, (SELECT COD FROM AGENCIA WHERE NUMERO = @Agencia), (SELECT COD FROM CLIENTE WHERE NOME = @Cliente), @Tipo, @Numero, @Saldo)";
                                    MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                                    cmd.Parameters.AddWithValue("@Banco", obj.Banco);
                                    cmd.Parameters.AddWithValue("@Agencia", Convert.ToInt32(obj.Cod_Agencia));
                                    cmd.Parameters.AddWithValue("@Cliente", obj.Cod_Cliente);
                                    cmd.Parameters.AddWithValue("@Tipo", obj.Tipo_Conta);
                                    cmd.Parameters.AddWithValue("@Numero", Convert.ToInt32(obj.Numero));
                                    cmd.Parameters.AddWithValue("@Saldo", Convert.ToDouble(obj.Saldo_Inicial));
                                    cmd.ExecuteNonQuery();
                                    return ("Cadastro realizado com sucesso!");
                                }
                            }
                        }
                    }
                }
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
        }

        public static DTO_Nova_Conta BuscarConta(string num)
        {
            DTO_Nova_Conta dados = new DTO_Nova_Conta();

            try
            {
                string script = "SELECT CON.NUMERO, CLI.NOME, CLI.CPF, BAN.NOME AS BANCO, AGE.NUMERO AS AGENCIA, CON.TIPO_CONTA, CON.SALDO FROM CONTA CON " +
                                "INNER JOIN CLIENTE CLI ON CON.COD_CLIENTE = CLI.COD " +
                                "INNER JOIN AGENCIA AGE ON CON.COD_AGENCIA = AGE.COD " +
                                "INNER JOIN BANCO BAN ON CON.BANCO = BAN.NOME " +
                                "WHERE CON.NUMERO = " + num;
                MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                dados.Banco = Convert.ToString(dr["BANCO"]);
                dados.Cod_Agencia = Convert.ToString(dr["AGENCIA"]);
                dados.Cod_Cliente = Convert.ToString(dr["NOME"]) + " - " + Convert.ToString(dr["CPF"]);
                dados.Tipo_Conta = Convert.ToString(dr["TIPO_CONTA"]);
                dados.Saldo_Inicial = Convert.ToString(dr["SALDO"]);
                
                return dados;
            }
            catch
            {
                throw new Exception("Conta ainda não Cadastrada!");
            }
            finally
            {
                if (Conexao.DAL_Conexao().State != ConnectionState.Closed)
                {
                    Conexao.DAL_Conexao().Close();
                }
            }
        }

        public static DataTable BuscarTipo(string ban, string cliente, string cpf)
        {
            DataTable tipos = new DataTable();
            try
            {
                string script = "SELECT TIPO_CONTA FROM CONTA WHERE COD_CLIENTE = (SELECT COD FROM CLIENTE WHERE NOME = '" + cliente + "' AND CPF = '" + cpf + "') AND BANCO = '" + ban + "';";
                MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                MySqlDataReader dr = cmd.ExecuteReader();
                tipos.Load(dr);

                return tipos;
            }
            catch
            {
                throw new Exception("Conta ainda não Cadastrada!");
            }
            finally
            {
                if (Conexao.DAL_Conexao().State != ConnectionState.Closed)
                {
                    Conexao.DAL_Conexao().Close();
                }
            }
        }

        public static string Alterar(DTO_Nova_Conta obj)
        {
            string script1 = "SELECT * FROM AGENCIA WHERE COD_BANCO = (SELECT COD FROM BANCO WHERE NOME = @Banco) AND NUMERO = @Agencia";
            MySqlCommand cmd1 = new MySqlCommand(script1, Conexao.DAL_Conexao());
            cmd1.Parameters.AddWithValue("@Banco", obj.Banco);
            cmd1.Parameters.AddWithValue("@Agencia", Convert.ToInt32(obj.Cod_Agencia));
            MySqlDataReader read = cmd1.ExecuteReader();

            if (!read.Read())
            {
                throw new Exception("Esta agencia não pertence a esse banco!");
            }

            try
            {
                string script = "UPDATE CONTA SET " +
                    "COD_AGENCIA = (SELECT COD FROM AGENCIA WHERE NUMERO = @Agencia), COD_CLIENTE = (SELECT COD FROM CLIENTE WHERE NOME = @Cliente AND CPF = @Cpf), " +
                    "TIPO_CONTA = @Tipo, SALDO = @Saldo WHERE NUMERO = @Numero";
                MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                cmd.Parameters.AddWithValue("@Banco", obj.Banco);
                cmd.Parameters.AddWithValue("@Agencia", Convert.ToInt32(obj.Cod_Agencia));
                cmd.Parameters.AddWithValue("@Cliente", obj.Cod_Cliente);
                cmd.Parameters.AddWithValue("@Cpf", obj.Cpf);
                cmd.Parameters.AddWithValue("@Tipo", obj.Tipo_Conta);
                cmd.Parameters.AddWithValue("@Numero", Convert.ToInt32(obj.Numero));
                cmd.Parameters.AddWithValue("@Saldo", Convert.ToDouble(obj.Saldo_Inicial));
                cmd.ExecuteNonQuery();
                return ("Atualização realizada com sucesso!");
            }
            catch (MySqlException)
            {
                throw new Exception("Está conta já existe!");
            }
            catch (Exception)
            {
                throw new Exception("Problemas na Atualização! Tente Novamente.");
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
