Imports System
Imports System.Windows.Forms
Imports System.IO
Imports System.Diagnostics
Imports System.Drawing.Imaging

Namespace GetTextMethods
    Partial Public Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Private fileName As String = String.Empty

        Public Sub New()
            InitializeComponent()
            richEditControl.LoadDocument("sample_document.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
        End Sub

        Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
            Me.fileName = GetFileName("Web Archive|*.mht")
            Dim mhtText As String = String.Empty

            If String.IsNullOrEmpty(fileName) Then
                Return
            End If
            Try
                '                #Region "#exportmht"
                If Me.richEditControl.Document.Selection.Length > 0 Then
                    Dim selection As DevExpress.XtraRichEdit.API.Native.DocumentRange = richEditControl.Document.Selection
                    Dim doc As DevExpress.XtraRichEdit.API.Native.SubDocument = selection.BeginUpdateDocument()
                    mhtText = doc.GetMhtText(selection)
                    selection.EndUpdateDocument(doc)
                Else
                    mhtText = richEditControl.Document.GetMhtText(richEditControl.Document.Range)
                End If
                '                #End Region ' #exportmht
                SaveFile(Me.fileName, mhtText)
                OpenFile(Me.fileName)
            Finally
                Me.fileName = String.Empty
            End Try
        End Sub
        Private Sub simpleButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton2.Click
            Me.fileName = GetFileName("Hypertext Markup Language|*.html")
            Dim htmlText As String = String.Empty

            If String.IsNullOrEmpty(fileName) Then
                Return
            End If
            Try
                '                #Region "#exporthtml"
                Dim uriProvider As New CustomUriProvider(Path.GetDirectoryName(fileName))
                If Me.richEditControl.Document.Selection.Length > 0 Then
                    Dim selection As DevExpress.XtraRichEdit.API.Native.DocumentRange = richEditControl.Document.Selection
                    Dim doc As DevExpress.XtraRichEdit.API.Native.SubDocument = selection.BeginUpdateDocument()
                    htmlText = doc.GetHtmlText(selection, uriProvider)
                    selection.EndUpdateDocument(doc)
                Else
                    htmlText = richEditControl.Document.GetHtmlText(richEditControl.Document.Range, uriProvider)
                End If
                '                #End Region ' #exporthtml
                SaveFile(Me.fileName, htmlText)
                OpenFile(Me.fileName)
            Finally
                Me.fileName = String.Empty
            End Try
        End Sub
        Private Sub simpleButton3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton3.Click
            Me.fileName = GetFileName("Word 2007 Document|*.docx")
            Dim bytes() As Byte

            If String.IsNullOrEmpty(fileName) Then
                Return
            End If
            Try
                '                #Region "#exportdocx"
                If Me.richEditControl.Document.Selection.Length > 0 Then
                    Dim selection As DevExpress.XtraRichEdit.API.Native.DocumentRange = richEditControl.Document.Selection
                    Dim doc As DevExpress.XtraRichEdit.API.Native.SubDocument = selection.BeginUpdateDocument()
                    bytes = doc.GetOpenXmlBytes(selection)
                    selection.EndUpdateDocument(doc)
                Else
                    bytes = richEditControl.Document.GetOpenXmlBytes(richEditControl.Document.Range)
                End If
                '                #End Region ' #exportdocx
                SaveFile(Me.fileName, bytes)
                OpenFile(Me.fileName)
            Finally
                Me.fileName = String.Empty
            End Try
        End Sub
        Private Sub simpleButton4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton4.Click
            Me.fileName = GetFileName("Rich Text Format|*.rtf")
            Dim rtfText As String = String.Empty

            If String.IsNullOrEmpty(fileName) Then
                Return
            End If
            Try
                '                #Region "#exportrtf"
                If Me.richEditControl.Document.Selection.Length > 0 Then
                    Dim selection As DevExpress.XtraRichEdit.API.Native.DocumentRange = richEditControl.Document.Selection
                    Dim doc As DevExpress.XtraRichEdit.API.Native.SubDocument = selection.BeginUpdateDocument()
                    rtfText = doc.GetRtfText(selection)
                    selection.EndUpdateDocument(doc)
                Else
                    rtfText = richEditControl.Document.GetRtfText(richEditControl.Document.Range)
                End If
                '                #End Region ' #exportrtf
                SaveFile(Me.fileName, rtfText)
                OpenFile(Me.fileName)
            Finally
                Me.fileName = String.Empty
            End Try
        End Sub

        Private Sub simpleButton5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton5.Click
            Me.fileName = GetFileName("Microsoft Word XML Document|*.xml")
            Dim wordMLText As String = String.Empty

            If String.IsNullOrEmpty(fileName) Then
                Return
            End If
            Try
                '                #Region "#exportxml"
                If Me.richEditControl.Document.Selection.Length > 0 Then
                    Dim selection As DevExpress.XtraRichEdit.API.Native.DocumentRange = richEditControl.Document.Selection
                    Dim doc As DevExpress.XtraRichEdit.API.Native.SubDocument = selection.BeginUpdateDocument()
                    wordMLText = doc.GetWordMLText(selection)
                    selection.EndUpdateDocument(doc)
                Else
                    wordMLText = richEditControl.Document.GetWordMLText(richEditControl.Document.Range)
                End If
                '                #End Region ' #exportxml
                SaveFile(Me.fileName, wordMLText)
                OpenFile(Me.fileName)
            Finally
                Me.fileName = String.Empty
            End Try
        End Sub

        Private Sub SaveFile(ByVal fileName As String, ByVal value As String)
            Using stream As New FileStream(fileName, FileMode.Create, FileAccess.Write)
                Using writer As New StreamWriter(stream)
                    writer.Write(value)
                End Using
            End Using
        End Sub
        Private Sub SaveFile(ByVal fileName As String, ByVal bytes() As Byte)
            Using stream As New FileStream(fileName, FileMode.Create, FileAccess.Write)
                stream.Write(bytes, 0, bytes.Length)
            End Using
        End Sub
        Private Function GetFileName(ByVal filter As String) As String
            Using saveFileDialog As New SaveFileDialog()
                saveFileDialog.Filter = filter
                saveFileDialog.RestoreDirectory = True
                saveFileDialog.CheckFileExists = False
                saveFileDialog.CheckPathExists = True
                saveFileDialog.OverwritePrompt = True
                saveFileDialog.DereferenceLinks = True
                saveFileDialog.ValidateNames = True
                If saveFileDialog.ShowDialog(Me) = DialogResult.OK Then
                    Return saveFileDialog.FileName
                End If
            End Using
            Return String.Empty
        End Function
        Private Sub OpenFile(ByVal fileName As String)
            If MessageBox.Show("File is saved. " & ControlChars.Lf & "Do you want to open this file?", "GetText Example", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim process As New Process()
                Try
                    process.StartInfo.FileName = fileName
                    process.Start()
                Catch
                End Try
            End If
        End Sub
#Region "#beforeexport"
        Private Sub richEditControl_BeforeExport(ByVal sender As Object, ByVal e As DevExpress.XtraRichEdit.BeforeExportEventArgs)
            Dim options As DevExpress.XtraRichEdit.Export.HtmlDocumentExporterOptions = TryCast(e.Options, DevExpress.XtraRichEdit.Export.HtmlDocumentExporterOptions)
            If options IsNot Nothing Then
                options.CssPropertiesExportType = DevExpress.XtraRichEdit.Export.Html.CssPropertiesExportType.Link
                options.HtmlNumberingListExportFormat = DevExpress.XtraRichEdit.Export.Html.HtmlNumberingListExportFormat.HtmlFormat
                options.TargetUri = Path.GetFileNameWithoutExtension(Me.fileName)
            End If
        End Sub
#End Region ' #beforeexport

    End Class

#Region "#uriprovider"
    Public Class CustomUriProvider
        Implements DevExpress.Office.Services.IUriProvider

        Private rootDirecory As String
        Public Sub New(ByVal rootDirectory As String)
            If String.IsNullOrEmpty(rootDirectory) Then
                DevExpress.Office.Utils.Exceptions.ThrowArgumentException("rootDirectory", rootDirectory)
            End If
            Me.rootDirecory = rootDirectory
        End Sub

        Public Function CreateCssUri(ByVal rootUri As String, ByVal styleText As String, ByVal relativeUri As String) As String Implements DevExpress.Office.Services.IUriProvider.CreateCssUri
            Dim cssDir As String = String.Format("{0}\{1}", Me.rootDirecory, rootUri.Trim("/"c))
            If Not Directory.Exists(cssDir) Then
                Directory.CreateDirectory(cssDir)
            End If
            Dim cssFileName As String = String.Format("{0}\style.css", cssDir)
            File.AppendAllText(cssFileName, styleText)
            Return GetRelativePath(cssFileName)
        End Function
        Public Function CreateImageUri(ByVal rootUri As String, ByVal image As DevExpress.Office.Utils.OfficeImage, ByVal relativeUri As String) As String Implements DevExpress.Office.Services.IUriProvider.CreateImageUri

            Dim imagesDir As String = String.Format("{0}\{1}", Me.rootDirecory, rootUri.Trim("/"c))
            If Not Directory.Exists(imagesDir) Then
                Directory.CreateDirectory(imagesDir)
            End If
            Dim imageName As String = String.Format("{0}\{1}.png", imagesDir, Guid.NewGuid())
            image.NativeImage.Save(imageName, ImageFormat.Png)
            Return GetRelativePath(imageName)
        End Function
        Private Function GetRelativePath(ByVal path As String) As String
            Dim substring As String = path.Substring(Me.rootDirecory.Length)
            Return substring.Replace("\", "/").Trim("/"c)
        End Function
    End Class
#End Region ' #uriprovider
End Namespace