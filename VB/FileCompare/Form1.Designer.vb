<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.CbxLoadHeaders = New System.Windows.Forms.CheckBox()
        Me.lblError = New System.Windows.Forms.Label()
        Me.txtColumnSeperator = New System.Windows.Forms.TextBox()
        Me.lblColumnSeperator = New System.Windows.Forms.Label()
        Me.BtnLoadRef = New System.Windows.Forms.Button()
        Me.TextBoxRef = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxFile = New System.Windows.Forms.TextBox()
        Me.BtnLoadFile = New System.Windows.Forms.Button()
        Me.BtnSaveAs = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CbxLoadHeaders
        '
        Me.CbxLoadHeaders.AutoSize = True
        Me.CbxLoadHeaders.Checked = True
        Me.CbxLoadHeaders.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbxLoadHeaders.Location = New System.Drawing.Point(48, 11)
        Me.CbxLoadHeaders.Name = "CbxLoadHeaders"
        Me.CbxLoadHeaders.Size = New System.Drawing.Size(181, 17)
        Me.CbxLoadHeaders.TabIndex = 0
        Me.CbxLoadHeaders.Text = "Load first row as column headers"
        Me.CbxLoadHeaders.UseVisualStyleBackColor = True
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(46, 91)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(87, 13)
        Me.lblError.TabIndex = 2
        Me.lblError.Text = "No error occured"
        Me.lblError.Visible = False
        '
        'txtColumnSeperator
        '
        Me.txtColumnSeperator.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColumnSeperator.Location = New System.Drawing.Point(322, 8)
        Me.txtColumnSeperator.Name = "txtColumnSeperator"
        Me.txtColumnSeperator.Size = New System.Drawing.Size(26, 22)
        Me.txtColumnSeperator.TabIndex = 3
        Me.txtColumnSeperator.Text = ";"
        Me.txtColumnSeperator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblColumnSeperator
        '
        Me.lblColumnSeperator.AutoSize = True
        Me.lblColumnSeperator.Location = New System.Drawing.Point(226, 13)
        Me.lblColumnSeperator.Name = "lblColumnSeperator"
        Me.lblColumnSeperator.Size = New System.Drawing.Size(89, 13)
        Me.lblColumnSeperator.TabIndex = 4
        Me.lblColumnSeperator.Text = "Column seperator"
        '
        'BtnLoadRef
        '
        Me.BtnLoadRef.Location = New System.Drawing.Point(399, 40)
        Me.BtnLoadRef.Name = "BtnLoadRef"
        Me.BtnLoadRef.Size = New System.Drawing.Size(75, 23)
        Me.BtnLoadRef.TabIndex = 5
        Me.BtnLoadRef.Text = "Load"
        Me.BtnLoadRef.UseVisualStyleBackColor = True
        '
        'TextBoxRef
        '
        Me.TextBoxRef.Location = New System.Drawing.Point(121, 42)
        Me.TextBoxRef.Name = "TextBoxRef"
        Me.TextBoxRef.Size = New System.Drawing.Size(272, 20)
        Me.TextBoxRef.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Reference file:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(539, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Modified file:"
        '
        'TextBoxFile
        '
        Me.TextBoxFile.Location = New System.Drawing.Point(611, 42)
        Me.TextBoxFile.Name = "TextBoxFile"
        Me.TextBoxFile.Size = New System.Drawing.Size(272, 20)
        Me.TextBoxFile.TabIndex = 9
        '
        'BtnLoadFile
        '
        Me.BtnLoadFile.Location = New System.Drawing.Point(889, 40)
        Me.BtnLoadFile.Name = "BtnLoadFile"
        Me.BtnLoadFile.Size = New System.Drawing.Size(75, 23)
        Me.BtnLoadFile.TabIndex = 10
        Me.BtnLoadFile.Text = "Load"
        Me.BtnLoadFile.UseVisualStyleBackColor = True
        '
        'BtnSaveAs
        '
        Me.BtnSaveAs.Location = New System.Drawing.Point(970, 40)
        Me.BtnSaveAs.Name = "BtnSaveAs"
        Me.BtnSaveAs.Size = New System.Drawing.Size(75, 23)
        Me.BtnSaveAs.TabIndex = 12
        Me.BtnSaveAs.Text = "Save as"
        Me.BtnSaveAs.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1097, 615)
        Me.Controls.Add(Me.BtnSaveAs)
        Me.Controls.Add(Me.BtnLoadFile)
        Me.Controls.Add(Me.TextBoxFile)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxRef)
        Me.Controls.Add(Me.BtnLoadRef)
        Me.Controls.Add(Me.lblColumnSeperator)
        Me.Controls.Add(Me.txtColumnSeperator)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.CbxLoadHeaders)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CbxLoadHeaders As System.Windows.Forms.CheckBox
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents lblColumnSeperator As System.Windows.Forms.Label
    Friend WithEvents BtnLoadRef As Button
    Friend WithEvents TextBoxRef As TextBox
    Friend WithEvents Label1 As Label
    Public WithEvents txtColumnSeperator As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxFile As TextBox
    Friend WithEvents BtnLoadFile As Button
    Friend WithEvents BtnSaveAs As Button
End Class
