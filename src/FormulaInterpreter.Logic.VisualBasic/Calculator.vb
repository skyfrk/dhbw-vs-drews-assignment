Public Module Calculator
    ' the idea of my approach is to loop through given formula string, validate each char and calculate the result at the same time.
    Function Solve(ByVal s As String) As Integer
        ' the formula should not be null.
        If s Is Nothing Then Throw New ArgumentNullException()
        ' to remove whitespace before and after the first tokens.
        Dim f = s.Trim()
        ' quick fail if there are less than 2 tokens.
        If f.Length < 3 Then Throw New InvalidOperationException()
        ' variable to keep track of the sum.
        Dim sum As Integer = 0
        ' variable to keep track of the last operation, starting with +.
        Dim op As Char = "+"c
        ' loop through given string.
        For i As Integer = 0 To f.Length - 1
            ' update the current operation
            If (f(i) = "+"c OrElse f(i) = "-"c) AndAlso op = "n"c Then
                op = f(i)
                Continue For
            End If
            ' add or subtract a number
            If Char.IsDigit(f(i)) AndAlso op <> "n"c Then
                If op = "+"c Then sum += CInt(Char.GetNumericValue(f(i)))
                If op = "-"c Then sum -= CInt(Char.GetNumericValue(f(i)))
                op = "n"c
                Continue For
            End If
            ' skip throwing an exception if the = token was detected.
            If f(i) = " "c OrElse (f(i) = "="c AndAlso i + 1 = f.Length) Then Continue For
            ' fail for invalid tokens.
            Throw New InvalidOperationException()
        Next
        ' fail if last operation wasnt adding or subtracting a number
        If op <> "n"c Then Throw New InvalidOperationException()
        Return sum
    End Function
End Module