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
        public List<MarkdownBasic> Open(Stream stream)
        {
            List<MarkdownBasic> datas = new List<MarkdownBasic>();
            StreamReader sr = new StreamReader(stream);
            string line = sr.ReadLine();
            

            return datas;
        }

    }

    public class MarkdownBasic
    {
        public string Raw { set; get; }
    }

    public class Title
    {
        public int Size { set; get; }
        public string Content { set; get; }
    }
}
