Namespace GetTextMethods
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
            Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
            Me.simpleButton5 = New DevExpress.XtraEditors.SimpleButton()
            Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
            Me.simpleButton4 = New DevExpress.XtraEditors.SimpleButton()
            Me.simpleButton3 = New DevExpress.XtraEditors.SimpleButton()
            Me.simpleButton2 = New DevExpress.XtraEditors.SimpleButton()
            Me.richEditControl = New DevExpress.XtraRichEdit.RichEditControl()
            DirectCast(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelControl1.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' simpleButton1
            ' 
            Me.simpleButton1.Location = New System.Drawing.Point(60, 5)
            Me.simpleButton1.Name = "simpleButton1"
            Me.simpleButton1.Size = New System.Drawing.Size(50, 23)
            Me.simpleButton1.TabIndex = 1
            Me.simpleButton1.Text = "Mht"
            ' 
            ' panelControl1
            ' 
            Me.panelControl1.Controls.Add(Me.simpleButton5)
            Me.panelControl1.Controls.Add(Me.labelControl1)
            Me.panelControl1.Controls.Add(Me.simpleButton4)
            Me.panelControl1.Controls.Add(Me.simpleButton3)
            Me.panelControl1.Controls.Add(Me.simpleButton2)
            Me.panelControl1.Controls.Add(Me.simpleButton1)
            Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Top
            Me.panelControl1.Location = New System.Drawing.Point(0, 0)
            Me.panelControl1.Name = "panelControl1"
            Me.panelControl1.Size = New System.Drawing.Size(963, 34)
            Me.panelControl1.TabIndex = 5
            ' 
            ' simpleButton5
            ' 
            Me.simpleButton5.Location = New System.Drawing.Point(288, 5)
            Me.simpleButton5.Name = "simpleButton5"
            Me.simpleButton5.Size = New System.Drawing.Size(50, 23)
            Me.simpleButton5.TabIndex = 6
            Me.simpleButton5.Text = "Xml"
            ' 
            ' labelControl1
            ' 
            Me.labelControl1.Location = New System.Drawing.Point(12, 10)
            Me.labelControl1.Name = "labelControl1"
            Me.labelControl1.Size = New System.Drawing.Size(42, 13)
            Me.labelControl1.TabIndex = 5
            Me.labelControl1.Text = "Save as:"
            ' 
            ' simpleButton4
            ' 
            Me.simpleButton4.Location = New System.Drawing.Point(231, 5)
            Me.simpleButton4.Name = "simpleButton4"
            Me.simpleButton4.Size = New System.Drawing.Size(50, 23)
            Me.simpleButton4.TabIndex = 4
            Me.simpleButton4.Text = "Rtf"
            ' 
            ' simpleButton3
            ' 
            Me.simpleButton3.Location = New System.Drawing.Point(174, 5)
            Me.simpleButton3.Name = "simpleButton3"
            Me.simpleButton3.Size = New System.Drawing.Size(50, 23)
            Me.simpleButton3.TabIndex = 3
            Me.simpleButton3.Text = "Docx"
            ' 
            ' simpleButton2
            ' 
            Me.simpleButton2.Location = New System.Drawing.Point(117, 5)
            Me.simpleButton2.Name = "simpleButton2"
            Me.simpleButton2.Size = New System.Drawing.Size(50, 23)
            Me.simpleButton2.TabIndex = 2
            Me.simpleButton2.Text = "Html"
            ' 
            ' richEditControl
            ' 
            Me.richEditControl.Dock = System.Windows.Forms.DockStyle.Fill
            Me.richEditControl.Location = New System.Drawing.Point(0, 34)
            Me.richEditControl.Name = "richEditControl"
            Me.richEditControl.Options.Fields.UseCurrentCultureDateTimeFormat = False
            Me.richEditControl.Options.MailMerge.KeepLastParagraph = False
            Me.richEditControl.Size = New System.Drawing.Size(963, 490)
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
            DirectCast(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelControl1.ResumeLayout(False)
            Me.panelControl1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private WithEvents simpleButton1 As DevExpress.XtraEditors.SimpleButton
        Private panelControl1 As DevExpress.XtraEditors.PanelControl
        Private WithEvents simpleButton2 As DevExpress.XtraEditors.SimpleButton
        Private WithEvents simpleButton3 As DevExpress.XtraEditors.SimpleButton
        Private WithEvents simpleButton4 As DevExpress.XtraEditors.SimpleButton
        Private labelControl1 As DevExpress.XtraEditors.LabelControl
        Private WithEvents simpleButton5 As DevExpress.XtraEditors.SimpleButton
        Private richEditControl As DevExpress.XtraRichEdit.RichEditControl
    End Class
End Namespace

