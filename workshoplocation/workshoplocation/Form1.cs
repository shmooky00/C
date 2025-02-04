using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workshoplocation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int workshop = 0;
        double location = 0;
        double days = 0;
        double Rfee = 0;
        double Lfee = 0;
        double total = 0;


        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            workshop = listBox1.SelectedIndex;
            location = listBox2.SelectedIndex;

            switch (workshop)
            {
                case 0:
                    Rfee = 1000;
                    days = 3;
                    break;

                    case 1:
                    Rfee = 800;
                    days = 3;
                    break;
                    case 2:
                    Rfee = 1500;
                        days = 3;
                    break;
                    case 3:
                    Rfee = 1300;
                        days = 3;
                    break;
                    case 4:
                    Rfee = 500;
                    days = 3;
                    break;
                    
                    

            }
            switch (location)
            {
                case 0:
                    Lfee = days * 150;
                    break;

                case 1:
                    Lfee = days * 225;
                    break;
                case 2:
                    Lfee = days * 175;
                    break;

                    case 3:
                    Lfee = days * 300;
                        break;
                    case 4:
                    Lfee = days * 175;
                    break;
                    case 5:
                    Lfee = days * 1500;
                    break;



            }
            total = Rfee * Lfee;

            label1.Text = Rfee.ToString();
            label2.Text = Lfee.ToString();
            label3.Text = total.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
