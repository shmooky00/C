using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prime_number
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number;

            if (int.TryParse(textBox1.Text, out number))
            {
                if (IsPrime(number))
                {
                    primeLabel.Text = $"{number} is a prime number.";
                }
                else
                {
                    primeLabel.Text = $"{number} is not a prime number.";
                }
            }
            else
            {
                primeLabel.Text = "Please enter a valid integer.";
            }

        }
        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

           

            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;

        }

    }
}
