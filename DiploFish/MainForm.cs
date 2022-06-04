using DiploFish.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiploFish
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                personBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            ClauseDict person = new ClauseDict(personBox.Text);
            ClauseDict data;
            string template;
            if (feedRadio.Checked)
            {
                data = ClauseDict.FromFile(@"data\dataF.txt");
                template = File.ReadAllText(@"data\templateF.txt");
            } 
            else
            {
                data = ClauseDict.FromFile(@"data\dataR.txt");
                template = File.ReadAllText(@"data\templateR.txt");
            }
            personBox.Text = ClauseDict.Substitute(template, data, person);
        }

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }
    }
}
