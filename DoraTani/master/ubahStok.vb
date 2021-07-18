Imports System.Windows.Forms

Public Class ubahStok
    Private k As String

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        cmd = New MySql.Data.MySqlClient.MySqlCommand("UPDATE master_barang SET stok=" & NumericUpDown1.Value & " WHERE kode = '" & k & "'", koneksi)
        cmd.ExecuteNonQuery()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ubahStok_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Overloads Function ShowDialog(ByVal kode As String) As DialogResult
        k = kode
        Dim dt As DataTable = Table("master_barang", "SELECT * FROM master_barang WHERE kode = '" & kode & "' LIMIT 1 OFFSET 0")
        With dt.Rows(0)
            Label1.Text &= .Item("nama")
            NumericUpDown1.Value = .Item("stok")
        End With
        Return Me.ShowDialog()
    End Function
End Class
