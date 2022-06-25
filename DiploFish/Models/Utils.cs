using Spire.Doc.Documents;
using Spire.Doc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment;

namespace DiploFish.Models
{
    public class Utils
    {
        public static void Run(string personText, string templateFileName, bool isFeedback)
        {
            ClauseDict personDict = GetPerson(personText);
            string outputPath = GetPath(templateFileName, isFeedback, personDict);
            string docText = Substitute(personDict, isFeedback);
            CreateDoc(docText, outputPath);
        }

        public static ClauseDict GetPerson(string text)
        {
            var person = new ClauseDict(text);
            person.MarkCorrection();
            return person;
        }


        public static string Substitute(ClauseDict person, bool isFeedback)
        {
            // load data
            ClauseDict data = ClauseDict.FromFile(@"data\data.txt");
            string template = isFeedback ?
                File.ReadAllText(@"data\templateF.txt") :
                template = File.ReadAllText(@"data\templateR.txt");


            Random rnd = new Random();

            // do substitutions
            Regex regex = new Regex(@"@\[[^@^[]*\]");   // @[key]

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




        // https://www.e-iceblue.com/Tutorials/Spire.Doc/Spire.Doc-Program-Guide/Create-Write-and-Save-Word-in-C-and-VB.NET.html
        public static void CreateDoc(string text, string path)
        {
            
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

            string[] lines = text.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                Paragraph para = section.AddParagraph();
                string txt = lines[i].Trim();
                if (txt.Length > 0 && txt[0] == '`')
                {
                    para.Text = txt.Substring(1);
                    para.Format.HorizontalAlignment = HorizontalAlignment.Center;
                }
                else
                {
                    para.Text = txt;
                    para.Format.HorizontalAlignment = HorizontalAlignment.Justify;
                    para.Format.FirstLineIndent = 30;
                }
                para.ApplyStyle("style1");
            }

            //Save to file
            doc.SaveToFile(path, FileFormat.Docx2013);
            System.Diagnostics.Process.Start(path);
        }

        public static string GetPath(string fileName, bool isFeedback, ClauseDict personDict)
        {
            string dir = Path.GetDirectoryName(fileName);
            string kind = isFeedback ? "відзив" : "рецензія";
            string group = personDict["@[group]"].Sentence;
            string name = personDict["@[name]"].Sentence.Replace(' ', '_').Replace('.', '_');
            string path = Path.Combine(dir, $"2022_Б_ПІ_{group}_{name}{kind}.docx");
            return path;
        }


    }

}
