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
        Regex m_Heading1 = new Regex(@"(?<count>#{1} )(?<heading>.+)");
        Regex m_Heading2 = new Regex(@"(?<count>#{2} )(?<heading>.+)");
        Regex m_Heading3 = new Regex(@"(?<count>#{3} )(?<heading>.+)");
        Regex m_Heading4 = new Regex(@"(?<count>#{4} )(?<heading>.+)");
        Regex m_Heading5 = new Regex(@"(?<count>#{5} )(?<heading>.+)");
        Regex m_Heading6 = new Regex(@"(?<count>#{6} )(?<heading>.+)");
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
            Regex regex = new Regex(@"(?<size>#{1,6})\s{1}(?<heading>.+)");
            var match1 = regex.Match("####  This is an apple");
            if (match1.Success == true)
            {
                System.Diagnostics.Trace.WriteLine($"{match1.Value}");
                this.richtextbox.Document.H1(match1.Groups["heading"].Value);
            }
            var match2 = m_Heading2.Match("## This is an apple");
            if (match2.Success == true)
            {
                System.Diagnostics.Trace.WriteLine($"{match2.Value}");
                this.richtextbox.Document.H2(match1.Groups["heading"].Value);
            }
            var match3 = m_Heading3.Match("### This is an apple");
            if (match3.Success == true)
            {
                System.Diagnostics.Trace.WriteLine($"{match3.Value}");
                this.richtextbox.Document.H3(match1.Groups["heading"].Value);
            }
            var match4 = m_Heading4.Match("#### This is an apple");
            if (match4.Success == true)
            {
                System.Diagnostics.Trace.WriteLine($"{match4.Value}");
                this.richtextbox.Document.H4(match1.Groups["heading"].Value);
            }
            var match5 = m_Heading5.Match("##### This is an apple");
            if (match5.Success == true)
            {
                System.Diagnostics.Trace.WriteLine($"{match5.Value}");
                this.richtextbox.Document.H5(match1.Groups["heading"].Value);
            }
            var match6 = m_Heading6.Match("###### This is an apple");
            if (match6.Success == true)
            {
                System.Diagnostics.Trace.WriteLine($"{match6.Value}");
                this.richtextbox.Document.H6(match1.Groups["heading"].Value);
            }

            this.richtextbox.Document.LineHeight = 1;
            
        }



    }

    

}
