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
using System.IO;
using System.Drawing.Imaging;

namespace Millenium_Bank
{
    public partial class Comprovante : Form
    {
        private Sacar sacar;
        private Depositar depositar;
        private String tipo;

        public Comprovante()
        {
            InitializeComponent();
        }

        public Comprovante(Sacar sacar)
        {
            InitializeComponent();
            tipo = "Saque";

            lbl_Data.Text = lbl_Data.Text + DateTime.Now.ToString("dd/MM/yyyy");
            lbl_Hora.Text = lbl_Hora.Text + DateTime.Now.ToString("HH:mm:ss");

            this.sacar = sacar;

            DTO_Operacoes obj = new DTO_Operacoes();

            obj.Conta = sacar.dados.Numero;

            lbl_Conta.Text = obj.Conta;

            obj = BLL_Sacar.Dados(obj.Conta);

            lbl_Banco.Text = lbl_Banco.Text + obj.Banco;
            lbl_Agencia.Text = lbl_Agencia.Text + obj.Agencia;
            lbl_Conta.Text = "CONTA " + obj.Tipo_Conta.ToUpper() + " : " + lbl_Conta.Text;
            lbl_Cliente.Text = lbl_Cliente.Text + obj.Cliente.ToUpper();

            try
            {
                lbl_SaldoAnterior.Text = "R$ " + Sacar.aux_sal.ToString("0.00");
                lbl_Valor_Saque.Text = "R$ " + Sacar.aux_vl.ToString("0.00");
                lbl_SaldoDisponivel.Text = "R$ " + Sacar.aux_disp.ToString("0.00");
            }
            catch
            {

            }

            lbl_SaldoAnterior.TextAlign = ContentAlignment.MiddleRight;
            lbl_Valor_Saque.TextAlign = ContentAlignment.MiddleRight;
            lbl_SaldoDisponivel.TextAlign = ContentAlignment.MiddleRight;
        }

        public Comprovante(Depositar depositar)
        {
            this.depositar = depositar;
            InitializeComponent();
            tipo = "Deposito";

            lbl_Data.Text = lbl_Data.Text + DateTime.Now.ToString("dd/MM/yyyy");
            lbl_Hora.Text = lbl_Hora.Text + (DateTime.Now.ToString("HH:mm:ss"));


            DTO_Operacoes obj = new DTO_Operacoes();

            obj.Conta = depositar.dados.Numero;

            lbl_Conta.Text = obj.Conta;

            obj = BLL_Sacar.Dados(obj.Conta);


            lbl_comprovante.Text = "COMPROVANTE DE DEPOSITO";
            lbl_Banco.Text = lbl_Banco.Text + obj.Banco;
            lbl_Agencia.Text = lbl_Agencia.Text + obj.Agencia;
            lbl_Conta.Text = "CONTA " + obj.Tipo_Conta.ToUpper() + " : " + lbl_Conta.Text;
            lbl_Cliente.Text = lbl_Cliente.Text + obj.Cliente.ToUpper();
            lbl_Vlr.Text = "VALOR DE DEPÓSITO";

            try
            {
                lbl_SaldoAnterior.Text = "R$ " + Depositar.aux_sal.ToString("0.00");
                lbl_Valor_Saque.Text = "R$ " + Depositar.aux_vl.ToString("0.00");
                lbl_SaldoDisponivel.Text = "R$ " + Depositar.aux_disp.ToString("0.00");
            }
            catch
            {

            }

            lbl_SaldoAnterior.TextAlign = ContentAlignment.MiddleRight;
            lbl_Valor_Saque.TextAlign = ContentAlignment.MiddleRight;
            lbl_SaldoDisponivel.TextAlign = ContentAlignment.MiddleRight;
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            Bitmap printscreen = new Bitmap(281, 426);
            Graphics graphics = Graphics.FromImage(printscreen);

            graphics.CopyFromScreen(this.Bounds.X, this.Bounds.Y, -25, -22, this.Bounds.Size);

            SaveFileDialog saveImageDialog = new SaveFileDialog();

            saveImageDialog.Title = "Selecionar caminho do Ficheiro:";

            saveImageDialog.Filter = "JPG Image|*.jpg|Gif Image|*.gif|PNG Image|*.png|All files (*.*)|*.*";

            saveImageDialog.FileName = ("Comprovante_" + tipo + "_" + lbl_Data.Text.Replace('/', '_').Replace(':', '_') + "_" + lbl_Hora.Text.Replace(':', '_')).Trim();


            if (saveImageDialog.ShowDialog() == DialogResult.OK)
            {
                printscreen.Save(saveImageDialog.FileName, ImageFormat.Png);
            }
        }
    }
}
