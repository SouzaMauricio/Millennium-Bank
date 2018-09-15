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
    public partial class Nova_Agencia : UserControl
    {
        public Nova_Agencia()
        {
            InitializeComponent();
            btn_Alterar.Enabled = false;
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            btn_Alterar.Enabled = false;

            try
            {
                DTO_Nova_Agencia obj = new DTO_Nova_Agencia();

                obj.Cod_Banco = txt_Cod_Banco.Text;
                obj.Numero_Agencia = txt_Agencia.Text;
                obj.Bairro = txt_Bairro.Text;

                MessageBox.Show(BLL_Validar_Agencia.ValidarAgencia(obj), "Millennium Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Limpar(this);


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            //btn_Cadastrar.Enabled = true;
            Limpar(this);
        }

        public static void Limpar(Nova_Agencia na)
        {
            na.txt_Cod_Banco.Clear();
            na.txt_Agencia.Clear();
            na.txt_Bairro.Clear();

            na.btn_Cadastrar.Enabled = true;
            na.btn_Alterar.Enabled = false;
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            //btn_Alterar.Enabled = true;
            //btn_Cadastrar.Enabled = false;
            DTO_Nova_Agencia agencia = new DTO_Nova_Agencia();

            try
            {
                agencia.Numero_Agencia = txt_Agencia.Text;
                
                agencia = BLL_Validar_Agencia.BuscarAgencia(txt_Agencia.Text.ToString());

                txt_Cod_Banco.Text = agencia.Cod_Banco;
                txt_Bairro.Text = agencia.Bairro;

                btn_Cadastrar.Enabled = false;
                btn_Alterar.Enabled = true;

                MessageBox.Show("Este Número de Agência já esta cadastrado!.", "Millennium Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            //btn_Cadastrar.Enabled = false;
            try
            {
                DTO_Nova_Agencia obj = new DTO_Nova_Agencia();

                obj.Cod_Banco = txt_Cod_Banco.Text;
                obj.Numero_Agencia = txt_Agencia.Text;
                obj.Bairro = txt_Bairro.Text;

                MessageBox.Show(BLL_Validar_Agencia.Atualizar(obj), "Millennium Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Limpar(this);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
