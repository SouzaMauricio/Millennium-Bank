using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Millennium_Bank_BLL;

namespace Millenium_Bank
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            welcome1.BringToFront();
            pnl_Select.Visible = false;
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btn_Novo_Banco_Click(object sender, EventArgs e)
        {
            try
            {
                novo_Banco1.BringToFront();
                novo_Banco1.Focus();
                pnl_Select.Left = btn_Novo_Banco.Left;
                pnl_Select.Top = btn_Novo_Banco.Bottom;
                pnl_Select.Visible = true;
                novo_Banco1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }            
        }

        private void btn_Nova_Agencia_Click(object sender, EventArgs e)
        {
            try
            {
                AutoCompleteStringCollection con = new AutoCompleteStringCollection();

                con = BLL_Validar_Banco.Bancos();

                nova_Agencia1.txt_Cod_Banco.AutoCompleteCustomSource = con;

                nova_Agencia1.BringToFront();
                nova_Agencia1.Focus();
                pnl_Select.Left = btn_Nova_Agencia.Left;
                pnl_Select.Top = btn_Nova_Agencia.Bottom;
                pnl_Select.Visible = true;
                nova_Agencia1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_Novo_Cliente_Click(object sender, EventArgs e)
        {
            try
            {
                novo_Cliente1.BringToFront();
                novo_Cliente1.Focus();
                pnl_Select.Left = btn_Novo_Cliente.Left;
                pnl_Select.Top = btn_Novo_Cliente.Bottom;
                novo_Cliente1.Focus();
                pnl_Select.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_Nova_Conta_Click(object sender, EventArgs e)
        {
            try
            {
                AutoCompleteStringCollection con = new AutoCompleteStringCollection();

                con = BLL_Validar_Operacoes.Clientes();

                nova_Conta1.txt_Cliente.AutoCompleteCustomSource = con;

                con = BLL_Validar_Banco.Bancos();

                nova_Conta1.txt_Banco.AutoCompleteCustomSource = con;

                nova_Conta1.BringToFront();
                nova_Conta1.Focus();
                pnl_Select.Left = btn_Nova_Conta.Left;
                pnl_Select.Top = btn_Nova_Conta.Bottom;
                pnl_Select.Visible = true;
                nova_Conta1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
                
        private void btn_Operacoes_Click(object sender, EventArgs e)
        {
            try
            {
                AutoCompleteStringCollection con = new AutoCompleteStringCollection();

                con = BLL_Validar_Operacoes.Clientes();

                operacoes1.txt_Cliente.AutoCompleteCustomSource = con;

                Operacoes aux = operacoes1;

                operacoes1.BringToFront();
                operacoes1.Visible = true;
                operacoes1.Focus();
                pnl_Select.Left = btn_Operacoes.Left;
                pnl_Select.Top = btn_Operacoes.Bottom;
                pnl_Select.Visible = true;
                operacoes1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }            
        }

        private void btn_Logoff_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja mesmo sair?", "Millennium Bank", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Properties.Settings.Default.LoginAutomatico = false;
                Properties.Settings.Default.Save();
                this.Hide();
                Login lg = new Login();
                lg.ShowDialog();
                this.Close();
            }
        }

        private void btn_Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
