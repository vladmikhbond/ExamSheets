using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiploFish.Models
{
    public class Clause
    {
        public string Tag { get; set; }
        public string[] Sentences { get; set; }
        public string Sentence => Sentences.FirstOrDefault();

        //public override string ToString()
        //{
        //    return Tag + Environment.NewLine + string.Join(Environment.NewLine, Sentences);
        //}
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
              new Clause { Tag = m.Value, Sentences = ss[i + 1].Split('\n') })
                .ToList();
            clauses.ForEach(c => this[c.Tag] = c);
        }

        //public override string ToString()
        //{
        //    var arr = this.Select(c => c.ToString()).ToArray();
        //    return string.Join(Environment.NewLine, arr);
        //}

        public static string Substitute(string template, ClauseDict data, ClauseDict person)
        {
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
                    template = template.Replace(key, data[key].Sentence);
            }
            return template;
        }


    }
}
