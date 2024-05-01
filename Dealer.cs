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
    public partial class Dealer : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6SSJFT7K\\SQLEXPRESS;Initial Catalog=DSD_Hardware;Integrated Security=True");

        //Data search part
        private void Search_recode()
        {
            try
            {
                string sqlsearch;
                sqlsearch = "select * from dealer where D_ID='" + textD_ID.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlsearch, con);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textDate.Text = dr["date"].ToString();
                    textTP.Text = dr["TP"].ToString();
                    textIN.Text = dr["item_name"].ToString();
                    textINO.Text = dr["item_NO"].ToString();
                    textPR.Text = dr["price"].ToString();
                    textTA.Text = dr["total_amount"].ToString();
                    textName2.Text = dr["dealer_name"].ToString();
                    textPaidAm.Text = dr["paid_amount"].ToString();
                    textBal.Text = dr["balence"].ToString();
                    textBQyt.Text = dr["bought_quantity"].ToString();

                }
                else
                    MessageBox.Show("Sorry! This dealer number dose not exist");
                con.Close();
            }
            catch
            {

            }
        }

        public Dealer()
        {
            InitializeComponent();
        }

        private void Dealer_Load(object sender, EventArgs e)
        {

        }
        //search button call
        private void btnsearch_Click(object sender, EventArgs e)
        {
            Search_recode();
        }

        //Ibeam controll using enter
        private void textD_ID1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textDName.Focus();
            }
        }
        
        private void textDName_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                textDate2.Focus();
            }
        }

        //Ibeam controll using enter
        private void textDate2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textTP2.Focus();
            }
        }
        //Ibeam controll using enter
        private void textTP2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textIN2.Focus();
            }
        }
        //Ibeam controll using enter
        private void textIN2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textINO2.Focus();
            }
        }
        //Ibeam controll using enter
        private void textINO2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textPR2.Focus();
            }
        }

        //Ibeam controll using enter
        private void textPR2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBQYT1.Focus();
            }
        }
        //Enter button code for call search function
        private void textD_ID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search_recode(); 
            }
        }
        //ibeam control 
        private void textTA2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textTA2.Focus();
            }
        }
        //ibeam control 
        private void textPA2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                balence_calculation();
                textBal2.Focus(); 
            }
        }
        //ibeam control 
        private void textTA2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textPA2.Focus();
            }
        }

        //ibeam control 
        private void textBQYT1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textTA2.Focus();
            }
        }

        //balance calculation part

        private void balence_calculation()
        {
            double Total_amount, Paid_amunt,balance;
            Total_amount = double.Parse(textTA2.Text);
            Paid_amunt = double.Parse(textPA2.Text);

            balance = Total_amount- Paid_amunt;

            textBal2.Text = balance.ToString();
        }

        //search part balance calculation part

        private void Search_balence_calculation()
        {
            double current_amount, Paid_amunt, balance;
            balance = double.Parse(textBal.Text);
            Paid_amunt = double.Parse(textPaidAm.Text);

            current_amount = balance - Paid_amunt;

            textNewBal.Text = current_amount.ToString();
        }


        //new balence calculation in search group box

        private void textPaidAm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search_balence_calculation();
            }
        }

        //taabel view label code

        private void LabTableView_Click(object sender, EventArgs e)
        {
            dealerGridView f1 = new dealerGridView();
            f1.Show();
        }

        // recod add corde
        private void add_record()
        {
            try
            {
                string sqlADD;
                sqlADD = "insert into dealer(D_ID,item_name,bought_quantity,price,date,Item_NO,total_amount,TP,dealer_name,paid_amount,balence) values ('" + textD_ID1.Text + "','" + textIN2.Text + "','" + textBQYT1.Text + "','" + textPR2.Text + "','" + textDate2.Text + "','" + textINO2.Text + "','" + textTA2.Text + "','" + textTP2.Text + "','" + textDName.Text + "','" + textPA2.Text + "','" + textBal2.Text + "')";
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

        //update function

        private void update_record()
        {
            try
            {
                string sqlupdate;
                sqlupdate = "update dealer set paid_amount='" + textPA2.Text + "',item_name='" + textIN2.Text + "',bought_quantity='" + textBQYT1.Text + "',price='" + textPR2.Text + "',date='" + textDate2.Text + "',item_NO='" + textINO2.Text + "',total_amount='" + textTA2.Text + "',TP='" + textTP2.Text + "',dealer_name='" + textDName.Text + "', balence='" + textBal2.Text + "'where D_ID='" + textD_ID1.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlupdate, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record updated!");
                con.Close();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        //add recode function call to add button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            add_record();
        }

        //update button code

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            update_record();
        }

        //clera function
        private void clear()
        {

            textPA2.Clear();
            textIN2.Clear();
            textBQYT1.Clear();
            textPR2.Clear();
            textDate2.Clear();
            textINO2.Clear();
            textPR.Clear();
            textTA2.Clear();
            textTP2.Clear();
            textDName.Clear();
            textBal2.Clear();
            textD_ID1.Clear();

        }

        //clera button code 

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }


        //update function in show data grupe box

        private void update_record_2()
        {
            try
            {
                string sqlupdate;
                sqlupdate = "update dealer set paid_amount='" + textPaidAm.Text + "', balence='" + textNewBal.Text + "'where D_ID='" + textD_ID.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlupdate, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record updated!");
                con.Close();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        //update button 2 code

        private void btnUpdate2_Click(object sender, EventArgs e)
        {
            update_record_2();
        }

        //2 clear button code

        private void btnClear2_Click(object sender, EventArgs e)
        {
            textD_ID.Clear();
            textName2.Clear();
            textDate.Clear();
            textTP.Clear();
            textIN.Clear();
            textINO.Clear();
            textPR.Clear();
            textBQyt.Clear();
            textTA.Clear();
            textBal.Clear();
            textPaidAm.Clear();
            textNewBal.Clear();
        }

        //delete button code

        // delete function
        private void delete_record()
        {
            string sqlDel;
            DialogResult res = MessageBox.Show("Do you want delete this record?", "", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                sqlDel = "delete from dealer where D_ID='" + textD_ID.Text + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlDel, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record deleted !!");
                textD_ID.Clear();
                textName2.Clear();
                textDate.Clear();
                textTP.Clear();
                textIN.Clear();
                textINO.Clear();
                textPR.Clear();
                textBQyt.Clear();
                textTA.Clear();
                textBal.Clear();
                textPaidAm.Clear();
                textNewBal.Clear();

                con.Close();
            }

        }

        //delete  button code
        private void btnDel_Click(object sender, EventArgs e)
        {
            delete_record();
        }
    }
}
 