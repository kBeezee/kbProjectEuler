﻿Imports System.Math
Public Class Question
    Private strName As String
    Private strText As String
    Public Property Name() As String
        Get
            Return strName
        End Get
        Set(value As String)
            strName = value
        End Set
    End Property
    Public Property Text() As String
        Get
            Return strText
        End Get
        Set(value As String)
            strText = value
        End Set
    End Property
    Public Function GetMe() As Question
        Return Me
    End Function
End Class

Public Class Question1
    Inherits Question
    Public Sub New()
        Me.Name = "1) Multiples of 3 and 5"
        Me.Text = "If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. " +
                "The sum of these multiples is 23." + vbNewLine _
                + vbNewLine + "Find the sum of all the multiples of 3 or 5 below 1000."
    End Sub

    Public Function Execute() as String
        Dim lngAnswer As Long, runstart As DateTime, elapsed As TimeSpan
        runstart = Now()
        For i = 1 To 1000 - 1
            If i Mod 3 = 0 Or i Mod 5 = 0 Then lngAnswer += i
        Next
        elapsed = Now.Subtract(runstart)
        Return lngAnswer.ToString() + " - Runtime: " + elapsed.TotalSeconds.ToString("0.00000")
    End Function
End Class

Public Class Question2
    Inherits Question
    Public Sub New()
        Me.Name = "2) Even Fibonacci numbers"
        Me.Text = "Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be" + vbNewLine + vbNewLine +
                     "1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ..." + vbNewLine + vbNewLine +
                     "By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms."
    End Sub
    Public Function Execute()
        Dim lngAnswer As Long, runstart As DateTime = Now(), elapsed As TimeSpan

        'Return "In Progress"
        Dim i As Long = 2, preI As Long = 1, t As Long
        Do While i < CLng("4,000,000") + 1
            If i Mod 2 = 0 Then
                lngAnswer += i
            End If
            t = preI
            preI = i
            i += t
        Loop

        elapsed = Now.Subtract(runstart)
        Return lngAnswer.ToString() + " - Runtime: " + elapsed.TotalSeconds.ToString("0.00000")
    End Function
End Class

Public Class Question3
    Inherits Question
    Public Sub New()
        Me.Name = "3) Largest prime factor"
        Me.Text = "The prime factors of 13195 are 5, 7, 13 and 29." + vbNewLine + vbNewLine +
                    "What is the largest prime factor of the number 600851475143 ?"
    End Sub
    Public Function Execute()
        Dim lngAnswer As Long, runstart As DateTime = Now(), elapsed As TimeSpan
        Dim n As Long = 600851475143
        Dim i As Long = 2

        For i = Sqrt(n) To 2 Step -1
            If n Mod i = 0 Then
                If IsPrime(i) Then lngAnswer = i : Exit For
            End If
        Next i

        elapsed = Now.Subtract(runstart)
        Return lngAnswer.ToString() + " - Runtime: " + elapsed.TotalSeconds.ToString("0.00000")
    End Function
End Class

Public Class Question4
    Inherits Question
    Public Sub New()
        Me.Name = "4) Largest palindrome product"
        Me.Text = "A palindromic number reads the same both ways. " +
            "largest palindrome made from the product of two 2-digit numbers Is 9009 = 91 × 99." + vbNewLine + vbNewLine +
            "Find the largest palindrome made from the product of two 3-digit numbers."
    End Sub
    Public Function Execute()
        Dim lngAnswer As Long, runstart As DateTime = Now(), elapsed As TimeSpan

        For i = 999 To 900 Step -1
            For j = 999 To 900 Step -1
                If IsPalindrome(i * j) Then
                    lngAnswer = i * j
                    GoTo BreakNested
                End If
            Next
        Next
BreakNested:

        elapsed = Now.Subtract(runstart)
        Return lngAnswer.ToString() + " - Runtime: " + elapsed.TotalSeconds.ToString("0.00000")
    End Function
End Class

Public Class Question5
    Inherits Question
    Public Sub New()
        Me.Name = "5) Smallest multiple"
        Me.Text = "2520 is the smallest number that can be divided by each of the numbers from 1 to 10 " +
            "without any remainder." + vbNewLine + vbNewLine +
            "What Is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?"
    End Sub
    Public Function Execute()
        Dim lngAnswer As Long, runstart As DateTime = Now(), elapsed As TimeSpan

        Dim r As Long = 20, n As Long = 2520, AllTen As Boolean = False
        While True
            For i = 2 To r
                If n Mod i <> 0 Then
                    AllTen = False
                    Exit For
                End If
                AllTen = True
            Next
            If AllTen = True Then
                lngAnswer = n : Exit While
            End If
            n += 1
        End While

        elapsed = Now.Subtract(runstart)
        Return lngAnswer.ToString() + " - Runtime: " + elapsed.TotalSeconds.ToString("0.00000")
    End Function
End Class

