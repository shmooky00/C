using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coin_toss
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //variable to indicate side up
            int sideUp;

            //create random object
            var rand = new Random();

            //get random integer between 0 and 1 
            sideUp = rand.Next(2);

            //show side up
            if (sideUp == 0)
            {
                //show tails
                tailsPictureBox.Visible = true;

                headsPictureBox .Visible = false;




            }
            else
            {
                headsPictureBox.Visible = true;
                tailsPictureBox.Visible = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
