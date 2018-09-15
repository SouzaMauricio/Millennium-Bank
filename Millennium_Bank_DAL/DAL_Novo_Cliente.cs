using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Millennium_Bank_DTO;
using System.Windows;

namespace Millennium_Bank_DAL
{
    public class DAL_Novo_Cliente
    {
        public static string Cadastrar(DTO_Novo_Cliente obj)
        {
            try
            {
                string script1 = "SELECT * FROM CLIENTE WHERE CPF = @cpf";
                MySqlCommand cmd1 = new MySqlCommand(script1, Conexao.DAL_Conexao());
                cmd1.Parameters.AddWithValue("@cpf", obj.CPF);
                MySqlDataReader read1 = cmd1.ExecuteReader();

                if (read1.HasRows)
                {
                    throw new Exception("Este CPF já esta cadastrado!");
                }
                else
                {

                    string script = "INSERT INTO CLIENTE (NOME, SEXO, ESTADO_CIVIL, RG, CPF, TEL_FIXO, TEL_COMERCIAL, CELULAR, LOGRADOURO, NUMERO, BAIRRO, CIDADE, UF, EMAIL) VALUES (@Nome, @Sexo, @Est_Civil, @rg, @cpf, @Fixo, @Comercial, @Celular, @Logradouro, @Num, @Bairro, @Cidade, @uf, @Email)";
                    MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                    cmd.Parameters.AddWithValue("@Nome", obj.Nome);
                    cmd.Parameters.AddWithValue("@Sexo", obj.Sexo);
                    cmd.Parameters.AddWithValue("@Est_Civil", obj.Estado_Civil);
                    cmd.Parameters.AddWithValue("@rg", obj.RG);
                    cmd.Parameters.AddWithValue("@cpf", Convert.ToInt64(obj.CPF));
                    cmd.Parameters.AddWithValue("@Fixo", obj.Tel_Fixo);
                    cmd.Parameters.AddWithValue("@Comercial", obj.Tel_Comercial);
                    cmd.Parameters.AddWithValue("@Celular", obj.Celular);
                    cmd.Parameters.AddWithValue("@Logradouro", obj.Logradouro);
                    cmd.Parameters.AddWithValue("@Num", Convert.ToInt32(obj.Numero));
                    cmd.Parameters.AddWithValue("@Bairro", obj.Bairro);
                    cmd.Parameters.AddWithValue("@Cidade", obj.Cidade);
                    cmd.Parameters.AddWithValue("@uf", obj.UF);
                    cmd.Parameters.AddWithValue("@Email", obj.Email);
                    cmd.ExecuteNonQuery();
                    return ("Cadastro realizado com sucesso!");
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

        /*public static DataTable Clientes()
        {
            DataTable clientes = new DataTable();
            try
            {
                string script = "SELECT COD, NOME FROM CLIENTE";
                MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                MySqlDataReader dr = cmd.ExecuteReader();
                clientes.Load(dr);
                return clientes;
            }
            catch
            {
                throw new Exception("Cliente já Cadastrado!");
            }
            finally
            {
                if (Conexao.DAL_Conexao().State != ConnectionState.Closed)
                {
                    Conexao.DAL_Conexao().Close();
                }
            }
        }*/

        public static DTO_Novo_Cliente BuscarCliente(string cpf)
        {
            DTO_Novo_Cliente dados = new DTO_Novo_Cliente();
            try
            {
                string script = "SELECT * FROM CLIENTE WHERE CPF = " + cpf + ";";
                MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                dados.Nome = Convert.ToString(dr["NOME"]);
                dados.Sexo = Convert.ToString(dr["SEXO"]);
                dados.Estado_Civil = Convert.ToString(dr["ESTADO_CIVIL"]);
                dados.RG = Convert.ToString(dr["RG"]);
                dados.Tel_Fixo = Convert.ToString(dr["TEL_FIXO"]);
                dados.Tel_Comercial = Convert.ToString(dr["TEL_COMERCIAL"]);
                dados.Celular = Convert.ToString(dr["CELULAR"]);
                dados.Logradouro = Convert.ToString(dr["LOGRADOURO"]);
                dados.Numero = Convert.ToString(dr["NUMERO"]);
                dados.Bairro = Convert.ToString(dr["BAIRRO"]);
                dados.Cidade = Convert.ToString(dr["CIDADE"]);
                dados.UF = Convert.ToString(dr["UF"]);
                dados.Email = Convert.ToString(dr["EMAIL"]);
                return dados;
            }
            catch
            {
                throw new Exception("Cliente Não Está Cadastrado!");
            }
            finally
            {
                if (Conexao.DAL_Conexao().State != ConnectionState.Closed)
                {
                    Conexao.DAL_Conexao().Close();
                }
            }
        }

        public static string Alterar(DTO_Novo_Cliente obj)
        {
            try
            {
                string script = "UPDATE CLIENTE SET NOME = @Nome, SEXO = @Sexo, ESTADO_CIVIL = @Est_Civil, RG = @rg, " +
                    "TEL_FIXO = @Fixo, TEL_COMERCIAL = @Comercial, CELULAR = @Celular, LOGRADOURO = @Logradouro, " +
                    "NUMERO = @Num, BAIRRO = @Bairro, CIDADE = @Cidade, UF = @uf, EMAIL = @Email WHERE CPF = @cpf";                    
                MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                cmd.Parameters.AddWithValue("@Nome", obj.Nome);
                cmd.Parameters.AddWithValue("@Sexo", obj.Sexo);
                cmd.Parameters.AddWithValue("@Est_Civil", obj.Estado_Civil);
                cmd.Parameters.AddWithValue("@rg", obj.RG);
                cmd.Parameters.AddWithValue("@cpf", Convert.ToInt64(obj.CPF));
                cmd.Parameters.AddWithValue("@Fixo", obj.Tel_Fixo);
                cmd.Parameters.AddWithValue("@Comercial", obj.Tel_Comercial);
                cmd.Parameters.AddWithValue("@Celular", obj.Celular);
                cmd.Parameters.AddWithValue("@Logradouro", obj.Logradouro);
                cmd.Parameters.AddWithValue("@Num", Convert.ToInt32(obj.Numero));
                cmd.Parameters.AddWithValue("@Bairro", obj.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", obj.Cidade);
                cmd.Parameters.AddWithValue("@uf", obj.UF);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.ExecuteNonQuery();
                return ("Atualização realizada com sucesso!");
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
    }
}
