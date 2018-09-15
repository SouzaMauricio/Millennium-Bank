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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txt_user.Focus();
        }
        private void btn_sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            DTO_Login obj = new DTO_Login();
            try
            {
                obj.User = txt_user.Text.ToString();
                obj.Senha = txt_senha.Text.ToString();
                

                if (BLL_Login.ValidarLogin(obj))
                {
                    //Verificar de o ckb_lembrar foi marcado para validar o login automatico
                    if (ckb_Lembrar.Checked)
                    {
                        Properties.Settings.Default.LoginAutomatico = true;
                    }
                    else
                    {
                        Properties.Settings.Default.LoginAutomatico = false;
                    }
                    Properties.Settings.Default.Save();
                    this.Hide();
                    Home hm = new Home();
                    hm.ShowDialog();
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //Validar o efeito de Placeholder

        private void txt_user_Leave(object sender, EventArgs e)
        {
            if (txt_user.Text == "Usuário" || string.IsNullOrWhiteSpace(txt_user.Text.ToString()))
            {
                txt_user.ForeColor = Color.Gray;
                txt_user.Text = "Usuário";
            }
        }

        private void txt_senha_Leave(object sender, EventArgs e)
        {
            if (txt_senha.Text == "Senha" || string.IsNullOrWhiteSpace(txt_senha.Text.ToString()))
            {
                txt_senha.ForeColor = Color.Gray;
                txt_senha.Text = "Senha";
            }
        }

        private void txt_senha_Enter(object sender, EventArgs e)
        {
            if (txt_senha.Text == "Senha" || string.IsNullOrWhiteSpace(txt_senha.Text.ToString()))
            {
                txt_senha.Clear();
                txt_senha.ForeColor = Color.Black;
            }
        }

        private void txt_user_Enter(object sender, EventArgs e)
        {
            if (txt_user.Text == "Usuário" || string.IsNullOrWhiteSpace(txt_user.Text.ToString()))
            {
                txt_user.Clear();
                txt_user.ForeColor = Color.Black;
            }
        }

        private void lbl_esqueceu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login: admin\nSenha: abc123", "Lembrar Senha", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
