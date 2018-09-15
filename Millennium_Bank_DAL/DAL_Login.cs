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
    public class DAL_Login
    {
        public static bool Logar(DTO_Login obj)
        {
            try
            {
                string script = "SELECT * FROM USUARIOS WHERE USUARIO = '" + obj.User + "' AND SENHA = '" + obj.Senha + "';";
                MySqlCommand cmd = new MySqlCommand(script, Conexao.DAL_Conexao());
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    bool res = true;
                    return res;
                }
                else
                {
                    throw new Exception("Usuário ou Senha inválidos!");
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
    }
}
