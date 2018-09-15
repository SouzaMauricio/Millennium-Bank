using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Millennium_Bank_DTO;
using Millennium_Bank_BLL;

namespace Millenium_Bank
{
    public partial class Novo_Cliente : UserControl
    {
        public Novo_Cliente()
        {
            InitializeComponent();
            btn_Alterar.Enabled = false;
        }

        private void btn_CadastrarB_Click(object sender, EventArgs e)
        {
            DTO_Novo_Cliente obj = new DTO_Novo_Cliente();

            try
            {
                obj.Nome = txt_Nome.Text;
                obj.Sexo = cbo_Sexo.Text;
                obj.Estado_Civil = cbo_Estado_Civil.Text;
                obj.CPF = mtb_CPF.Text;
                obj.RG = mtb_RG.Text;
                obj.Tel_Fixo = mtb_fixo.Text;
                obj.Tel_Comercial = mtb_comercial.Text;
                obj.Celular = mtb_celular.Text;
                obj.Logradouro = txt_Logradouro.Text;
                obj.Numero = txt_Numero.Text;
                obj.Bairro = txt_Bairro.Text;
                obj.Cidade = txt_Cidade.Text;
                obj.UF = cbo_UF.Text;
                obj.Email = txt_Email.Text;

                MessageBox.Show(BLL_Validar_Cliente.ValidarCliente(obj), "Millennium Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Limpar(this);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            Limpar(this);
        }

        public static void Limpar(Novo_Cliente nc)
        {
            nc.txt_Nome.Clear();
            nc.cbo_Sexo.SelectedIndex = -1;
            nc.cbo_Estado_Civil.SelectedIndex = -1;
            nc.mtb_CPF.Clear();
            nc.mtb_RG.Clear();
            nc.mtb_fixo.Clear();
            nc.mtb_comercial.Clear();
            nc.mtb_celular.Clear();
            nc.txt_Logradouro.Clear();
            nc.txt_Numero.Clear();
            nc.txt_Bairro.Clear();
            nc.txt_Cidade.Clear();
            nc.cbo_UF.SelectedIndex = -1;
            nc.txt_Email.Clear();

            nc.btn_CadastrarB.Enabled = true;
            nc.btn_Alterar.Enabled = false;
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                DTO_Novo_Cliente dados = new DTO_Novo_Cliente();
                dados = BLL_Validar_Cliente.BuscarCliente(mtb_CPF.Text);

                txt_Nome.Text = dados.Nome;
                cbo_Sexo.Text = dados.Sexo;
                cbo_Estado_Civil.Text = dados.Estado_Civil;
                mtb_RG.Text = dados.RG;
                mtb_fixo.Text = dados.Tel_Fixo;
                mtb_comercial.Text = dados.Tel_Comercial;
                mtb_celular.Text = dados.Celular;
                txt_Logradouro.Text = dados.Logradouro;
                txt_Numero.Text = dados.Numero;
                txt_Bairro.Text = dados.Bairro;
                txt_Cidade.Text = dados.Cidade;
                cbo_UF.Text = dados.UF;
                txt_Email.Text = dados.Email;

                btn_CadastrarB.Enabled = false;
                btn_Alterar.Enabled = true;

                MessageBox.Show("O Cliente já está cadastrado.", "Millennium Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            DTO_Novo_Cliente obj = new DTO_Novo_Cliente();

            try
            {
                obj.Nome = txt_Nome.Text;
                obj.Sexo = cbo_Sexo.Text;
                obj.Estado_Civil = cbo_Estado_Civil.Text;
                obj.CPF = mtb_CPF.Text;
                obj.RG = mtb_RG.Text;
                obj.Tel_Fixo = mtb_fixo.Text;
                obj.Tel_Comercial = mtb_comercial.Text;
                obj.Celular = mtb_celular.Text;
                obj.Logradouro = txt_Logradouro.Text;
                obj.Numero = txt_Numero.Text;
                obj.Bairro = txt_Bairro.Text;
                obj.Cidade = txt_Cidade.Text;
                obj.UF = cbo_UF.Text;
                obj.Email = txt_Email.Text;
                MessageBox.Show(BLL_Validar_Cliente.Atualizar(obj), "Millennium Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
