using FormulaInterpreter.Logic.Csharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FormulaInterpreter.Logic.Csharp
{
    public static class Lexer
    {
        private static readonly char[] numberChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public static Token[] Tokenize(string formula)
        {
            if (formula == null)
            {
                throw new ArgumentNullException(nameof(formula), formula);
            }

            if (formula.Length == 0)
            {
                return new Token[] { };
            }

            var result = new List<Token>();

            for (int i = 0; i < formula.Length; i++)
            {
                if (formula[i] == ' ')
                {
                    continue;
                }

                if (numberChars.Contains(formula[i]))
                {
                    result.Add(new Token(TokenType.Number, Convert.ToInt32(formula[i].ToString())));
                    continue;
                }

                if (formula[i] == '+')
                {
                    result.Add(new Token(TokenType.Plus));
                    continue;
                }

                if (formula[i] == '-')
                {
                    result.Add(new Token(TokenType.Minus));
                    continue;
                }

                if (formula[i] == '=')
                {
                    result.Add(new Token(TokenType.Equal));
                    continue;
                }

                throw new InvalidOperationException("Invalid char in formula.");
            }

            return result.ToArray();
        }
    }
}
