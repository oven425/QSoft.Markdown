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
        //Regex m_hr1 = new Regex(@"^-{3}$");
        //Regex m_hr2 = new Regex(@"^[*]{3}$");
        //Regex m_hr3 = new Regex(@"^_{3}$");

        Regex m_HorizontalRules1 = new Regex("^-{3,}$");
        Regex m_HorizontalRules2 = new Regex("^[*]{3,}$");
        Regex m_HorizontalRules3 = new Regex("^_{3,}$");
        Regex m_Break1 = new Regex("  $");
        Regex m_Break2 = new Regex(" {1,}^$");
        public MarkdownReader()
        {

        }
        public List<MarkdownBasic> Open(Stream stream)
        {
            List<MarkdownBasic> datas = new List<MarkdownBasic>();
            StreamReader sr = new StreamReader(stream);
            MarkdownBasic basic = new MarkdownBasic();
            while (sr.Peek() >= 0)
            {
                string line = sr.ReadLine();
                Match match = null;
                match = m_Heading.Match(line);
                if (match.Success)
                {
                    if (string.IsNullOrEmpty(basic.Content) == false)
                    {
                        datas.Add(basic);
                        basic = new MarkdownBasic();
                    }
                    Heading heaging = new Heading();
                    heaging.Size = match.Groups["size"].Value.Length;
                    heaging.Content = match.Groups["heading"].Value;
                    datas.Add(heaging);
                }
                else if(this.m_HorizontalRules1.IsMatch(line) == true)
                {
                    datas.Add(new HorizontalRule());
                }
                else if (this.m_HorizontalRules2.IsMatch(line) == true)
                {
                    datas.Add(new HorizontalRule());
                }
                else if (this.m_HorizontalRules3.IsMatch(line) == true)
                {
                    datas.Add(new HorizontalRule());
                }
                else
                {
                    basic.Content = basic.Content+line;
                    if(this.m_Break1.IsMatch(line) == true)
                    {
                        datas.Add(basic);
                        basic = new MarkdownBasic();
                    }
                    else if(line.Length == 0 || this.m_Break2.IsMatch(line)==true)
                    {
                        datas.Add(basic);
                        basic = new MarkdownBasic();
                        datas.Add(basic);
                        basic = new MarkdownBasic();
                    }
                }
            }
            if(string.IsNullOrEmpty(basic.Content) == false)
            {
                datas.Add(basic);
            }
            return datas;
        }
    }

    public class MarkdownBasic
    {
        public string Content { set; get; }
    }

    public class HorizontalRule : MarkdownBasic
    {

    }

    public class Heading: MarkdownBasic
    {
        public int Size { set; get; }
    }

    

}
