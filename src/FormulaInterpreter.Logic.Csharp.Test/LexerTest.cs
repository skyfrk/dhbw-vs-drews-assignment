using FluentAssertions;
using FormulaInterpreter.Logic.Csharp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaInterpreter.Logic.Csharp.Test
{
    [TestClass]
    public class LexerTest
    {
        [TestMethod]
        public void Tokenize_ValidFormula_CorrectTokens()
        {
            var tests = new Dictionary<string, Token[]>
            {
                {
                    "1+1", new Token[] { new Token(TokenType.Number, 1), new Token(TokenType.Plus), new Token(TokenType.Number, 1) }
                },
                {
                    "    1 -   2  ", new Token[] { new Token(TokenType.Number, 1), new Token(TokenType.Minus), new Token(TokenType.Number, 2) }
                },
                {
                    "1-2", new Token[] { new Token(TokenType.Number, 1), new Token(TokenType.Minus), new Token(TokenType.Number, 2) }
                },
                {
                    " 1 + 2 - 3 =", new Token[] { new Token(TokenType.Number, 1), new Token(TokenType.Plus), new Token(TokenType.Number, 2), new Token(TokenType.Minus), new Token(TokenType.Number, 3) }
                },
                {
                    "1-2=", new Token[] { new Token(TokenType.Number, 1), new Token(TokenType.Minus), new Token(TokenType.Number, 2) }
                },
                {
                    "1-+2=", new Token[] { new Token(TokenType.Number, 1), new Token(TokenType.Minus), new Token(TokenType.Plus), new Token(TokenType.Number, 2) }
                },
                {
                    "123", new Token[] { new Token(TokenType.Number, 1), new Token(TokenType.Number, 2), new Token(TokenType.Plus), new Token(TokenType.Number, 3) }
                },
                {
                    "1 2   3 ", new Token[] { new Token(TokenType.Number, 1), new Token(TokenType.Number, 2), new Token(TokenType.Plus), new Token(TokenType.Number, 3) }
                }

            };

            foreach (var test in tests)
            {
                Lexer.Tokenize(test.Key).Should().BeEquivalentTo(test.Value);
            }
        }

        [DataTestMethod]
        [DataRow("a")]
        [DataRow("fail")]
        [DataRow("*.:")]
        [DataRow("2+2f")]
        [DataRow("a2 + 2 = 1")]
        public void Tokenize_InvalidFormula_ThrowsException(string formula)
        {
            Action action = () => Lexer.Tokenize(formula);
            action
                .Should()
                .Throw<InvalidOperationException>()
                .WithMessage("Invalid char in formula.");
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("   ")]
        [DataRow("=")]
        [DataRow(" =")]
        [DataRow(" = ")]
        public void Tokenize_EmptyFormula_ReturnsEmptyArray(string formula)
        {
            Lexer.Tokenize(formula).Should().BeEmpty();
        }
    }
}
