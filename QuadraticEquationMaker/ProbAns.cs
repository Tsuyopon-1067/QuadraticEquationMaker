using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquationMaker
{
    internal class ProbAns
    {
        internal ProbAns() : this("", "") { }
        internal ProbAns(string problem, string ans)
        {
            this.problem = new StringBuilder(problem);
            this.ans = new StringBuilder(ans);
        }

        public StringBuilder problem;
        public StringBuilder ans;
    }
}
