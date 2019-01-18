Imports mshtml
Imports System.Windows.Forms.WebBrowser
Imports System.Data
Imports System.Data.OleDb
Public Class Form1
    Dim flag As Integer
    Dim cn As New OleDbConnection
    Dim dr As OleDbDataReader
    Dim cmd As New OleDbCommand
    Dim adap As New OleDbDataAdapter
    Dim dset As DataSet = New DataSet()
    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        WebBrowser1.Navigate("https://www.linkedin.com/uas/login")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        WebBrowser1.Document.GetElementById("session_key").SetAttribute("value", "suparnika.mohata@rediffmail.com")
        WebBrowser1.Document.GetElementById("session_password").SetAttribute("value", "dolly04")
        WebBrowser1.Document.GetElementById("signin").InvokeMember("click")
        
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        WebBrowser1.Document.GetElementById("keywords").SetAttribute("value", "studied at ycce")
        WebBrowser1.Document.GetElementById("type").SetAttribute("value", "people")
        WebBrowser1.Document.GetElementById("search").InvokeMember("click")
        
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        For Each div_elem As HtmlElement In WebBrowser1.Document.GetElementsByTagName("div")
            If div_elem.Id = "results-col" Then
                cmd = New OleDbCommand("insert into major values(div_elem.InnerText)")
                Dim dr As DataRow
                For Each dr In dset.Tables(0).Rows
                    Dim i As Integer
                    For i = 1 To dset.Tables(0).Columns.Count
                        Me.dataset.DataSource = dset.Tables(0)
                    Next i
                    flag = 1
                Next

            End If
        Next
       
        For Each a_elem As HtmlElement In Me.WebBrowser1.Document.GetElementsByTagName("a")
            Try
                If a_elem.GetAttribute("title") = "Next Page" Then
                    WebBrowser1.Navigate(a_elem.GetAttribute("href"))
                    Do Until WebBrowser1.ReadyState = WebBrowserReadyState.Complete
                        Application.DoEvents()
                    Loop
                    Button4.PerformClick()
                End If

            Catch unaceess As UnauthorizedAccessException
                Debug.WriteLine("Search complete")
            End Try
        Next
        cn.Close()
    End Sub
    
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cn.ConnectionString = "Provider= Microsoft.Jet.OleDB.4.0;" & _
        "Data Source=" & "D:\major.mdb"
        cn.Open()
    End Sub


End Class


































