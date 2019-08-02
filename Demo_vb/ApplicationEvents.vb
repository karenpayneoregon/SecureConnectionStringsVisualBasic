Imports ConfigurationLibrary_vb
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    Partial Friend Class MyApplication
        Private operations As New ConnectionProtection(
            Windows.Forms.Application.ExecutablePath)

        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            If Not operations.IsProtected() Then
                operations.EncryptFile()
            End If
            operations.DecryptFile()
        End Sub
        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            operations.EncryptFile()
        End Sub
    End Class
End Namespace
