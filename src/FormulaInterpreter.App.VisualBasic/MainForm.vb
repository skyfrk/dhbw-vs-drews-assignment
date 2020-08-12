Imports FormulaInterpreter.Logic.VisualBasic

Public Class MainForm
    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        Try
            resultText.Text = Solve(tbFormula.Text).ToString()
        Catch ex As Exception
            MessageBox.Show("Bitte geben Sie eine korrekte Formel ein (Einziffrige Zahlen, '+' und '-' Operanden oder ein '=' als letztes Zeichen).", "Fehler")
        End Try
    End Sub
End Class
