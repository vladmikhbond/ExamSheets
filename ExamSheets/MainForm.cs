using ExamSheets.Models;
using Spire.Doc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ExamSheets
{
    public partial class MainForm : Form
    {
        Sheet _sheet; 
        public MainForm()
        {
         

            InitializeComponent();
            //var docFile = @"c:\111\TestDoc.doc";
            //var markFile = @"c:\111\000.txt";
            //try
            //{
            //    _sheet = new Sheet(docFile, "19.10", Check.Exam);
            //    _sheet.LoadMarks(markFile);

            //    statusStrip.Text = _sheet.WriteData();
            //    System.Diagnostics.Process.Start(_sheet.OutputPath);
            //} 
            //catch (Exception ex)
            //{
            //    dataBox.Text += "------------------\n" + ex.Message;
            //}
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openDocDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _sheet = new Sheet(openDocDialog.FileName, "19.10", Check.Exam);
                    _sheet.LoadMarks(dataBox.Text);

                    statusStrip.Text = _sheet.WriteData();
                    System.Diagnostics.Process.Start(_sheet.OutputPath);
                }
                catch (Exception ex)
                {
                    dataBox.Text += "------------------\n" + ex.Message;
                }
            }
        }
    }
}
