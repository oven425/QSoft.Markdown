using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QSoft.Markdown
{
    public class MarkdownReader
    {
        Regex m_Heading = new Regex(@"^(?<size>#{1,6}?)\s{1}(?<heading>.+)?$", RegexOptions.Compiled);
        //^(?<size>#{1,6}?) (?<heading>.+)?$
        //Regex m_hr1 = new Regex(@"^-{3}$");
        //Regex m_hr2 = new Regex(@"^[*]{3}$");
        //Regex m_hr3 = new Regex(@"^_{3}$");
        List<Regex> m_Regexs = new List<Regex>();
        public MarkdownReader()
        {

        }
        public List<MarkdownBasic> Open(Stream stream)
        {
            List<MarkdownBasic> datas = new List<MarkdownBasic>();
            StreamReader sr = new StreamReader(stream);
            while(sr.EndOfStream == false)
            {
                string line = sr.ReadLine();
                Match match = null;
                match = m_Heading.Match(line);
                if (match.Success)
                {
                    Heading heaging = new Heading();
                    heaging.Size = match.Groups["size"].Value.Length;
                    heaging.Content = match.Groups["heading"].Value;
                    datas.Add(heaging);
                }
                else
                {
                    MarkdownBasic basic = new MarkdownBasic();
                    basic.Content = line;
                    datas.Add(basic);
                }
            }
            
            return datas;
        }
    }

    public class MarkdownBasic
    {
        public string Content { set; get; }
    }

    public class Heading: MarkdownBasic
    {
        public int Size { set; get; }
    }

    

}
