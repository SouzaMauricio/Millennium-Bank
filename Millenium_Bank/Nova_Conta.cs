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
    public partial class Nova_Conta : UserControl
    {
        public Nova_Conta()
        {
            InitializeComponent();
            btn_Alterar.Enabled = false;
        }

        private void btn_CadastrarB_Click(object sender, EventArgs e)
        {
            DTO_Nova_Conta obj = new DTO_Nova_Conta();

            try
            {
                obj.Banco = txt_Banco.Text;
                obj.Cod_Agencia = txt_Agencia.Text;
                obj.Cod_Cliente = txt_Cliente.Text;
                obj.Tipo_Conta = cbo_Tipo_Conta.Text;
                obj.Numero = txt_Numero.Text;
                obj.Saldo_Inicial = txt_Saldo_Inicial.Text;

                MessageBox.Show(BLL_Validar_Conta.ValidarConta(obj), "Millennium Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        public static void Limpar(Nova_Conta nc)
        {
            nc.txt_Banco.Clear();
            nc.txt_Agencia.Clear();
            nc.cbo_Tipo_Conta.SelectedIndex = -1;
            nc.txt_Cliente.Clear();
            nc.txt_Numero.Clear();
            nc.txt_Saldo_Inicial.Clear();
            nc.btn_CadastrarB.Enabled = true;
            nc.btn_Alterar.Enabled = false;
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                DTO_Nova_Conta dt = new DTO_Nova_Conta();

                dt = BLL_Validar_Conta.BuscarConta(txt_Numero.Text);


                txt_Banco.Text = dt.Banco;
                

                txt_Agencia.Text = dt.Cod_Agencia;

                txt_Cliente.Text = dt.Cod_Cliente;
                cbo_Tipo_Conta.Text = dt.Tipo_Conta;
                txt_Saldo_Inicial.Text = dt.Saldo_Inicial;

                btn_CadastrarB.Enabled = false;
                btn_Alterar.Enabled = true;

                MessageBox.Show("Essa Conta já está Cadastrada.", "Millennium Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                
        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            DTO_Nova_Conta obj = new DTO_Nova_Conta();

            try
            {
                obj.Banco = txt_Banco.Text;
                obj.Cod_Agencia = txt_Agencia.Text;
                obj.Cod_Cliente = txt_Cliente.Text;
                obj.Tipo_Conta = cbo_Tipo_Conta.Text;
                obj.Numero = txt_Numero.Text;
                obj.Saldo_Inicial = txt_Saldo_Inicial.Text;
                
                MessageBox.Show(BLL_Validar_Conta.Atualizar(obj), "Millennium Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Limpar(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_Agencia_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Agencia.AutoCompleteCustomSource = BLL_Validar_Agencia.Agencias(txt_Banco.Text.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_Banco_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                try
                {
                    txt_Agencia.AutoCompleteCustomSource = BLL_Validar_Agencia.Agencias(txt_Banco.Text.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Banco.Focus();
                }
            }            
        }
    }
}
