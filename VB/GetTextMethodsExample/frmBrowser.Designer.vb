Namespace GetTextMethods
    Partial Public Class frmBrowser
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
            Me.webBrowser1 = New System.Windows.Forms.WebBrowser()
            Me.SuspendLayout()
            ' 
            ' webBrowser1
            ' 
            Me.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.webBrowser1.Location = New System.Drawing.Point(0, 0)
            Me.webBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
            Me.webBrowser1.Name = "webBrowser1"
            Me.webBrowser1.Size = New System.Drawing.Size(784, 561)
            Me.webBrowser1.TabIndex = 0
            ' 
            ' frmBrowser
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(784, 561)
            Me.Controls.Add(Me.webBrowser1)
            Me.Name = "frmBrowser"
            Me.Text = "frmBrowser"
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private webBrowser1 As System.Windows.Forms.WebBrowser
    End Class
End Namespace