Public Module Calculator
    Function Solve(ByVal s As String) As Integer
        If s Is Nothing Then Throw New ArgumentNullException()
        Dim f = s.Trim()
        If f.Length < 3 Then Throw New InvalidOperationException()
        Dim sum As Integer = 0
        Dim op As Char = "+"c
        For i As Integer = 0 To f.Length - 1
            If (f(i) = "+"c OrElse f(i) = "-"c) AndAlso op = "n"c Then
                op = f(i)
                Continue For
            End If
            If Char.IsDigit(f(i)) AndAlso op <> "n"c Then
                If op = "+"c Then sum += CInt(Char.GetNumericValue(f(i)))
                If op = "-"c Then sum -= CInt(Char.GetNumericValue(f(i)))
                op = "n"c
                Continue For
            End If
            If f(i) = " "c OrElse (f(i) = "="c AndAlso i + 1 = f.Length) Then Continue For
            Throw New InvalidOperationException()
        Next
        If op <> "n"c Then Throw New InvalidOperationException()
        Return sum
    End Function
End Module