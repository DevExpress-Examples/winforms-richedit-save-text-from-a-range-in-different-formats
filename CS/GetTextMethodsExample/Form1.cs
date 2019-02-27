using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace GetTextMethods
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        string fileName = String.Empty;

        public Form1()
        {
            InitializeComponent();
            richEditControl.LoadDocument("sample_document.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
        }

        private void btnMht_Click(object sender, EventArgs e)
        {
            this.fileName = GetFileName("Web Archive|*.mht");
            string mhtText = String.Empty;

            if (String.IsNullOrEmpty(fileName))
                return;
            try
            {
                #region #exportmht
                if (this.richEditControl.Document.Selection.Length > 0)
                {
                    DevExpress.XtraRichEdit.API.Native.DocumentRange selection = richEditControl.Document.Selection;
                    DevExpress.XtraRichEdit.API.Native.SubDocument doc = selection.BeginUpdateDocument();
                    mhtText = doc.GetMhtText(selection);
                    selection.EndUpdateDocument(doc);
                }
                else
                {
                    mhtText = richEditControl.Document.GetMhtText(richEditControl.Document.Range);
                }
                #endregion #exportmht
                SaveFile(this.fileName, mhtText);
                OpenFile(this.fileName);
            }
            finally
            {
                this.fileName = String.Empty;
            }
        }
        private void btnHtmlCustomUri_Click(object sender, EventArgs e)
        {
            this.fileName = GetFileName("Hypertext Markup Language|*.html");
            string htmlText = String.Empty;

            if (String.IsNullOrEmpty(fileName))
                return;
            try
            {
                #region #exporthtml
                CustomUriProvider uriProvider = new CustomUriProvider(Path.GetDirectoryName(fileName));
                if (this.richEditControl.Document.Selection.Length > 0)
                {
                    DevExpress.XtraRichEdit.API.Native.DocumentRange selection = richEditControl.Document.Selection;
                    DevExpress.XtraRichEdit.API.Native.SubDocument doc = selection.BeginUpdateDocument();
                    htmlText = doc.GetHtmlText(selection, uriProvider);
                    selection.EndUpdateDocument(doc);
                }
                else
                {
                    htmlText = richEditControl.Document.GetHtmlText(richEditControl.Document.Range, uriProvider);
                }
                #endregion #exporthtml
                SaveFile(this.fileName, htmlText);
                OpenFile(this.fileName);
            }
            finally
            {
                this.fileName = String.Empty;
            }
        }

        private void btnHtmlOptions_Click(object sender, EventArgs e)
        {
            #region #exporthtmloptions
            frmBrowser myBrowser = new frmBrowser();
            DevExpress.XtraRichEdit.Export.HtmlDocumentExporterOptions myExportOptions =
                new DevExpress.XtraRichEdit.Export.HtmlDocumentExporterOptions();
            myExportOptions.Encoding = System.Text.Encoding.Unicode;

            if (this.richEditControl.Document.Selection.Length > 0)
            {
                DevExpress.XtraRichEdit.API.Native.DocumentRange selection = richEditControl.Document.Selection;
                DevExpress.XtraRichEdit.API.Native.SubDocument doc = selection.BeginUpdateDocument();
                myBrowser.SetHtml(doc.GetHtmlText(selection, null, myExportOptions));
                selection.EndUpdateDocument(doc);
            }
            else
            {
                myBrowser.SetHtml(richEditControl.Document.GetHtmlText(richEditControl.Document.Range, null, myExportOptions));
            }

            myBrowser.Show();
        }
        #endregion #exporthtmloptions
        private void btnDocx_Click(object sender, EventArgs e)
        {
            this.fileName = GetFileName("Word 2007 Document|*.docx");
            byte[] bytes;

            if (String.IsNullOrEmpty(fileName))
                return;
            try
            {
                #region #exportdocx
                if (this.richEditControl.Document.Selection.Length > 0)
                {
                    DevExpress.XtraRichEdit.API.Native.DocumentRange selection = richEditControl.Document.Selection;
                    DevExpress.XtraRichEdit.API.Native.SubDocument doc = selection.BeginUpdateDocument();
                    bytes = doc.GetOpenXmlBytes(selection);
                    selection.EndUpdateDocument(doc);
                }
                else
                {
                    bytes = richEditControl.Document.GetOpenXmlBytes(richEditControl.Document.Range);
                }
                #endregion #exportdocx
                SaveFile(this.fileName, bytes);
                OpenFile(this.fileName);
            }
            finally
            {
                this.fileName = String.Empty;
            }
        }
        private void btnRtf_Click(object sender, EventArgs e)
        {
            this.fileName = GetFileName("Rich Text Format|*.rtf");
            string rtfText = String.Empty;

            if (String.IsNullOrEmpty(fileName))
                return;
            try
            {
                #region #exportrtf
                if (this.richEditControl.Document.Selection.Length > 0)
                {
                    DevExpress.XtraRichEdit.API.Native.DocumentRange selection = richEditControl.Document.Selection;
                    DevExpress.XtraRichEdit.API.Native.SubDocument doc = selection.BeginUpdateDocument();
                    rtfText = doc.GetRtfText(selection);
                    selection.EndUpdateDocument(doc);
                }
                else
                {
                    rtfText = richEditControl.Document.GetRtfText(richEditControl.Document.Range);
                }
                #endregion #exportrtf
                SaveFile(this.fileName, rtfText);
                OpenFile(this.fileName);
            }
            finally
            {
                this.fileName = String.Empty;
            }
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            this.fileName = GetFileName("Microsoft Word XML Document|*.xml");
            string wordMLText = String.Empty;

            if (String.IsNullOrEmpty(fileName))
                return;
            try
            {
                #region #exportxml
                if (this.richEditControl.Document.Selection.Length > 0)
                {
                    DevExpress.XtraRichEdit.API.Native.DocumentRange selection = richEditControl.Document.Selection;
                    DevExpress.XtraRichEdit.API.Native.SubDocument doc = selection.BeginUpdateDocument();
                    wordMLText = doc.GetWordMLText(selection);
                    selection.EndUpdateDocument(doc);
                }
                else
                {
                    wordMLText = richEditControl.Document.GetWordMLText(richEditControl.Document.Range);
                }
                #endregion #exportxml
                SaveFile(this.fileName, wordMLText);
                OpenFile(this.fileName);
            }
            finally
            {
                this.fileName = String.Empty;
            }
        }



        private void SaveFile(string fileName, string value)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(value);
                }
            }
        }
        private void SaveFile(string fileName, byte[] bytes)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                stream.Write(bytes, 0, bytes.Length);
            }
        }
        private string GetFileName(string filter)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = filter;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.CheckFileExists = false;
                saveFileDialog.CheckPathExists = true;
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.DereferenceLinks = true;
                saveFileDialog.ValidateNames = true;
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                    return saveFileDialog.FileName;
            }
            return String.Empty;
        }
        private void OpenFile(string fileName)
        {
            if (MessageBox.Show("File is saved. \nDo you want to open this file?", "GetText Example", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Process process = new Process();
                try
                {
                    process.StartInfo.FileName = fileName;
                    process.Start();
                }
                catch { }
            }
        }
        #region #beforeexport
        private void richEditControl_BeforeExport(object sender, DevExpress.XtraRichEdit.BeforeExportEventArgs e)
        {
            DevExpress.XtraRichEdit.Export.HtmlDocumentExporterOptions options = e.Options as DevExpress.XtraRichEdit.Export.HtmlDocumentExporterOptions;
            if (options != null)
            {
                options.CssPropertiesExportType = DevExpress.XtraRichEdit.Export.Html.CssPropertiesExportType.Link;
                options.HtmlNumberingListExportFormat = DevExpress.XtraRichEdit.Export.Html.HtmlNumberingListExportFormat.HtmlFormat;
                options.TargetUri = Path.GetFileNameWithoutExtension(this.fileName);
            }
        }
        #endregion #beforeexport


    }

    #region #uriprovider
    public class CustomUriProvider : DevExpress.Office.Services.IUriProvider
    {
        string rootDirecory;
        public CustomUriProvider(string rootDirectory)
        {
            if (String.IsNullOrEmpty(rootDirectory))
                DevExpress.Office.Utils.Exceptions.ThrowArgumentException("rootDirectory", rootDirectory);
            this.rootDirecory = rootDirectory;
        }

        public string CreateCssUri(string rootUri, string styleText, string relativeUri)
        {
            string cssDir = String.Format("{0}\\{1}", this.rootDirecory, rootUri.Trim('/'));
            if (!Directory.Exists(cssDir))
                Directory.CreateDirectory(cssDir);
            string cssFileName = String.Format("{0}\\style.css", cssDir);
            File.AppendAllText(cssFileName, styleText);
            return GetRelativePath(cssFileName);
        }
        public string CreateImageUri(string rootUri, DevExpress.Office.Utils.OfficeImage image, string relativeUri)
        {
            string imagesDir = String.Format("{0}\\{1}", this.rootDirecory, rootUri.Trim('/'));
            if (!Directory.Exists(imagesDir))
                Directory.CreateDirectory(imagesDir);
            string imageName = String.Format("{0}\\{1}.png", imagesDir, Guid.NewGuid());
            image.NativeImage.Save(imageName, ImageFormat.Png);
            return GetRelativePath(imageName);
        }
        string GetRelativePath(string path)
        {
            string substring = path.Substring(this.rootDirecory.Length);
            return substring.Replace("\\", "/").Trim('/');
        }
    }
    #endregion #uriprovider
}