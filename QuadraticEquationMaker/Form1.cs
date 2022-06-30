using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuadraticEquationMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rnd = new System.Random();
        }
        private Random rnd;

        private void button1_Click(object sender, EventArgs e)
        {
            int problemNum, column;
            int.TryParse(tbProblemNum.Text, out problemNum);
            int.TryParse(tbColumn.Text, out column);
            if (problemNum <= 0) problemNum = 1;
            if (column <= 0) column = 1;

            StringBuilder sb = initializeSb(column);
            ProbAns tmp;

            ProbAns probAns = new ProbAns();
            for (int i = 0; i < problemNum; i++)
            {
                tmp = QuadraticEquation.generate(-9, 9, rnd);
                probAns.problem.Append(tmp.problem);
                probAns.ans.Append(tmp.ans);
            }

            sb.Append(probAns.problem);
            midSb(sb, column);
            sb.Append(probAns.ans);
            bottomSb(sb, problemNum);

            saver(sb.ToString());
        }
        private StringBuilder initializeSb(int n)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\\documentclass[11pt,a4paper,dvipdfmx]{jsarticle}\n");
            sb.Append("\\setlength{\\textwidth}{\\fullwidth}\n");
            sb.Append("\\setlength{\\textheight}{40\\baselineskip}\n");
            sb.Append("\\addtolength{\\textheight}{\\topskip}\n");
            sb.Append("\\usepackage[top=25.4truemm,bottom=25.4truemm,left=19.05truemm,right=19.05truemm]{geometry}\n");
            sb.Append("\\usepackage{multicol}\n");
            sb.Append("\\usepackage{enumerate}\n");
            sb.Append("\\begin{document}\n");
            sb.Append("  \\subsection*{問題}\n");
            sb.Append("  \\begin{multicols}{");
            sb.Append(n.ToString());
            sb.Append("}\n");
            sb.Append("    \\begin{enumerate}[(1)]\n");
            return sb;
        }
        private void midSb(StringBuilder sb, int n)
        {

            sb.Append("    \\end{enumerate}\n");
            sb.Append("  \\end{multicols}\n");
            sb.Append("  \\newpage\n");
            sb.Append("  \\subsection*{答え}\n");
            sb.Append("  \\begin{multicols}{");
            sb.Append(n.ToString());
            sb.Append("}\n");
            sb.Append("    \\begin{enumerate}[(1)]\n");
        }
        private void bottomSb(StringBuilder sb, int n)
        {

            sb.Append("    \\end{enumerate}\n");
            sb.Append("  \\end{multicols}\n");
            sb.Append("  \\subsection*{正答率}\n");
            sb.Append("  \\Huge\\hspace{1cm} /360\n");
            sb.Append("\\end{document}\n");
        }
        private void saver(string s)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            sfd.FileName = "newFIle.tex";
            //はじめに表示されるフォルダを指定する
            sfd.InitialDirectory = @"C:\";
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            sfd.Filter = "texファイル(*.tex)|*.tex";
            //タイトルを設定する
            sfd.Title = "保存先のファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.RestoreDirectory = true;
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream stream;
                stream = sfd.OpenFile();
                if (stream != null)
                {
                    //ファイルに書き込む
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(stream);
                    sw.Write(s);
                    //閉じる
                    sw.Close();
                    stream.Close();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
