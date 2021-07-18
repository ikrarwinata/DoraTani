Imports MySql.Data.MySqlClient

Public Class barangMasukForm
    Private OnFinish As Action
    Private stateReady As Boolean = False

    Public Overloads Sub Show(ByVal act As Action)
        OnFinish = act
        Me.Show()
    End Sub
    Private querydefault As String = "SELECT a.id AS ID, a.kode_barang AS 'Kode Barang', b.barcode AS Barcode, b.nama AS Produk, b.kategori AS Kategori, CONCAT(a.qty, ' ', b.satuan) AS Qty FROM barang_masuk a INNER JOIN master_barang b ON a.kode_barang = b.kode"

    Public Sub BukaDatabase()
        dgv1.DataSource = Table("barang_masuk", querydefault)
        dgv1.Columns("ID").Width = 45
    End Sub

    Private Sub BukaKategori()
        Dim dt As DataTable = Table("master_barang", "SELECT DISTINCT(kategori) AS kategori FROM master_barang ORDER BY kategori ASC")
        ComboBox1.Items.Clear()
        For Each ro As DataRow In dt.Rows
            ComboBox1.Items.Add(ro.Item("kategori").ToString())
        Next
    End Sub

    Private Sub BukaSatuan()
        Dim dt As DataTable = Table("master_barang", "SELECT DISTINCT(satuan) AS satuan FROM master_barang ORDER BY satuan ASC")
        ComboBox2.Items.Clear()
        For Each ro As DataRow In dt.Rows
            ComboBox2.Items.Add(ro.Item("satuan").ToString())
        Next
    End Sub

    Private Sub akunForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            OnFinish()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BuatKode()
        cmd = New MySqlCommand("SELECT kode FROM master_barang ORDER BY kode DESC LIMIT 1 OFFSET 0", koneksi)
        Dim c As String = cmd.ExecuteScalar()
        Dim i As Integer
        If String.IsNullOrEmpty(c) Then
            i = 1
        Else
            i = c.Split("-")(2) + 1
        End If

        TextBox2.Text = "PRDK-" & Date.Now.Year & "-" & New String("0", 10 - i.ToString().Length) & i.ToString()
    End Sub

    Private Sub akunForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaDatabase()
        BukaKategori()
        BukaSatuan()
        DateTimePicker1.Value = New Date(Date.Now.Year + 1, Date.Now.Month, Date.Now.Day)
        TextBox1.Focus()
        stateReady = True
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If sender.Text = "Cari" Then
            Dim k As String = ToolStripTextBox1.Text
            Dim searchq As String = " WHERE b.kode LIKE '%" & k & "%' OR b.barcode LIKE '%" & k & "%' OR b.nama LIKE '%" & k & "%' OR b.kategori LIKE '%" & k & "%'"
            dgv1.DataSource = Table("barang_masuk", querydefault & searchq)
            sender.Text = "Reset"
        Else
            BukaDatabase()
            sender.Text = "Cari"
        End If
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

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If MessageBox.Show("Anda yakin ingin menghapus " & dgv1.SelectedRows.Count & " data barang masuk ?", "Konfirmasi hapus", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                For Each ro As DataGridViewRow In dgv1.SelectedRows
                    cmd = New MySqlCommand("DELETE FROM barang_masuk WHERE kode = '" & ro.Cells("Kode Barang").Value & "'", koneksi)
                    cmd.ExecuteNonQuery()
                Next
                BukaDatabase()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BersihkanText()
        stateReady = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.SelectedItem = ""
        ComboBox1.Text = ""
        ComboBox2.SelectedItem = ""
        ComboBox2.Text = ""
        NumericUpDown1.Value = 1000
        NumericUpDown2.Value = 1
        Label9.Text = ""
        Label10.Text = ""
        GroupBox3.Enabled = False
        stateReady = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        BersihkanText()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            GroupBox3.Enabled = True
            Try
                If Not IsExist("master_barang", "barcode = '" & TextBox1.Text & "'") Then
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    ComboBox1.SelectedItem = ""
                    ComboBox2.SelectedItem = ""
                    NumericUpDown1.Value = 1000
                    NumericUpDown2.Value = 1
                    Label9.Text = ""
                    Label10.Text = ""
                    BuatKode()
                    TextBox3.Focus()
                    Exit Sub
                End If
                Dim dt As DataTable = Table("masater_barang", "SELECT a.kode AS kode_barang, a.barcode, a.nama AS produk, a.kategori, a.satuan, a.harga, a.kadaluarsa, a.stok, c.* FROM master_barang a LEFT OUTER JOIN barang_masuk b ON a.kode = b.kode_barang LEFT OUTER JOIN suplier c ON b.kode_suplier = c.kode WHERE a.barcode = '" & TextBox1.Text & "' LIMIT 1 OFFSET 0")

                With dt.Rows(0)
                    TextBox2.Text = .Item("kode_barang").ToString()
                    TextBox3.Text = .Item("produk").ToString()
                    ComboBox1.SelectedItem = .Item("kategori").ToString()
                    ComboBox2.SelectedItem = .Item("satuan").ToString()
                    NumericUpDown1.Value = .Item("harga").ToString()
                    NumericUpDown1.Value = 1
                    DateTimePicker1.Value = StringToTime(.Item("kadaluarsa").ToString())
                    Label9.Text = .Item("kode").ToString()
                    Label10.Text = .Item("nama").ToString()
                End With

                GroupBox3.Enabled = False
                NumericUpDown2.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Function IsEmpty() As Boolean
        If String.IsNullOrEmpty(TextBox1.Text) Then
            Return True
        End If
        For Each o As Object In GroupBox3.Controls
            If TypeOf (o) Is TextBox Then
                If String.IsNullOrEmpty(CType(o, TextBox).Text) Then Return True
            ElseIf TypeOf (o) Is ComboBox Then
                If String.IsNullOrEmpty(CType(o, ComboBox).Text) Then Return True
            End If
        Next
        If String.IsNullOrEmpty(Label9.Text) Or String.IsNullOrEmpty(Label10.Text) Then Return True

        Return False
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If IsEmpty() Then
            MessageBox.Show("Data tidak boleh kosong")
            Exit Sub
        End If
        Dim n, d As Long
        n = TimeToString(Date.Now)
        d = TimeToString(DateTimePicker1.Value)
        If n >= d Then
            MessageBox.Show("Tanggal kadaluarsa tidak valid")
            Exit Sub
        End If
        Dim q, kategori, satuan As String
        kategori = ComboBox1.SelectedItem
        satuan = ComboBox2.SelectedItem
        If String.IsNullOrEmpty(kategori) Then kategori = ComboBox1.Text
        If String.IsNullOrEmpty(satuan) Then satuan = ComboBox2.Text
        If IsExist("master_barang", "kode = '" & TextBox2.Text & "' AND barcode = '" & TextBox1.Text & "'") Then
            Dim kadaluarsa As Long
            Dim dt As DataTable = Table("master_barang", "SELECT kadaluarsa FROM master_barang WHERE kode = '" & TextBox2.Text & "' AND barcode = '" & TextBox1.Text & "' LIMIT 1 OFFSET 0")
            kadaluarsa = Math.Min(Long.Parse(dt.Rows(0).Item("kadaluarsa").ToString()), Long.Parse(TimeToString(DateTimePicker1.Value)))

            q = "UPDATE master_barang SET kadaluarsa = '" & kadaluarsa & "', stok = stok+" & NumericUpDown2.Value & " WHERE kode = '" & TextBox2.Text & "' AND barcode = '" & TextBox1.Text & "'"
            cmd = New MySqlCommand(q, koneksi)
            cmd.ExecuteNonQuery()
        ElseIf IsExist("master_barang", "kode = '" & TextBox2.Text & "' OR barcode = '" & TextBox1.Text & "'") Then
            MessageBox.Show("Kode Barang atau Kode Barcode telah digunakan barang lain")
            TextBox1.Focus()
            Exit Sub
        Else
            q = "INSERT INTO master_barang (kode, barcode, nama, kategori, satuan, harga, kadaluarsa, stok) VALUES ('" & TextBox2.Text & "', '" & TextBox1.Text & "', '" & TextBox3.Text & "', '" & SentenceCase(kategori) & "', '" & SentenceCase(satuan) & "', '" & NumericUpDown1.Value & "', '" & TimeToString(DateTimePicker1.Value) & "', '" & NumericUpDown2.Value & "')"
            cmd = New MySqlCommand(q, koneksi)
            cmd.ExecuteNonQuery()
        End If

        q = "INSERT INTO barang_masuk (kode_barang, tanggal, bulan, tahun, qty, kode_suplier, users) VALUES ('" & TextBox2.Text & "', " & Date.Now.Day & ", " & Date.Now.Month & ", " & Date.Now.Year & ", " & NumericUpDown2.Value & ", '" & Label9.Text & "', '" & username & "')"
        cmd = New MySqlCommand(q, koneksi)
        cmd.ExecuteNonQuery()

        BersihkanText()
        BukaDatabase()
        TextBox1.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Using cr As cariSuplierForm = New cariSuplierForm
            If cr.ShowDialog() = DialogResult.OK Then
                Label9.Text = cr.SelectedSuplierCode
                Label10.Text = cr.SelectedSuplierName
            End If
        End Using
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim ed As editSuplier = New editSuplier
        ed.TambahBaru()
    End Sub
End Class