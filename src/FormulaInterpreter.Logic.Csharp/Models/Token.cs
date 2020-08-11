using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaInterpreter.Logic.Csharp.Models
{
    public class Token : IEquatable<Token>
    {
        public TokenType Type { get; }

        public int Value { get; }

        public Token(TokenType type, int value)
        {
            Type = type;
            Value = value;
        }

        public Token(TokenType type)
        {
            Type = type;
        }

        public bool Equals(Token other)
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

            return (this.Type == other.Type) && (this.Value == other.Value);
        }
    }
}
