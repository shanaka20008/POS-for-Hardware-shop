using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace hardware
{
    public partial class Bill_History : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6SSJFT7K\\SQLEXPRESS;Initial Catalog=DSD_Hardware;Integrated Security=True");

        public Bill_History()
        {
            InitializeComponent();
        }

        private void Bill_History_Load(object sender, EventArgs e)
        {
            

            // data grid view code           
            con.Open();
            {

                SqlDataAdapter sqlda = new SqlDataAdapter("select * from bill_history", con);
                DataTable dtb1 = new DataTable();

                sqlda.Fill(dtb1);

                dataGridView1.DataSource = dtb1;

            }
            con.Close();
        }
    }
}
