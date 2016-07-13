Imports System.Math
Imports System.ComponentModel
Imports System.Runtime.CompilerServices.ExtensionAttribute
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
    Function Factorial(lngInput As Long) As Double
        Dim lngOutput As Double = 1
        For i = lngInput To 1 Step -1
            lngOutput *= i
        Next
        Return lngOutput
    End Function

    Public Class Divisors
        'https://www.youtube.com/watch?v=2JM2oImb9Qg
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
    Public Class ConvertToWords
        Private _wordDictionary As New Dictionary(Of Long, String)
        Private Const OneThousand As Long = 1000
        Private Const OneMillion As Long = 1000000
        Private Const OneBillion As Long = 1000000000
        Private Const OneTrillion As Long = 1000000000000
        Private Const OneQuadrillion As Long = 1000000000000000
        Private Const OneQuintillion As Long = 1000000000000000000

        Public Function ConvertNumbersToWords(lngInput As Long) As String
            Dim strOutput As String
            If lngInput <= 0 Then Exit Function

            '1-20
            If lngInput <= 20 Then Return _wordDictionary(lngInput)

            '21 - 99
            If lngInput < 100 Then
                Return _wordDictionary(Left(lngInput, 1) * 10) & "-" & ConvertNumbersToWords(Right(lngInput, 1))
            End If

            '100-1000
            If lngInput < 1000 Then
                Return ConvertNumbersToWords(Left(lngInput, 1)) & " hundred " & ConvertNumbersToWords(Mid(lngInput, 2))
            End If

            '>1000
            If lngInput / OneQuintillion >= 1 Then

            ElseIf lngInput / OneQuadrillion >= 1 Then

            ElseIf lngInput / OneTrillion >= 1 Then

            ElseIf lngInput / OneBillion >= 1 Then

            ElseIf lngInput / OneMillion >= 1 Then

            ElseIf lngInput / OneThousand >= 1 Then
                Select Case Len(lngInput) / 2
                    Case 4
                        Return ConvertNumbersToWords(Left(lngInput, 1)) & " thousand and " & ConvertNumbersToWords(Right(lngInput, 3))
                    Case 5
                        Return ConvertNumbersToWords(Left(lngInput, 2)) & " thousand and " & ConvertNumbersToWords(Right(lngInput, 3))
                    Case 6
                        Return ConvertNumbersToWords(Left(lngInput, 3)) & " thousand and " & ConvertNumbersToWords(Right(lngInput, 3))
                End Select
            End If

        End Function

        Public Sub New()
            _wordDictionary.Add(1, "one")
            _wordDictionary.Add(2, "two")
            _wordDictionary.Add(3, "three")
            _wordDictionary.Add(4, "four")
            _wordDictionary.Add(5, "five")
            _wordDictionary.Add(6, "six")
            _wordDictionary.Add(7, "seven")
            _wordDictionary.Add(8, "eight")
            _wordDictionary.Add(9, "nine")
            _wordDictionary.Add(10, "ten")
            _wordDictionary.Add(11, "eleven")
            _wordDictionary.Add(12, "twelve")
            _wordDictionary.Add(13, "thirteen")
            _wordDictionary.Add(14, "fourteen")
            _wordDictionary.Add(15, "fifteen")
            _wordDictionary.Add(16, "sixteen")
            _wordDictionary.Add(17, "seventeen")
            _wordDictionary.Add(18, "eighteen")
            _wordDictionary.Add(19, "nineteen")
            _wordDictionary.Add(20, "twenty")
            _wordDictionary.Add(30, "thirty")
            _wordDictionary.Add(40, "forty")
            _wordDictionary.Add(50, "fifty")
            _wordDictionary.Add(60, "sixty")
            _wordDictionary.Add(70, "seventy")
            _wordDictionary.Add(80, "eighty")
            _wordDictionary.Add(90, "ninety")
            _wordDictionary.Add(100, "hundred")
            _wordDictionary.Add(OneThousand, "thousand")
            _wordDictionary.Add(OneMillion, "million")
            _wordDictionary.Add(OneBillion, "billion")
            _wordDictionary.Add(OneTrillion, "trillion")
            _wordDictionary.Add(OneQuadrillion, "quadrillion")
            _wordDictionary.Add(OneQuintillion, "quintillion")
        End Sub
    End Class

End Module



