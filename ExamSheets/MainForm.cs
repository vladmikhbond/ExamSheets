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
            var docFile = @"c:\111\TestDoc.doc";
            var markFile = @"c:\111\000.txt";

            InitializeComponent();

            try
            {
                _sheet = new Sheet(docFile, "19.10", Check.Exam);
                _sheet.LoadMarks(markFile);

                messageBox.Text = _sheet.WriteData();
                System.Diagnostics.Process.Start(_sheet.OutputPath);
            } 
            catch (Exception ex)
            {
                messageBox.Text = ex.Message;
            }
        }
    }
}
