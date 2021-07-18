Public Class Main_Menu
    Private quit As Boolean = False

    Public Sub ReShow()
        Me.Show()
    End Sub

    Private Sub Main_Menu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If quit Then Exit Sub
        Using d As ConfirmE = New ConfirmE

            Select Case d.ShowDialog()
                Case DialogResult.Yes
                    quit = True
                    Application.Exit()
                Case DialogResult.OK
                    quit = True
                    LoginForm.Show()
                    Me.Close()
                Case DialogResult.Cancel
                    e.Cancel = True
                Case Else
                    e.Cancel = True
            End Select
        End Using
    End Sub

    Private Sub Main_Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        quit = False
    End Sub

    Private Sub btnUsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUsers.Click
        Dim ak As akunForm = New akunForm
        ak.Show(AddressOf Me.ReShow)
        Me.Hide()
    End Sub

    Private Sub btnSuplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuplier.Click
        Dim sup As suplierForm = New suplierForm
        sup.Show(AddressOf Me.ReShow)
        Me.Hide()
    End Sub

    Private Sub btnMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaster.Click
        Dim m As masterForm = New masterForm
        m.Show(AddressOf Me.ReShow)
        Me.Hide()
    End Sub

    Private Sub btnBarang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBarang.Click
        Dim m As barangMasukForm = New barangMasukForm
        m.Show(AddressOf Me.ReShow)
        Me.Hide()
    End Sub

    Private Sub btnTransaksi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransaksi.Click
        Dim t As TransaksiPenjualan = New TransaksiPenjualan
        t.Show(AddressOf Me.ReShow)
        Me.Hide()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim report As reportForm = New reportForm
        report.Show(AddressOf Me.ReShow)
        Me.Hide()
    End Sub
End Class
