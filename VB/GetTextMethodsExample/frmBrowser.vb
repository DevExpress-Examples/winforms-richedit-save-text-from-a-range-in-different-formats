Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace GetTextMethods
    Partial Public Class frmBrowser
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub SetHtml(ByVal htmlText As String)
            Me.webBrowser1.DocumentText = htmlText
        End Sub
    End Class
End Namespace
