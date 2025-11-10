using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hospital_charges
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }



        private void button1_Click(object sender, EventArgs e)
        {
            textBoxTotal.Text = CalcTotalCharges().ToString();
            //call totalcharges value to display in label



        }

        private int CalcStayCharges(int days)
        {
            return 350 * days;
            //const of 350 per day
        }

        private double CalcMiscCharges()
        {

            double charges = 0, meds, surg, lab, phys;
            //double total charges and set base to 0

            if (double.TryParse(textBox2.Text, out meds) //if statement for proper variable input
                && double.TryParse(textBox3.Text, out surg)
                && double.TryParse(textBox4.Text, out lab)
                && double.TryParse(textBox5.Text, out phys)
                )
            //convert values from textboxes to add to the total charges 
            {
                charges += meds + surg + lab + phys;
                //adds the numeric values
            }
            else
            {
                MessageBox.Show("Please input a value for all textboxes"); //excpetion
            }
            return charges;
            //returns method



        }

        private double CalcTotalCharges()
        {
            int days; //declare days
            double charges = 0; //declare charges 
            if (int.TryParse(textBox1.Text, out days)) //parse textboxes to label and display total value
            {
                charges += CalcStayCharges(days);
                charges += CalcMiscCharges();
            }
            else
            {
                MessageBox.Show("Please input value for all textboxes"); //excpetion
            }

            return charges;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            //clear textboxes

            textBoxTotal.Text = string.Empty;
            //clear total label

        }



        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
