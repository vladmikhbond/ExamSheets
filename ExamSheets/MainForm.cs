using ExamSheets.Models;
using System;
using System.Windows.Forms;

namespace ExamSheets
{
    public partial class MainForm : Form
    {
        Sheet _sheet; 
        public MainForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openDocDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _sheet = new Sheet(openDocDialog.FileName, dateBox.Text, examRadio.Checked);
                    _sheet.LoadMarks(dataBox.Text.Trim());

                    messageBox.Text = _sheet.WriteData();
                    System.Diagnostics.Process.Start(_sheet.OutputPath);
                }
                catch (Exception ex)
                {
                    messageBox.Text += "\r\n" + ex.Message;
                }
            }
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            messageBox.Text =
@"Перед першою частиною таблиці повинно знаходитися 9 абзацних знаків ¶.
Між першою и другою частинами таблиці повинен бути 1 абзацний знак.

1.Заповніть поле дати і оберіть вид контролю.
2.Заповніть поле оцінок (Прізвище\tОцінка\n).
3.Відкрийте документ (.doc або .docx) з відомостю (меню File/Open).
4.Видаліть червоний рядок з початку створеного документа.
";
        }
    }
}
