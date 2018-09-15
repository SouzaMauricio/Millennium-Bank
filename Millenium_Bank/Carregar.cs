using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Millenium_Bank
{
    public partial class Carregar : Form
    {
        public Carregar()
        {
            InitializeComponent();
        }

        private void tim_Carregar_Tick(object sender, EventArgs e)
        {
            if (pgb_Carregar.Value < 100)
            {
                pgb_Carregar.Value = pgb_Carregar.Value + 2;
            }
            else
            {
                //Após o timer verifica se na sessão anterior foi marcado o ckb_lembrar ou se foi feito o logoff
                if (Properties.Settings.Default.LoginAutomatico)
                {
                    this.Hide();
                    tim_Carregar.Enabled = false;
                    Home hm = new Home();
                    hm.ShowDialog();
                    this.Close();
                }
                else
                {
                    this.Hide();
                    tim_Carregar.Enabled = false;
                    Login lg = new Login();
                    lg.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
