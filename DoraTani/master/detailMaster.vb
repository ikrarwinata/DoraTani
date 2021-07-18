Public Class detailMaster

    Public Overloads Sub Show(ByVal kode As String)
        Dim dt As DataTable = Table("master_barang", "SELECT * FROM master_barang WHERE kode = '" & kode & "' LIMIT 1 OFFSET 0")
        With dt.Rows(0)
            Label3.Text = .Item("kode").ToString()
            Label10.Text = .Item("barcode").ToString()
            Label2.Text = .Item("nama").ToString()
            Label4.Text = .Item("kategori").ToString()
            Label12.Text = .Item("stok").ToString() & .Item("satuan").ToString()
            Label6.Text = .Item("harga").ToString()
            Try
                Label9.Text = StringToTime(.Item("kadaluarsa").ToString()).ToLongDateString()
            Catch ex As Exception
                Label9.Text = "-"
            End Try
        End With
        Me.Show()
    End Sub

    Private Sub detailSuplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class