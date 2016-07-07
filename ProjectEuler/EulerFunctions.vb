Imports System.Math
''Only Functions that are generic and can be applied to many questions.
Module EulerFunctions
    Function IsPrime(n As Long) As Boolean
        If n = 0 Then Return False
        If n = 1 Then Return False
        If n = 2 Then Return True

        Dim divs As Long = 2
        For i = 2 To Sqrt(n + 1)
            If n Mod i = 0 Then
                divs += 1
                If divs > 2 Then
                    Return False
                End If
            End If
        Next

        If divs = 2 Then Return True

    End Function

    Function IsPalindrome(n As String) As Boolean
        If n = StrReverse(n) Then
            Return True
        Else
            Return False
        End If
    End Function

    Function MultipleString(strInput As String)
        Dim answer As Long = 1
        For Each c In strInput
            answer = answer * c.ToString()
        Next
        Return answer
    End Function

    Public Class Divisors
        Private lngDivisorCount As Long
        Private lngNumber As Long
        Private arrDivisors As Collection
        Public Sub New(lngValue As Long)
            lngNumber = lngValue
            arrDivisors = Nothing
            arrDivisors = New Collection
        End Sub

        Public ReadOnly Property Number As Long
            Get
                Return lngNumber
            End Get
        End Property
        Public ReadOnly Property DivCount As Long
            Get
                Return lngDivisorCount
            End Get
        End Property
        Public Sub GetDivisors()
            Dim lngTempNum As Long = lngNumber

            While lngTempNum Mod 2 = 0
                lngTempNum = lngTempNum / 2
                arrDivisors.Add(2)
            End While

            For i = 3 To Sqrt(lngTempNum) Step 2
                While lngTempNum Mod i = 0
                    arrDivisors.Add(i)
                    lngTempNum = lngTempNum / i
                End While
            Next i

            If lngTempNum > 2 Then arrDivisors.Add(lngTempNum)

            Dim arrDivisorsWithExponents As New Dictionary(Of Long, Long)
            For Each n As Long In arrDivisors
                If arrDivisorsWithExponents.ContainsKey(n) Then
                    arrDivisorsWithExponents(n) += 1
                Else
                    arrDivisorsWithExponents.Add(n, 1)
                End If
            Next

            lngDivisorCount = 1
            For Each p In arrDivisorsWithExponents
                lngDivisorCount = lngDivisorCount * (p.Value + 1)
            Next
        End Sub
    End Class
End Module
