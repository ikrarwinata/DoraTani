Imports MySql.Data.MySqlClient

Public Class editSuplier
    Private id As String
    Private mode As String = "Baru"
    Private refAction As Action

    Private Sub BuatKode()
        cmd = New MySqlCommand("SELECT kode FROM suplier ORDER BY kode DESC LIMIT 1 OFFSET 0", koneksi)
        Dim c As String = cmd.ExecuteScalar()
        Dim i As Integer
        If String.IsNullOrEmpty(c) Then
            i = 1
        Else
            i = c.Split("-")(2) + 1
        End If

        TextBox2.Text = "SPL-" & Date.Now.Year & "-" & New String("0", 10 - i.ToString().Length) & i.ToString()
    End Sub

    Public Sub TambahBaru(Optional ByVal ref As Action = Nothing)
        refAction = ref
        mode = "Baru"
        BuatKode()
        Me.Text = "Tambah Data Suplier"
        Me.Show()
    End Sub

    Public Sub UbahData(ByVal usr As String, Optional ByVal ref As Action = Nothing)
        id = usr
        refAction = ref
        TextBox4.Enabled = True
        Label4.Enabled = True
        mode = "Ubah"
        Me.Text = "Ubah Data Suplier"
        Dim ds As DataTable = Table("suplier", "SELECT * FROM suplier WHERE kode = '" & id & "' LIMIT 1 OFFSET 0")
        With ds.Rows(0)
            TextBox2.Text = .Item("kode").ToString()
            TextBox3.Text = .Item("nama").ToString()
            TextBox4.Text = .Item("kota").ToString()
            TextBox5.Text = .Item("telp").ToString()
            TextBox6.Text = .Item("alamat").ToString()
            TextBox1.Text = .Item("keterangan").ToString()
        End With

        Me.Show()
    End Sub

    Private Sub editAkunPengguna_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Function MasihKosong() As Boolean
        For Each o As Object In TableLayoutPanel1.Controls
            If TypeOf (o) Is TextBox Then
                If String.IsNullOrEmpty(CType(o, TextBox).Text) Then
                    CType(o, TextBox).Focus()
                    Return True
                    Exit For
                End If
            End If
        Next
        Return False
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MasihKosong() Then
            MessageBox.Show("Data tidak boleh kosong")
            Exit Sub
        End If

        If mode = "Baru" Then
            If IsExist("suplier", "kode", TextBox2.Text) Then
                MessageBox.Show("Kode suplier ini sudah digunakan")
                TextBox2.Focus()
                Exit Sub
            End If

            cmd = New MySqlCommand("INSERT INTO suplier (kode, nama, kota, telp, alamat, keterangan) VALUES ('" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox5.Text & "', '" & TextBox6.Text & "', '" & TextBox1.Text & "')", koneksi)
            cmd.ExecuteNonQuery()
        Else
            If Not TextBox2.Text = id Then
                If IsExist("suplier", "kode", TextBox2.Text) Then
                    MessageBox.Show("Kode suplier ini sudah digunakan")
                    TextBox2.Focus()
                    Exit Sub
                End If
            End If

            cmd = New MySqlCommand("UPDATE suplier SET kode='" & TextBox2.Text & "', nama='" & TextBox3.Text & "', kota='" & TextBox4.Text & "', telp='" & TextBox5.Text & "', alamat='" & TextBox6.Text & "', keterangan='" & TextBox1.Text & "' WHERE kode='" & id & "'", koneksi)
            cmd.ExecuteNonQuery()
        End If
        Try
            If Not refAction = Nothing Then
                refAction()
            End If
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub
End Class