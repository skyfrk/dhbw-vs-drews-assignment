using FormulaInterpreter.Logic.Csharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace FormulaInterpreter.Logic.Csharp
{
    public static class Parser
    {
        public static TokenTree BuildTokenTree(Token[] tokens)
        {
            if (tokens.Length < 3)
            {
                throw new InvalidOperationException("Invalid token combination.");
            }

            var tokenList = CleanTokens(tokens);
            ValidateTokens(tokenList);

            // transform
            throw new NotImplementedException();
        }

        private static List<Token> CleanTokens(Token[] tokens)
        {
            var tokenList = tokens.ToList();
            if (tokens[tokens.Length - 1].Type == TokenType.Equal)
            {
                tokenList.RemoveAt(tokens.Length - 1);
            }
            return tokenList;
        }

        private static void ValidateTokens(List<Token> tokens)
        {
            if (tokens.Count % 2 != 0)
            {
                throw new InvalidOperationException("Invalid token combination.");
            }

            for (int i = 0; i < tokens.Count; i = i + 2)
            {
                if (tokens[i].Type != TokenType.Number)
                {
                    throw new InvalidOperationException("Invalid token combination.");
                }

                if (i + 1 < tokens.Count - 1)
                {
                    if (tokens[i + 1].Type != TokenType.Minus || tokens[i + 1].Type != TokenType.Plus)
                    {
                        throw new InvalidOperationException("Invalid token combination.");
                    }
                }
            }
        }
    }
}
