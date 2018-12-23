Public Class Form1
    Private _dataOperations As New DataOperations
    Private _bsPeople As New BindingSource
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtPeople = _dataOperations.ReadPeople()
        If _dataOperations.IsSuccessFul Then
            _bsPeople.DataSource = dtPeople
            DataGridView1.DataSource = _bsPeople
            BindingNavigator1.BindingSource = _bsPeople
        Else
            MessageBox.Show($"Failed to load data{Environment.NewLine}{_dataOperations.LastExceptionMessage}")
        End If
    End Sub
    Private Sub exitButton_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        Close()
    End Sub
End Class
