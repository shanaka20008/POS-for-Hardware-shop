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
    public partial class PASSWORD_UPDATE : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6SSJFT7K\\SQLEXPRESS;Initial Catalog=DSD_Hardware;Integrated Security=True");

        //update record function

        private void update_newPassword()
        {
            string username, password;

            username = txtU_nm.Text;
            password = txtCP.Text;

            try
            {
                string querry = "SELECT * FROM admin_LOG WHERE username ='" + txtU_nm.Text + "'AND password ='" + txtCP.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, con);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = txtU_nm.Text;
                    password = txtCP.Text;

                    //Password updating!
                    try
                    {
                        string sqlupdate;
                        sqlupdate = "update admin_LOG set password= '" + txtN_p.Text + "' where username='" + txtU_nm.Text + "'";
                        SqlCommand cmd = new SqlCommand(sqlupdate, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Password updated!");
                        con.Close();

                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }

                }
                else
                {
                    MessageBox.Show("Sorry Current password or username incorrect !", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        public PASSWORD_UPDATE()
        {
            InitializeComponent();
        }

       

        //reset button call
        private void btnRest_Click(object sender, EventArgs e)
        {            
                update_newPassword();           
        }

        //back label

        private void laBack_Click(object sender, EventArgs e)
        {
       
            LOGIN f1 = new LOGIN();
            f1.Show();

            //closing form
            this.Close();
        }
        //Ibeam controll
        private void txtU_nm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCP.Focus();
            }
        }
        //Ibeam controll
        private void txtCP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtN_p.Focus();
            }
        }
        //password update using enter key
        private void txtN_p_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                update_newPassword();
            }
        }
    }
}
