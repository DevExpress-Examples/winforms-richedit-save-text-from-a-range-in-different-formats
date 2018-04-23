using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;
#region #usings
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Export;
using DevExpress.XtraRichEdit.Export.Html;
using DevExpress.XtraRichEdit.Utils;
using DevExpress.XtraRichEdit.Services;
#endregion #usings

namespace GetTextMethods {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        string fileName = String.Empty;

        public Form1() {
            InitializeComponent();
            richEditControl.LoadDocument("sample_document.rtf", DocumentFormat.Rtf); 
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            this.fileName = GetFileName("Web Archive|*.mht");
            if (String.IsNullOrEmpty(fileName))
                return;
            try {
                string mhtText = this.richEditControl.Document.GetMhtText(this.richEditControl.Document.Range);
                SaveFile(this.fileName, mhtText);
                OpenFile(this.fileName);
            }
            finally {
                this.fileName = String.Empty;
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e) {
            this.fileName = GetFileName("Hypertext Markup Language|*.html");
            if (String.IsNullOrEmpty(fileName))
                return;
            try {
                UriProvider uriProvider = new UriProvider(Path.GetDirectoryName(fileName));
                string htmlText = this.richEditControl.Document.GetHtmlText(this.richEditControl.Document.Range, uriProvider);
                SaveFile(this.fileName, htmlText);
                OpenFile(this.fileName);
            }
            finally {
                this.fileName = String.Empty;
            }
        }
        private void simpleButton3_Click(object sender, EventArgs e) {
            this.fileName = GetFileName("Word Document|*.docx");
            if (String.IsNullOrEmpty(fileName))
                return;
            try {
                byte[] bytes = this.richEditControl.Document.GetOpenXmlBytes(this.richEditControl.Document.Range);
                SaveFile(this.fileName, bytes);
                OpenFile(this.fileName);
            }
            finally {
                this.fileName = String.Empty;
            }
        }
        private void simpleButton4_Click(object sender, EventArgs e) {
            this.fileName = GetFileName("Rich Text Format|*.rtf");
            if (String.IsNullOrEmpty(fileName))
                return;
            try {
                string rtfText = this.richEditControl.Document.GetRtfText(this.richEditControl.Document.Range);
                SaveFile(this.fileName, rtfText);
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
    public class UriProvider : IUriProvider {
    string rootDirecory;
    public UriProvider(string rootDirectory) {
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
        public string CreateImageUri(string rootUri, Image image, string relativeUri) {
        string imagesDir = String.Format("{0}\\{1}", this.rootDirecory, rootUri.Trim('/'));
        if (!Directory.Exists(imagesDir))
            Directory.CreateDirectory(imagesDir);
        string imageName = String.Format("{0}\\{1}.png", imagesDir, Guid.NewGuid());
        image.Save(imageName, ImageFormat.Png);
        return GetRelativePath(imageName);
    }
    string GetRelativePath(string path) {
        string substring = path.Substring(this.rootDirecory.Length);
        return substring.Replace("\\", "/").Trim('/');
    }
}
    #endregion #uriprovider
}