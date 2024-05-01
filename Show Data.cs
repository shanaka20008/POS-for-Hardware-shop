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
    public partial class Show_Data : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6SSJFT7K\\SQLEXPRESS;Initial Catalog=DSD_Hardware;Integrated Security=True");

        //data input part to combobox

        private void fill_pack_id()
        {
            SqlDataAdapter gg = new SqlDataAdapter("select item_no from DSD_data", con);
            DataTable bb = new DataTable();
            gg.Fill(bb);
            comIN.DataSource = bb;
            comIN.DisplayMember = "item_no";
            comIN.ValueMember = "item_no";

        }

        //Data search part
        private void Search_recode()
        {
            try
            {
                string sqlsearch;
                sqlsearch = "select * from DSD_data where item_no='" + comIN.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlsearch, con);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textNa.Text = dr["name"].ToString();
                    textPR.Text = dr["price"].ToString();
                    textQU.Text = dr["quantity"].ToString();
                    
                }
                else
                    MessageBox.Show("Sorry! This item number dose not exist");
                con.Close();
            }
            catch
            {

            }
        }
        public Show_Data()
        {
            InitializeComponent();
        }
        //show data load code
        private void Show_Data_Load(object sender, EventArgs e)
        {
            fill_pack_id();

            // data grid view code           
            con.Open();
            {
               
                SqlDataAdapter sqlda = new SqlDataAdapter("select * from DSD_data", con);
                DataTable dtb1 = new DataTable();
                sqlda.Fill(dtb1);

                dgv1.DataSource = dtb1;

            }
            con.Close();
        }

        //search button click
        private void btnSE_Click(object sender, EventArgs e)
        {
            Search_recode();
        }

        private void comIN_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Search_recode();
            }
            
        }
    }
}
