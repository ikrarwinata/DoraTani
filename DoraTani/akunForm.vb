Imports MySql.Data.MySqlClient

Public Class akunForm
    Private OnFinish As Action

    Public Overloads Sub Show(ByVal act As Action)
        OnFinish = act
        Me.Show()
    End Sub

    Public Sub BukaDatabase()
        dgv1.DataSource = Table("akun_pengguna", "SELECT username AS Username, nama AS 'Nama Pengguna', level AS LEVEL FROM akun_pengguna")
    End Sub

    Private Sub akunForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            OnFinish()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub akunForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaDatabase()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If sender.Text = "Cari" Then
            Dim k As String = ToolStripTextBox1.Text
            Dim searchq As String = " WHERE username LIKE '%" & k & "%' OR nama LIKE '%" & k & "%' OR level LIKE '%" & k & "%'"
            dgv1.DataSource = Table("akun_pengguna", "SELECT username AS Username, nama AS 'Nama Pengguna', level AS LEVEL FROM akun_pengguna" & searchq)
            sender.Text = "Reset"
        Else
            BukaDatabase()
            sender.Text = "Cari"
        End If
    End Sub

    Private Sub TambahToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TambahToolStripMenuItem.Click
        Dim editak As editAkunPengguna = New editAkunPengguna
        editak.TambahBaru(AddressOf Me.BukaDatabase)
    End Sub

    Private Sub HapusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HapusToolStripMenuItem.Click
        Try
            If MessageBox.Show("Anda yakin ingin menghapus " & dgv1.SelectedRows.Count & " akun pengguna ?", "Konfirmasi hapus", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                For Each ro As DataGridViewRow In dgv1.SelectedRows
                    cmd = New MySqlCommand("DELETE FROM akun_pengguna WHERE username = '" & ro.Cells("Username").Value & "'", koneksi)
                    cmd.ExecuteNonQuery()
                Next
                BukaDatabase()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UbahToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UbahToolStripMenuItem.Click
        Try
            Dim edit As editAkunPengguna = New editAkunPengguna
            edit.UbahData(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("Username").Value, AddressOf Me.BukaDatabase)
        Catch ex As Exception

        End Try
    End Sub
End Class