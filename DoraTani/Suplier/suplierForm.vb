Imports MySql.Data.MySqlClient

Public Class suplierForm
    Private OnFinish As Action

    Public Overloads Sub Show(ByVal act As Action)
        OnFinish = act
        Me.Show()
    End Sub

    Public Sub BukaDatabase()
        dgv1.DataSource = Table("suplier", "SELECT kode AS 'Kode Suplier', nama AS 'Nama Suplier', telp AS Telpon FROM suplier")
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
            Dim searchq As String = " WHERE kode LIKE '%" & k & "%' OR nama LIKE '%" & k & "%' OR kota LIKE '%" & k & "%' OR telp LIKE '%" & k & "%' OR alamat LIKE '%" & k & "%' OR keterangan LIKE '%" & k & "%'"
            dgv1.DataSource = Table("suplier", "SELECT kode AS 'Kode Suplier', nama AS 'Nama Suplier', telp AS Telpon FROM suplier" & searchq)
            sender.Text = "Reset"
        Else
            BukaDatabase()
            sender.Text = "Cari"
        End If
    End Sub

    Private Sub TambahToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TambahToolStripMenuItem.Click
        Dim editak As editSuplier = New editSuplier
        editak.TambahBaru(AddressOf Me.BukaDatabase)
    End Sub

    Private Sub HapusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HapusToolStripMenuItem.Click
        Try
            If MessageBox.Show("Anda yakin ingin menghapus " & dgv1.SelectedRows.Count & " data suplier ?", "Konfirmasi hapus", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                For Each ro As DataGridViewRow In dgv1.SelectedRows
                    cmd = New MySqlCommand("DELETE FROM suplier WHERE kode = '" & ro.Cells("Kode Suplier").Value & "'", koneksi)
                    cmd.ExecuteNonQuery()
                Next
                BukaDatabase()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UbahToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UbahToolStripMenuItem.Click
        Try
            Dim edit As editSuplier = New editSuplier
            edit.UbahData(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("Kode Suplier").Value, AddressOf Me.BukaDatabase)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LihatDetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LihatDetailToolStripMenuItem.Click
        Try
            Dim det As detailSuplier = New detailSuplier
            det.Show(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("Kode Suplier").Value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgv1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv1.CellMouseDoubleClick
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            Try
                Dim det As detailSuplier = New detailSuplier
                det.Show(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("Kode Suplier").Value)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
End Class