﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QSoft.Markdown;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //https://frankbing.gitbooks.io/markdown/content/part3_9.html
        //https://markdown-it.github.io/
        //Heading  
        //# h1 Heading

        //--- *** ___ are split line



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.richtextbox.Document.LineHeight = 1;
            //            string text = @"abcdegf  
            //ghijk  
            //yui
            //aa";

            //            string text = @"aa

            //bb

            //cc";
            string text = @"aa  
bb

cc";
            List<(int begin, int end)> ll = new List<(int begin, int end)>();
            //Regex br = new Regex(@"(?<a1>.*)\b\s{2}\r\n");
            //Regex br = new Regex(@"(?<a2>\B\r\n\.*)");
            Regex br = new Regex(@"((?<a1>.*)\b\s{2}\r\n)|(?<a2>\B\r\n\.*)");
            var matchs = br.Matches(text);
            int lastend = 0;
            foreach(Match match in matchs)
            {
                var item = match.Groups["a1"];
                System.Diagnostics.Trace.WriteLine($"index:{item.Index} length:{item.Length}");
                if(ll.Count == 0)
                {
                    ll.Add((0, item.Length));
                }
                else
                {
                    ll.Add((item.Index,  +item.Index+item.Length));
                }
                lastend = match.Index + match.Length;
            }
            if(lastend != text.Length)
            {
                ll.Add((lastend, text.Length));
            }

            StringBuilder strb = new StringBuilder();
            foreach(var oo in ll)
            {
                string s = text.Substring(oo.begin, oo.end - oo.begin);
                s = s.Replace("\r\n", "");
                strb.AppendLine(s);
            }
            System.Diagnostics.Trace.WriteLine(strb.ToString());
            var splts = Regex.Split(text, @"(\s{2})", RegexOptions.Compiled);
            return;
            //string test = "***aa****bb*";
            //Regex rg = new Regex("(?<begin>[*]{1,3})(?<value>.*?)(?<end>[*]{1,3})");
            //var matchs = rg.Matches(test);
            //foreach(Match match in matchs)
            //{
            //    System.Diagnostics.Trace.WriteLine($"{match.Groups["begin"].Value}");
            //    System.Diagnostics.Trace.WriteLine($"{match.Groups["value"].Value}");
            //    System.Diagnostics.Trace.WriteLine($"{match.Groups["end"].Value}");
            //}

            //this.richtextbox.Document.p(new List<(string content, bool bold, bool italic)>()
            //{
            //    (content:"FontWeight Bold", bold:true, italic:false),
            //    (content:"FontStyle Italic", bold:false, italic:true),
            //    (content:"FontWeight Bold FontStyle Italic", bold:true, italic:true),
            //});
            //return;

            string pattern_bold1 = @"\b[*]{2}\w+[*]{2}\b";
            string pattern_bold = @"\b[_]{2}\w+[_]{2}\b";
            string pattern_italic = @"\b[_]{2}\w+[_]{2}\b";
            Regex rgx = new Regex(pattern_bold1);
            string sentence = "__Who__ **eswrites** __these__ __notes?__";

            foreach (Match match in rgx.Matches(sentence))
            {
                Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
            }
                

            var heading = File.OpenRead("../../../md sample/heading.md");
            MarkdownReader mr = new MarkdownReader();
            var mds = mr.Open(heading);
            foreach(var oo in mds)
            {
                oo.Heading(this.richtextbox.Document);
            }
            return;

            Regex m_hr1 = new Regex(@"^-{3}$");
            Regex m_hr2 = new Regex(@"^[*]{3}$");
            Regex m_hr3 = new Regex(@"^_{3}$");
            var hr_match1 = m_hr1.Match("---");
            if(hr_match1.Success == true)
            {
                this.richtextbox.Document.hr();
            }
            var hr_match2 = m_hr2.Match("***");
            if (hr_match2.Success == true)
            {
                this.richtextbox.Document.hr();
            }
            var hr_match3 = m_hr3.Match("___");
            if (hr_match3.Success == true)
            {
                this.richtextbox.Document.hr();
            }

            string title1 = "# This is an apple";
            //Regex regex = new Regex(@"#+ (.+)");
            //Regex regex = new Regex(@"(?<=# )(?<heading>.+)");

            
            
        }



    }

    

}
