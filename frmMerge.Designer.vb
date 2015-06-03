<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMerge
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMerge))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lstDBFiles = New System.Windows.Forms.ListBox()
        Me.btnDB1 = New System.Windows.Forms.Button()
        Me.txtDBOut = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnDBOut = New System.Windows.Forms.Button()
        Me.fdDB1 = New System.Windows.Forms.OpenFileDialog()
        Me.fdDB2 = New System.Windows.Forms.OpenFileDialog()
        Me.sfdOutDB = New System.Windows.Forms.SaveFileDialog()
        Me.btnMerge = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TaBortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnClear)
        Me.GroupBox1.Controls.Add(Me.lstDBFiles)
        Me.GroupBox1.Controls.Add(Me.btnDB1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(401, 183)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datafiler"
        '
        'btnClear
        '
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(351, 48)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(29, 23)
        Me.btnClear.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.btnClear, "Rensa")
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'lstDBFiles
        '
        Me.lstDBFiles.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lstDBFiles.FormattingEnabled = True
        Me.lstDBFiles.HorizontalScrollbar = True
        Me.lstDBFiles.Location = New System.Drawing.Point(16, 19)
        Me.lstDBFiles.Name = "lstDBFiles"
        Me.lstDBFiles.Size = New System.Drawing.Size(329, 134)
        Me.lstDBFiles.TabIndex = 4
        '
        'btnDB1
        '
        Me.btnDB1.Image = CType(resources.GetObject("btnDB1.Image"), System.Drawing.Image)
        Me.btnDB1.Location = New System.Drawing.Point(351, 19)
        Me.btnDB1.Name = "btnDB1"
        Me.btnDB1.Size = New System.Drawing.Size(29, 23)
        Me.btnDB1.TabIndex = 3
        Me.btnDB1.UseVisualStyleBackColor = True
        '
        'txtDBOut
        '
        Me.txtDBOut.Location = New System.Drawing.Point(7, 20)
        Me.txtDBOut.Name = "txtDBOut"
        Me.txtDBOut.Size = New System.Drawing.Size(338, 20)
        Me.txtDBOut.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnDBOut)
        Me.GroupBox3.Controls.Add(Me.txtDBOut)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 202)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(401, 51)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Utdata"
        '
        'btnDBOut
        '
        Me.btnDBOut.Image = CType(resources.GetObject("btnDBOut.Image"), System.Drawing.Image)
        Me.btnDBOut.Location = New System.Drawing.Point(351, 20)
        Me.btnDBOut.Name = "btnDBOut"
        Me.btnDBOut.Size = New System.Drawing.Size(29, 23)
        Me.btnDBOut.TabIndex = 5
        Me.btnDBOut.UseVisualStyleBackColor = True
        '
        'fdDB1
        '
        Me.fdDB1.FileName = "fdDB1"
        '
        'fdDB2
        '
        Me.fdDB2.FileName = "fdDB2"
        '
        'btnMerge
        '
        Me.btnMerge.Location = New System.Drawing.Point(333, 270)
        Me.btnMerge.Name = "btnMerge"
        Me.btnMerge.Size = New System.Drawing.Size(81, 23)
        Me.btnMerge.TabIndex = 3
        Me.btnMerge.Text = "Sammanfoga"
        Me.btnMerge.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TaBortToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(113, 26)
        '
        'TaBortToolStripMenuItem
        '
        Me.TaBortToolStripMenuItem.Name = "TaBortToolStripMenuItem"
        Me.TaBortToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.TaBortToolStripMenuItem.Text = "Ta bort"
        '
        'frmMerge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 304)
        Me.Controls.Add(Me.btnMerge)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMerge"
        Me.Text = "Sammanfoga databas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDB1 As System.Windows.Forms.Button
    Friend WithEvents txtDBOut As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDBOut As System.Windows.Forms.Button
    Friend WithEvents fdDB1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents fdDB2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents sfdOutDB As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnMerge As System.Windows.Forms.Button
    Friend WithEvents lstDBFiles As System.Windows.Forms.ListBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TaBortToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
