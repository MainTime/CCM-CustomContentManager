Public Class Form1
    Dim main As New CCM_CustomContentManager.toControl
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.RichTextBox1.Text = main.GetCode(Panel1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim str As New CCM_CustomContentManager.toJson()
        Dim s = str.getControl(RichTextBox2.Text)
        MsgBox(s)
    End Sub
End Class
