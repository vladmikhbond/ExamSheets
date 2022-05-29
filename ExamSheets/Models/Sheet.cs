using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;

namespace ExamSheets.Models
{
    public enum Check { Exam, Test}
    public class Sheet
    {
        const string Z = " зарах", NZ = "незарах";
        const string M2 = "незадов", M3 = " задов", M4 = " добре", M5 = " відм";

        Document _document;
        List<TableRow> _rows;
        Dictionary<string, string> _marks;
        string _path;
        string _date;
        Check _check;
        
        public Sheet(string path, string date, Check check)
        {
            _document = new Document(path);
            MakeRows();
            _path = path;
            _date = date;
            _check = check;
        }


        void MakeRows()
        {
            Table table1 = _document.Sections[0].Paragraphs[8].NextSibling as Table;
            Table table2 = _document.Sections[0].Paragraphs[9].NextSibling as Table;

            _rows = new List<TableRow>();
            for (int i = 3; i < table1.Rows.Count; i++) _rows.Add(table1.Rows[i]);
            for (int i = 1; i < table2.Rows.Count; i++) _rows.Add(table2.Rows[i]);
        }

        public void LoadMarks(string path)
        {
            string[] ss = File.ReadAllLines(path);
            _marks = ss.Select(x => x.Split('\t'))
                .ToDictionary(ar => ar[0].Trim(), ar => ar[1].Trim());
        }

        string GetFullName(int r)
        {
            string[] items = _rows[r].Cells[1].Paragraphs[0].Items
              .Cast<TextRange>()
              .Select(t => t.Text)
              .ToArray();
            return string.Join("", items);
        }
        (string, string, string) Get3marks(string surname)
        {
            int[] ns    =   { 1,   35,  60,  66,  75,  90, 96, 100 };
            string[] A =    { "F","FX", "E", "D", "C", "B", "A", "A"};
            string[] vidm = { M2,  M2,  M3,  M3,  M4,  M5,  M5,  M5 };
            string[] zarah ={ NZ,  NZ,  Z,   Z,   Z,   Z,   Z,   Z  };

            if (_marks.ContainsKey(surname))
            {
                int m = Convert.ToInt32(_marks[surname]);
                int i = ns.TakeWhile(n => n <= m).Count() - 1;
                var s = _check == Check.Exam ? vidm[i] : zarah[i];
                if (i >= 0)
                   return (s, " " + _marks[surname], " " + A[i]);
            }
            return ("", "", "");
        }

        Paragraph Parag(int r, int c) =>
                _rows[r].Cells[c].Paragraphs[0];

        public string WriteData()
        {
            string message = "";
            var marks = new List<string>();
            for (int i = 0; i < _rows.Count; i++)
            {
                string fullName = GetFullName(i);
                string surname = fullName.Split(' ')[0];
                var (vidm, _90, a) = Get3marks(surname);
                if (!string.IsNullOrEmpty(a))
                {
                    Parag(i, 3).Text = vidm;
                    Parag(i, 4).Text = _90;
                    Parag(i, 5).Text = a;
                    Parag(i, 6).Text = " " + _date;
                    marks.Add(vidm);
                } 
                else
                {
                    message += $"No mark for: {fullName} \n";
                }
            }
            WriteSummary(marks);

            
            _document.SaveToFile(OutputPath, FileFormat.Doc);
            
            return message += "Ready.";
        }

        public string OutputPath => 
            Path.ChangeExtension(_path, "FILLED.doc");

        void WriteSummary(List<string>marks)
        {
            Table t = _document.Sections[0].Paragraphs[10].NextSibling as Table;
            //Не з'явилося 	 1
            //Відмінно	     2
            //Добре	         3
            //Задовільно	 4
            //Незадовільно	 5
            // 	             6
            //Зараховано	 7
            //Незараховано	 8
            if (_check == Check.Test)
            {
                int z = marks.Count(x => x == Z);
                int nz = marks.Count(x => x == NZ);
                t.Rows[7].Cells[5].FirstParagraph.Text = z.ToString();
                t.Rows[8].Cells[5].FirstParagraph.Text = nz.ToString();
            } 
            else
            {
                int m2 = marks.Count(x => x == M2);
                int m3 = marks.Count(x => x == M3);
                int m4 = marks.Count(x => x == M4);
                int m5 = marks.Count(x => x == M5);

                t.Rows[2].Cells[5].FirstParagraph.Text = m5.ToString();
                t.Rows[3].Cells[4].FirstParagraph.Text = m4.ToString();
                t.Rows[4].Cells[4].FirstParagraph.Text = m3.ToString();
                t.Rows[5].Cells[3].FirstParagraph.Text = m2.ToString();
            }
        }
        public void Save (string path)
        {
            
        }
    }
}




//var tr = t3.Rows[1].Cells[4].FirstParagraph.Text;


