using System;

namespace FormulaInterpreter.Logic.Csharp.Models
{
    public class TokenTree : IEquatable<TokenTree>
    {
        public Token Token { get; }

        public TokenTree LeftChild { get; }

        public TokenTree RightChild { get; }

        public TokenTree(Token token)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            Token = token;
        }

        public TokenTree(Token token, TokenTree leftChildTree, TokenTree rightChildTree)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            if (leftChildTree == null)
            {
                throw new ArgumentNullException(nameof(leftChildTree));
            }

            if (rightChildTree == null)
            {
                throw new ArgumentNullException(nameof(rightChildTree));
            }

            Token = token;
            LeftChild = leftChildTree;
            RightChild = rightChildTree;
        }

        public int GetValue()
        {
            if (this.Token.Type == TokenType.Number)
            {
                return this.Token.Value;
            }

            if (this.Token.Type == TokenType.Minus)
            {
                return this.LeftChild.GetValue() - this.RightChild.GetValue();
            }

            if (this.Token.Type == TokenType.Plus)
            {
                return this.LeftChild.GetValue() + this.RightChild.GetValue();
            }

            throw new InvalidOperationException("Invalid token type.");
        }

        public bool Equals(TokenTree other)
        {
            if (other == null)
            {
                return false;
            }

            if (other == this)
            {
                return true;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            return (this.Token == other.Token) && (this.LeftChild == other.LeftChild) && (this.RightChild == other.RightChild);
        }
    }
}
