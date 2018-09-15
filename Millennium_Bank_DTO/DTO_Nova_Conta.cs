using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millennium_Bank_DTO
{
    public class DTO_Nova_Conta
    {
        public string Cod_Agencia { get; set; }
        public string Cod_Cliente { get; set; }
        public string Cpf { get; set; }
        public string Banco { get; set; }
        public string Numero { get; set; }
        public string Tipo_Conta { get; set; }
        public string Saldo_Inicial { get; set; }
    }
}
