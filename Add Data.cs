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
    public partial class Add_Data : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6SSJFT7K\\SQLEXPRESS;Initial Catalog=DSD_Hardware;Integrated Security=True");


        // recod add corde
        private void add_record()
        {
            try
            {
                string sqlADD;
                sqlADD = "insert into DSD_data(item_no,price,quantity,name) values ('" + textIN.Text + "','" + textPR.Text + "','" + textqu.Text + "','" + textNA.Text + "')";
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
        public Add_Data()
        {
            InitializeComponent();
            
        }
        //add button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            add_record();
        }
        // delete function
        private void delete_record()
        {
            string sqlDel;
            DialogResult res = MessageBox.Show("Do you want delete this record?", "", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                sqlDel = "delete from DSD_data where item_no='" + textIN.Text + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlDel, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record deleted !!");
                textIN.Clear();
                textNA.Clear();
                textPR.Clear();
                textqu.Clear();
                
                con.Close();
            }

        }
        //Delete button

        private void btnDEL_Click(object sender, EventArgs e)
        {
            delete_record();
        }

        //update record function
        private void update_record()
        {
            try
            {
                string sqlupdate;
                sqlupdate = "update DSD_data set price='" + textPR.Text + "',quantity='" + textqu.Text + "',name='" + textNA.Text + "'where item_no='" + textIN.Text + "'";
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
        //update button

        private void btnUP_Click(object sender, EventArgs e)
        {
            update_record();
        }
        //clear button
        private void clear()
        {

            textIN.Clear();
            textNA.Clear();
            textPR.Clear();
            textqu.Clear();
            
        }
        //clear button
        private void btnCL_Click(object sender, EventArgs e)
        {
            clear();
        }
        //Ibeam control using enter
        private void textIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textNA.Focus();
            }
        }
        //Ibeam control using enter
        private void textNA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textPR.Focus();
            }
        }
        //Ibeam control using enter
        private void textPR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textqu.Focus();
            }
        }
        //add data using enter key
        private void textqu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_record();
            }
        }

        private void Add_Data_Load(object sender, EventArgs e)
        {

        }
    }
}
