<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLotto
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLotto))
        Me.txtAntal = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSlumpa = New System.Windows.Forms.Button()
        Me.rtxtResult = New System.Windows.Forms.RichTextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAntal
        '
        Me.txtAntal.Location = New System.Drawing.Point(6, 17)
        Me.txtAntal.Name = "txtAntal"
        Me.txtAntal.Size = New System.Drawing.Size(100, 20)
        Me.txtAntal.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtAntal)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(115, 51)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Antal"
        '
        'btnSlumpa
        '
        Me.btnSlumpa.Location = New System.Drawing.Point(134, 27)
        Me.btnSlumpa.Name = "btnSlumpa"
        Me.btnSlumpa.Size = New System.Drawing.Size(81, 23)
        Me.btnSlumpa.TabIndex = 2
        Me.btnSlumpa.Text = "Slumpa!"
        Me.btnSlumpa.UseVisualStyleBackColor = True
        '
        'rtxtResult
        '
        Me.rtxtResult.Location = New System.Drawing.Point(13, 71)
        Me.rtxtResult.Name = "rtxtResult"
        Me.rtxtResult.Size = New System.Drawing.Size(253, 370)
        Me.rtxtResult.TabIndex = 3
        Me.rtxtResult.Text = ""
        '
        'frmLotto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 453)
        Me.Controls.Add(Me.rtxtResult)
        Me.Controls.Add(Me.btnSlumpa)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmLotto"
        Me.Text = "Slumpa"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtAntal As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSlumpa As System.Windows.Forms.Button
    Friend WithEvents rtxtResult As System.Windows.Forms.RichTextBox
End Class
