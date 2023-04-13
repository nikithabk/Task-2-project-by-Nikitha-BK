using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient; //connecting to sqlserver

namespace RTO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //to connect to sql
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-GTR3GR14\SQLEXPRESS;Initial Catalog=task;Integrated Security=True");
        string complianceType;
        string dateRange;
        string dateSelected1;
        string dateSelected2;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        // submit button code
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != string.Empty)     // for validation
                {
                    // for complianceType
                    if (radioButton1.Checked == true)
                    {
                        complianceType = radioButton1.Text;
                    }
                    else if (radioButton2.Checked == true)
                    {
                        complianceType = radioButton2.Text;
                    }
                    else if (radioButton3.Checked == true)
                    {
                        complianceType = radioButton3.Text;
                    }
                    else if (radioButton4.Checked == true)
                    {
                        complianceType = radioButton4.Text;
                    }
                    else
                    {
                        complianceType = radioButton5.Text;
                    }


                    //for dateRange
                    if (radioButton6.Checked == true)
                    {
                        dateRange = radioButton6.Text;
                        dateSelected1 = monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd");
                        textBox2.Text = dateSelected1;
                        con.Open();
                        // sql query to insert values in database
                        string result = "insert into RTODetails(employeeID,complianceType,dateRange,dateSelected) values (" + textBox1.Text + ",'" + complianceType + "','" + dateRange + "','" + textBox2.Text + "') ";
                        SqlCommand cmd = new SqlCommand(result, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Submitted sucessful");
                        con.Close();

                    }
                    else
                    {
                        dateRange = radioButton7.Text;
                        dateSelected1 = monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd");
                        textBox2.Text = dateSelected1;
                        dateSelected2 = monthCalendar1.SelectionEnd.Date.ToString("yyyy-MM-dd");
                        textBox3.Text = dateSelected2;
                        con.Open();
                        // sql query to insert values in database
                        string result = "insert into RTODetails(employeeID,complianceType,dateRange,dateSelected,dateSelectedTill) values (" + textBox1.Text + ",'" + complianceType + "','" + dateRange + "','" + textBox2.Text + "','" + textBox3.Text + "') ";
                        SqlCommand cmd = new SqlCommand(result, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Submitted sucessful");
                        con.Close();

                    }

                }
                else
                {
                    MessageBox.Show("You have not entered the values");
                }
            }
            catch (Exception u)
            {
                MessageBox.Show(u.Message);
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
        }

        // cancel or reset button code
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Focus();
            textBox2.Clear();
            textBox3.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            

            
        }

        // employeeID textbox code to only take digits
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "  ^ [0-9]"))
            {
                textBox1.Text = "";
            }
        }
    }
}
