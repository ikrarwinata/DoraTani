Imports MySql.Data.MySqlClient

Public Class TransaksiPenjualan
    Private OnFinish As Action
    Private counter As Integer = 1

    Public Overloads Sub Show(ByVal act As Action)
        OnFinish = act
        Me.Show()
    End Sub

    Private Sub BuatKode()
        cmd = New MySqlCommand("SELECT kode FROM transaksi ORDER BY kode DESC LIMIT 1 OFFSET 0", koneksi)
        Dim c As String = cmd.ExecuteScalar()
        Dim i As Integer
        If String.IsNullOrEmpty(c) Then
            i = 1
        Else
            i = c.Split("-")(2) + 1
        End If

        field3.Text = "TRN-" & Date.Now.Year & "-" & New String("0", 10 - i.ToString().Length) & i.ToString()
        counter += 1
    End Sub

    Private Sub TransaksiPenjualan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        field1.Text = Now.DayOfWeek.ToString() & ", " & Now.ToLongDateString()
        field8.Text = Now.ToLongTimeString()
        field5.Text = counter
        BuatKode()
        field4.Text = nama
        field6.Text = level
        TextBox1.Focus()
        Timer1.Start()
    End Sub

    Private Sub TransaksiPenjualan_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            OnFinish()
        Catch ex As Exception

        End Try
    End Sub

    Private hargasatuan, subtotal, bayar, kembali As Long

    Private Sub OnBarcodeScan()
        Try
            If Not IsExist("master_barang", "barcode", TextBox1.Text) Then
                BersihkanText(False)
                TextBox1.Focus()
                Button5.Enabled = False
                Exit Sub
            End If
            Dim dt As DataTable = Table("master_barang", "SELECT * FROM master_barang WHERE barcode='" & TextBox1.Text & "' LIMIT 1 OFFSET 0")
            With dt.Rows(0)
                Label3.Text = .Item("kode").ToString()
                Label4.Text = .Item("nama").ToString()
                Label6.Text = .Item("kategori").ToString()
                Label8.Text = .Item("stok").ToString() & " " & .Item("satuan").ToString()
                hargasatuan = .Item("harga").ToString()
                Label10.Text = "Rp." & FormatNumber(hargasatuan, 0)
                Label12.Text = StringToTime(.Item("harga").ToString()).ToLongDateString()
                NumericUpDown1.Value = 1
                NumericUpDown1.Maximum = .Item("stok").ToString()
            End With
            Button5.Enabled = True
            NumericUpDown1.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            OnBarcodeScan()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        Hitung()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Using cari As cariBarangForm = New cariBarangForm
            If cari.ShowDialog() = DialogResult.OK Then
                TextBox1.Text = cari.SelectedBarcode
            End If
        End Using
        TextBox1.Focus()
        OnBarcodeScan()
    End Sub

    Private Sub Hitung()
        Label16.Text = "Rp." & FormatNumber(subtotal, 0)
        Try
            bayar = TextBox2.Text
            kembali = bayar - subtotal
            If kembali >= 0 Then
                Label30.Text = "Rp." & FormatNumber(kembali, 0)
            End If
        Catch ex As Exception
            bayar = 0
            kembali = 0
            Label30.Text = "Rp.0"
        End Try
    End Sub

    Private Sub AddToCart()
        subtotal += hargasatuan * NumericUpDown1.Value
        dgv1.Rows.Add(TextBox1.Text, Label3.Text, Label4.Text, Label10.Text, NumericUpDown1.Value, hargasatuan * NumericUpDown1.Value)
        Hitung()
    End Sub

    Private Function IsEmpty() As Boolean
        If dgv1.Rows.Count = 0 Then
            MessageBox.Show("Barang tidak boleh kosong")
            Return True
        End If

        If String.IsNullOrEmpty(TextBox2.Text) Then
            MessageBox.Show("Masukan nilai pembayaran")
            TextBox2.Focus()
            Return True
        End If

        If kembali < 0 Then
            MessageBox.Show("Uang pembayaran kurang")
            TextBox2.Focus()
            Return True
        End If

        Return False
    End Function

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        AddToCart()
        BersihkanText(False)
        TextBox1.Text = ""
        TextBox1.Focus()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub BersihkanText(ByVal clearbarcode As Boolean)
        If clearbarcode Then
            dgv1.Rows.Clear()
            hargasatuan = 0
            subtotal = 0
            bayar = 0
            kembali = 0
            TextBox1.Text = ""
            TextBox2.Text = ""
            Label16.Text = ""
            Label30.Text = ""
        End If
        Label3.Text = ""
        Label4.Text = ""
        Label6.Text = ""
        Label8.Text = ""
        hargasatuan = 0
        Label10.Text = "Rp.0"
        Label12.Text = ""
        NumericUpDown1.Value = 1
        Button5.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MessageBox.Show("Anda yakin ingin membersihkan data ?", "Konfirmasi", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            BersihkanText(True)
        End If
    End Sub

    Private Sub Simpan()
        Dim kode As String = field3.Text

        cmd = New MySqlCommand("INSERT INTO transaksi (kode, timestamps, total, bayar, kembali, kasir) VALUES ('" & kode & "', " & TimeToString(Now) & ", " & subtotal & ", " & TextBox2.Text & ", " & kembali & ", '" & username & "')", koneksi)
        cmd.ExecuteNonQuery()

        For Each ro As DataGridViewRow In dgv1.Rows
            cmd = New MySqlCommand("INSERT INTO detail_transaksi (kode_transaksi, qty, kode_barang) VALUES ('" & kode & "', " & ro.Cells("dgvcqty").Value & ", '" & ro.Cells("dgvckode").Value & "')", koneksi)
            cmd.ExecuteNonQuery()
            cmd = New MySqlCommand("UPDATE master_barang SET stok=stok-" & ro.Cells("dgvcqty").Value & " WHERE kode = '" & ro.Cells("dgvckode").Value & "'", koneksi)
            cmd.ExecuteNonQuery()
        Next
    End Sub

    Private Sub Cetak()
        Dim strf As StrukTransaksi = New StrukTransaksi(field3.Text)
        strf.PrintAsync()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If IsEmpty() Then
            TextBox1.Focus()
            Exit Sub
        End If

        Simpan()
        Cetak()
        BersihkanText(True)
        BuatKode()
        field5.Text = counter
        TextBox1.Focus()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        field8.Text = Now.ToLongTimeString()
    End Sub

    Private Sub dgv1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv1.KeyUp
        If e.KeyCode = Keys.Delete Then
            For Each row As DataGridViewRow In dgv1.SelectedRows
                subtotal -= row.Cells("dgvcsubtotal").Value
                dgv1.Rows.Remove(row)
            Next
            Hitung()
        End If
    End Sub
End Class