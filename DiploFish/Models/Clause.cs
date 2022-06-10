using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Spire.Doc;
using Spire.Doc.Documents;

namespace DiploFish.Models
{
    public class Clause
    {
        public string Tag { get; set; }
        public string[] Sentences { get; set; }
        public string Sentence => Sentences.FirstOrDefault();

        public string GetRandomSentence(Random rnd)
        {
            int i = rnd.Next(Sentences.Length);
            return Sentences[i];
        }
    }

    public class ClauseDict : Dictionary<string, Clause>
    {  
        public static ClauseDict FromFile(string path)
        {
            var content = File.ReadAllText(path);
            return new ClauseDict(content);
        }
        public ClauseDict(string content)
        {
            Regex regex = new Regex(@"@\[[^@^[]*\]");
            var matches = regex.Matches(content);
            var ss = regex.Split(content)
                .Select(s => s.Trim()).ToArray();
            var clauses = matches.OfType<Match>().Select((m, i) =>
              new Clause { 
                  Tag = m.Value, 
                  Sentences = ss[i + 1].Split(new char[]{'\n','\r'}, StringSplitOptions.RemoveEmptyEntries) 
              }).ToList();

            clauses.ForEach(c => this[c.Tag] = c);
        }

        // свертка всех строк в одну строку для ключа @[resume]
        public void ResumeCorrection()
        {
            string sentence = string.Join(" ", this["@[resume]"].Sentences);
            this["@[resume]"].Sentences = new[] { sentence }; 
        }

        public static string Substitute(ClauseDict person, bool isFeedback )
        {
            // load data
            ClauseDict data = FromFile(@"data\data.txt");
            string template = isFeedback ?
                File.ReadAllText(@"data\templateF.txt") :
                template = File.ReadAllText(@"data\templateR.txt");
            

            Random rnd = new Random();

            // do substitutions
            Regex regex = new Regex(@"@\[[^@^[]*\]");
            var keys = regex.Matches(template).OfType<Match>().Select(m => m.Value).ToArray();
            foreach (var key in keys)
            {
                if (person.ContainsKey(key))
                    template = template.Replace(key, person[key].Sentence);
            }
            foreach (var key in keys)
            {
                if (data.ContainsKey(key))
                    template = template.Replace(key, data[key].GetRandomSentence(rnd));
            }
            return template;
        }

        public static void CreateDoc(string[] lines, string personPath)
        {
// https://www.e-iceblue.com/Tutorials/Spire.Doc/Spire.Doc-Program-Guide/Create-Write-and-Save-Word-in-C-and-VB.NET.html

            //Create a Document object
            Document doc = new Document();
            //Add a section
            Section section = doc.AddSection();
            //Set the page margins
            section.PageSetup.Margins.Left = 75f;
            section.PageSetup.Margins.Right = 40f;
            section.PageSetup.Margins.Top = 70f;
            section.PageSetup.Margins.Bottom = 70f;

            ParagraphStyle style1 = new ParagraphStyle(doc);          
            style1.Name = "style1";
            style1.CharacterFormat.FontName = "Times New Roman";
            style1.CharacterFormat.FontSize = 13;
            //style1.CharacterFormat.Bold = true;

            doc.Styles.Add(style1);

            for (int i = 0; i < lines.Length; i++)
            {
                Paragraph para = section.AddParagraph();
                string text = lines[i].Trim();
                if (text.Length > 0 && text[0] == '`')
                {
                    para.Text = text.Substring(1);
                    para.Format.HorizontalAlignment = HorizontalAlignment.Center;
                } else
                {
                    para.Text = text;
                    para.Format.HorizontalAlignment = HorizontalAlignment.Justify;
                    para.Format.FirstLineIndent = 30;
                }
                para.ApplyStyle("style1");
            }
            //Save to file
            string path = Path.ChangeExtension(personPath, ".docx");
            doc.SaveToFile(path, FileFormat.Docx2013);
            System.Diagnostics.Process.Start(path);
        }
    }
}
