Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Computer.Clipboard.SetText(New CCM_CustomContentManager.toJson().getJson(Panel1))
    End Sub
End Class
