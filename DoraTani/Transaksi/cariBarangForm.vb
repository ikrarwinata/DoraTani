Imports System.Windows.Forms

Public Class cariBarangForm
    Private slpk, slpn, sb As String

    Public ReadOnly Property SelectedProductCode As String
        Get
            Return slpk
        End Get
    End Property

    Public ReadOnly Property SelectedBarcode As String
        Get
            Return sb
        End Get
    End Property

    Public ReadOnly Property SelectedProductName As String
        Get
            Return slpn
        End Get
    End Property

    Private Sub BukaDatabase()
        dgv1.DataSource = Table("master_barang", "SELECT kode AS 'Kode Barang', barcode AS 'Barcode',nama AS 'Nama Barang', kategori AS Kategori, CONCAT(stok, ' ', satuan) AS Stok FROM master_barang WHERE stok > 0")
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        slpk = dgv1.SelectedRows(0).Cells("Kode Barang").Value
        slpn = dgv1.SelectedRows(0).Cells("Nama Barang").Value
        sb = dgv1.SelectedRows(0).Cells("Barcode").Value
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If sender.Text = "Cari" Then
            Dim k As String = ToolStripTextBox1.Text
            Dim searchq As String = " AND (kode LIKE '%" & k & "%' OR nama LIKE '%" & k & "%' OR kota LIKE '%" & k & "%' OR telp LIKE '%" & k & "%' OR alamat LIKE '%" & k & "%' OR keterangan LIKE '%" & k & "%')"
            dgv1.DataSource = Table("master_barang", "SELECT kode AS 'Kode Barang', barcode AS 'Barcode',nama AS 'Nama Barang', kategori AS Kategori, CONCAT(stok, ' ', satuan) AS Stok FROM master_barang WHERE (stok > 0)" & searchq)
            sender.Text = "Reset"
        Else
            BukaDatabase()
            sender.Text = "Cari"
        End If
    End Sub

    Private Sub cariSuplierForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BukaDatabase()
    End Sub

    Private Sub dgv1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv1.CellMouseDoubleClick
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            slpk = dgv1.SelectedRows(0).Cells("Kode Barang").Value
            slpn = dgv1.SelectedRows(0).Cells("Nama Barang").Value
            sb = dgv1.SelectedRows(0).Cells("Barcode").Value
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub
End Class
