namespace GetTextMethods {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnMht = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnHtmlOptions = new DevExpress.XtraEditors.SimpleButton();
            this.btnXml = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnRtf = new DevExpress.XtraEditors.SimpleButton();
            this.btnDocx = new DevExpress.XtraEditors.SimpleButton();
            this.btnHtmlCustomUri = new DevExpress.XtraEditors.SimpleButton();
            this.richEditControl = new DevExpress.XtraRichEdit.RichEditControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMht
            // 
            this.btnMht.Location = new System.Drawing.Point(60, 5);
            this.btnMht.Name = "btnMht";
            this.btnMht.Size = new System.Drawing.Size(50, 23);
            this.btnMht.TabIndex = 1;
            this.btnMht.Text = "Mht";
            this.btnMht.Click += new System.EventHandler(this.btnMht_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnHtmlOptions);
            this.panelControl1.Controls.Add(this.btnXml);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnRtf);
            this.panelControl1.Controls.Add(this.btnDocx);
            this.panelControl1.Controls.Add(this.btnHtmlCustomUri);
            this.panelControl1.Controls.Add(this.btnMht);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(963, 64);
            this.panelControl1.TabIndex = 5;
            // 
            // btnHtmlOptions
            // 
            this.btnHtmlOptions.Location = new System.Drawing.Point(127, 34);
            this.btnHtmlOptions.Name = "btnHtmlOptions";
            this.btnHtmlOptions.Size = new System.Drawing.Size(163, 23);
            this.btnHtmlOptions.TabIndex = 7;
            this.btnHtmlOptions.Text = "Html using export options";
            this.btnHtmlOptions.Click += new System.EventHandler(this.btnHtmlOptions_Click);
            // 
            // btnXml
            // 
            this.btnXml.Location = new System.Drawing.Point(441, 5);
            this.btnXml.Name = "btnXml";
            this.btnXml.Size = new System.Drawing.Size(50, 23);
            this.btnXml.TabIndex = 6;
            this.btnXml.Text = "Xml";
            this.btnXml.Click += new System.EventHandler(this.btnXml_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Save as:";
            // 
            // btnRtf
            // 
            this.btnRtf.Location = new System.Drawing.Point(374, 5);
            this.btnRtf.Name = "btnRtf";
            this.btnRtf.Size = new System.Drawing.Size(50, 23);
            this.btnRtf.TabIndex = 4;
            this.btnRtf.Text = "Rtf";
            this.btnRtf.Click += new System.EventHandler(this.btnRtf_Click);
            // 
            // btnDocx
            // 
            this.btnDocx.Location = new System.Drawing.Point(307, 5);
            this.btnDocx.Name = "btnDocx";
            this.btnDocx.Size = new System.Drawing.Size(50, 23);
            this.btnDocx.TabIndex = 3;
            this.btnDocx.Text = "Docx";
            this.btnDocx.Click += new System.EventHandler(this.btnDocx_Click);
            // 
            // btnHtmlCustomUri
            // 
            this.btnHtmlCustomUri.Location = new System.Drawing.Point(127, 5);
            this.btnHtmlCustomUri.Name = "btnHtmlCustomUri";
            this.btnHtmlCustomUri.Size = new System.Drawing.Size(163, 23);
            this.btnHtmlCustomUri.TabIndex = 2;
            this.btnHtmlCustomUri.Text = "Html using custom UriProvider";
            this.btnHtmlCustomUri.Click += new System.EventHandler(this.btnHtmlCustomUri_Click);
            // 
            // richEditControl
            // 
            this.richEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richEditControl.EnableToolTips = true;
            this.richEditControl.Location = new System.Drawing.Point(0, 64);
            this.richEditControl.Name = "richEditControl";
            this.richEditControl.Options.Bookmarks.ConflictNameResolution = DevExpress.XtraRichEdit.ConflictNameAction.Keep;
            this.richEditControl.Options.Export.PlainText.ExportFinalParagraphMark = DevExpress.XtraRichEdit.Export.PlainText.ExportFinalParagraphMark.Never;
            this.richEditControl.Size = new System.Drawing.Size(963, 460);
            this.richEditControl.TabIndex = 6;
            this.richEditControl.Text = "richEditControl1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 524);
            this.Controls.Add(this.richEditControl);
            this.Controls.Add(this.panelControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnMht;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnHtmlCustomUri;
        private DevExpress.XtraEditors.SimpleButton btnDocx;
        private DevExpress.XtraEditors.SimpleButton btnRtf;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnXml;
        private DevExpress.XtraRichEdit.RichEditControl richEditControl;
        private DevExpress.XtraEditors.SimpleButton btnHtmlOptions;
    }
}

