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

Public Class Question11
    Inherits Question
    Public Sub New()
        Me.Name = "11) Largest product in a grid"
        Me.Text = "In the 20×20 grid below, four numbers along a diagonal line have been marked in red.

<See code for grid>

The product of these numbers is 26 × 63 × 78 × 14 = 1788696.

What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?"
    End Sub

    Public Function Execute() As String

        Dim lngAnswer As Long, runstart As DateTime, elapsed As TimeSpan
        runstart = Now()

        Dim strGrid As String
        strGrid = "08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08\" & 'Line 1
                  "49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00\" & '2
                  "81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65\" & '3
                  "52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91\" & '4
                  "22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80\" & '5
                  "24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50\" & '6
                  "32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70\" & '7
                  "67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21\" & '8
                  "24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72\" & '9
                  "21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95\" & '10
                  "78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92\" & '11
                  "16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57\" & '12
                  "86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58\" & '13
                  "19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40\" & '14
                  "04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66\" & '15
                  "88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69\" & '16
                  "04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36\" & '17
                  "20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16\" & '18
                  "20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54\" & '19
                  "01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48"    '20
        '''''''''''01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 
        Dim arrGrid(19, 19) As String, arrRows As Array, arrItems As Array
        Dim j As Long, i As Long, tempAnswer As Long
        arrRows = Split(strGrid, "\")
        For j = 0 To UBound(arrRows)
            arrItems = Split(arrRows(j))
            For i = 0 To UBound(arrItems)
                arrGrid(j, i) = arrItems(i)
            Next
        Next

        '2nd number goes left(-) and right(+), 1st number goes up (-) and down(+)

        For i = 0 To UBound(arrGrid)
            For j = 0 To UBound(arrGrid, 2)
                'up
                If i - 3 < 0 Then GoTo NotUp
                tempAnswer = arrGrid(i, j) * arrGrid(i - 1, j) * arrGrid(i - 2, j) * arrGrid(i - 3, j)
                If tempAnswer > lngAnswer Then lngAnswer = tempAnswer
NotUp:
                'down
                If i + 3 > 19 Then GoTo NotDown
                tempAnswer = arrGrid(i, j) * arrGrid(i + 1, j) * arrGrid(i + 2, j) * arrGrid(i + 3, j)
                If tempAnswer > lngAnswer Then lngAnswer = tempAnswer
NotDown:
                'left
                If j - 3 < 0 Then GoTo NotLeft : 
                tempAnswer = arrGrid(i, j) * arrGrid(i, j - 1) * arrGrid(i, j - 2) * arrGrid(i, j - 3)
                If tempAnswer > lngAnswer Then lngAnswer = tempAnswer
NotLeft:
                'right
                If j + 3 > 19 Then GoTo NotRight : 
                tempAnswer = arrGrid(i, j) * arrGrid(i, j + 1) * arrGrid(i, j + 2) * arrGrid(i, j + 3)
                If tempAnswer > lngAnswer Then lngAnswer = tempAnswer
NotRight:
                'Down and to the right
                If i + 3 > 19 Or j + 3 > 19 Then GoTo NotDownRight
                tempAnswer = arrGrid(i, j) * arrGrid(i + 1, j + 1) * arrGrid(i + 2, j + 2) * arrGrid(i + 3, j + 3)
                If tempAnswer > lngAnswer Then lngAnswer = tempAnswer
NotDownRight:
                'Down and to the left
                If i + 3 > 19 Or j - 3 < 0 Then GoTo NotDownLeft
                tempAnswer = arrGrid(i, j) * arrGrid(i + 1, j - 1) * arrGrid(i + 2, j - 2) * arrGrid(i + 3, j - 3)
                If tempAnswer > lngAnswer Then lngAnswer = tempAnswer
NotDownLeft:
                'Up and to the right
                If i - 3 < 0 Or j + 3 > 19 Then GoTo NotUpRight
                tempAnswer = arrGrid(i, j) * arrGrid(i - 1, j + 1) * arrGrid(i - 2, j + 2) * arrGrid(i - 3, j + 3)
                If tempAnswer > lngAnswer Then lngAnswer = tempAnswer
NotUpRight:
                'Up and to the left
                If i - 3 < 0 Or j - 3 < 0 Then GoTo NotUpLeft
                tempAnswer = arrGrid(i, j) * arrGrid(i - 1, j - 1) * arrGrid(i - 2, j - 2) * arrGrid(i - 3, j - 3)
                If tempAnswer > lngAnswer Then lngAnswer = tempAnswer
NotUpLeft:
            Next
        Next
        elapsed = Now.Subtract(runstart)
        Return lngAnswer.ToString() + " - Runtime: " + elapsed.TotalSeconds.ToString("0.00000")
    End Function
End Class
Public Class Question12
    Inherits Question
    Public Sub New()
        Me.Name = "12) Highly divisible triangular number"
        Me.Text = "The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. 
The first ten terms would be:

1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

Let us list the factors of the first seven triangle numbers:

 1: 1
 3: 1,3
 6: 1,2,3,6
10: 1,2,5,10
15: 1,3,5,15
21: 1,3,7,21
28: 1,2,4,7,14,28
We can see that 28 is the first triangle number to have over five divisors.

What is the value of the first triangle number to have over five hundred divisors?"
    End Sub
    Public Function Execute()
        Dim lngAnswer As Long, runstart As DateTime = Now(), elapsed As TimeSpan
        Dim n As Long = 6, TriangleNumber As Long = 0
        Dim divs As Long = 0, div As Divisors
        'First make a triangle number
        Do Until divs > 500
            divs = 0 : TriangleNumber = 0
            For i = 1 To n
                TriangleNumber += i
            Next

            'and then get the divisors
            div = Nothing
            div = New Divisors(TriangleNumber)
            div.GetDivisors()
            divs = div.DivCount
            n += 1
        Loop

        lngAnswer = TriangleNumber

        elapsed = Now.Subtract(runstart)
        Return lngAnswer.ToString() + " - Runtime: " + elapsed.TotalSeconds.ToString("0.00000")
    End Function


End Class
