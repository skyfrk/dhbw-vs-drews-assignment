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

            var tokenList = RemoveTrailingEqualSign(tokens);
            ValidateTokens(tokenList);

            TokenTree tree = new TokenTree(tokenList[1], new TokenTree(tokenList[0]), new TokenTree(tokenList[2]));
            for (int i = 3; i < tokenList.Count; i = i + 2)
            {
                tree = new TokenTree(tokenList[i], tree, new TokenTree(tokenList[i + 1]));
            }

            return tree;
        }

        private static List<Token> RemoveTrailingEqualSign(Token[] tokens)
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
            if (tokens.Count < 3 || tokens.Count % 2 == 0)
            {
                throw new InvalidOperationException("Invalid token combination.");
            }

            for (int i = 0; i < tokens.Count; i++)
            {
                if (i % 2 == 0)
                {
                    if (tokens[i].Type != TokenType.Number)
                    {
                        throw new InvalidOperationException("Invalid token combination.");
                    }
                }
                else
                {
                    if (tokens[i].Type != TokenType.Minus && tokens[i].Type != TokenType.Plus)
                    {
                        throw new InvalidOperationException("Invalid token combination.");
                    }
                }
            }
        }
    }
}
