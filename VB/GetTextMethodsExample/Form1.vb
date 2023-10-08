Imports System
Imports System.Windows.Forms
Imports System.IO
Imports System.Diagnostics
Imports System.Drawing.Imaging

Namespace GetTextMethods

    Public Partial Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Private fileName As String = String.Empty

        Public Sub New()
            InitializeComponent()
            richEditControl.LoadDocument("sample_document.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
        End Sub

        Private Sub btnMht_Click(ByVal sender As Object, ByVal e As EventArgs)
            fileName = GetFileName("Web Archive|*.mht")
            Dim mhtText As String = String.Empty
            If String.IsNullOrEmpty(fileName) Then Return
            Try
'#Region "#exportmht"
                If richEditControl.Document.Selection.Length > 0 Then
                    Dim selection As DevExpress.XtraRichEdit.API.Native.DocumentRange = richEditControl.Document.Selection
                    Dim doc As DevExpress.XtraRichEdit.API.Native.SubDocument = selection.BeginUpdateDocument()
                    mhtText = doc.GetMhtText(selection)
                    selection.EndUpdateDocument(doc)
                Else
                    mhtText = richEditControl.Document.GetMhtText(richEditControl.Document.Range)
                End If

'#End Region  ' #exportmht
                SaveFile(fileName, mhtText)
                OpenFile(fileName)
            Finally
                fileName = String.Empty
            End Try
        End Sub

        Private Sub btnHtmlCustomUri_Click(ByVal sender As Object, ByVal e As EventArgs)
            fileName = GetFileName("Hypertext Markup Language|*.html")
            Dim htmlText As String = String.Empty
            If String.IsNullOrEmpty(fileName) Then Return
            Try
'#Region "#exporthtml"
                Dim uriProvider As CustomUriProvider = New CustomUriProvider(Path.GetDirectoryName(fileName))
                If richEditControl.Document.Selection.Length > 0 Then
                    Dim selection As DevExpress.XtraRichEdit.API.Native.DocumentRange = richEditControl.Document.Selection
                    Dim doc As DevExpress.XtraRichEdit.API.Native.SubDocument = selection.BeginUpdateDocument()
                    htmlText = doc.GetHtmlText(selection, uriProvider)
                    selection.EndUpdateDocument(doc)
                Else
                    htmlText = richEditControl.Document.GetHtmlText(richEditControl.Document.Range, uriProvider)
                End If

'#End Region  ' #exporthtml
                SaveFile(fileName, htmlText)
                OpenFile(fileName)
            Finally
                fileName = String.Empty
            End Try
        End Sub

        Private Sub btnHtmlOptions_Click(ByVal sender As Object, ByVal e As EventArgs)
'#Region "#exporthtmloptions"
            Dim myBrowser As frmBrowser = New frmBrowser()
            Dim myExportOptions As DevExpress.XtraRichEdit.Export.HtmlDocumentExporterOptions = New DevExpress.XtraRichEdit.Export.HtmlDocumentExporterOptions()
            myExportOptions.Encoding = System.Text.Encoding.Unicode
            If richEditControl.Document.Selection.Length > 0 Then
                Dim selection As DevExpress.XtraRichEdit.API.Native.DocumentRange = richEditControl.Document.Selection
                Dim doc As DevExpress.XtraRichEdit.API.Native.SubDocument = selection.BeginUpdateDocument()
                myBrowser.SetHtml(doc.GetHtmlText(selection, Nothing, myExportOptions))
                selection.EndUpdateDocument(doc)
            Else
                myBrowser.SetHtml(richEditControl.Document.GetHtmlText(richEditControl.Document.Range, Nothing, myExportOptions))
            End If

            myBrowser.Show()
        End Sub

'#End Region  ' #exporthtmloptions
        Private Sub btnDocx_Click(ByVal sender As Object, ByVal e As EventArgs)
            fileName = GetFileName("Word 2007 Document|*.docx")
            Dim bytes As Byte()
            If String.IsNullOrEmpty(fileName) Then Return
            Try
'#Region "#exportdocx"
                If richEditControl.Document.Selection.Length > 0 Then
                    Dim selection As DevExpress.XtraRichEdit.API.Native.DocumentRange = richEditControl.Document.Selection
                    Dim doc As DevExpress.XtraRichEdit.API.Native.SubDocument = selection.BeginUpdateDocument()
                    bytes = doc.GetOpenXmlBytes(selection)
                    selection.EndUpdateDocument(doc)
                Else
                    bytes = richEditControl.Document.GetOpenXmlBytes(richEditControl.Document.Range)
                End If

'#End Region  ' #exportdocx
                SaveFile(fileName, bytes)
                OpenFile(fileName)
            Finally
                fileName = String.Empty
            End Try
        End Sub

        Private Sub btnRtf_Click(ByVal sender As Object, ByVal e As EventArgs)
            fileName = GetFileName("Rich Text Format|*.rtf")
            Dim rtfText As String = String.Empty
            If String.IsNullOrEmpty(fileName) Then Return
            Try
'#Region "#exportrtf"
                If richEditControl.Document.Selection.Length > 0 Then
                    Dim selection As DevExpress.XtraRichEdit.API.Native.DocumentRange = richEditControl.Document.Selection
                    Dim doc As DevExpress.XtraRichEdit.API.Native.SubDocument = selection.BeginUpdateDocument()
                    rtfText = doc.GetRtfText(selection)
                    selection.EndUpdateDocument(doc)
                Else
                    rtfText = richEditControl.Document.GetRtfText(richEditControl.Document.Range)
                End If

'#End Region  ' #exportrtf
                SaveFile(fileName, rtfText)
                OpenFile(fileName)
            Finally
                fileName = String.Empty
            End Try
        End Sub

        Private Sub btnXml_Click(ByVal sender As Object, ByVal e As EventArgs)
            fileName = GetFileName("Microsoft Word XML Document|*.xml")
            Dim wordMLText As String = String.Empty
            If String.IsNullOrEmpty(fileName) Then Return
            Try
'#Region "#exportxml"
                If richEditControl.Document.Selection.Length > 0 Then
                    Dim selection As DevExpress.XtraRichEdit.API.Native.DocumentRange = richEditControl.Document.Selection
                    Dim doc As DevExpress.XtraRichEdit.API.Native.SubDocument = selection.BeginUpdateDocument()
                    wordMLText = doc.GetWordMLText(selection)
                    selection.EndUpdateDocument(doc)
                Else
                    wordMLText = richEditControl.Document.GetWordMLText(richEditControl.Document.Range)
                End If

'#End Region  ' #exportxml
                SaveFile(fileName, wordMLText)
                OpenFile(fileName)
            Finally
                fileName = String.Empty
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
                If saveFileDialog.ShowDialog(Me) = DialogResult.OK Then Return saveFileDialog.FileName
            End Using

            Return String.Empty
        End Function

        Private Sub OpenFile(ByVal fileName As String)
            If MessageBox.Show("File is saved. " & Microsoft.VisualBasic.Constants.vbLf & "Do you want to open this file?", "GetText Example", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim process As Process = New Process()
                Try
                    process.StartInfo.FileName = fileName
                    process.Start()
                Catch
                End Try
            End If
        End Sub

'#Region "#beforeexport"
        Private Sub richEditControl_BeforeExport(ByVal sender As Object, ByVal e As DevExpress.XtraRichEdit.BeforeExportEventArgs)
            Dim options As DevExpress.XtraRichEdit.Export.HtmlDocumentExporterOptions = TryCast(e.Options, DevExpress.XtraRichEdit.Export.HtmlDocumentExporterOptions)
            If options IsNot Nothing Then
                options.CssPropertiesExportType = DevExpress.XtraRichEdit.Export.Html.CssPropertiesExportType.Link
                options.HtmlNumberingListExportFormat = DevExpress.XtraRichEdit.Export.Html.HtmlNumberingListExportFormat.HtmlFormat
                options.TargetUri = Path.GetFileNameWithoutExtension(fileName)
            End If
        End Sub
'#End Region  ' #beforeexport
    End Class

'#Region "#uriprovider"
    Public Class CustomUriProvider
        Implements DevExpress.Office.Services.IUriProvider

        Private rootDirecory As String

        Public Sub New(ByVal rootDirectory As String)
            If String.IsNullOrEmpty(rootDirectory) Then DevExpress.Office.Utils.Exceptions.ThrowArgumentException("rootDirectory", rootDirectory)
            rootDirecory = rootDirectory
        End Sub

        Public Function CreateCssUri(ByVal rootUri As String, ByVal styleText As String, ByVal relativeUri As String) As String Implements DevExpress.Office.Services.IUriProvider.CreateCssUri
            Dim cssDir As String = String.Format("{0}\{1}", rootDirecory, rootUri.Trim("/"c))
            If Not Directory.Exists(cssDir) Then Directory.CreateDirectory(cssDir)
            Dim cssFileName As String = String.Format("{0}\style.css", cssDir)
            File.AppendAllText(cssFileName, styleText)
            Return GetRelativePath(cssFileName)
        End Function

        Public Function CreateImageUri(ByVal rootUri As String, ByVal image As DevExpress.Office.Utils.OfficeImage, ByVal relativeUri As String) As String Implements DevExpress.Office.Services.IUriProvider.CreateImageUri
            Dim imagesDir As String = String.Format("{0}\{1}", rootDirecory, rootUri.Trim("/"c))
            If Not Directory.Exists(imagesDir) Then Directory.CreateDirectory(imagesDir)
            Dim imageName As String = String.Format("{0}\{1}.png", imagesDir, Guid.NewGuid())
            image.NativeImage.Save(imageName, ImageFormat.Png)
            Return GetRelativePath(imageName)
        End Function

        Private Function GetRelativePath(ByVal path As String) As String
            Dim substring As String = path.Substring(rootDirecory.Length)
            Return substring.Replace("\", "/").Trim("/"c)
        End Function
    End Class
'#End Region  ' #uriprovider
End Namespace
