using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Millennium_Bank_DTO;
using Millennium_Bank_DAL;
using System.Data;

namespace Millennium_Bank_BLL
{
    public class BLL_Validar_Cliente
    {
        public static string ValidarCliente(DTO_Novo_Cliente obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Nome) || string.IsNullOrWhiteSpace(obj.Sexo) || string.IsNullOrWhiteSpace(obj.Estado_Civil)
                || string.IsNullOrWhiteSpace(obj.CPF) || string.IsNullOrWhiteSpace(obj.RG) || string.IsNullOrWhiteSpace(obj.Tel_Fixo)
                || string.IsNullOrWhiteSpace(obj.Tel_Comercial) || string.IsNullOrWhiteSpace(obj.Celular) || string.IsNullOrWhiteSpace(obj.Logradouro)
                || string.IsNullOrWhiteSpace(obj.Numero) || string.IsNullOrWhiteSpace(obj.Bairro) || string.IsNullOrWhiteSpace(obj.Cidade)
                || string.IsNullOrWhiteSpace(obj.UF) || string.IsNullOrWhiteSpace(obj.Email))
            {
                throw new Exception("Preencha todos os Campos!");
            }

            try
            {
                Convert.ToInt64(obj.CPF);
            }
            catch
            {
                throw new Exception("CPF incorreto!");
            }

            try
            {
                Convert.ToInt64(obj.RG);
            }
            catch
            {
                throw new Exception("RG incorreto!");
            }

            try
            {
                return DAL_Novo_Cliente.Cadastrar(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*public static DataTable Clientes()
        {
            DataTable cli = new DataTable();
            cli = DAL_Novo_Cliente.Clientes();
            return cli;
        }*/

        
        /*public static string Selecionar_Clien(string cli, DataTable clientes)
        {
            cli.ToLower();
            string busca = string.Format("NOME = '" + cli + "'");
            DataRow[] result = clientes.Select(busca);
            cli = result.ToString();
            foreach (DataRow row in result)
            {
                cli = Convert.ToString(row["COD"]);
            }

            return cli;
        }*/

        public static DTO_Novo_Cliente BuscarCliente(string cpf)
        {
            DTO_Novo_Cliente dados = new DTO_Novo_Cliente();

             if (string.IsNullOrWhiteSpace(cpf))
             {
                 throw new Exception("Campo 'CPF' vazio");
             }

             try
             {
                 Convert.ToInt64(cpf);
             }
             catch
             {
                 throw new Exception("Preencha o Campo 'CPF' corretamente!");
             }
             
            dados = DAL_Novo_Cliente.BuscarCliente(cpf);
            return dados;
        }

        public static string Atualizar(DTO_Novo_Cliente obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Nome) || string.IsNullOrWhiteSpace(obj.Sexo) || string.IsNullOrWhiteSpace(obj.Estado_Civil)
                || string.IsNullOrWhiteSpace(obj.CPF) || string.IsNullOrWhiteSpace(obj.RG) || string.IsNullOrWhiteSpace(obj.Tel_Fixo)
                || string.IsNullOrWhiteSpace(obj.Tel_Comercial) || string.IsNullOrWhiteSpace(obj.Celular) || string.IsNullOrWhiteSpace(obj.Logradouro)
                || string.IsNullOrWhiteSpace(obj.Numero) || string.IsNullOrWhiteSpace(obj.Bairro) || string.IsNullOrWhiteSpace(obj.Cidade)
                || string.IsNullOrWhiteSpace(obj.UF) || string.IsNullOrWhiteSpace(obj.Email))
            {
                throw new Exception("Preencha todos os Campos!");
            }

            try
            {
                Convert.ToInt64(obj.CPF);
            }
            catch
            {
                throw new Exception("CPF incorreto!");
            }

            try
            {
                Convert.ToInt64(obj.RG);
            }
            catch
            {
                throw new Exception("RG incorreto!");
            }

            try
            {
                return DAL_Novo_Cliente.Alterar(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
