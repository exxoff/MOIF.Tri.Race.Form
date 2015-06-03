Public Class frmLotto

    Private Sub btnSlumpa_Click(sender As Object, e As EventArgs) Handles btnSlumpa.Click
        If Len(txtAntal.Text) < 1 Then txtAntal.Text = 1

        Form1.RandomAthlete(txtAntal.Text)

    End Sub

    Private Sub frmLotto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtAntal.Text = "5"
    End Sub
End Class