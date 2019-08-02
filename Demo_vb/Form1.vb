Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: This line of code loads data into the 'PeopleDataSet.People' table. You can move, or remove it, as needed.

        Me.PeopleTableAdapter.Fill(Me.PeopleDataSet.People)

    End Sub
    Private Sub PeopleBindingNavigatorSaveItem_Click_1(sender As Object, e As EventArgs) Handles PeopleBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.PeopleBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PeopleDataSet)
    End Sub
    Private Sub exitButton_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        Close()
    End Sub
End Class
