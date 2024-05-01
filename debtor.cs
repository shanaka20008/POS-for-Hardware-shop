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
    public partial class debtor : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6SSJFT7K\\SQLEXPRESS;Initial Catalog=DSD_Hardware;Integrated Security=True");


        //add recode to the DB code.
        private void add_record()
        {
            try
            {
                string sqlADD;
                sqlADD = "insert into debtor(bill_no,debtor_name,TP,Items,owe,paid_am,Availabel_bal,date) values ('" + textBillNO.Text + "','" + textDna.Text + "','" + textTP.Text + "','" + richTextItem.Text + "','" + textOwe.Text + "','" + textPaAM.Text + "','" + textAvBal.Text + "','" + labelTime.Text + "')";
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

        //Data search part

        private void Search_recode()
        {
            try
            {
                string sqlsearch;
                sqlsearch = "select * from debtor where bill_no='" + textBillNO.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlsearch, con);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBillNO.Text = dr["bill_no"].ToString();
                    textDna.Text = dr["debtor_name"].ToString();
                    textTP.Text = dr["TP"].ToString();
                    richTextItem.Text = dr["Items"].ToString();
                    textOwe.Text = dr["owe"].ToString();
                    textPaAM.Text = dr["paid_am"].ToString();
                    textAvBal.Text = dr["Availabel_bal"].ToString();
                    dateTimePicker2.Text = dr["date"].ToString();
                }
                else
                    MessageBox.Show("Sorry! This bill number dose not exist");
                con.Close();
            }
            catch
            {

            }
        }
        public debtor()
        {
            InitializeComponent();
        }


        //add recode to the DB function call to button
        private void btnADD_Click(object sender, EventArgs e)
        {
            add_record();
        }

        //search button code
        private void btnSE_Click(object sender, EventArgs e)
        {
            Search_recode();
        }

        // data grid view code 
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            con.Open();
            {

                SqlDataAdapter sqlda = new SqlDataAdapter("select * from debtor", con);
                DataTable dtb1 = new DataTable();
                sqlda.Fill(dtb1);

                dgv1.DataSource = dtb1;

            }
            con.Close();
        }

        //Ibeam controll
        private void textBillNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textDna.Focus();
            }
        }
        //Ibeam controll
        private void textDna_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textTP.Focus();
            }
        }
        //Ibeam controll
        private void textTP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                richTextItem.Focus();
            }
        }
        //Ibeam controll
        private void richTextItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                textOwe.Focus();
            }
        }
        //Ibeam controll
        private void textOwe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textPaAM.Focus();
            }
        }
        //Ibeam controll
        private void textPaAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                balence_calculation();
            }
        }

        //availabel balance calculation
        private void balence_calculation()
        {

            double paid_am, owe, bal;
            owe = double.Parse(textOwe.Text);
            paid_am = double.Parse(textPaAM.Text);

            bal = owe - paid_am;

            textAvBal.Text = bal.ToString();//balance amount pass to balance text box


        }
        //time add to time label(01)
        private void time()
        {
            labelTime.Text = DateTime.Now.ToShortDateString().ToString();
        }
        //taim label code(01.1)
        private void debtor_Load(object sender, EventArgs e)
        {
            time();

            //data grid viver load
            con.Open();
            {

                SqlDataAdapter sqlda = new SqlDataAdapter("select * from debtor", con);
                DataTable dtb1 = new DataTable();
                sqlda.Fill(dtb1);

                dgv1.DataSource = dtb1;

            }
            con.Close();
        }


        //delete button code
        private void btnDelete_Click(object sender, EventArgs e)
        {
              // delete function
        
            string sqlDel;
            DialogResult res = MessageBox.Show("Do you want delete this record?", "", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                sqlDel = "delete from debtor where bill_no='" + textBillNO.Text + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlDel, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record deleted !!");
                

                con.Close();
            }

        
    }
    }

    }
