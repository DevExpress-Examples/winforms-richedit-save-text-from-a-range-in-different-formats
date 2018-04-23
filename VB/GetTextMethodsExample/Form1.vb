Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Diagnostics
Imports System.Drawing.Imaging
#Region "#usings"
Imports DevExpress.XtraEditors
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.Export
Imports DevExpress.XtraRichEdit.Export.Html
Imports DevExpress.XtraRichEdit.Utils
Imports DevExpress.XtraRichEdit.Services
#End Region ' #usings

Namespace GetTextMethods
    Public Partial Class Form1
        Inherits DevExpress.XtraEditors.XtraForm
        Private fileName As String = String.Empty
		Private rich As RichEditControl = Me.richEditControl

        Public Sub New()
            InitializeComponent()
            rich.LoadDocument("sample_document.rtf", DocumentFormat.Rtf)
        End Sub

        Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
            Me.fileName = GetFileName("Web Archive|*.mht")
            If String.IsNullOrEmpty(fileName) Then
                Return
            End If
            Try
                Dim mhtText As String = Me.rich.Document.GetMhtText(Me.rich.Document.Range)
                SaveFile(Me.fileName, mhtText)
                OpenFile(Me.fileName)
            Finally
                Me.fileName = String.Empty
            End Try
        End Sub
        Private Sub simpleButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton2.Click
            Me.fileName = GetFileName("Hypertext Markup Language|*.html")
            If String.IsNullOrEmpty(fileName) Then
                Return
            End If
            Try
                Dim uriProvider As UriProvider = New UriProvider(Path.GetDirectoryName(fileName))
                Dim htmlText As String = Me.rich.Document.GetHtmlText(Me.rich.Document.Range, uriProvider)
                SaveFile(Me.fileName, htmlText)
                OpenFile(Me.fileName)
            Finally
                Me.fileName = String.Empty
            End Try
        End Sub
        Private Sub simpleButton3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton3.Click
            Me.fileName = GetFileName("Word Document|*.docx")
            If String.IsNullOrEmpty(fileName) Then
                Return
            End If
            Try
                Dim bytes As Byte() = Me.rich.Document.GetOpenXmlBytes(Me.rich.Document.Range)
                SaveFile(Me.fileName, bytes)
                OpenFile(Me.fileName)
            Finally
                Me.fileName = String.Empty
            End Try
        End Sub
        Private Sub simpleButton4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton4.Click
            Me.fileName = GetFileName("Rich Text Format|*.rtf")
            If String.IsNullOrEmpty(fileName) Then
                Return
            End If
            Try
                Dim rtfText As String = Me.rich.Document.GetRtfText(Me.rich.Document.Range)
                SaveFile(Me.fileName, rtfText)
                OpenFile(Me.fileName)
            Finally
                Me.fileName = String.Empty
            End Try
        End Sub
        Private Sub SaveFile(ByVal fileName As String, ByVal value As String)
            Using stream As FileStream = New FileStream(fileName, FileMode.Create, FileAccess.Write)
                Using writer As StreamWriter = New StreamWriter(stream)
                    writer.Write(value)
                End Using
            End Using
        End Sub
        Private Sub SaveFile(ByVal fileName As String, ByVal bytes As Byte())
            Using stream As FileStream = New FileStream(fileName, FileMode.Create, FileAccess.Write)
                stream.Write(bytes, 0, bytes.Length)
            End Using
        End Sub
        Private Function GetFileName(ByVal filter As String) As String
            Using saveFileDialog As SaveFileDialog = New SaveFileDialog()
                saveFileDialog.Filter = filter
                saveFileDialog.RestoreDirectory = True
                saveFileDialog.CheckFileExists = False
                saveFileDialog.CheckPathExists = True
                saveFileDialog.OverwritePrompt = True
                saveFileDialog.DereferenceLinks = True
                saveFileDialog.ValidateNames = True
                If saveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                    Return saveFileDialog.FileName
                End If
            End Using
            Return String.Empty
        End Function
        Private Sub OpenFile(ByVal fileName As String)
            If XtraMessageBox.Show("Do you want to open this file?", "Html Example",  _
				MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim process As Process = New Process()
                Try
                    process.StartInfo.FileName = fileName
                    process.Start()
                Catch
                End Try
            End If
        End Sub
        #Region "#beforeexport"
        Private Sub richEditControl_BeforeExport(ByVal sender As Object, ByVal e As BeforeExportEventArgs) _
                Handles richEditControl.BeforeExport
            Dim options As HtmlDocumentExporterOptions = TryCast(e.Options, HtmlDocumentExporterOptions)
            If Not options Is Nothing Then
                options.CssPropertiesExportType = CssPropertiesExportType.Link
                options.HtmlNumberingListExportFormat = HtmlNumberingListExportFormat.HtmlFormat
                options.TargetUri = Path.GetFileNameWithoutExtension(Me.fileName)
            End If
        End Sub
        #End Region ' beforeexport
    End Class

    #Region "#uriprovider"
    Public Class UriProvider
        Implements IUriProvider
    Private rootDirecory As String
    Public Sub New(ByVal rootDirectory As String)
        If String.IsNullOrEmpty(rootDirectory) Then
            Exceptions.ThrowArgumentException("rootDirectory", rootDirectory)
        End If
        Me.rootDirecory = rootDirectory
    End Sub

        Public Function CreateCssUri(ByVal rootUri As String, ByVal styleText As String, _
			ByVal relativeUri As String) _
                As String Implements IUriProvider.CreateCssUri
            Dim cssDir As String = String.Format("{0}\{1}", Me.rootDirecory, rootUri.Trim("/"c))
            If (Not Directory.Exists(cssDir)) Then
                Directory.CreateDirectory(cssDir)
            End If
            Dim cssFileName As String = String.Format("{0}\style.css", cssDir)
            File.AppendAllText(cssFileName, styleText)
            Return GetRelativePath(cssFileName)
        End Function
        Public Function CreateImageUri(ByVal rootUri As String, ByVal image As Image, _
			ByVal relativeUri As String) As String _
            Implements IUriProvider.CreateImageUri
            Dim imagesDir As String = String.Format("{0}\{1}", Me.rootDirecory, rootUri.Trim("/"c))
            If (Not Directory.Exists(imagesDir)) Then
                Directory.CreateDirectory(imagesDir)
            End If
            Dim imageName As String = String.Format("{0}\{1}.png", imagesDir, Guid.NewGuid())
            image.Save(imageName, ImageFormat.Png)
            Return GetRelativePath(imageName)
        End Function
    Private Function GetRelativePath(ByVal path As String) As String
        Dim substring As String = path.Substring(Me.rootDirecory.Length)
        Return substring.Replace("\", "/").Trim("/"c)
    End Function
    End Class
    #End Region ' #uriprovider
End Namespace