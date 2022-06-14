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
            person.ResumeCorrection();

            string text = ClauseDict.Substitute(person, feedRadio.Checked);
            string[] lines = text.Split('\n');

            // file name
            string dir = Path.GetDirectoryName(openFileDialog.FileName);
            string kind = feedRadio.Checked ? "відзив" : "рецензія";
            string group = person["@[group]"].Sentence;
            string name = person["@[name]"].Sentence.Replace(' ', '_').Replace('.', '_');
            string path = Path.Combine(dir, $"2022_Б_ПІ_{group}_{name}{kind}.docx");

            ClauseDict.CreateDoc(lines, path);
        }
    }
}
