Public Class toJson
    Function getJson(cnt As System.Windows.Forms.Control) As String
        Dim jsS As New ControlStructure
        With jsS

            Dim c = 0
            For Each i In [Enum].GetNames(GetType(stype))
                If cnt.GetType.Name = i Then
                    .strItem = c
                End If
                c += 1
            Next

            .size = cnt.Size

            .location = cnt.Location

            .backcolor = cnt.BackColor
            .forecolor = cnt.ForeColor

            Try
                .style = cnt.GetType.GetProperty("FlatStyle").GetValue(cnt)
            Catch
                .style = Nothing
            End Try

            Try
                .text = cnt.GetType.GetProperty("Text").GetValue(cnt)
            Catch
                .text = Nothing
            End Try

            .backgroundimage.image = ImageToBase64(cnt.BackgroundImage)

            .backgroundimage.layout = cnt.BackgroundImageLayout

            Try
                .image.image = ImageToBase64(cnt.GetType.GetProperty("Image").GetValue(cnt))
            Catch
                .image.image = Nothing
            End Try

            Try
                .image.layout = cnt.GetType.GetProperty("SizeMode").GetValue(cnt)
            Catch
                .image.layout = Nothing
            End Try

            If cnt.Controls.Count > 0 Then
                For Each xxxxx1 As Windows.Forms.Control In cnt.Controls
                    .subControls.Add(getJson(xxxxx1))
                Next
            End If

            .font.name = cnt.Font.Name
            .font.size = cnt.Font.Size
            .font.fontfamily = cnt.Font.FontFamily.Name
            .font.bold = cnt.Font.Bold
            .font.italics = cnt.Font.Italic
            .font.underline = cnt.Font.Underline

            .name = cnt.Name
        End With
        Return New System.Web.Script.Serialization.JavaScriptSerializer().Serialize(jsS)
    End Function
    Private Function ImageToBase64(ByVal oImage As Drawing.Image) As String
        If oImage IsNot Nothing Then
            With New System.Drawing.ImageConverter
                Dim nBytes() As Byte = CType(.ConvertTo(oImage, GetType(Byte())), Byte())
                Return (Convert.ToBase64String(nBytes,
                      Base64FormattingOptions.InsertLineBreaks))
            End With
        Else
            Return ("")
        End If
    End Function
End Class
Public Enum stype
    Button
    Label
    PictureBox
    TextBox
    Panel
End Enum