Public Class Question6
    Inherits Question
    Public Sub New()
        Me.Name = "6) Sum square difference"
        Me.Text = "The sum of the squares of the first ten natural numbers is: " + vbNewLine +
            "1^2 + 2^2 + ... + 10^2 = 385" + vbNewLine + vbNewLine +
            "The square of the sum of the first ten natural numbers is:" + vbNewLine +
            "(1 + 2 + ... + 10)^2 = 55^2 = 3025" + vbNewLine +
            "Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640." + vbNewLine + vbNewLine +
        "Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum."

    End Sub
    Public Function Execute()
        Dim lngAnswer As Long, runstart As DateTime = Now(), elapsed As TimeSpan

        Dim r As Long = 100
        Dim SquareOfSums As Long, SumOfSquares As Long
        'First do Square of Sum
        For i = 1 To r
            SquareOfSums += i
        Next
        SquareOfSums *= SquareOfSums

        For i = 1 To r
            SumOfSquares += i * i
        Next

        lngAnswer = SquareOfSums - SumOfSquares
        elapsed = Now.Subtract(runstart)
        Return lngAnswer.ToString() + " - Runtime: " + elapsed.TotalSeconds.ToString("0.00000")
    End Function
End Class

Public Class Question7
    Inherits Question
    Public Sub New()
        Me.Name = "7) 10001st prime"
        Me.Text = "By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13. " + vbNewLine +
                "What is the 10 001st prime number?"
    End Sub
    Public Function Execute()
        Dim lngAnswer As Long, runstart As DateTime = Now(), elapsed As TimeSpan

        Dim PrimeCounter As Long = 0, i As Long = 1
        Do Until PrimeCounter = 10001
            If IsPrime(i) Then PrimeCounter += 1
            i += 1
        Loop
        lngAnswer = i - 1

        elapsed = Now.Subtract(runstart)
        Return lngAnswer.ToString() + " - Runtime: " + elapsed.TotalSeconds.ToString("0.00000")
    End Function
End Class

Public Class Question8
    Inherits Question
    Public Sub New()
        Me.Name = "8) Largest product in a series"
        Me.Text = "The four adjacent digits in the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832." + vbNewLine + vbNewLine +
            "Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?" + vbNewLine + vbNewLine +
            "(Number string omitted)"
    End Sub
    Public Function Execute()
        Dim lngAnswer As Long, runstart As DateTime = Now(), elapsed As TimeSpan

        Dim DigitSampleSize As Long = 13
        Dim strNumberString As String =
            "73167176531330624919225119674426574742355349194934" +
"96983520312774506326239578318016984801869478851843" +
"85861560789112949495459501737958331952853208805511" +
"12540698747158523863050715693290963295227443043557" +
"66896648950445244523161731856403098711121722383113" +
"62229893423380308135336276614282806444486645238749" +
"30358907296290491560440772390713810515859307960866" +
"70172427121883998797908792274921901699720888093776" +
"65727333001053367881220235421809751254540594752243" +
"52584907711670556013604839586446706324415722155397" +
"53697817977846174064955149290862569321978468622482" +
"83972241375657056057490261407972968652414535100474" +
"82166370484403199890008895243450658541227588666881" +
"16427171479924442928230863465674813919123162824586" +
"17866458359124566529476545682848912883142607690042" +
"24219022671055626321111109370544217506941658960408" +
"07198403850962455444362981230987879927244284909188" +
"84580156166097919133875499200524063689912560717606" +
"05886116467109405077541002256983155200055935729725" +
"71636269561882670428252483600823257530420752963450"

        Dim DigitStart As Long = 1, DigitSample As String, DigitSampleProduct As Long
        For i = 1 To Len(strNumberString) - DigitSampleSize
            DigitSample = Mid(strNumberString, i, DigitSampleSize)
            DigitSampleProduct = MultipleString(DigitSample)
            If DigitSampleProduct > lngAnswer Then
                lngAnswer = DigitSampleProduct
            End If
        Next

        elapsed = Now.Subtract(runstart)
        Return lngAnswer.ToString() + " - Runtime: " + elapsed.TotalSeconds.ToString("0.00000")
    End Function
End Class

Public Class Question9
    Inherits Question
    Public Sub New()
        Me.Name = "9) Special Pythagorean triplet"
        Me.Text = "A Pythagorean triplet is a set of three natural numbers, a < b < c, for which," + vbNewLine +
                "a^2 + b^2 = c^2" + vbNewLine +
                "For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2." + vbNewLine + vbNewLine +
                "There exists exactly one Pythagorean triplet for which a + b + c = 1000." + vbNewLine +
                "Find the product abc."
    End Sub
    Public Function Execute()
        Dim lngAnswer As Long, runstart As DateTime = Now(), elapsed As TimeSpan
        Dim a, b, c As Long

        For a = 2 To 700
            For b = a + 1 To 700
                For c = b + 1 To 700
                    If (a * a) + (b * b) = (c * c) Then
                        If a + b + c = 1000 Then
                            lngAnswer = a * b * c
                            GoTo LeaveLoop
                        End If
                    End If
                Next
            Next
        Next
LeaveLoop:

        elapsed = Now.Subtract(runstart)
        Return lngAnswer.ToString() + " - Runtime: " + elapsed.TotalSeconds.ToString("0.00000")
    End Function
End Class