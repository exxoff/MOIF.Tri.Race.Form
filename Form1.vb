Imports System.Data.SQLite
Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices



Public Class Form1
    Public Shared DBFile As String




    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim DB As New clsSQLite
        Dim DBConnection As New DBConnection_Return
        Dim Athlete_Return As New INSERT_RETURN
        Dim Find_Return As New FIND_RETURN
        Dim msg As String = Nothing



        txtName.Text = Globalization.CultureInfo.CurrentCulture.TextInfo.ToLower(txtName.Text)
        txtName.Text = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtName.Text)
        txtLastName.Text = Globalization.CultureInfo.CurrentCulture.TextInfo.ToLower(txtLastName.Text)
        txtLastName.Text = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtLastName.Text)

        ' Check if any field is empty
        If Len(txtBIB.Text) < 1 Then
            lblFeedback.ForeColor = Color.Red
            lblFeedback.Text = "Nummerlapp får inte vara tomt"
            txtBIB.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtBIB.Text) Then
            lblFeedback.ForeColor = Color.Red
            lblFeedback.Text = "Nummerlapp måste vara numeriskt."
            txtBIB.Focus()
            Exit Sub
        End If
        If txtBIB.Text = "0" Then
            lblFeedback.ForeColor = Color.Red
            lblFeedback.Text = "Jag tror inte du har startnummer 0."
            txtBIB.Focus()
            Exit Sub
        End If
        If Len(txtName.Text) < 1 Then
            lblFeedback.ForeColor = Color.Red
            lblFeedback.Text = "Förnamn får inte vara tomt"
            txtName.Focus()
            Exit Sub
        End If
        If Len(txtLastName.Text) < 1 Then
            lblFeedback.ForeColor = Color.Red
            lblFeedback.Text = "Efternamn får inte vara tomt"
            txtName.Focus()
            Exit Sub
        End If
        'If Len(txtEMail.Text) < 1 Then
        '    lblFeedback.ForeColor = Color.Red
        '    lblFeedback.Text = "E-post får inte vara tomt"
        '    txtEMail.Focus()
        '    Exit Sub
        'End If
        Dim sClass As String = Nothing
        Dim xClass As String = Nothing

        If rdoClassLong.Checked Then
            sClass = "Long"
            xClass = "Lång"
        Else
            sClass = "Short"
            xClass = "Kort"
        End If
        Try
            DBConnection = DB.ConnectDB(DBFile)
            If DBConnection.rc <> 0 Then Throw New ApplicationException(DBConnection.ErrMsg)

            'Vi kollar om den tävlande redan är registrerad och, om så är fallet, skickar ut en fråga om vi ska uppdatera.

            Find_Return = DB.FindAthlete(DBConnection.Connection, txtBIB.Text)
            If Find_Return.rc <> 0 Then MsgBox(Find_Return.ErrMsg, MsgBoxStyle.Critical) : Exit Sub


            If Find_Return.NumberOfAthletes > 0 Then
                msg = String.Format("Nummer {0} är registrerad på {1} {2}. Vill du uppdatera anmälan?", txtBIB.Text, Find_Return.FirstName, Find_Return.LastName)
                Dim bUpdateAthlete As Integer = MsgBox(msg, MsgBoxStyle.YesNo, "Redan registrerad")
                If bUpdateAthlete = 6 Then ' 6=Ja
                    Dim oDelRet As DELETE_RETURN = DB.DeleteAthlete(DBConnection.Connection, txtBIB.Text)
                    If oDelRet.rc <> 0 Then
                        MsgBox(oDelRet.ErrMsg, MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                Else
                    Exit Sub
                End If
            End If

            Athlete_Return = DB.AddAthlete(DBConnection.Connection, CInt(txtBIB.Text), txtName.Text, txtLastName.Text, txtEMail.Text, sClass, String.Format(Now(), "YYYY-MM-DD HH:mm:ss"))
            If Athlete_Return.rc <> 0 Then Throw New ApplicationException(Athlete_Return.ErrMsg)
            lblFeedback.ForeColor = Color.Green
            'lblFeedback.Text = "Nummer " + txtBIB.Text + " registrerades OK. Lycka till!"
            msg = String.Format("Nummer {0}, {1} {2}, registrerades för klass '{3}'. Lycka till!", txtBIB.Text, txtName.Text, txtLastName.Text, xClass)
            'MsgBox(msg)
            txtBIB.Clear()
            txtEMail.Clear()
            txtName.Clear()
            txtLastName.Clear()
            rdoClassLong.Checked = True
            txtBIB.Focus()
            lblFeedback.Text = msg

        Catch applex As ApplicationException
            MsgBox(applex.Message)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DisableForm()




    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub NyDatabasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NyDatabasToolStripMenuItem.Click

        Dim dlgResult As DialogResult = Nothing

        SaveFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        SaveFileDialog1.Title = "Ny databasfil"
        SaveFileDialog1.DefaultExt = ".db3"
        SaveFileDialog1.FileName = "MOIF.Tri.Athlete" + Format(Now(), "yyyyMMdd") + ".db3"
        SaveFileDialog1.Filter = "SQLite-filer|*.db3|Alla filer|*.*"

        dlgResult = SaveFileDialog1.ShowDialog()
        If dlgResult = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim DB As New clsSQLite

        DBFile = SaveFileDialog1.FileName.ToString

        If DB.CreateDB(DBFile, True) Then EnableForm()



        Me.Text = "Mölndal Outdoor Triathlonregistrering" + "(" + DBFile + ")"



    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim DB As New clsSQLite

        Dim strFileName As String = OpenFileDialog1.FileName.ToString

        If DB.CreateDB(strFileName) = True Then
            EnableForm()
        End If


    End Sub

    Private Sub DisableForm()
        txtBIB.Enabled = False
        txtName.Enabled = False
        txtEMail.Enabled = False
        txtLastName.Enabled = False
        btnSubmit.Enabled = False
        ExporteraTillCSVToolStripMenuItem.Enabled = False
        VisaTävlandeToolStripMenuItem.Enabled = False
        SlumpaToolStripMenuItem.Enabled = False

    End Sub

    Public Sub EnableForm()
        txtBIB.Enabled = True
        txtName.Enabled = True
        txtLastName.Enabled = True
        txtEMail.Enabled = True
        btnSubmit.Enabled = True
        ExporteraTillCSVToolStripMenuItem.Enabled = True
        VisaTävlandeToolStripMenuItem.Enabled = True
        SlumpaToolStripMenuItem.Enabled = True
        txtBIB.Focus()
    End Sub

    Private Sub VisaTävlandeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisaTävlandeToolStripMenuItem.Click
        Dim DB As New clsSQLite
        Dim DBConnection As New DBConnection_Return
        Dim DSAthlete As SELECT_RETURN

        DBConnection = DB.ConnectDB(DBFile)
        DSAthlete = DB.ReadAthletes(DBConnection.Connection)
        If DSAthlete.rc <> 0 Then
            MsgBox(DSAthlete.ErrMsg)
            Exit Sub
        End If

        Dim f As New Form2
        f.DataGridView1.DataSource = DSAthlete.Athletes
        f.DataGridView1.DataMember = "Athletes"

        f.ShowDialog()

    End Sub

    Private Sub ExporteraTillCSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExporteraTillCSVToolStripMenuItem.Click

        Dim DB As New clsSQLite
        Dim DBConnection As New DBConnection_Return
        Dim DSAthlete As SELECT_RETURN
        Dim CSVFile As String = Nothing
        Dim sepchar As String = ","
        Dim dlgResult As DialogResult = Nothing
        Dim bWaveStart As Boolean = False

        Dim tempfile = My.Computer.FileSystem.GetFileInfo(DBFile)
        'Dim ext As String = tempfile.Extension
        Dim extlocation As Integer = InStr(tempfile.FullName, tempfile.Extension)
        CSVFile = Strings.Left(tempfile.FullName, extlocation - 1) + ".csv"

        Dim tempcsv = My.Computer.FileSystem.GetFileInfo(CSVFile)

        DBConnection = DB.ConnectDB(DBFile)
        DSAthlete = DB.ReadAthletes(DBConnection.Connection)
        If DSAthlete.rc <> 0 Then
            MsgBox(DSAthlete.ErrMsg)
            Exit Sub
        End If

        SaveFileDialog1.InitialDirectory = tempfile.DirectoryName
        SaveFileDialog1.Title = "Spara .CSV"
        SaveFileDialog1.DefaultExt = ".csv"
        SaveFileDialog1.FileName = tempcsv.Name
        SaveFileDialog1.Filter = "CSV-filer|*.csv|Alla filer|*.*"
        dlgResult = SaveFileDialog1.ShowDialog()
        If dlgResult = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim cols As New ArrayList

        With cols
            .Add("BIB")
            .Add("Wave Number")
            .Add("First Name")
            .Add("Last Name")
            .Add("Group")
            .Add("Email")
            .Add("Date")

        End With

        CSVFile = SaveFileDialog1.FileName.ToString

        Dim dt As DataTable = DSAthlete.Athletes.Tables("Athletes")

        Dim writer As System.IO.StreamWriter = Nothing
        Try
            writer = New System.IO.StreamWriter(CSVFile)

            ' first write a line with the columns name
            Dim sep As String = ""
            Dim builder As New System.Text.StringBuilder
            For Each col In cols
                builder.Append(sep).Append(col)
                sep = sepchar
            Next
            'For Each col As DataColumn In dt.Columns
            '    builder.Append(sep).Append(col.ColumnName)
            '    sep = sepChar
            'Next
            writer.WriteLine(builder.ToString())

            ' then write all the rows
            For Each row As DataRow In dt.Rows
                sep = ""
                builder = New System.Text.StringBuilder

                For Each col As DataColumn In dt.Columns
                    builder.Append(sep).Append(row(col.ColumnName))
                    sep = sepchar
                Next
                writer.WriteLine(builder.ToString())
            Next
        Finally
            If Not writer Is Nothing Then writer.Close()
        End Try


    End Sub

    Private Sub ÖppnaDatabasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÖppnaDatabasToolStripMenuItem.Click
        Dim dlgResult As DialogResult = Nothing
        OpenFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        OpenFileDialog1.Title = "Öppna databasfil"
        OpenFileDialog1.CheckFileExists = True
        dlgResult = OpenFileDialog1.ShowDialog()
        If dlgResult = Windows.Forms.DialogResult.Cancel Then Exit Sub
        DBFile = OpenFileDialog1.FileName.ToString

        Me.Text = String.Format("Mölndal Outdoor Triathlonregistrering ({0})", DBFile)

    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        'Dim DB As New clsSQLite

        'Dim strFileName As String = SaveFileDialog1.FileName.ToString

        'If DB.CreateDB(strFileName, True) Then EnableForm()
    End Sub

    Private Sub txtName_LostFocus(sender As Object, e As EventArgs) Handles txtName.LostFocus
        txtName.Text = Globalization.CultureInfo.CurrentCulture.TextInfo.ToLower(txtName.Text)
        txtName.Text = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtName.Text)
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged

    End Sub

    Private Sub OmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OmToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub txtLastName_LostFocus(sender As Object, e As EventArgs) Handles txtLastName.LostFocus
        txtLastName.Text = Globalization.CultureInfo.CurrentCulture.TextInfo.ToLower(txtLastName.Text)
        txtLastName.Text = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtLastName.Text)
    End Sub

    Private Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.TextChanged

    End Sub

    Private Sub txtBIB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBIB.KeyPress
        lblFeedback.Text = ""
    End Sub

    Private Sub txtBIB_TextChanged(sender As Object, e As EventArgs) Handles txtBIB.TextChanged

    End Sub

    Private Sub SammanfogaDatabaserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SammanfogaDatabaserToolStripMenuItem.Click
        frmMerge.ShowDialog()

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)
        RandomAthlete(5)
    End Sub

    Public Sub RandomAthlete(antal As Integer)
        Dim objSQLite As New clsSQLite
        Dim objConnection As DBConnection_Return = objSQLite.ConnectDB(DBFile)
        Dim SQL As String = String.Format("select * from Athletes order by RANDOM() LIMIT {0}", antal)
        Dim objAthlete As SELECT_RETURN = objSQLite.ReadAthletes(objConnection.Connection, SQL)
        Dim msg As New StringBuilder
        Dim dt As DataTable = objAthlete.Athletes.Tables("Athletes")
        Dim i As Integer = 1

        For Each row In dt.Rows
            msg.Append(String.Format("{0}: ,#{1}, {2} {3}{4}", i, row("BIB"), row("FirstName"), row("LastName"), ControlChars.NewLine))
            i = i + 1
        Next
        frmLotto.rtxtResult.Text = msg.ToString
        'MsgBox(msg.ToString)
    End Sub


    Private Sub SlumpaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SlumpaToolStripMenuItem.Click
        frmLotto.ShowDialog()

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class
