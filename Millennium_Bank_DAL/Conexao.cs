using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Millennium_Bank_DAL
{
    public class Conexao
    {
        private static String Servidor = "localhost";
        private static String Porta = "3306";
        private static String Usuario = "root";
        private static String Senha = "";
        private static String db = "BD_MILLENNIUM_BANK";
        private static String UrlConnection = @"Server=" + Servidor + "; port=" + Porta + "; User Id=" + Usuario + "; Password=" + Senha + "; Database=" + db + ";";

        public static MySqlConnection DAL_Conexao()
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(UrlConnection);
                               
                cn.Open();
                return cn;
            }
            catch (Exception)
            {
                throw new Exception("Problemas na conexão!");
            }
        }
    }
}
