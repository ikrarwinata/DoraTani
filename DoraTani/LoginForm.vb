Imports MySql.Data.MySqlClient

Public Class LoginForm

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If String.IsNullOrEmpty(UsernameTextBox.Text) Or String.IsNullOrEmpty(PasswordTextBox.Text) Then
            MessageBox.Show("Username atau password kosong")
            Exit Sub
        End If

        If IsExist("akun_pengguna", "username='" & UsernameTextBox.Text & "' AND password=md5('" & PasswordTextBox.Text & "')") Then
            Dim dt As DataTable = Table("akun_pengguna", "SELECT * FROM akun_pengguna WHERE username='" & UsernameTextBox.Text & "' AND password=md5('" & PasswordTextBox.Text & "') LIMIT 1 OFFSET 0")
            With dt.Rows(0)
                username = .Item("username")
                password = PasswordTextBox.Text
                nama = .Item("nama")
                level = .Item("level")
            End With
            PasswordTextBox.Text = ""
            PasswordTextBox.Focus()
            Main_Menu.Show()
            With Main_Menu
                Select Case level
                    Case "kasir"
                        .btnTransaksi.Enabled = True
                        .btnMaster.Enabled = False
                        .btnSuplier.Enabled = False
                        .btnBarang.Enabled = False
                        .btnReport.Enabled = False
                        .btnUsers.Enabled = False
                    Case "admin"
                        .btnTransaksi.Enabled = True
                        .btnMaster.Enabled = True
                        .btnSuplier.Enabled = True
                        .btnBarang.Enabled = True
                        .btnReport.Enabled = False
                        .btnUsers.Enabled = True
                    Case "owner"
                        .btnTransaksi.Enabled = False
                        .btnMaster.Enabled = True
                        .btnSuplier.Enabled = True
                        .btnBarang.Enabled = True
                        .btnReport.Enabled = True
                        .btnUsers.Enabled = True
                    Case Else
                        .btnTransaksi.Enabled = False
                        .btnMaster.Enabled = False
                        .btnSuplier.Enabled = False
                        .btnBarang.Enabled = False
                        .btnReport.Enabled = False
                        .btnUsers.Enabled = False
                End Select
                .ToolStripStatusLabel1.Text = nama
            End With

            Me.Hide()
        Else
            MessageBox.Show("Username atau password salah")
            PasswordTextBox.Text = ""
            PasswordTextBox.Focus()
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HubungkanDatabase()
    End Sub
End Class
