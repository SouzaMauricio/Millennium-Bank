using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Millennium_Bank_DTO;
using Millennium_Bank_DAL;
using System.Data.SqlClient;

namespace Millennium_Bank_BLL
{
    public class BLL_Login
    {
        public static bool ValidarLogin(DTO_Login obj)
        {
            if (string.IsNullOrWhiteSpace(obj.User.ToString()) || string.IsNullOrWhiteSpace(obj.Senha.ToString()))
            {
                throw new Exception("Preencha todos os campos!");
            }

            if (obj.User.Contains("'") || obj.Senha.Contains("'") || obj.User.Contains("=") || obj.Senha.Contains("=") || obj.User.Contains(" or ") || obj.Senha.Contains(" or "))
            {
                throw new Exception("Tentou Sql Injection né safado!");
            }
            try
            {
                return DAL_Login.Logar(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
