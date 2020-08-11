using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FormulaInterpreter.Logic.Csharp.Test
{
    [TestClass]
    public class CalculatorTest
    {
        [DataTestMethod]
        [DataRow("1 + 1 = ", 2)]
        [DataRow("1 - 1 = ", 0)]
        [DataRow("1 - 1 + 1 = ", 1)]
        [DataRow("1 + 1 - 1 = ", 1)]
        [DataRow("1+1-1=", 1)]
        [DataRow("7+8-1  =", 14)]
        [DataRow("   7   +    8  - 1  =", 14)]
        [DataRow("1-1-1-1", -4)]
        [DataRow("1+1+1+1", 4)]
        [DataRow("1+2", 3)]
        [DataRow("1-3 ", -2)]
        [DataRow(" 1+2", 3)]
        public void Solve_ValidFormula_CorrectResult(string formula, int result)
        {
            Calculator.Solve(formula).Should().Be(result);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("   ")]
        [DataRow("=")]
        [DataRow(" = ")]
        [DataRow("a")]
        [DataRow("fail")]
        [DataRow("*.:")]
        [DataRow("1++1=")]
        [DataRow("1+=")]
        [DataRow("1+2-=")]
        [DataRow("+2")]
        [DataRow("2+2f")]
        [DataRow("= 2 + 2 =")]
        [DataRow("1+2++4=")]
        public void Solve_InvalidFormula_ThrowsException(string formula, int result)
        {
            Action action = () => Calculator.Solve(formula);

            action.Should().Throw<InvalidOperationException>();
        }
    }
}
