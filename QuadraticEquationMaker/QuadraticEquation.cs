using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquationMaker
{
    internal class QuadraticEquation
    {
        public static ProbAns generate(int min, int max, Random rnd)
        {
            int ans1, ans2, b, c;
            ans1 = rnd.Next(min, max + 1);
            ans2 = rnd.Next(min, max + 1);
            // x^2 + bx + c = 0
            b = -(ans1 + ans2);
            c = ans1 * ans2;
            if (ans1 > ans2) (ans1, ans2) = (ans2, ans1);

            StringBuilder problem = new StringBuilder();
            StringBuilder ans = new StringBuilder();

            problem.Append("      \\item $x^2");
            addTerm(problem, b);
            addTerm(problem, c);
            problem.Append("=0$ \\\\\n");

            ans.Append("      \\item x = ");
            ans.Append(ans1.ToString());
            if (ans1 != ans2)
            {
                ans.Append(", ");
                ans.Append(ans2.ToString());
            }
            ans.Append(" \\\\\n");

            return new ProbAns(problem.ToString(), ans.ToString());
        }
        private static void addTerm(StringBuilder problem, int n)
        {
            if (n != 0)
            {
                if (n > 0) problem.Append("+");
                problem.Append(n.ToString());
            }
        }
    }
}
