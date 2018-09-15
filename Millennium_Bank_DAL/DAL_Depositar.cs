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
    public class DAL_Depositar
    {
        public static DTO_Deposito Depositar(DTO_Deposito obj, string numero)
        {
            try
            {
                string script = "UPDATE CONTA SET SALDO = " + obj.Saldo + " WHERE NUMERO = " + numero;
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
    }
}
