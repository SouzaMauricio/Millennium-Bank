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
    public partial class Saldo : Form
    {
        private Operacoes operacoes;

        public Saldo(Operacoes operacoes)
        {
            InitializeComponent();
            try
            {
                this.operacoes = operacoes;

                this.operacoes = operacoes;

                string aux = operacoes.txt_Cliente.Text;
                string aux2 = operacoes.cbo_TipoConta.Text;
                string aux3 = operacoes.txt_Banco.Text;


                DTO_Operacoes op = new DTO_Operacoes();
                op = BLL_Validar_Operacoes.Dados_Conta(aux, aux3, aux2);

                lbl_Saldo.Text = lbl_Saldo.Text + op.Saldo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
