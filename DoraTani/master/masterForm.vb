Imports MySql.Data.MySqlClient

Public Class masterForm
    Private OnFinish As Action

    Public Overloads Sub Show(ByVal act As Action)
        OnFinish = act
        Me.Show()
    End Sub
    Private querydefault As String = "SELECT kode AS 'Kode Barang', barcode AS Barcode, nama AS Produk, kategori AS Kategori, CONCAT(stok, ' ', satuan) AS Stok FROM master_barang"

    Public Sub BukaDatabase()
        dgv1.DataSource = Table("master_barang", querydefault)
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
            Dim searchq As String = " WHERE kode LIKE '%" & k & "%' OR barcode LIKE '%" & k & "%' OR nama LIKE '%" & k & "%' OR kategori LIKE '%" & k & "%' OR stok LIKE '%" & k & "%'"
            dgv1.DataSource = Table("master_barang", querydefault & searchq)
            sender.Text = "Reset"
        Else
            BukaDatabase()
            sender.Text = "Cari"
        End If
    End Sub

    Private Sub HapusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HapusToolStripMenuItem.Click
        Try
            If MessageBox.Show("Anda yakin ingin menghapus " & dgv1.SelectedRows.Count & " data barang ?", "Konfirmasi hapus", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                For Each ro As DataGridViewRow In dgv1.SelectedRows
                    cmd = New MySqlCommand("DELETE FROM master_barang WHERE kode = '" & ro.Cells("Kode Barang").Value & "'", koneksi)
                    cmd.ExecuteNonQuery()
                Next
                BukaDatabase()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UbahToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UbahToolStripMenuItem.Click
        Try
            Using edit As ubahStok = New ubahStok
                If edit.ShowDialog(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("Kode Barang").Value) = DialogResult.OK Then
                    Me.BukaDatabase()
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgv1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv1.CellMouseDoubleClick
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            Try
                Dim det As detailMaster = New detailMaster
                det.Show(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("Kode Barang").Value)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub LihatDetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LihatDetailToolStripMenuItem.Click
        Try
            Dim det As detailMaster = New detailMaster
            det.Show(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("Kode Barang").Value)
        Catch ex As Exception

        End Try
    End Sub
End Class