using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace total_sales
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                //create array that read text file completely 
                string[] allLines = File.ReadAllLines("Sales.Txt"); //array that reads all lines of file
                double[] numbers = new double[allLines.Length]; //converts string into double
                int counter = 0; //start w 0
                double sum = 0; //start w 0

                    //populate alllines to numbers 
                    foreach (string value in allLines) //loop from 0 to end
                {
                    numbers[counter] = Convert.ToDouble(value); //numbers of counter, convert value from all lines to double
                    sum += numbers[counter]; //already converted to double so get sum of all
                    listBox1.Items.Add(numbers[counter]); //grab listbox items
                    counter++; //each number added 
                }
                MessageBox.Show("The Total = " + sum); //messagebox of total sum

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); //catch exception
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); //close 
        }
    }
}
