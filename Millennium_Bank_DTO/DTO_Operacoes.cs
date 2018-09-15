using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millennium_Bank_DTO
{
    public class DTO_Operacoes
    {
        public string Conta { get; set; }
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public string Cliente { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Saldo { get; set; }
        public string Tipo_Conta { get; set; }
    }
}
