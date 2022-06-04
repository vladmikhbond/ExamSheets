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

        private void fishButton_Click(object sender, EventArgs e)
        {
            ClauseDict person = new ClauseDict(personBox.Text);
            personBox.Text = ClauseDict.Substitute(person, feedRadio.Checked);
            ClauseDict.CreateDoc(personBox.Lines, openFileDialog.FileName);
        }
    }
}
