Public Class Shower


    Private Sub Shower_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Me.Controls.Add(New CCM_CustomContentManager.toControl().getControl(InputBox("", "", My.Computer.Clipboard.GetText)))
    End Sub

    Private Sub Shower_ResizeBegin(sender As Object, e As EventArgs) Handles MyBase.ResizeBegin
        Me.Controls.Clear()
    End Sub
End Class