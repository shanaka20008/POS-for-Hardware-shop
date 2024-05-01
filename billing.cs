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
    public partial class billing : Form
    {
        DataTable table = new DataTable("table"); //data grid view tabel related.

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6SSJFT7K\\SQLEXPRESS;Initial Catalog=DSD_Hardware;Integrated Security=True");

        public billing()
        {
            InitializeComponent();
        }
        //Data search part
        private void Search_recode()
        {
            try
            {
                string sqlsearch;
                sqlsearch = "select * from DSD_data where item_no='" + textIN.Text + "'";
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
        //enter key code
        private void textIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search_recode();
                textQU1.Focus();
                textQU1.Clear();  //quantity text box clear

            }
        }
        //zero input to text boxes
        private void zero()
        {
            try
           {
                string sqlsearch;
                sqlsearch = "select * from zero";
                SqlCommand cmd = new SqlCommand(sqlsearch, con);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textSubT.Text = dr["dis"].ToString();
                   textDis.Text = dr["dis"].ToString();
                    textGrandT.Text = dr["dis"].ToString();
                    textPaidA.Text = dr["dis"].ToString();
                    textBal.Text = dr["dis"].ToString();
                    textQU1.Text = dr["dis"].ToString();
                }

                con.Close();
            }
            catch
            {

            }
        }

        //sub total calculation
        public void sub_total()
        {
            int quantity;
            double price;
            double subTotal, subT;


            price = double.Parse(textPR.Text);
            quantity = int.Parse(textQU1.Text);
            subT = double.Parse(textSubT.Text);

            subTotal = (price * quantity) + subT;


            textSubT.Text = subTotal.ToString();

        }
        //update the quantity when buying

        private void update_record()
        {
            try
            {
                string sqlupdate;
                sqlupdate = "update DSD_data set quantity='" + textQU.Text + "'where item_no='" + textIN.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlupdate, con);
                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        //add button

        private void btnAdd_Click(object sender, EventArgs e)
        {

            // add recod to sales product
            add_record_salesProduct();


            int quantity, quantity2, newQ;
            quantity = int.Parse(textQU.Text);
            quantity2 = int.Parse(textQU1.Text);
            if (quantity2 <= quantity)        //quantity substraction part
            {
                sub_total();
                grand_total(); //grand total calculation
                add_data_gridView1();//data add to grid view
            }
            else MessageBox.Show("There are not enough availabel quantity!");

            newQ = quantity - quantity2;

            if (quantity2 <= quantity)
            {
                textQU.Text = newQ.ToString();
                update_record();                       //update quantity function
                textQU.Text = newQ.ToString();
            }



        }

        //sub tot function call using shift key

        private void textQU1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                

                int quantity, quantity2, newQ;
                quantity = int.Parse(textQU.Text);     //quantity substraction part
                quantity2 = int.Parse(textQU1.Text);
                if (quantity2 <= quantity)
                {
                    sub_total();
                    grand_total();//grand total calculation
                    add_data_gridView1();//data add to grid view
                    //add_record_salesProduct();//data add to sales pr data table
                }

                else MessageBox.Show("There are not enough availabel quantity!");

                newQ = quantity - quantity2;

                if (quantity2 <= quantity)
                {
                    textQU.Text = newQ.ToString();
                    update_record();                       //update quantity function
                    textQU.Text = newQ.ToString();
                }
                itemTotal_price();// //item total pricee calulation
                add_record_salesProduct();//recode add to data base

            }

            if (e.KeyCode == Keys.Up)
            {
                textIN.Focus();  //arrow up key code for move the Ibeam to Item NO
            }
        }
        // form load
        private void billing_Load(object sender, EventArgs e)
        {
            zero();  //zero gain to sub total text box when form load

            GenarateBillNumber();  //bill number genarate
            timelebel();//time pass to time label

            //data grid view columns load

            table.Columns.Add("item NO", Type.GetType("System.Int32"));
            table.Columns.Add("item Name", Type.GetType("System.String"));
            table.Columns.Add("quantity", Type.GetType("System.Int32"));
            table.Columns.Add("item price", Type.GetType("System.Double"));

            dataGridView1.DataSource = table;
        }

        //grand total calculation part
        private void grand_total()
        {

            double subtotal1;
            subtotal1 = int.Parse(textSubT.Text);
            textGrandT.Text = subtotal1.ToString();//sub total pass to grand total text box



        }



        //balence calculation part

        private void balence_calculation()
        {

            double grand_tot, paid_am, bal;
            grand_tot = double.Parse(textGrandT.Text);
            paid_am = double.Parse(textPaidA.Text);

            bal = paid_am - grand_tot;

            textBal.Text = bal.ToString();//balance amount pass to balance text box



        }

        private void textBal_KeyDown(object sender, KeyEventArgs e)
        {

        }


        //ballance calculation function call using enter key
        private void textPaidA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                balence_calculation();
                add_record_salesProduct_DT();
                //add o gain part
            }



        }
        //grid view data adding function
        private void add_data_gridView1()
        {
            table.Rows.Add(textIN.Text, textNa.Text, textQU1.Text, textPR.Text);
        }

        //return button
        private void btnreturn_Click(object sender, EventArgs e)
        {
            Return f1 = new Return();
            f1.Show();
        }

        //debtor button
        private void btnDebtor_Click(object sender, EventArgs e)
        {
            debtor f1 = new debtor();
            f1.Show();
        }

        //print button
        private void btnPrint_Click(object sender, EventArgs e)
        {
            add_record_billHistory();
        }


        //bill genarator
        private void GenarateBillNumber()
        {
            string orderNumber;
            Random rnd = new Random();
            long Orderpart1 = rnd.Next(500, 2999);
            int orderpart2 = rnd.Next(100, 500);

            orderNumber = Orderpart1 + "" + orderpart2;

            textBillNO.Text = orderNumber.ToString();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {

                //discount calculation
                double discount, presentage, subtotal, grand_total;

                presentage = int.Parse(textDis.Text);
                subtotal = int.Parse(textSubT.Text);

                discount = (subtotal * presentage) / 100;


                grand_total = subtotal - discount;

                textGrandT.Text = grand_total.ToString();
            }
            if (checkBox1.Checked == false)
            {
                double gg;
                gg = double.Parse(textSubT.Text);
                textGrandT.Text = gg.ToString();
            }
        }

        //recod add to seles
        private void add_record_sales()
        {
            try
            {
                string sqlADD;
                sqlADD = "insert into sales(sub_t,discount,grand_T,paid_AM,Balence) values ('" + textSubT.Text + "','" + textDis.Text + "','" + textGrandT.Text + "','" + textPaidA.Text + "','" + textBal.Text + "')";
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

        // recod add to seles product
        private void add_record_salesProduct()//(product_pr)
        {
            try
            {
                string sqlADD;
                sqlADD = "insert into product_pr(item_no,qyt,item_name,price,item_t_pr,bill_no) values ('" + textIN.Text + "','" + textQU1.Text + "','" + textNa.Text + "','" + textPR.Text + "','" + text_i_TP_PR.Text + "','" + textBillNO.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlADD, con);
                con.Open();
                cmd.ExecuteNonQuery();
                // MessageBox.Show("Inserted the record!");
                con.Close();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }


        }

        // recod add to seles product

        private void add_record_salesProduct_DT()
        {
            try
            {
                string sqlADD;
                sqlADD = "insert into product_dt(bill_no,sub_t,discount,grand_t,paid_am,balence) values ('" + textBillNO.Text + "','" + textSubT.Text + "','" + textDis.Text + "','" + textGrandT.Text + "','" + textPaidA.Text + "','" + textBal.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlADD, con);
                con.Open();
                cmd.ExecuteNonQuery();
                // MessageBox.Show("Inserted the record!");
                con.Close();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }


        }

        //time passe 
        private void timelebel()
        {

            laTime.Text = DateTime.Now.ToShortTimeString().ToString();
            laDate.Text = DateTime.Now.ToShortDateString().ToString();
        }

        // delete function
        private void delete_record()
        {
            string sqlDel;
            // DialogResult res = MessageBox.Show("Do you want delete this record?", "", MessageBoxButtons.YesNo);
            //if (res == DialogResult.Yes)
            {
                sqlDel = "delete from sales";
                sqlDel = "delete from sales_product";
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlDel, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // delete function
        private void delete_record_sales()
        {
            string sqlDel;
            // DialogResult res = MessageBox.Show("Do you want delete this record?", "", MessageBoxButtons.YesNo);
            //if (res == DialogResult.Yes)
            {
                sqlDel = "delete from sales";

                con.Open();
                SqlCommand cmd = new SqlCommand(sqlDel, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //refresh butoon 

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            delete_record();//delete recode
            delete_record_sales();
            zero();  //zero gain to sub total text box when form load

            GenarateBillNumber();  //bill number genarate
            timelebel();//time pass to time label


            billing f1 = new billing();
            f1.Show();

            //this.Close();


        }

        //item total pricee calulation

        private void itemTotal_price()
        {
            double price, total;
            int qyt;
            price = double.Parse(textPR.Text);
            qyt = int.Parse(textQU1.Text);
            total = price * qyt;

            text_i_TP_PR.Text = total.ToString();
        }

        //bill history function
        // recod add to seles
        private void add_record_billHistory()
        {
            try
            {
                string sqlADD;
                sqlADD = "insert into Bill_history(bill_no,amount,paid_am,balence,date,timee) values ('" + textBillNO.Text + "','" + textGrandT.Text + "','" + textPaidA.Text + "','" + textBal.Text + "','" + laDate.Text + "','" + laTime.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlADD, con);

                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }
    }

}


