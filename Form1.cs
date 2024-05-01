using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hardware
{
    public partial class HOME : Form
    {
        public HOME()
        {
            InitializeComponent();
        }

        //login page call
        private void lahardware_Click(object sender, EventArgs e)
        {

            LOGIN f1 = new LOGIN();
            f1.Show();
        }
        //login page call
        private void laAdress_Click(object sender, EventArgs e)
        {

            LOGIN f1 = new LOGIN();
            f1.Show();
        }
        //login page call
        private void HOME_MouseClick(object sender, MouseEventArgs e)
        {
            LOGIN f1 = new LOGIN();
            f1.Show();
        }
        //login page call

        private void laDSD_Click(object sender, EventArgs e)
        {
            LOGIN f1 = new LOGIN();
            f1.Show();
        }

        private void HOME_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LOGIN f1 = new LOGIN();
                f1.Show();
            }
        }
    }
}
