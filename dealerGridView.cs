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
    public partial class dealerGridView : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6SSJFT7K\\SQLEXPRESS;Initial Catalog=DSD_Hardware;Integrated Security=True");

        public dealerGridView()
        {
            InitializeComponent();
        }

        private void dealerGridView_Load(object sender, EventArgs e)
        {
            con.Open();
            {

                SqlDataAdapter sqlda = new SqlDataAdapter("select * from dealer", con);
                DataTable dtb1 = new DataTable();
                sqlda.Fill(dtb1);

                dGView1.DataSource = dtb1;

            }
            con.Close();
        }
    }
}
