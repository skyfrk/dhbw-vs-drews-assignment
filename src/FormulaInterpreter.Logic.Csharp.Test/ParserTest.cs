using FluentAssertions;
using FormulaInterpreter.Logic.Csharp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaInterpreter.Logic.Csharp.Test
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void BuildTokenTree_OnePlusOne_CorrectTokenTree()
        {
            var tokens = new Token[]
            {
                new Token(TokenType.Number, 1),
                new Token(TokenType.Plus),
                new Token(TokenType.Number, 1),
            };

            var correct_tree = new TokenTree(tokens[1], new TokenTree(tokens[0]), new TokenTree(tokens[2]));

            var tree = Parser.BuildTokenTree(tokens);

            tree.Should().BeEquivalentTo(correct_tree);
        }

        [TestMethod]
        public void BuildTokenTree_OneMinusOne_CorrectTokenTree()
        {
            var tokens = new Token[]
            {
                new Token(TokenType.Number, 1),
                new Token(TokenType.Minus),
                new Token(TokenType.Number, 1),
            };

            var correct_tree = new TokenTree(tokens[1], new TokenTree(tokens[0]), new TokenTree(tokens[2]));

            var tree = Parser.BuildTokenTree(tokens);

            tree.Should().BeEquivalentTo(correct_tree);
        }

        [TestMethod]
        public void BuildTokenTree_OneMinusOnePlusTwo_CorrectTokenTree()
        {
            var tokens = new Token[]
            {
                new Token(TokenType.Number, 1),
                new Token(TokenType.Minus),
                new Token(TokenType.Number, 1),
                new Token(TokenType.Plus),
                new Token(TokenType.Number, 2),
                new Token(TokenType.Equal),
            };

            var correct_tree = new TokenTree(tokens[1], new TokenTree(tokens[0]), new TokenTree(tokens[3], new TokenTree(tokens[2]), new TokenTree(tokens[4])));

            var tree = Parser.BuildTokenTree(tokens);

            tree.Should().BeEquivalentTo(correct_tree);
        }

        [TestMethod]
        public void BuildTokenTree_OneMinusOnePlusTwoMinusThree_CorrectTokenTree()
        {
            var tokens = new Token[]
            {
                new Token(TokenType.Number, 1),
                new Token(TokenType.Minus),
                new Token(TokenType.Number, 1),
                new Token(TokenType.Plus),
                new Token(TokenType.Number, 2),
                new Token(TokenType.Minus),
                new Token(TokenType.Number, 3),
            };

            var correct_tree = new TokenTree(
                tokens[1],
                new TokenTree(tokens[0]),
                new TokenTree(
                    tokens[3],
                    new TokenTree(tokens[2]),
                    new TokenTree(
                        tokens[5],
                        new TokenTree(tokens[4]),
                        new TokenTree(tokens[6]))));

            var tree = Parser.BuildTokenTree(tokens);

            tree.Should().BeEquivalentTo(correct_tree);
        }

        [TestMethod]
        public void BuildTokenTree_EqualSignInfront_ThrowsException()
        {
            var tokens = new Token[]
            {
                new Token(TokenType.Equal),
                new Token(TokenType.Number, 1),
                new Token(TokenType.Minus),
                new Token(TokenType.Number, 1),
            };

            Action action = () => Parser.BuildTokenTree(tokens);

            action
                .Should()
                .Throw<InvalidOperationException>()
                .WithMessage("Invalid token combination.");
        }

        [TestMethod]
        public void BuildTokenTree_DoubleEqualSign_ThrowsException()
        {
            var tokens = new Token[]
            {
                new Token(TokenType.Number, 1),
                new Token(TokenType.Minus),
                new Token(TokenType.Number, 1),
                new Token(TokenType.Equal),
                new Token(TokenType.Equal),
            };

            Action action = () => Parser.BuildTokenTree(tokens);

            action
                .Should()
                .Throw<InvalidOperationException>()
                .WithMessage("Invalid token combination.");
        }

        [TestMethod]
        public void BuildTokenTree_DoubleOperator_ThrowsException()
        {
            var tokens = new Token[]
            {
                new Token(TokenType.Number, 1),
                new Token(TokenType.Minus),
                new Token(TokenType.Minus, 1),
            };

            Action action = () => Parser.BuildTokenTree(tokens);

            action
                .Should()
                .Throw<InvalidOperationException>()
                .WithMessage("Invalid token combination.");
        }

        [TestMethod]
        public void BuildTokenTree_DoubleNumber_ThrowsException()
        {
            var tokens = new Token[]
            {
                new Token(TokenType.Number, 1),
                new Token(TokenType.Number, 1),
                new Token(TokenType.Minus, 1),
            };

            Action action = () => Parser.BuildTokenTree(tokens);

            action
                .Should()
                .Throw<InvalidOperationException>()
                .WithMessage("Invalid token combination.");
        }
    }
}
