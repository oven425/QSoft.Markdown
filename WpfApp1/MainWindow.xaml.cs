using System;
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

        public string GetValue(string str, string s, string e)
        {
            //string str1 = $"(?<=({s}))[.\\s\\S]*?(?=({e}))";
            string str1 = $"(?<=([{s}]))[.\\s\\S]*?(?=({e}))";

            Regex rg = new Regex(str1);

            //Regex rg = new Regex("(?<=(" + s + "))[.\\s\\S]*?(?=(" + e + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(str).Value;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var mmi = GetValue("__AA__", "__", "__");
            //this.richtextbox.Document.LineHeight = 1;


            string str1 = $"(?<=(__))[.\\s\\S]*?(?=(__))";

            Regex rg = new Regex(str1);
            var mms = rg.Matches("__aa__ ___aba___ __b_ _c__ _d_");
            foreach(Match oo in mms)
            {
                System.Diagnostics.Trace.WriteLine(oo.Value);
            }

            var url = $@"www.xxx.com/group///{ Guid.NewGuid() }/report/{ Guid.NewGuid() }";

            var groupRegex = new Regex(@"(?<=group[/]{1,})(.*?)(?=/report)");
            var reportRegex = new Regex(@"(?<=report/)(.*)");


            Console.WriteLine(url);
            Console.WriteLine(groupRegex.Match(url).Value);
            Console.WriteLine(reportRegex.Match(url).Value);


            Regex regex = new Regex("(?<=<<).*?(?=>>)");

            foreach (Match match in regex.Matches("this is a test for <<<bob>>> who like <<<books>>"))
            {
                Console.WriteLine(match.Value);
            }




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
