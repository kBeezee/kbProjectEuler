Public Class Question19
    Inherits Question
    Public Sub New()
        Me.Name = "19) Counting Sundays"
        Me.Text = "You are given the following information, but you may prefer to do some research for yourself.

1 Jan 1900 was a Monday.
Thirty days has September,
April, June and November.
All the rest have thirty-one,
Saving February alone,
Which has twenty-eight, rain or shine.
And on leap years, twenty-nine.
A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?"
    End Sub
    Public Function Execute()
        Dim lngAnswer As Long, runstart As DateTime = Now(), elapsed As TimeSpan


        Dim dtDate As Date = #12/30/1900#
        Do Until dtDate >= #1/1/2001#
            dtDate = dtDate.AddDays(7)
            If dtDate.Day = 1 Then
                lngAnswer += 1
            End If
        Loop

        elapsed = Now.Subtract(runstart)
        Return lngAnswer.ToString() + " - Runtime: " + elapsed.TotalSeconds.ToString("0.00000")
    End Function
End Class