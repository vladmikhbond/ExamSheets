﻿using System;
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
            Regex regex = new Regex(@"@\[[^@^[]*\]");  // @[key]
            var matches = regex.Matches(content);

            var value = regex.Split(content)
                .Select(s => s.Trim()).ToArray();

            var clauses = matches.OfType<Match>().Select((m, i) =>
              new Clause { 
                  Tag = m.Value,
            
                  Sentences = value[i + 1].Split('|')
                      .Select(sent => sent.Trim().Replace("\r\n", " ").Replace(">", "\r\n"))
                      .Where(sent => sent != "")
                      .ToArray()
              }).ToList();

            clauses.ForEach(c => this[c.Tag] = c);

        }

        // расширение оценки для ключа @[mark]
        public void MarkCorrection()
        {
            string markStr = this["@[mark]"].Sentence;
            int mark;
            try
            {
                mark = Convert.ToInt32(markStr);
            } catch
            {
                return;
            }
            if (mark >= 96)
                this["@[mark]"].Sentences[0] = $"відмінно {mark} (A)";
            else if (mark >= 90)
                this["@[mark]"].Sentences[0] = $"відмінно {mark} (B)";
            else if (mark >= 75)
                this["@[mark]"].Sentences[0] = $"добре {mark} (C)";
            else if (mark >= 65)
                this["@[mark]"].Sentences[0] = $"задовільно {mark} (D)";
            else if (mark >= 60)
                this["@[mark]"].Sentences[0] = $"задовільно {mark} (E)";            
        }





    }


}
