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
End Module
