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
    public partial class @Return : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6SSJFT7K\\SQLEXPRESS;Initial Catalog=DSD_Hardware;Integrated Security=True");

        public @Return()
        {
            InitializeComponent();
        }

        //search button
        private void btnSearch_Click(object sender, EventArgs e)

        {
            try
            {
                string sqlsearch;
                sqlsearch = "select * from DSD_data where item_no='" + textItemNO.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlsearch, con);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textItemNO.Text = dr["item_no"].ToString();
                    textPrice.Text = dr["price"].ToString();
                    textQyt.Text = dr["quantity"].ToString();
                    textNA.Text = dr["name"].ToString();
                }
                else
                    MessageBox.Show("Sorry! This bill number dose not exist");
                con.Close();
            }
            catch
            {

            }
        }

        //availabel balance calculation
        private void quntityupdate()
        {

            int qyt, addQyt, newqyt;
            qyt = int.Parse(textQyt.Text);
            addQyt = int.Parse(textREqyt.Text);

            newqyt = qyt + addQyt;

            lblQyt.Text = newqyt.ToString();//balance amount pass to balance text box
        }

            //update Quantity function
        private void update_record()
        {
            try
            {
                string sqlupdate;
                sqlupdate = "update DSD_data set quantity='" + lblQyt.Text+ "'where item_no='" + textItemNO.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlupdate, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Quantity updated!");
                con.Close();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
       
        //add quantity to label
        private void textREqyt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                quntityupdate();
            }
        }

        //add button call to update function

        private void btnadd_Click(object sender, EventArgs e)        
        {
            quntityupdate();
            update_record();
        }
        //enter button code
        private void textItemNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                textREqyt.Focus();
            }
        }
    }
    }

