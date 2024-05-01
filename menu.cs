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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        //billing form loading code

        private void billingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            billing f1 = new billing();
            f1.Show();
        }
        //calculator form loading code
        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculator f1 = new Calculator();
            f1.Show();
        }
        //Bill_History form loading code

        private void billHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bill_History f1 = new Bill_History();
            f1.Show();
        }
        //Dealer form loading code
        private void dealerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dealer f1 = new Dealer();
            f1.Show();
        }

        //Show data form loading code
        private void showDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Data f1 = new Show_Data();
            f1.Show();
        }

        //Add_data form loading code
        private void addDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Data f1 = new Add_Data();
            f1.Show();
        }
    }
}
