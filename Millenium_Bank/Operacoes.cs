using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Millennium_Bank_BLL;
using Millennium_Bank_DTO;

namespace Millenium_Bank
{
    public partial class Operacoes : UserControl
    {
        public Operacoes()
        {
            InitializeComponent();            
        }

        private void btn_Sacar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_Conta.Text))
                {
                    MessageBox.Show("Selecione os dados para Saque!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Sacar sc = new Sacar(this);
                    sc.ShowDialog(this);
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                       
        }

        private void btn_Depositar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_Conta.Text))
                {
                    MessageBox.Show("Selecione os dados para Depósito!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Depositar dp = new Depositar(this);
                    dp.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            Limpar(this);
        }

        private void cbo_TipoConta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            DTO_Operacoes op = new DTO_Operacoes();

            try
            {
                op.Cliente = txt_Cliente.Text;
                op = BLL_Validar_Operacoes.Dados_Conta(op.Cliente, txt_Banco.Text, cbo_TipoConta.Text);

                txt_RG.Text = Convert.ToString(op.RG);
                txt_CPF.Text = Convert.ToString(op.CPF);
                txt_Conta.Text = Convert.ToString(op.Conta);
                txt_Agencia.Text = Convert.ToString(op.Agencia);
                string aux = Convert.ToString(op.Saldo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
        }
        
        private void cbo_TipoConta_Click(object sender, EventArgs e)
        {

            DTO_Operacoes op = new DTO_Operacoes();
            DataTable tipo = new DataTable();

            op.Cliente = txt_Cliente.Text.ToString();
            op.Banco = txt_Banco.Text.ToString();

            try
            {
                tipo = BLL_Validar_Conta.BuscarTipo(op.Banco, op.Cliente);
                cbo_TipoConta.DisplayMember = "TIPO_CONTA";
                cbo_TipoConta.DataSource = tipo;
                cbo_TipoConta.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public static void Limpar(Operacoes op)
        {
            op.txt_Cliente.Clear();
            op.cbo_TipoConta.DataSource = null;
            op.txt_CPF.Clear();
            op.txt_RG.Clear();
            op.txt_Conta.Clear();
            op.txt_Banco.Clear();
            op.txt_Agencia.Clear();
        }

        public static void LimparParcial(Operacoes op)
        {
            //op.cbo_TipoConta.DataSource = null;
            op.txt_CPF.Clear();
            op.txt_RG.Clear();
            op.txt_Conta.Clear();
            op.txt_Banco.Clear();
            op.txt_Agencia.Clear();
        }

        private void txt_Cliente_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                try
                {
                    AutoCompleteStringCollection con = new AutoCompleteStringCollection();

                    con = BLL_Validar_Operacoes.Bancos(txt_Cliente.Text.ToString());

                    txt_Banco.AutoCompleteCustomSource = con;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            



            /*if (e.KeyCode == Keys.Tab)
            {
                DTO_Operacoes op = new DTO_Operacoes();
                DataTable tipo = new DataTable();

                op.Cliente = txt_Cliente.Text.ToString();
                op.Banco = txt_Banco.Text.ToString();

                try
                {
                    tipo = BLL_Validar_Conta.BuscarTipo(op.Banco, op.Cliente);
                    cbo_TipoConta.DisplayMember = "TIPO_CONTA";
                    cbo_TipoConta.DataSource = tipo;
                    cbo_TipoConta.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }*/
        }


        private void txt_Banco_Click(object sender, EventArgs e)
        {
            try
            {
                AutoCompleteStringCollection con = new AutoCompleteStringCollection();

                con = BLL_Validar_Operacoes.Bancos(txt_Cliente.Text.ToString());

                txt_Banco.AutoCompleteCustomSource = con;
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
                DTO_Operacoes op = new DTO_Operacoes();
                DataTable tipo = new DataTable();

                op.Cliente = txt_Cliente.Text.ToString();
                op.Banco = txt_Banco.Text.ToString();

                try
                {
                    tipo = BLL_Validar_Conta.BuscarTipo(op.Banco, op.Cliente);
                    cbo_TipoConta.DisplayMember = "TIPO_CONTA";
                    cbo_TipoConta.DataSource = tipo;
                    cbo_TipoConta.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Saldo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_CPF.Text) || string.IsNullOrWhiteSpace(cbo_TipoConta.Text))
            {
                MessageBox.Show("Selecione os dados para consultar o Saldo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Saldo sl = new Saldo(this);
                sl.ShowDialog();
            }            
        }
    }
}
