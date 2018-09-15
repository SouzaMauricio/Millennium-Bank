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
    public partial class Novo_Banco : UserControl
    {
        public Novo_Banco()
        {
            InitializeComponent();
            btn_Alterar.Enabled = false;
        }

        private void btn_CadastrarB_Click(object sender, EventArgs e)
        {
            DTO_Novo_Banco obj = new DTO_Novo_Banco();

            try
            {
                obj.Codigo = txt_Cod.Text;
                obj.Nome = txt_Nome.Text;
                obj.CNPJ = mtb_CNPJ.Text;
                MessageBox.Show(BLL_Validar_Banco.ValidarBanco(obj), "Millennium Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public static void Limpar(Novo_Banco nb)
        {
            nb.txt_Cod.Clear();
            nb.txt_Nome.Clear();
            nb.mtb_CNPJ.Clear();
            nb.txt_Cod.Focus();

            nb.btn_CadastrarB.Enabled = true;
            nb.btn_Alterar.Enabled = false;
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            DTO_Novo_Banco ban = new DTO_Novo_Banco();

            try
            {
                ban = BLL_Validar_Banco.BuscarBanco(txt_Cod.Text.ToString());

                txt_Nome.Text = ban.Nome;
                mtb_CNPJ.Text = ban.CNPJ;

                btn_CadastrarB.Enabled = false;
                btn_Alterar.Enabled = true;

                MessageBox.Show("O Banco já está cadastrado.", "Millennium Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            DTO_Novo_Banco obj = new DTO_Novo_Banco();

            try
            {
                obj.Codigo = txt_Cod.Text;
                obj.Nome = txt_Nome.Text;
                obj.CNPJ = mtb_CNPJ.Text;

                //Tirar a Mascara
                /*mtb_CNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                obj.CNPJ = mtb_CNPJ.Text;
                mtb_CNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;*/

                MessageBox.Show(BLL_Validar_Banco.Atualizar(obj), "Millennium Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Limpar(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
