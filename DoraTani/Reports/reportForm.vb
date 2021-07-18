Public Class reportForm
    Private OnFinish As Action

    Public Overloads Sub Show(ByVal act As Action)
        OnFinish = act
        Me.Show()
    End Sub

    Private Sub reportForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            OnFinish()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub reportForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = New Date(Date.Now.Year - 1, Date.Now.Month, Date.Now.Day)
        DateTimePicker2.Value = New Date(Date.Now.Year, Date.Now.Month, Date.Now.Day)

        Try
            Dim bt As reportBarangMasuk = New reportBarangMasuk
            bt.Refresh()
            CrystalReportViewer2.ReportSource = bt
            CrystalReportViewer2.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            Dim tb As DataTable = Table("master_barang")
            For Each ro As DataRow In tb.Rows
                ro.Item("kadaluarsa") = StringToTime(ro.Item("kadaluarsa")).ToLongDateString()
            Next
            Dim sb As reportStokBarang = New reportStokBarang
            sb.SetDataSource(tb)
            sb.Refresh()
            CrystalReportViewer3.ReportSource = sb
            CrystalReportViewer3.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim st, et As String
        st = TimeToString(DateTimePicker1.Value)
        et = TimeToString(New Date(DateTimePicker2.Value.Year, DateTimePicker2.Value.Month, DateTimePicker2.Value.Day, 17, 0, 0))

        Dim dt As DataTable = Table("transaksi_report", "SELECT * FROM transaksi_report WHERE timestamps >='" & st & "' AND timestamps <='" & et & "'")
        For Each ro As DataRow In dt.Rows
            ro.Item("timestamps") = StringToTime(ro.Item("timestamps")).ToLongDateString()
        Next

        Dim rt As reportTransaksi = New reportTransaksi
        rt.SetDataSource(dt)
        rt.Refresh()
        CrystalReportViewer1.ReportSource = rt
        CrystalReportViewer1.Refresh()
    End Sub
End Class