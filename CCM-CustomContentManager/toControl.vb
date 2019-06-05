Public Class toControl
    ''' <summary>
    ''' Gives your a ControlStructure
    ''' </summary>
    ''' <param name="json"></param>
    ''' <returns></returns>
    Function getControlStructure(json) As ControlStructure
        json = DecompressString(json)
        Dim obj As ControlStructure = New System.Web.Script.Serialization.JavaScriptSerializer().Deserialize(json, GetType(ControlStructure))

        For Each s As String In obj.subControls
            obj.extsubControls.Add(getControlStructure(s))
        Next

        Return obj
    End Function
    ''' <summary>
    ''' Gives you a control from a ControlStructure
    ''' </summary>
    ''' <param name="cs"></param>
    ''' <returns></returns>
    Function getControl(cs As ControlStructure) As Windows.Forms.Control
        Dim workingItem As Windows.Forms.Control
        Select Case cs.strItem
            Case stype.Button
                workingItem = New Windows.Forms.Button
            Case stype.Label
                workingItem = New Windows.Forms.Label
            Case stype.Panel
                workingItem = New Windows.Forms.Panel
            Case stype.PictureBox
                workingItem = New Windows.Forms.PictureBox
            Case stype.TextBox
                workingItem = New Windows.Forms.TextBox
            Case stype.CheckBox 'NF
                workingItem = New Windows.Forms.CheckBox
            Case stype.ListBox 'NF
                workingItem = New Windows.Forms.ListBox
            Case stype.ComboBox 'NF
                workingItem = New Windows.Forms.ComboBox
            Case stype.RadioButton 'NF
                workingItem = New Windows.Forms.RadioButton
            Case stype.ProgressBar 'NF
                workingItem = New Windows.Forms.ProgressBar
            Case stype.TreeView 'NF
                workingItem = New Windows.Forms.TreeView
            Case stype.ListView 'NF
                workingItem = New Windows.Forms.ListView
            Case stype.LinkLabel 'NF
                workingItem = New Windows.Forms.LinkLabel
            Case stype.NumericUpDown 'NF
                workingItem = New Windows.Forms.NumericUpDown
            Case stype.RichTextBox 'NF
                workingItem = New Windows.Forms.RichTextBox
            Case Else
                Return Nothing
        End Select

        workingItem.BackgroundImage = Base64ToImage(cs.backgroundimage.image)
        workingItem.BackgroundImageLayout = cs.backgroundimage.layout
        Try
            workingItem.GetType.GetProperty("Image").SetValue(workingItem, Base64ToImage(cs.image.image))
            workingItem.GetType.GetProperty("SizeMode").SetValue(workingItem, cs.image.layout)
        Catch
        End Try
        workingItem.Size = cs.size
        workingItem.Location = cs.location

        workingItem.BackColor = cs.backcolor
        workingItem.ForeColor = cs.forecolor
        Try
            workingItem.GetType.GetProperty("FlatStyle").SetValue("FlatStyle", cs.style)
        Catch
        End Try

        workingItem.Font = CreateFont(cs.font.name, cs.font.size, cs.font.bold, cs.font.italics, cs.font.underline)

        workingItem.Text = cs.text

        workingItem.Name = cs.name
        For Each cntrls As ControlStructure In cs.extsubControls
            workingItem.Controls.Add(getControl(cntrls))
        Next
        Return workingItem
    End Function
    ''' <summary>
    ''' Combines getControlStructure() and getControl()
    ''' </summary>
    ''' <param name="Json"></param>
    ''' <returns></returns>
    Function getControl(Json) As Windows.Forms.Control
        Return getControl(getControlStructure(Json))
    End Function

    Private Function CreateFont(ByVal fontName As String,
                           ByVal fontSize As Integer,
                           ByVal isBold As Boolean,
                           ByVal isItalic As Boolean,
                           ByVal isUnderline As Boolean) As Drawing.Font

        Dim styles As Drawing.FontStyle = Drawing.FontStyle.Regular

        If (isBold) Then
            styles = styles Or Drawing.FontStyle.Bold
        End If

        If (isItalic) Then
            styles = styles Or Drawing.FontStyle.Italic
        End If

        If (isUnderline) Then
            styles = styles Or Drawing.FontStyle.Underline
        End If

        Dim newFont As New Drawing.Font(fontName, fontSize, styles)
        Return newFont

    End Function
    Private Function Base64ToImage(ByVal sData As String) As Drawing.Image
        Dim oImage As Drawing.Image = Nothing

        If sData.Length > 0 Then
            ' String decodieren und in Byte-Array umwandeln
            Dim nBytes() As Byte = Convert.FromBase64String(sData)
            If nBytes IsNot Nothing AndAlso nBytes.Length > 0 Then
                ' Byte-Array in Image-Objekt umwandeln
                With New System.Drawing.ImageConverter
                    oImage = CType(.ConvertFrom(nBytes), Drawing.Image)
                End With
            End If
        End If
        Return (oImage)
    End Function
    Private Function DecompressString(ByVal compressedText As String) As String
        Dim gZipBuffer() As Byte = Convert.FromBase64String(compressedText)
        Using memoryStream = New IO.MemoryStream()
            Dim dataLength As Integer = BitConverter.ToInt32(gZipBuffer, 0)
            memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4)

            Dim buffer = New Byte(dataLength - 1) {}

            memoryStream.Position = 0
            Using gZipStream = New IO.Compression.GZipStream(memoryStream, IO.Compression.CompressionMode.Decompress)
                gZipStream.Read(buffer, 0, buffer.Length)
            End Using

            Return System.Text.Encoding.UTF8.GetString(buffer)
        End Using
    End Function
End Class
