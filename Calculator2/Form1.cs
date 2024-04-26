using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.TextChanged -= textBox1_TextChanged;

            try
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    double number = double.Parse(textBox1.Text.Replace(",", ""));
                    textBox1.Text = number.ToString("#,##0"); 
                    textBox1.SelectionStart = textBox1.Text.Length;
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = "";
            }

            textBox1.TextChanged += textBox1_TextChanged;
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.TextChanged -= textBox2_TextChanged; 

            try
            {
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    double number = double.Parse(textBox2.Text.Replace(",", "")); 
                    textBox2.Text = number.ToString("#,##0"); 
                    textBox2.SelectionStart = textBox2.Text.Length; 
                }
            }
            catch (Exception ex)
            {
                textBox2.Text = "";
            }

            textBox2.TextChanged += textBox2_TextChanged;
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Fill up all fields");
                return;
            }

            if(textBox3.Text == "+" || textBox3.Text == "-" || textBox3.Text == "*" || textBox3.Text == "/")
            {
                if (textBox3.Text == "+")
                {
                    double result = double.Parse(textBox1.Text) + double.Parse(textBox2.Text);
                    label1.Text = result.ToString("#,##0");
                }

                if (textBox3.Text == "-")
                {
                    double result = double.Parse(textBox1.Text) - double.Parse(textBox2.Text);
                    label1.Text = result.ToString("#,##0");
                }

                if (textBox3.Text == "*")
                {
                    double result = double.Parse(textBox1.Text) * double.Parse(textBox2.Text);
                    label1.Text = result.ToString("#,##0");
                }

                if (textBox3.Text == "/")
                {
                    double result = double.Parse(textBox1.Text) / double.Parse(textBox2.Text);
                    label1.Text = result.ToString("#,##0");
                }
            }
            else
            {
                MessageBox.Show("Invalid Operator");
                return;
            }
        }
    }
}
