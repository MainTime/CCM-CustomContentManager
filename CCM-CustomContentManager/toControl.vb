Public Class toControl
    Function getControl(json) As ControlStructure
        Dim obj As ControlStructure = New System.Web.Script.Serialization.JavaScriptSerializer().Deserialize(json, GetType(ControlStructure))

        For Each s As String In obj.subControls
            obj.extsubControls.Add(getControl(s))
        Next

        Return obj
    End Function
End Class
