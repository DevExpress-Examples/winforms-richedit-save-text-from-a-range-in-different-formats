Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace GetTextMethods

    Public Partial Class frmBrowser
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub SetHtml(ByVal htmlText As String)
            webBrowser1.DocumentText = htmlText
        End Sub
    End Class
End Namespace
