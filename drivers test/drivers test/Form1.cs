using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drivers_test
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }

        private char GetSelectedAnswers(GroupBox groupBox) 
            //collect user answers from groupboxes
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked) //if buttons checked
                {
                    return radioButton.Text[0]; //return
                }
            }
            return '\0'; //if no answer then false
        }
            

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); //exit button
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            char[] userAnswers = //stores user answers
            {
                GetSelectedAnswers(groupBox1),
                GetSelectedAnswers(groupBox2),
                GetSelectedAnswers(groupBox3), //groupboxes selected button
                GetSelectedAnswers(groupBox4),
                GetSelectedAnswers(groupBox5),
            };

            char[] correctAnswers = { 'A', 'C', 'B', 'D', 'C' }; //correct answers

            int correctCount = userAnswers.Where((answer, index) => 
            answer == correctAnswers[index]).Count(); //compares the selected w/ answer 
         
                    MessageBox.Show($"You failed! {correctCount} out of 5 questions right."); //message
                
            if (correctCount >= 4) //if = or higher than 4, right
            {
                MessageBox.Show("You have passed!");//message
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
