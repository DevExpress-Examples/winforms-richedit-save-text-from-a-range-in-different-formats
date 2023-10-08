Namespace GetTextMethods

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

'#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.btnMht = New DevExpress.XtraEditors.SimpleButton()
            Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
            Me.btnHtmlOptions = New DevExpress.XtraEditors.SimpleButton()
            Me.btnXml = New DevExpress.XtraEditors.SimpleButton()
            Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
            Me.btnRtf = New DevExpress.XtraEditors.SimpleButton()
            Me.btnDocx = New DevExpress.XtraEditors.SimpleButton()
            Me.btnHtmlCustomUri = New DevExpress.XtraEditors.SimpleButton()
            Me.richEditControl = New DevExpress.XtraRichEdit.RichEditControl()
            CType((Me.panelControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelControl1.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' btnMht
            ' 
            Me.btnMht.Location = New System.Drawing.Point(60, 5)
            Me.btnMht.Name = "btnMht"
            Me.btnMht.Size = New System.Drawing.Size(50, 23)
            Me.btnMht.TabIndex = 1
            Me.btnMht.Text = "Mht"
            AddHandler Me.btnMht.Click, New System.EventHandler(AddressOf Me.btnMht_Click)
            ' 
            ' panelControl1
            ' 
            Me.panelControl1.Controls.Add(Me.btnHtmlOptions)
            Me.panelControl1.Controls.Add(Me.btnXml)
            Me.panelControl1.Controls.Add(Me.labelControl1)
            Me.panelControl1.Controls.Add(Me.btnRtf)
            Me.panelControl1.Controls.Add(Me.btnDocx)
            Me.panelControl1.Controls.Add(Me.btnHtmlCustomUri)
            Me.panelControl1.Controls.Add(Me.btnMht)
            Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Top
            Me.panelControl1.Location = New System.Drawing.Point(0, 0)
            Me.panelControl1.Name = "panelControl1"
            Me.panelControl1.Size = New System.Drawing.Size(963, 64)
            Me.panelControl1.TabIndex = 5
            ' 
            ' btnHtmlOptions
            ' 
            Me.btnHtmlOptions.Location = New System.Drawing.Point(127, 34)
            Me.btnHtmlOptions.Name = "btnHtmlOptions"
            Me.btnHtmlOptions.Size = New System.Drawing.Size(163, 23)
            Me.btnHtmlOptions.TabIndex = 7
            Me.btnHtmlOptions.Text = "Html using export options"
            AddHandler Me.btnHtmlOptions.Click, New System.EventHandler(AddressOf Me.btnHtmlOptions_Click)
            ' 
            ' btnXml
            ' 
            Me.btnXml.Location = New System.Drawing.Point(441, 5)
            Me.btnXml.Name = "btnXml"
            Me.btnXml.Size = New System.Drawing.Size(50, 23)
            Me.btnXml.TabIndex = 6
            Me.btnXml.Text = "Xml"
            AddHandler Me.btnXml.Click, New System.EventHandler(AddressOf Me.btnXml_Click)
            ' 
            ' labelControl1
            ' 
            Me.labelControl1.Location = New System.Drawing.Point(12, 10)
            Me.labelControl1.Name = "labelControl1"
            Me.labelControl1.Size = New System.Drawing.Size(42, 13)
            Me.labelControl1.TabIndex = 5
            Me.labelControl1.Text = "Save as:"
            ' 
            ' btnRtf
            ' 
            Me.btnRtf.Location = New System.Drawing.Point(374, 5)
            Me.btnRtf.Name = "btnRtf"
            Me.btnRtf.Size = New System.Drawing.Size(50, 23)
            Me.btnRtf.TabIndex = 4
            Me.btnRtf.Text = "Rtf"
            AddHandler Me.btnRtf.Click, New System.EventHandler(AddressOf Me.btnRtf_Click)
            ' 
            ' btnDocx
            ' 
            Me.btnDocx.Location = New System.Drawing.Point(307, 5)
            Me.btnDocx.Name = "btnDocx"
            Me.btnDocx.Size = New System.Drawing.Size(50, 23)
            Me.btnDocx.TabIndex = 3
            Me.btnDocx.Text = "Docx"
            AddHandler Me.btnDocx.Click, New System.EventHandler(AddressOf Me.btnDocx_Click)
            ' 
            ' btnHtmlCustomUri
            ' 
            Me.btnHtmlCustomUri.Location = New System.Drawing.Point(127, 5)
            Me.btnHtmlCustomUri.Name = "btnHtmlCustomUri"
            Me.btnHtmlCustomUri.Size = New System.Drawing.Size(163, 23)
            Me.btnHtmlCustomUri.TabIndex = 2
            Me.btnHtmlCustomUri.Text = "Html using custom UriProvider"
            AddHandler Me.btnHtmlCustomUri.Click, New System.EventHandler(AddressOf Me.btnHtmlCustomUri_Click)
            ' 
            ' richEditControl
            ' 
            Me.richEditControl.Dock = System.Windows.Forms.DockStyle.Fill
            Me.richEditControl.EnableToolTips = True
            Me.richEditControl.Location = New System.Drawing.Point(0, 64)
            Me.richEditControl.Name = "richEditControl"
            Me.richEditControl.Options.Bookmarks.AllowNameResolution = False
            Me.richEditControl.Options.Export.PlainText.ExportFinalParagraphMark = DevExpress.XtraRichEdit.Export.PlainText.ExportFinalParagraphMark.Never
            Me.richEditControl.Size = New System.Drawing.Size(963, 460)
            Me.richEditControl.TabIndex = 6
            Me.richEditControl.Text = "richEditControl1"
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(963, 524)
            Me.Controls.Add(Me.richEditControl)
            Me.Controls.Add(Me.panelControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            CType((Me.panelControl1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelControl1.ResumeLayout(False)
            Me.panelControl1.PerformLayout()
            Me.ResumeLayout(False)
        End Sub

'#End Region
        Private btnMht As DevExpress.XtraEditors.SimpleButton

        Private panelControl1 As DevExpress.XtraEditors.PanelControl

        Private btnHtmlCustomUri As DevExpress.XtraEditors.SimpleButton

        Private btnDocx As DevExpress.XtraEditors.SimpleButton

        Private btnRtf As DevExpress.XtraEditors.SimpleButton

        Private labelControl1 As DevExpress.XtraEditors.LabelControl

        Private btnXml As DevExpress.XtraEditors.SimpleButton

        Private richEditControl As DevExpress.XtraRichEdit.RichEditControl

        Private btnHtmlOptions As DevExpress.XtraEditors.SimpleButton
    End Class
End Namespace
