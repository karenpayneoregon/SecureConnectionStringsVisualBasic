Imports System.Data.SqlClient
Imports BaseLibrary
Imports ConfigurationLibrary_vb
Public Class DataOperations
    Inherits BaseExceptionsHandler

    Private operations As New ConnectionProtection(Application.ExecutablePath)
    Public Sub New()
        If Not operations.IsProtected() Then
            operations.EncryptFile()
        End If
    End Sub
    ''' <summary>
    ''' Read data from SQL-Server database where the connection string has been setup
    ''' under My.Settings of type Connection String.
    ''' </summary>
    ''' <returns>A DataTable representing people data or on failure an empty DataTable</returns>
    Public Function ReadPeople() As DataTable
        Dim dt As New DataTable
        Const selectStatement = "SELECT Identifier, FirstName, LastName FROM dbo.People"

        operations.DecryptFile()

        Using cn = New SqlConnection(My.Settings.MainConnection)
            Using cmd = New SqlCommand() With {.Connection = cn, .CommandText = selectStatement}
                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader())

                Catch ex As Exception
                    mHasException = True
                    mLastException = ex
                Finally
                    operations.EncryptFile()
                End Try
            End Using
        End Using

        Return dt

    End Function
End Class
