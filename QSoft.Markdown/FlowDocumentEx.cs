using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace QSoft.Markdown.WPF
{
    public static class FlowDocumentEx
    {
        public static void hr(this FlowDocument doc)
        {
            BlockUIContainer hr = new BlockUIContainer();
            hr.BorderThickness = new Thickness(0, 1, 0, 0);
            hr.BorderBrush = new SolidColorBrush(Color.FromRgb(0xDD, 0xDD, 0xDD));
            hr.Margin = new Thickness(0, 20, 0, 20);
            
            doc.Blocks.Add(hr);
        }

        public static void p(this FlowDocument doc, List<(string content, bool bold, bool italic)> datas)
        {
            Paragraph p = new Paragraph();
            foreach (var oo in datas)
            {
                var run = new Run(oo.content);
                if (oo.bold == true)
                {
                    run.FontWeight = FontWeights.Bold;
                }
                if (oo.italic == true)
                {
                    run.FontStyle = FontStyles.Italic;
                }
                p.Inlines.Add(run);
            }
            p.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            doc.Blocks.Add(p);
        }

        public static void p(this FlowDocument doc, string content)
        {
            Paragraph p = new Paragraph(new Run(content));
            p.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            doc.Blocks.Add(p);
        }

        public static void BreakLine(this FlowDocument doc)
        {
            doc.Blocks.Add(new Paragraph());
        }

        public static void H1(this FlowDocument doc, string headeing)
        {
            Paragraph p = new Paragraph(new Run(headeing));
            p.FontSize = 36;
            p.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            doc.Blocks.Add(p);
        }

        public static void H2(this FlowDocument doc, string headeing)
        {
            Paragraph p = new Paragraph(new Run(headeing));
            p.FontSize = 30;
            p.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            doc.Blocks.Add(p);
        }

        public static void H3(this FlowDocument doc, string headeing)
        {
            Paragraph p = new Paragraph(new Run(headeing));
            p.FontSize = 24;
            p.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            doc.Blocks.Add(p);
        }

        public static void H4(this FlowDocument doc, string headeing)
        {
            Paragraph p = new Paragraph(new Run(headeing));
            p.FontSize = 18;
            p.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            doc.Blocks.Add(p);
        }

        public static void H5(this FlowDocument doc, string headeing)
        {
            Paragraph p = new Paragraph(new Run(headeing));
            p.FontSize = 14;
            p.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            doc.Blocks.Add(p);
        }

        public static void H6(this FlowDocument doc, string headeing)
        {
            Paragraph p = new Paragraph(new Run(headeing));
            p.FontSize = 12;
            p.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            doc.Blocks.Add(p);
        }
    }
}