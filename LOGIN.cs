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
    public partial class LOGIN : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6SSJFT7K\\SQLEXPRESS;Initial Catalog=DSD_Hardware;Integrated Security=True");
        public LOGIN()
        {
            InitializeComponent();
        }
        

        //log in button  //loging and loging checking
        private void btn_login_Click_1(object sender, EventArgs e)
        {
            string username, password;

            username = txtUN.Text;
            password = txtPW.Text;

            try
            {
                string querry = "SELECT * FROM admin_LOG WHERE username ='" + txtUN.Text + "'AND password ='" + txtPW.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, con);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = txtUN.Text;
                    password = txtPW.Text;


                    //maine menu lord
                    menu f1 = new menu();
                    f1.Show();
                    

                }
                else
                {
                    MessageBox.Show("Invalid password or username !", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                con.Close();
            }


        }
        //link of password update
        private void laUpdate_Click(object sender, EventArgs e)
        {
            PASSWORD_UPDATE f1 = new PASSWORD_UPDATE();
            f1.Show();
            this.Close();
        }

        //Ibeam control using enter
        private void txtUN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPW.Focus();
            }
        }

       
    }
}
