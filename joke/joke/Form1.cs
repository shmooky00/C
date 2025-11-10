using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace joke
{
    public partial class jokepunchline : Form
    {
        public jokepunchline()
        {
            InitializeComponent();
        }

        private void setupButton_Click(object sender, EventArgs e)
        {
            jokeLabel.Text = "What makes a tissue dance?";
        }

        private void jokeButton_Click(object sender, EventArgs e)
        {
            jokeLabel.Text = "Putting a lil boogie in it.";
        }
    }
}
