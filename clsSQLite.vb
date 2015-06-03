Imports System.Data.SQLite

Public Structure DBConnection_Return
    Dim rc As Integer
    Dim Connection As SQLite.SQLiteConnection
    Dim ErrMsg As String

End Structure

Public Structure INSERT_RETURN
    Dim rc As Integer
    Dim ErrMsg As String

End Structure

Public Structure SELECT_RETURN
    Dim rc As Integer
    Dim ErrMsg As String
    Dim Athletes As DataSet

End Structure

Public Structure FIND_RETURN
    Dim rc As Integer
    Dim ErrMsg As String
    Dim NumberOfAthletes As Integer
    Dim FirstName As String
    Dim LastName As String

End Structure

Public Structure DELETE_RETURN
    Dim rc As Integer
    Dim ErrMsg As String
End Structure

Public Structure VERSION_RETURN
    Dim rc As Integer
    Dim ErrMsg As String
    Dim DBVersion As Version
    Dim OldestOKVersion As Version
End Structure
Public Class clsSQLite
    Public Structure objDB
        Dim dbconn As SQLiteConnection
        Dim rc As Integer
    End Structure


    Public sqlconnection As SQLiteConnection

    Public Function CreateDB(strFileName As String, Optional NewFile As Boolean = False) As Boolean

        'Vi kollar först om filen finns. Finns den testar vi om den är en MOIF.Tri.Race.Form-kompatibel databas.

        Dim oVersion As New VERSION_RETURN
        Dim msg As String = Nothing
        If NewFile = True Then
            Try
                SQLiteConnection.CreateFile(strFileName)
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try


            'Dim sqlconnection As New SQLite.SQLiteConnection()
            Dim sqlconnection As New SQLiteConnection()
            Dim sqlcommand As New SQLite.SQLiteCommand("", sqlconnection)

            Try
                sqlconnection.ConnectionString = "Data Source=" + strFileName
                sqlconnection.Open()
                '************************ NOTE ***********************************************************************
                ' Om man gör förändringar i databasen måste man uppdatera OldestOKVersion till denna denna version
                '*****************************************************************************************************
                sqlcommand.CommandText = "CREATE TABLE Athletes(AthID INTEGER PRIMARY KEY ASC, BIB INTEGER(4), WaveNumber INTEGER(2), FirstName VARCHAR(50), LastName VARCHAR(80), Grp VARCHAR(20), EMail VARCHAR(100), Datum VARCHAR(20));"
                sqlcommand.ExecuteNonQuery()
                sqlcommand.CommandText = "CREATE TABLE VersionTable(DBVersion VARCHAR(8));"
                sqlcommand.ExecuteNonQuery()
                sqlcommand.CommandText = "INSERT INTO VersionTable(DBVersion) values ('" + My.Application.Info.Version.ToString + "');"
                sqlcommand.ExecuteNonQuery()
                sqlconnection.Close()

            Catch connex As Exception
                MsgBox(connex.Message)
                If sqlconnection.State = ConnectionState.Open Then sqlconnection.Close()
                Return False

            End Try

        Else
            'Här kollar vi om filen som vi försöker använda verkar vara en valid databas.
            Dim sqlconnection As New SQLiteConnection()
            Dim sqlcommand As New SQLite.SQLiteCommand("", sqlconnection)

            Try
                sqlconnection.ConnectionString = "Data Source=" + strFileName
                sqlconnection.Open()
                sqlcommand.CommandText = "SELECT count(name) FROM sqlite_master WHERE type='table' AND name='Athletes';"
                If sqlcommand.ExecuteScalar() = Nothing Then
                    MsgBox("Den här filen är antingen skadad eller så är det inte en riktig MOIF.Tri.Race-databas")
                    Return False
                End If
                oVersion = CheckDBVersion(sqlconnection)
                If oVersion.rc <> 0 Then Throw New ApplicationException


                sqlconnection.Close()

            Catch applex As ApplicationException
                MsgBox(oVersion.ErrMsg)
                Return False
            Catch ex As Exception
                MsgBox(ex.Message)

                Return False
            End Try
        End If


        Return True


    End Function

    Function CheckDBVersion(connection As SQLiteConnection) As VERSION_RETURN
        Dim SCommand As New SQLiteCommand("", connection)
        Dim oRet As New VERSION_RETURN
        Dim ver As Version = Nothing
        Dim OldestOKVersion As New Version("1.5.0")



        Try
            If Not connection.State = ConnectionState.Open Then Throw New System.Data.SQLite.SQLiteException
            SCommand.CommandText = "SELECT count(name) FROM sqlite_master WHERE type='table' AND name='VersionTable';"
            If SCommand.ExecuteScalar() = Nothing Then Throw New ApplicationException 'Databasen är för gammal för att ens ha versionskontrollen


            SCommand.CommandText = "SELECT * From VersionTable;"

            Dim oReader As String = SCommand.ExecuteScalar()
            Dim k As Boolean = Version.TryParse(oReader, oRet.DBVersion)

            If oRet.DBVersion.CompareTo(OldestOKVersion) = -1 Then Throw New ApplicationException
            
            oRet.rc = 0

        Catch applex As ApplicationException
            oRet.ErrMsg = "Den här databasfilen är skapad för en tidigare version av det här programmet och kan inte öppnas."
            oRet.rc = 1
        Catch sqliteex As System.Data.SQLite.SQLiteException

        Catch ex As Exception
            oRet.rc = 1
            oRet.ErrMsg = ex.Message
        End Try

        Return oRet
    End Function

    Public Function ConnectDB(strDBFile As String) As DBConnection_Return

        Dim oRet As New DBConnection_Return

        Dim sqlconnection As New SQLiteConnection
        'Dim dbfile As String = "C:\Temp\Test.db3"

        Try
            If Not My.Computer.FileSystem.FileExists(strDBFile) Then Throw New System.IO.IOException

        Catch ioex As IO.IOException

        End Try

        Try
            sqlconnection.ConnectionString = "Data Source=" + strDBFile
            sqlconnection.Open()

        Catch ex As Exception
            oRet.rc = 1
            oRet.Connection = Nothing
            oRet.ErrMsg = ex.Message
            Return oRet
        End Try
        oRet.Connection = sqlconnection
        oRet.rc = 0
        oRet.ErrMsg = Nothing


        Return oRet



    End Function

    Public Function DeleteAthlete(sqlconnection As SQLiteConnection, BIB As Integer) As DELETE_RETURN
        Dim oRet As New DELETE_RETURN
        oRet.rc = 0

        Try
            If Not sqlconnection.State = ConnectionState.Open Then Throw New System.Data.SQLite.SQLiteException
            Dim strSQL As String = "DELETE FROM Athletes WHERE BIB='" + BIB.ToString + "';"
            Dim SCommand As New SQLiteCommand(strSQL, sqlconnection)
            SCommand.ExecuteNonQuery()

        Catch sqliteex As System.Data.SQLite.SQLiteException
            oRet.rc = sqliteex.ErrorCode
            oRet.ErrMsg = sqliteex.Message
        Catch ex As Exception
            oRet.rc = 1
            oRet.ErrMsg = ex.Message

        End Try

        Return oRet
    End Function


    Public Function AddAthlete(sqlconnection As SQLiteConnection, BIB As Integer, FirstName As String, LastName As String, email As String, distance As String, datum As String) As INSERT_RETURN

        Dim oRet As New INSERT_RETURN
        Dim iWave As New Integer

        If distance.ToUpper = "LONG" Then
            iWave = 1
        Else
            iWave = 2
        End If
        Try
            If Not sqlconnection.State = ConnectionState.Open Then Throw New System.Data.SQLite.SQLiteException
            Dim strSQL As String = "INSERT INTO Athletes(BIB,WaveNumber,FirstName,LastName,Grp,EMail,Datum) values ('" + BIB.ToString + "','" + iWave.ToString + "','" + FirstName + "','" + LastName + "','" + distance + "','" + email + "','" + datum + "');"




            Dim SCommand As New SQLiteCommand(strSQL, sqlconnection)
            SCommand.ExecuteNonQuery()

        Catch sqliteex As System.Data.SQLite.SQLiteException
            oRet.rc = sqliteex.ErrorCode
            oRet.ErrMsg = sqliteex.Message


        Catch ex As Exception
            oRet.rc = 1
            oRet.ErrMsg = ex.Message

        Finally
            'sqlconnection.Close()
        End Try

        Return oRet

    End Function

    Function FindAthlete(sqlconnection As SQLiteConnection, BIB As Integer) As FIND_RETURN

        Dim oRet As New FIND_RETURN
        oRet.rc = 0

        Try
            If Not sqlconnection.State = ConnectionState.Open Then Throw New System.Data.SQLite.SQLiteException
            Dim strSQL As String = "SELECT COUNT(BIB) as CNT,FirstName,LastName FROM Athletes WHERE BIB = '" + BIB.ToString + "';"


            Dim SCommand As New SQLiteCommand(strSQL, sqlconnection)
            Dim oReader As SQLiteDataReader = SCommand.ExecuteReader()

            While oReader.Read
                oRet.NumberOfAthletes = oReader("CNT")
                If oRet.NumberOfAthletes > 0 Then
                    oRet.FirstName = oReader("FirstName")
                    oRet.LastName = oReader("LastName")
                End If
            End While
            'oRet.NumberOfAthletes = SCommand.ExecuteScalar()
            oReader.Close()
        Catch sqliteex As System.Data.SQLite.SQLiteException
            oRet.rc = sqliteex.ErrorCode
            oRet.ErrMsg = sqliteex.Message


        Catch ex As Exception
            oRet.rc = 1
            oRet.ErrMsg = ex.Message

        Finally

        End Try


        Return oRet

    End Function
    Public Function ReadAthletes(DBConnection As SQLiteConnection, Optional SQLQuery As String = "SELECT BIB,WaveNumber,FirstName,LastName,Grp,Email,Datum FROM Athletes ORDER BY BIB") As SELECT_RETURN
        'Dim SQLQuery As String = "SELECT BIB,FirstName,LastName,Grp,Email FROM Athletes ORDER BY BIB"
        Dim oAthletes As New SELECT_RETURN
        Dim objDataSet As New DataSet

        Try
            ''Dim f As New Form2
            Dim da As SQLiteDataAdapter = New SQLiteDataAdapter
            da.SelectCommand = New SQLiteCommand(SQLQuery, DBConnection)
            da.Fill(objDataSet, "Athletes")
            If objDataSet.Tables.Count < 1 Then Throw New Exception("Databasen innehåller ingen data")

            ''f.DataGridView1.DataSource = objDataSet
            ''f.DataGridView1.DataMember = "Athletes"

            ''f.ShowDialog()
            oAthletes.rc = 0
            oAthletes.Athletes = objDataSet

        Catch ex As Exception
            oAthletes.ErrMsg = ex.Message.ToString
            oAthletes.rc = 1
        End Try

        Return oAthletes





    End Function
End Class
