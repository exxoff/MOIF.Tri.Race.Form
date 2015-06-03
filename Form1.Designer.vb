<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtEMail = New System.Windows.Forms.TextBox()
        Me.txtBIB = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rdoClassLong = New System.Windows.Forms.RadioButton()
        Me.rdoClassShort = New System.Windows.Forms.RadioButton()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.lblFeedback = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AdminToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NyDatabasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÖppnaDatabasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VisaTävlandeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExporteraTillCSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SammanfogaDatabaserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SlumpaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HjälpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OmToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(255, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(182, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ANMÄLAN"
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(6, 20)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(184, 38)
        Me.txtName.TabIndex = 2
        '
        'txtEMail
        '
        Me.txtEMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEMail.Location = New System.Drawing.Point(7, 25)
        Me.txtEMail.Name = "txtEMail"
        Me.txtEMail.Size = New System.Drawing.Size(453, 38)
        Me.txtEMail.TabIndex = 5
        '
        'txtBIB
        '
        Me.txtBIB.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBIB.Location = New System.Drawing.Point(6, 25)
        Me.txtBIB.Name = "txtBIB"
        Me.txtBIB.Size = New System.Drawing.Size(123, 38)
        Me.txtBIB.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(200, 91)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 72)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Förnamn"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtEMail)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(200, 188)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(474, 82)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "E-postadress (ej obligatorisk)"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtBIB)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(43, 86)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(135, 77)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Startnummer"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rdoClassLong)
        Me.GroupBox4.Controls.Add(Me.rdoClassShort)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(43, 188)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(135, 82)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Klass"
        '
        'rdoClassLong
        '
        Me.rdoClassLong.AutoSize = True
        Me.rdoClassLong.Checked = True
        Me.rdoClassLong.Location = New System.Drawing.Point(9, 27)
        Me.rdoClassLong.Name = "rdoClassLong"
        Me.rdoClassLong.Size = New System.Drawing.Size(67, 24)
        Me.rdoClassLong.TabIndex = 8
        Me.rdoClassLong.TabStop = True
        Me.rdoClassLong.Text = "Lång"
        Me.rdoClassLong.UseVisualStyleBackColor = True
        '
        'rdoClassShort
        '
        Me.rdoClassShort.AutoSize = True
        Me.rdoClassShort.Location = New System.Drawing.Point(9, 50)
        Me.rdoClassShort.Name = "rdoClassShort"
        Me.rdoClassShort.Size = New System.Drawing.Size(60, 24)
        Me.rdoClassShort.TabIndex = 9
        Me.rdoClassShort.Text = "Kort"
        Me.rdoClassShort.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.Location = New System.Drawing.Point(541, 287)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(144, 41)
        Me.btnSubmit.TabIndex = 8
        Me.btnSubmit.Text = "Anmäl!"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'lblFeedback
        '
        Me.lblFeedback.AutoSize = True
        Me.lblFeedback.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFeedback.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblFeedback.Location = New System.Drawing.Point(46, 341)
        Me.lblFeedback.Name = "lblFeedback"
        Me.lblFeedback.Size = New System.Drawing.Size(0, 16)
        Me.lblFeedback.TabIndex = 9
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdminToolStripMenuItem, Me.HjälpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(713, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AdminToolStripMenuItem
        '
        Me.AdminToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NyDatabasToolStripMenuItem, Me.ÖppnaDatabasToolStripMenuItem, Me.VisaTävlandeToolStripMenuItem, Me.ExporteraTillCSVToolStripMenuItem, Me.SammanfogaDatabaserToolStripMenuItem, Me.SlumpaToolStripMenuItem})
        Me.AdminToolStripMenuItem.Name = "AdminToolStripMenuItem"
        Me.AdminToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.AdminToolStripMenuItem.Text = "Admin"
        '
        'NyDatabasToolStripMenuItem
        '
        Me.NyDatabasToolStripMenuItem.Name = "NyDatabasToolStripMenuItem"
        Me.NyDatabasToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.NyDatabasToolStripMenuItem.Text = "&Ny databas..."
        '
        'ÖppnaDatabasToolStripMenuItem
        '
        Me.ÖppnaDatabasToolStripMenuItem.Name = "ÖppnaDatabasToolStripMenuItem"
        Me.ÖppnaDatabasToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ÖppnaDatabasToolStripMenuItem.Text = "Öppna databas..."
        '
        'VisaTävlandeToolStripMenuItem
        '
        Me.VisaTävlandeToolStripMenuItem.Name = "VisaTävlandeToolStripMenuItem"
        Me.VisaTävlandeToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.VisaTävlandeToolStripMenuItem.Text = "&Visa tävlande"
        '
        'ExporteraTillCSVToolStripMenuItem
        '
        Me.ExporteraTillCSVToolStripMenuItem.Name = "ExporteraTillCSVToolStripMenuItem"
        Me.ExporteraTillCSVToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ExporteraTillCSVToolStripMenuItem.Text = "&Exportera till CSV"
        '
        'SammanfogaDatabaserToolStripMenuItem
        '
        Me.SammanfogaDatabaserToolStripMenuItem.Name = "SammanfogaDatabaserToolStripMenuItem"
        Me.SammanfogaDatabaserToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.SammanfogaDatabaserToolStripMenuItem.Text = "Sammanfoga databaser"
        '
        'SlumpaToolStripMenuItem
        '
        Me.SlumpaToolStripMenuItem.Name = "SlumpaToolStripMenuItem"
        Me.SlumpaToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.SlumpaToolStripMenuItem.Text = "Slumpa"
        '
        'HjälpToolStripMenuItem
        '
        Me.HjälpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OmToolStripMenuItem})
        Me.HjälpToolStripMenuItem.Name = "HjälpToolStripMenuItem"
        Me.HjälpToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.HjälpToolStripMenuItem.Text = "Hjälp"
        '
        'OmToolStripMenuItem
        '
        Me.OmToolStripMenuItem.Name = "OmToolStripMenuItem"
        Me.OmToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.OmToolStripMenuItem.Text = "Om..."
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.CheckFileExists = False
        Me.OpenFileDialog1.Filter = "SQLite-filer|*.db3|Alla filer|*.*"
        '
        'SaveFileDialog1
        '
        '
        'txtLastName
        '
        Me.txtLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(6, 20)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(240, 38)
        Me.txtLastName.TabIndex = 3
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtLastName)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(418, 91)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(256, 72)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Efternamn"
        '
        'Form1
        '
        Me.AcceptButton = Me.btnSubmit
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 378)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.lblFeedback)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Mölndal Outdoor Triathlonregistrering"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtEMail As System.Windows.Forms.TextBox
    Friend WithEvents txtBIB As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoClassLong As System.Windows.Forms.RadioButton
    Friend WithEvents rdoClassShort As System.Windows.Forms.RadioButton
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblFeedback As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AdminToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NyDatabasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExporteraTillCSVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VisaTävlandeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ÖppnaDatabasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents HjälpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OmToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents SammanfogaDatabaserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SlumpaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
