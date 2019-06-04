Imports Newtonsoft.Json
Public Class ControlStructure
    <JsonProperty("strItem")>
    Property strItem As stype

    <JsonProperty("size")>
    Property size As System.Drawing.Size

    <JsonProperty("location")>
    Property location As System.Drawing.Point

    <JsonProperty("backcolor")>
    Property backcolor As System.Drawing.Color

    <JsonProperty("forecolor")>
    Property forecolor As System.Drawing.Color

    <JsonProperty("style")>
    Property style As Integer

    <JsonProperty("font")>
    Property font As New FontStructure

    <JsonProperty("text")>
    Property text As String

    <JsonProperty("name")>
    Property name As String

    <JsonProperty("backgroundimage")>
    Property backgroundimage As New ImageStructure

    <JsonProperty("image")>
    Property image As New ImageStructure

    <JsonProperty("subControls")>
    Property subControls As New List(Of String)

    Property extsubControls As New List(Of ControlStructure)
End Class
Public Class FontStructure
    <JsonProperty("size")>
    Property size As String

    <JsonProperty("name")>
    Property name As String

    <JsonProperty("name")>
    Property fontfamily As String

    <JsonProperty("name")>
    Property bold As Boolean

    <JsonProperty("name")>
    Property italics As Boolean

    <JsonProperty("name")>
    Property underline As Boolean
End Class
Public Class ImageStructure
    <JsonProperty("name")>
    Property image As String

    <JsonProperty("name")>
    Property layout As String
End Class
