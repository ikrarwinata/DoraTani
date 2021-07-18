Imports MySql.Data.MySqlClient

Public Class editAkunPengguna
    Private id As String
    Private mode As String = "Baru"
    Private refAction As Action

    Public Sub TambahBaru(Optional ByVal ref As Action = Nothing)
        refAction = ref
        TextBox4.Enabled = False
        Label4.Enabled = False
        mode = "Baru"
        Me.Text = "Tambah Akun Pengguna"
        Me.Show()
    End Sub

    Public Sub UbahData(ByVal usr As String, Optional ByVal ref As Action = Nothing)
        id = usr
        refAction = ref
        TextBox4.Enabled = True
        Label4.Enabled = True
        mode = "Ubah"
        Me.Text = "Ubah Akun Pengguna"
        Dim ds As DataTable = Table("akun_pengguna", "SELECT * FROM akun_pengguna WHERE username = '" & id & "' LIMIT 1 OFFSET 0")
        With ds.Rows(0)
            TextBox2.Text = .Item("nama").ToString()
            TextBox3.Text = .Item("username").ToString()
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            ComboBox1.SelectedItem = .Item("level").ToString()
        End With

        Me.Show()
    End Sub

    Private Sub editAkunPengguna_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("admin")

        If level = "owner" Then
            ComboBox1.Items.Add("owner")
        End If
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Function MasihKosong() As Boolean
        For Each o As Object In TableLayoutPanel1.Controls
            If TypeOf (o) Is TextBox Then
                If CType(o, TextBox).Name = "TextBox4" And mode = "Baru" Then
                    Continue For
                End If
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
        If Not TextBox5.Text = TextBox6.Text Then
            MessageBox.Show("Konfirmasi password tidak cocok")
            TextBox6.Focus()
            Exit Sub
        End If

        If mode = "Baru" Then
            If IsExist("akun_pengguna", "username", TextBox3.Text) Then
                MessageBox.Show("Username ini sudah digunakan")
                TextBox2.Focus()
                Exit Sub
            End If

            cmd = New MySqlCommand("INSERT INTO akun_pengguna (username, password, nama, level) VALUES ('" & TextBox3.Text & "', md5('" & TextBox6.Text & "'), '" & TextBox2.Text & "', '" & ComboBox1.SelectedItem & "')", koneksi)
            cmd.ExecuteNonQuery()
        Else
            If Not TextBox3.Text = id Then
                If IsExist("akun_pengguna", "username", TextBox3.Text) Then
                    MessageBox.Show("Username ini sudah digunakan")
                    TextBox2.Focus()
                    Exit Sub
                End If
            End If

            Dim q As String = "username = '" & id & "' AND password = md5('" & TextBox4.Text & "')"
            If Not IsExist("akun_pengguna", q) Then
                MessageBox.Show("Password saat ini salah")
                TextBox4.Text = ""
                TextBox4.Focus()
                Exit Sub
            End If

            cmd = New MySqlCommand("UPDATE akun_pengguna SET username='" & TextBox3.Text & "', password=md5('" & TextBox4.Text & "'), nama='" & TextBox2.Text & "', level='" & ComboBox1.SelectedItem & "' WHERE username='" & id & "'", koneksi)
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