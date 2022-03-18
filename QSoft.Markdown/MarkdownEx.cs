using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;

namespace QSoft.Markdown.WPF
{
    public static class MarkdownEx
    {
        static void Heading(this Heading src, FlowDocument doc)
        {
            switch (src.Size)
            {
                case 1: { doc.H1(src.Content); } break;
                case 2: { doc.H2(src.Content); } break;
                case 3: { doc.H3(src.Content); } break;
                case 4: { doc.H4(src.Content); } break;
                case 5: { doc.H5(src.Content); } break;
                case 6: default: { doc.H6(src.Content); } break;
            }
        }

        public static void ToFlowDocument(this MarkdownBasic src, FlowDocument doc)
        {
            if (src is Heading)
            {
                (src as Heading)?.Heading(doc);
            }
            else if (src is HorizontalRule)
            {
                doc.hr();
            }
            else if (src is MarkdownBasic)
            {
                doc.p((src as MarkdownBasic)?.Content);
            }
            else
            {
                doc.p(src.Content);
            }
        }
    }
}
