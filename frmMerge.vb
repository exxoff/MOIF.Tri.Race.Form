Public Class frmMerge

    Public LastDirectory As String = Nothing

    Private Sub btnDB1_Click(sender As Object, e As EventArgs) Handles btnDB1.Click

        If Not IsNothing(Form1.DBFile) Then
            Dim tempfile = My.Computer.FileSystem.GetFileInfo(Form1.DBFile)
            fdDB1.InitialDirectory = tempfile.DirectoryName
            'fdDB1.FileName = tempfile.Name
        Else
            fdDB1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        End If
        With fdDB1
            .FileName = ""
            .DefaultExt = ".db3"
            .Filter = "SQLite-filer|*.db3|Alla filer|*.*"
            .Multiselect = True
        End With

        Dim dlgres As DialogResult = fdDB1.ShowDialog

        If dlgres = Windows.Forms.DialogResult.Cancel Then Exit Sub



        For Each DBFile In fdDB1.FileNames
            lstDBFiles.Items.Add(DBFile)
        Next





    End Sub

    Private Sub frmMerge_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btnMerge.Enabled = True
        'txtDB1.Text = ""
        'txtDB2.Text = ""
        'txtDBOut.Text = ""
        lstDBFiles.Items.Clear()
        If Not IsNothing(Form1.DBFile) Then
            lstDBFiles.Items.Add(Form1.DBFile)
        End If

    End Sub


    Private Sub btnDBOut_Click(sender As Object, e As EventArgs) Handles btnDBOut.Click

        If IsNothing(LastDirectory) Then
            sfdOutDB.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        End If
        With sfdOutDB
            .Filter = "SQLite-filer|*.db3|Alla filer|*.*"
            .DefaultExt = ".db3"
            .FileName = ""
        End With
        Dim dlgres As DialogResult = sfdOutDB.ShowDialog

        If dlgres = Windows.Forms.DialogResult.Cancel Then Exit Sub

        txtDBOut.Text = sfdOutDB.FileName.ToString
        LastDirectory = txtDBOut.Text

    End Sub

    Private Sub txtDB1_TextChanged(sender As Object, e As EventArgs)


    End Sub

    Private Sub txtDB2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtDBOut_TextChanged(sender As Object, e As EventArgs) Handles txtDBOut.TextChanged

    End Sub

    Private Sub btnMerge_Click(sender As Object, e As EventArgs) Handles btnMerge.Click

        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Dim objSQLite As New clsSQLite

        Dim DBFileList As New ArrayList

        For Each Item In lstDBFiles.Items
            DBFileList.Add(Item)
        Next
        'With DBFileList
        '    .Add(txtDB1.Text)
        '    .Add(txtDB2.Text)
        'End With

        For Each DBFile As String In DBFileList
            If Not My.Computer.FileSystem.FileExists(DBFile) Then
                MsgBox(String.Format("Kan inte hitta {0}", DBFile))
                System.Windows.Forms.Cursor.Current = Cursors.Default
                Exit Sub
            End If
        Next


        If My.Computer.FileSystem.FileExists(txtDBOut.Text) Then
            If MsgBox(String.Format("{0} finns redan. Är du säker på att du vill skriva över?", txtDBOut.Text), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Try
                    My.Computer.FileSystem.DeleteFile(txtDBOut.Text)
                Catch ex As Exception
                    MsgBox(String.Format("Kunde inte skriva över {0}, {1}", txtDBOut.Text, ex.Message))
                    System.Windows.Forms.Cursor.Current = Cursors.Default

                    Exit Sub
                End Try
            Else
                System.Windows.Forms.Cursor.Current = Cursors.Default
                Exit Sub
            End If

        End If
        If objSQLite.CreateDB(txtDBOut.Text, True) = False Then
            MsgBox(String.Format("Kunde inte skapa {0}", txtDBOut.Text))

        End If

        Dim objDBOut As DBConnection_Return = objSQLite.ConnectDB(txtDBOut.Text)

        For Each DBFile As String In DBFileList
            Try
                Dim objDB As DBConnection_Return = objSQLite.ConnectDB(DBFile)
                If objDB.rc <> 0 Then Throw New ApplicationException(String.Format("Kunde inte läsa {0}, {1}", DBFile, objDB.ErrMsg))

                Dim objAthletes As SELECT_RETURN = objSQLite.ReadAthletes(objDB.Connection)
                Dim dt As DataTable = objAthletes.Athletes.Tables("Athletes")
                For Each row As DataRow In dt.Rows
                    objSQLite.AddAthlete(objDBOut.Connection, row("BIB"), row("FirstName"), row("LastName"), row("EMail"), row("Grp"), row("Datum"))

                Next
                objDB.Connection.Close()

            Catch applex As ApplicationException
                MsgBox(applex.Message)
                'Exit Sub
            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                System.Windows.Forms.Cursor.Current = Cursors.Default

            End Try


        Next

        objDBOut.Connection.Close()


        If MsgBox("Klar! Vill du ladda den sammanfogade databasen nu?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Form1.DBFile = txtDBOut.Text
            Form1.Text = String.Format("Mölndal Outdoor Triathlonregistrering ({0})", Form1.DBFile)
            Form1.EnableForm()
        End If
        Me.Close()


    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        lstDBFiles.Items.Clear()
    End Sub

    Private Sub lstDBFiles_MouseDown(sender As Object, e As MouseEventArgs) Handles lstDBFiles.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim index As Integer = lstDBFiles.IndexFromPoint(New Point(e.X, e.Y))
            If index >= 0 Then
                lstDBFiles.SelectedItem = lstDBFiles.Items(index)
            End If
        End If
        If lstDBFiles.SelectedIndex = -1 Then
            TaBortToolStripMenuItem.Enabled = False
        Else
            TaBortToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub lstDBFiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDBFiles.SelectedIndexChanged

    End Sub

    Private Sub TaBortToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TaBortToolStripMenuItem.Click

        lstDBFiles.Items.RemoveAt(lstDBFiles.SelectedIndex)
    End Sub
End Class