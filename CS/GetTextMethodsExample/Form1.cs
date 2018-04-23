using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;
#region #usings
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Export;
using DevExpress.XtraRichEdit.Export.Html;
using DevExpress.XtraRichEdit.Services;
using DevExpress.Office.Utils;
using DevExpress.XtraRichEdit.API.Native;
#endregion #usings

namespace GetTextMethods {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        string fileName = String.Empty;

        public Form1() {
            InitializeComponent();
            richEditControl.LoadDocument("sample_document.docx", DocumentFormat.OpenXml); 
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            this.fileName = GetFileName("Web Archive|*.mht");
            string mhtText = String.Empty;

            if (String.IsNullOrEmpty(fileName))
                return;
            try {
                if (this.richEditControl.Document.Selection.Length > 0) {
                    SubDocument doc = this.richEditControl.Document.Selection.BeginUpdateDocument();
                    mhtText = doc.GetMhtText(this.richEditControl.Document.Selection);
                    this.richEditControl.Document.Selection.EndUpdateDocument(doc);  
                }
                else {
                mhtText = this.richEditControl.Document.GetMhtText(this.richEditControl.Document.Range);
                }
                SaveFile(this.fileName, mhtText);
                OpenFile(this.fileName);
            }
            finally {
                this.fileName = String.Empty;
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e) {
            this.fileName = GetFileName("Hypertext Markup Language|*.html");
            string htmlText = String.Empty;

            if (String.IsNullOrEmpty(fileName))
                return;
            try {
                CustomUriProvider uriProvider = new CustomUriProvider(Path.GetDirectoryName(fileName));
                if (this.richEditControl.Document.Selection.Length > 0) {
                    SubDocument doc = this.richEditControl.Document.Selection.BeginUpdateDocument();
                    htmlText = doc.GetHtmlText(this.richEditControl.Document.Selection, uriProvider);
                    this.richEditControl.Document.Selection.EndUpdateDocument(doc);
                }
                else {
                    htmlText = this.richEditControl.Document.GetHtmlText(this.richEditControl.Document.Range, uriProvider);
                }
                
                SaveFile(this.fileName, htmlText);
                OpenFile(this.fileName);
            }
            finally {
                this.fileName = String.Empty;
            }
        }
        private void simpleButton3_Click(object sender, EventArgs e) {
            this.fileName = GetFileName("Word 2007 Document|*.docx");
            byte[] bytes;

            if (String.IsNullOrEmpty(fileName))
                return;
            try {
                if (this.richEditControl.Document.Selection.Length > 0) {
                    SubDocument doc = this.richEditControl.Document.Selection.BeginUpdateDocument();
                    bytes = doc.GetOpenXmlBytes(this.richEditControl.Document.Selection);
                    this.richEditControl.Document.Selection.EndUpdateDocument(doc);
                }
                else {
                    bytes = this.richEditControl.Document.GetOpenXmlBytes(this.richEditControl.Document.Range);
                }
                SaveFile(this.fileName, bytes);
                OpenFile(this.fileName);
            }
            finally {
                this.fileName = String.Empty;
            }
        }
        private void simpleButton4_Click(object sender, EventArgs e) {
            this.fileName = GetFileName("Rich Text Format|*.rtf");
            string rtfText = String.Empty;

            if (String.IsNullOrEmpty(fileName))
                return;
            try {
                if (this.richEditControl.Document.Selection.Length > 0) {
                    SubDocument doc = this.richEditControl.Document.Selection.BeginUpdateDocument();
                    rtfText = doc.GetRtfText(this.richEditControl.Document.Selection);
                    this.richEditControl.Document.Selection.EndUpdateDocument(doc);
                }
                else {
                    rtfText = this.richEditControl.Document.GetRtfText(this.richEditControl.Document.Range);
                }
                SaveFile(this.fileName, rtfText);
                OpenFile(this.fileName);
            }
            finally {
                this.fileName = String.Empty;
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e) {
            this.fileName = GetFileName("Microsoft Word XML Document|*.xml");
            string wordMLText = String.Empty;

            if (String.IsNullOrEmpty(fileName))
                return;
            try {
                if (this.richEditControl.Document.Selection.Length > 0) {
                    SubDocument doc = this.richEditControl.Document.Selection.BeginUpdateDocument();
                    wordMLText = doc.GetWordMLText(this.richEditControl.Document.Selection);
                    this.richEditControl.Document.Selection.EndUpdateDocument(doc);
                }
                else {
                    wordMLText = this.richEditControl.Document.GetWordMLText(this.richEditControl.Document.Range);
                }
                SaveFile(this.fileName, wordMLText);
                OpenFile(this.fileName);
            }
            finally {
                this.fileName = String.Empty;
            }
        }

        private void SaveFile(string fileName, string value) {
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write)) {
                using (StreamWriter writer = new StreamWriter(stream)) {
                    writer.Write(value);
                }
            }
        }
        private void SaveFile(string fileName, byte[] bytes) {
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write)) {
                stream.Write(bytes, 0, bytes.Length);
            }
        }
        private string GetFileName(string filter) {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {
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
        private void OpenFile(string fileName) {
            if (XtraMessageBox.Show("Do you want to open this file?", "Html Example", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Process process = new Process();
                try {
                    process.StartInfo.FileName = fileName;
                    process.Start();
                }
                catch { }
            }
        }
        #region #beforeexport
        private void richEditControl_BeforeExport(object sender, BeforeExportEventArgs e) {
            HtmlDocumentExporterOptions options = e.Options as HtmlDocumentExporterOptions;
            if (options != null) {
                options.CssPropertiesExportType = CssPropertiesExportType.Link;
                options.HtmlNumberingListExportFormat = HtmlNumberingListExportFormat.HtmlFormat;
                options.TargetUri = Path.GetFileNameWithoutExtension(this.fileName);
            }
        }
        #endregion #beforeexport

    }

    #region #uriprovider
    public class CustomUriProvider : IUriProvider {
    string rootDirecory;
    public CustomUriProvider(string rootDirectory) {
        if (String.IsNullOrEmpty(rootDirectory))
            Exceptions.ThrowArgumentException("rootDirectory", rootDirectory);
        this.rootDirecory = rootDirectory;
    }

    public string CreateCssUri(string rootUri, string styleText, string relativeUri) {
        string cssDir = String.Format("{0}\\{1}", this.rootDirecory, rootUri.Trim('/'));
        if (!Directory.Exists(cssDir))
            Directory.CreateDirectory(cssDir);
        string cssFileName = String.Format("{0}\\style.css", cssDir);
        File.AppendAllText(cssFileName, styleText);
        return GetRelativePath(cssFileName);
    }
        public string CreateImageUri(string rootUri, OfficeImage image, string relativeUri) {
        string imagesDir = String.Format("{0}\\{1}", this.rootDirecory, rootUri.Trim('/'));
        if (!Directory.Exists(imagesDir))
            Directory.CreateDirectory(imagesDir);
        string imageName = String.Format("{0}\\{1}.png", imagesDir, Guid.NewGuid());
        image.NativeImage.Save(imageName, ImageFormat.Png);
        return GetRelativePath(imageName);
    }
    string GetRelativePath(string path) {
        string substring = path.Substring(this.rootDirecory.Length);
        return substring.Replace("\\", "/").Trim('/');
    }
}
    #endregion #uriprovider
}