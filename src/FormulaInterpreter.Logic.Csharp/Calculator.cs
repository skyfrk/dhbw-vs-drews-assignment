using System;

namespace FormulaInterpreter.Logic.Csharp
{
    /// <summary>
    /// A calculator which is able to solve simple formulas.
    /// </summary>
    public static class Calculator
    {
        /// <summary>
        /// Solves a simple fomula.
        /// </summary>
        /// <param name="formula">Formula consisting of '+', '-', '=' and number tokens.</param>
        /// <returns>Result of the formula.</returns>
        public static int Solve(string formula)
        {
            var tokens = Lexer.Tokenize(formula);

            var tokenTree = Parser.BuildTokenTree(tokens);

            return tokenTree.GetValue();
        }

        public static int SolveBoring(string s)
        {
            if (s == null) throw new ArgumentNullException();
            var f = s.Trim();
            if (f.Length < 3) throw new InvalidOperationException();
            int sum = 0;
            char op = '+';
            for (int i = 0; i < f.Length; i++)
            {
                if ((f[i] == '+' || f[i] == '-') && op == 'n') { op = f[i]; continue; }
                if (char.IsDigit(f[i]) && op != 'n')
                {
                    if (op == '+') sum += (int)char.GetNumericValue(f[i]);
                    if (op == '-') sum -= (int)char.GetNumericValue(f[i]);
                    op = 'n';
                    continue;
                }
                if (f[i] == ' ' || (f[i] == '=' && i + 1 == f.Length)) continue;
                throw new InvalidOperationException();
            }
            if (op != 'n') throw new InvalidOperationException();
            return sum;
        }
    }
}
