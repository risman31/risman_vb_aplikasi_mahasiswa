Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Public Class Form1
    Public id As String
    Private Sub carinis()
        Try
            DataGridView1.Rows.Clear()
            Dim uriString As String = "http://localhost/CodeIgniter_API/index.php/api/GetData" & txt_search.Text.Trim
            Dim uri As New Uri(uriString)
            Dim request As HttpWebRequest = HttpWebRequest.Create(uri)
            request.Method = "GET"
            Dim response As HttpWebResponse = request.GetResponse()
            Dim read = New StreamReader(response.GetResponseStream())
            Dim raw As String = read.ReadToEnd()
            Dim dict As Object = New JavaScriptSerializer().Deserialize(Of List(Of Object))(raw)
            For Each item As Object In dict
                DataGridView1.Rows.Add(item("npm").ToString, item("nama").ToString, item("jurusan").ToString,
                                       item("prodi").ToString, item("kelas").ToString)
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Notifikasi")
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        carinis()
    End Sub
End Class
