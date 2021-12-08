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
        Regex m_Heading1 = new Regex(@"(?<count>#{1} )(?<heading>.+)");
        Regex m_Heading2 = new Regex(@"(?<count>#{2} )(?<heading>.+)");
        Regex m_Heading3 = new Regex(@"(?<count>#{3} )(?<heading>.+)");
        Regex m_Heading4 = new Regex(@"(?<count>#{4} )(?<heading>.+)");
        Regex m_Heading5 = new Regex(@"(?<count>#{5} )(?<heading>.+)");
        Regex m_Heading6 = new Regex(@"(?<count>#{6} )(?<heading>.+)");
        Regex m_hr1 = new Regex(@"^-{3}$");
        Regex m_hr2 = new Regex(@"^[*]{3}$");
        Regex m_hr3 = new Regex(@"^_{3}$");
        List<Regex> m_Regexs = new List<Regex>();
        public MarkdownReader()
        {
            this.m_Regexs.Add(this.m_Heading1);
            this.m_Regexs.Add(this.m_Heading2);
            this.m_Regexs.Add(this.m_Heading3);
            this.m_Regexs.Add(this.m_Heading4);
            this.m_Regexs.Add(this.m_Heading5);
            this.m_Regexs.Add(this.m_Heading6);
        }
        public List<MarkdownBasic> Open(Stream stream)
        {
            List<MarkdownBasic> datas = new List<MarkdownBasic>();
            StreamReader sr = new StreamReader(stream);
            string line = sr.ReadLine();
            Regex regex;

            return datas;
        }

    }

    public class MarkdownBasic
    {
        public string Raw { set; get; }
    }

    public class Heading1
    {
        public int Size { set; get; }
        public string Content { set; get; }
    }
}
