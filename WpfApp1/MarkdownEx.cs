using QSoft.Markdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace WpfApp1
{
    public static class MarkdownEx
    {
        public static void Heading(this Heading src, FlowDocument doc)
        {
            switch (src.Size)
            {
                case 1: { doc.H1(src.Content); } break;
                case 2: { doc.H2(src.Content); } break;
                case 3: { doc.H3(src.Content); } break;
                case 4: { doc.H4(src.Content); } break;
                case 5: { doc.H5(src.Content); } break;
                case 6: { doc.H6(src.Content); } break;
            }
        }

        public static void Heading(this MarkdownBasic src, FlowDocument doc)
        {
            if(src is Heading)
            {
                (src as Heading)?.Heading(doc);
            }
            else
            {
                doc.p(src.Content);
            }
            
        }
    }
}
