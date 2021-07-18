Public Class detailSuplier

    Public Overloads Sub Show(ByVal kode As String)
        Dim dt As DataTable = Table("suplier", "SELECT * FROM suplier WHERE kode = '" & kode & "' LIMIT 1 OFFSET 0")
        With dt.Rows(0)
            Label3.Text = .Item("nama").ToString()
            Label2.Text = .Item("kode").ToString()
            Label4.Text = .Item("kota").ToString()
            LinkLabel1.Text = .Item("telp").ToString()
            Label6.Text = .Item("alamat").ToString()
            Label9.Text = .Item("keterangan").ToString()
        End With
        Me.Show()
    End Sub

    Private Sub detailSuplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class