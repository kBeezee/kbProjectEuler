Imports System.Math

Public Class Question10
    Inherits Question
    Public Sub New()
        Me.Name = "10) Summation of primes"
        Me.Text = "The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

Find the sum of all the primes below two million."
    End Sub

    Public Function Execute() As String
        Dim lngAnswer As Long, runstart As DateTime, elapsed As TimeSpan
        runstart = Now()

        For i = 1 To CLng("2,000,000")
            If IsPrime(i) Then lngAnswer += i
        Next

        elapsed = Now.Subtract(runstart)
        Return lngAnswer.ToString() + " - Runtime: " + elapsed.TotalSeconds.ToString("0.00000")
    End Function
End Class
