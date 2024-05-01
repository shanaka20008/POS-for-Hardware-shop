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
    public partial class Calculator : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6SSJFT7K\\SQLEXPRESS;Initial Catalog=DSD_Hardware;Integrated Security=True");

        public Calculator()
        {
            InitializeComponent();
        }

        // recod add corde
        private void add_record()
        {
            try
            {
                string sqlADD;
                sqlADD = "insert into cal(it_no,price,name) values ('" + textIN.Text + "','" + textP1KG.Text + "','" + textNA.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlADD, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted the record!");
                con.Close();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }
        //update button
        private void btnUP_Click(object sender, EventArgs e)
        {
            add_record();
        }
        //Data search part
        private void Search_recode()
        {
            try
            {
                string sqlsearch;
                sqlsearch = "select * from cal where it_no='" + textIN2.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlsearch, con);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textNA2.Text = dr["name"].ToString();
                    textPR.Text = dr["price"].ToString();


                }
                else
                    MessageBox.Show("Sorry! This item number dose not exist");
                con.Close();
            }
            catch
            {

            }
        }
               //search button

        private void btnSE_Click(object sender, EventArgs e)
        {
            Search_recode();
        }
        //calculation part
        private void calculation()
        {
            try
            {
                string sqlsearch;              
                double gram, price, total; 
                
                sqlsearch = "select * from cal where it_no='" + textIN2.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlsearch, con);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    gram = double.Parse(textg.Text);
                    price = double.Parse(textPR.Text);

                    total = (price * gram) / 1000;

                    textprice.Text = total.ToString();


                }
                else
                    MessageBox.Show("Sorry! This recode empty");
                con.Close();
            }
            catch
            {

            }
        
        }
        //calculte button
        private void btncal_Click(object sender, EventArgs e)
        {
            calculation();
        }
        //Ibeam controll using enter
        private void textIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textNA.Focus();
            }
        }
        //Ibeam controll using enter
        private void textNA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textP1KG.Focus();
            }
            
        }
        //update function call using enter key
        private void textP1KG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_record(); 
            }
        }
        //search function call using enter key
        private void textIN2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search_recode();
                textg.Focus();
            }
        }
        //calculate function call using enter key
        private void textg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                calculation();
            }
        }

       
    }
}
