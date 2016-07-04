﻿Imports System.Collections.ObjectModel
Imports System.Reflection

Class MainWindow
    Public Function FindDerivedTypes(assembly As Assembly, baseType As Type) As IEnumerable(Of Type)
        Return assembly.GetTypes().Where(Function(t) baseType.IsAssignableFrom(t))
    End Function


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim qs As New Collection(Of Question)
        qs.Add(New Question1) : qs.Add(New Question2) : qs.Add(New Question3)
        qs.Add(New Question4) : qs.Add(New Question5) : qs.Add(New Question6)
        qs.Add(New Question7)
        lvQuestions.ItemsSource = qs
    End Sub

    Private Sub lvQuestions_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles lvQuestions.SelectionChanged
        tbQuestion.Text = lvQuestions.Items(lvQuestions.SelectedIndex).Text
    End Sub

    Private Sub btnExecute_Click(sender As Object, e As RoutedEventArgs) Handles btnExecute.Click
        tbAnswer.Text = lvQuestions.Items(lvQuestions.SelectedIndex).Execute()
    End Sub
End Class
