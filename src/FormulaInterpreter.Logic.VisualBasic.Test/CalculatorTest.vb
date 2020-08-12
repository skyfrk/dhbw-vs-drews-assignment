Imports FluentAssertions
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System

Namespace FormulaInterpreter.Logic.VisualBasic.Test
    <TestClass>
    Public Class CalculatorTest

        <DataTestMethod>
        <DataRow("1 + 1 = ", 2)>
        <DataRow("1 - 1 = ", 0)>
        <DataRow("1 - 1 + 1 = ", 1)>
        <DataRow("1 + 1 - 1 = ", 1)>
        <DataRow("1+1-1=", 1)>
        <DataRow("7+8-1  =", 14)>
        <DataRow("   7   +    8  - 1  =", 14)>
        <DataRow("1-1-1-1", -2)>
        <DataRow("1+1+1+1", 4)>
        <DataRow("1+2", 3)>
        <DataRow("1-3 ", -2)>
        <DataRow(" 1+2", 3)>
        Public Sub Solve_ValidFormula_CorrectResult(ByVal formula As String, ByVal result As Integer)
            Solve(formula).Should().Be(result)
        End Sub

        <DataTestMethod>
        <DataRow("")>
        <DataRow(" ")>
        <DataRow("   ")>
        <DataRow("=")>
        <DataRow(" = ")>
        <DataRow("a")>
        <DataRow("fail")>
        <DataRow("*.:")>
        <DataRow("1++1=")>
        <DataRow("1+=")>
        <DataRow("1+2-=")>
        <DataRow("+2")>
        <DataRow("2+2f")>
        <DataRow("= 2 + 2 =")>
        <DataRow("1+2++4=")>
        Public Sub Solve_InvalidFormula_ThrowsException(ByVal formula As String)
            Dim action As Action = Sub() Solve(formula)
            action.Should().[Throw](Of InvalidOperationException)()
        End Sub
    End Class
End Namespace