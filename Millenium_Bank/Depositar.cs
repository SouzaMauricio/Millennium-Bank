using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Millennium_Bank_DTO;
using Millennium_Bank_BLL;

namespace Millenium_Bank
{
    public partial class Depositar : Form
    {
        private Operacoes operacoes;
        public DTO_Nova_Conta dados = new DTO_Nova_Conta();

        public static double aux_sal { get; set; }
        public static double aux_vl { get; set; }
        public static double aux_disp { get; set; }

        public Depositar()
        {
            InitializeComponent();
        }

        public Depositar(Operacoes operacoes)
        {
            InitializeComponent();

            this.operacoes = operacoes;

            try
            {
                this.operacoes = operacoes;

                string aux = operacoes.txt_Cliente.Text;
                string aux2 = operacoes.cbo_TipoConta.Text;
                string aux3 = operacoes.txt_Banco.Text;

                DTO_Operacoes op = new DTO_Operacoes();
                dados.Numero = operacoes.txt_Conta.Text;
                op = BLL_Validar_Operacoes.Dados_Conta(aux, aux3, aux2);

                txt_Saldo.Text = op.Saldo;
            }
            catch (Exception ex)
            {
                throw new Exception("Dados Inválidos!");
            }
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            txt_Valor_Deposito.Text = txt_Valor_Deposito.Text + 1;
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            txt_Valor_Deposito.Text = txt_Valor_Deposito.Text + 2;
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            txt_Valor_Deposito.Text = txt_Valor_Deposito.Text + 3;
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            txt_Valor_Deposito.Text = txt_Valor_Deposito.Text + 4;
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            txt_Valor_Deposito.Text = txt_Valor_Deposito.Text + 5;
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            txt_Valor_Deposito.Text = txt_Valor_Deposito.Text + 6;
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            txt_Valor_Deposito.Text = txt_Valor_Deposito.Text + 7;
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            txt_Valor_Deposito.Text = txt_Valor_Deposito.Text + 8;
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            txt_Valor_Deposito.Text = txt_Valor_Deposito.Text + 9;
        }

        private void btn_P_Click(object sender, EventArgs e)
        {
            txt_Valor_Deposito.Text = txt_Valor_Deposito.Text + ",";
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            txt_Valor_Deposito.Text = txt_Valor_Deposito.Text + 0;
        }

        private void btn_Apagar_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Valor_Deposito.Text = txt_Valor_Deposito.Text.Remove(txt_Valor_Deposito.TextLength - 1);
            }
            catch
            {

            }
        }

        public void btn_Depositar_Click(object sender, EventArgs e)
        {
            //double aux;

            try
            {
                DTO_Deposito obj = new DTO_Deposito();

                obj.Valor_Deposito = txt_Valor_Deposito.Text;
                obj.Saldo = Convert.ToDouble(txt_Saldo.Text);

                try
                {
                    aux_sal = Convert.ToDouble(txt_Saldo.Text);
                    aux_vl = Convert.ToDouble(txt_Valor_Deposito.Text);
                }
                catch
                {

                }
                
                obj = BLL_Depositar.Validar_Deposito(obj, dados.Numero);

                txt_Saldo.Text = obj.Saldo.ToString("0.00");

                MessageBox.Show("Depósito efetuado com sucesso!", "Millennium Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);

                aux_disp = Convert.ToDouble(obj.Saldo);

                Comprovante dp = new Comprovante(this);
                dp.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_Valor_Deposito_KeyPress(object sender, KeyPressEventArgs e)
        {
            string caracteresNegados = "ABCDEFGHIJKLMNOPQRSTUVWXYZÇ₢_;><[]{}´`+=-^~'.!@#$%¨&*()ªº°?/\"|";

            if (caracteresNegados.Contains(e.KeyChar.ToString().ToUpper()))
            {
                e.Handled = true;
            }
        }
    }
}
