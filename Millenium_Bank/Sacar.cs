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
    public partial class Sacar : Form
    {
        private Operacoes operacoes;
        public DTO_Nova_Conta dados = new DTO_Nova_Conta();

        public static double aux_sal { get; set; }
        public static double aux_vl { get; set; }
        public static double aux_disp { get; set; }

        public Sacar(Operacoes operacoes)
        {
            InitializeComponent();            
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


                if (Convert.ToDouble(txt_Saldo.Text) <= 0)
                {
                    this.txt_Limite.Text = "0";
                }
                else if (Convert.ToDouble(txt_Saldo.Text) < 5000)
                {
                    this.txt_Limite.Text = (Convert.ToDouble(txt_Saldo.Text) + (Convert.ToDouble(txt_Saldo.Text) * .60)).ToString("0.00");
                }
                else
                {
                    this.txt_Limite.Text = (Convert.ToDouble(txt_Saldo.Text) + (Convert.ToDouble(txt_Saldo.Text) * .80)).ToString("0.00");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Dados Inválidos");
            }
        }


        private void btn_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btn_Sacar_Click(object sender, EventArgs e)
        {
            try
            {       
      
                DTO_Saque obj = new DTO_Saque();

                obj.Valor_Saque = Convert.ToDouble(txt_Valor_Saque.Text);
                obj.Limite = Convert.ToDouble(txt_Limite.Text);
                obj.Saldo = Convert.ToDouble(txt_Saldo.Text);

                try
                {
                    aux_sal = Convert.ToDouble(txt_Saldo.Text);
                    aux_vl = Convert.ToDouble(txt_Valor_Saque.Text);
                }
                catch
                {

                }

                obj = BLL_Sacar.ValidarSaque(obj, dados.Numero);

                txt_Saldo.Text = obj.Saldo.ToString("0.00");

                MessageBox.Show("Saque efetuado com sucesso!", "Millennium Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                aux_disp = Convert.ToDouble(obj.Saldo);
                                                
                if (Convert.ToDouble(txt_Saldo.Text) <= 0)
                {
                    this.txt_Limite.Text = "0";
                }
                else if (Convert.ToDouble(txt_Saldo.Text) < 5000)
                {
                    this.txt_Limite.Text = (Convert.ToDouble(txt_Saldo.Text) + (Convert.ToDouble(txt_Saldo.Text) * .60)).ToString("0.00");
                }
                else
                {
                    this.txt_Limite.Text = (Convert.ToDouble(txt_Saldo.Text) + (Convert.ToDouble(txt_Saldo.Text) * .80)).ToString("0.00");
                }

                Comprovante sq = new Comprovante(this);
                sq.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            txt_Valor_Saque.Text = txt_Valor_Saque.Text + 1;
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            txt_Valor_Saque.Text = txt_Valor_Saque.Text + 2;
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            txt_Valor_Saque.Text = txt_Valor_Saque.Text + 3;
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            txt_Valor_Saque.Text = txt_Valor_Saque.Text + 4;
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            txt_Valor_Saque.Text = txt_Valor_Saque.Text + 5;
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            txt_Valor_Saque.Text = txt_Valor_Saque.Text + 6;
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            txt_Valor_Saque.Text = txt_Valor_Saque.Text + 7;
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            txt_Valor_Saque.Text = txt_Valor_Saque.Text + 8;
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            txt_Valor_Saque.Text = txt_Valor_Saque.Text + 9;
        }

        private void btn_P_Click(object sender, EventArgs e)
        {
            txt_Valor_Saque.Text = txt_Valor_Saque.Text + ",";
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            txt_Valor_Saque.Text = txt_Valor_Saque.Text + 0;
        }

        private void btn_Apagar_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Valor_Saque.Text = txt_Valor_Saque.Text.Remove(txt_Valor_Saque.TextLength - 1);
            }
            catch
            {

            }
        }

        private void txt_Valor_Saque_KeyPress(object sender, KeyPressEventArgs e)
        {
            string caracteresNegados = "ABCDEFGHIJKLMNOPQRSTUVWXYZÇ₢_;><[]{}´`+=-^~'.!@#$%¨&*()ªº°?/\"|";

            if (caracteresNegados.Contains(e.KeyChar.ToString().ToUpper()))
            {
                e.Handled = true;
            } 
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            txt_Valor_Saque.Clear();
        }
    }
}
