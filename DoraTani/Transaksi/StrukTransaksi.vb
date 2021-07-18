Imports MySql.Data.MySqlClient

Public Class StrukTransaksi
    Public PageWidth As Long = 190
    'Field Size in Percent
    Public itemSize As Integer = 50
    Public qtySize As Integer = 20
    Public priceSize As Integer = 30
    Public fontFamily = "Consolas"

    Private Const StoreName As String = "Dora Tani"
    Private Const StoreAddress As String = "RT. IV Kel.Siulak Deras – Kecamatan Gunung Kerinci"
    Private Const Telpon As String = "+62812-7495-8900"

    Dim arrWidth() As Integer
    Dim arrFormat() As StringFormat
    Dim c As New PrintingFormat
    Dim ds As New DataSet

    Public Sub New(ByVal kode As String)
        dataadapter = New MySqlDataAdapter("SELECT * FROM struk WHERE kode='" & kode & "'", koneksi)
        dataadapter.Fill(ds, "struk")
    End Sub

    Public Function TestPrint() As Boolean
        Dim res As Boolean = True
        Try
            Printer.NewPrint()
            Printer.SetFont(Me.fontFamily, 11, FontStyle.Bold)
            Printer.Print(StoreName, {PageWidth}, {c.MidCenter})
            Printer.SetFont(Me.fontFamily, 6, FontStyle.Regular)
            Printer.Print(StoreAddress, {PageWidth}, {c.MidCenter})

            Printer.Print(" ")
            Printer.SetFont(Me.fontFamily, 7, FontStyle.Bold)
            Printer.Print(Me.fontFamily, {PageWidth}, {c.MidCenter})
        Catch ex As Exception

        End Try
        Return res
    End Function

    Public Sub PrintAsync()
        Printer.NewPrint()

        Printer.SetFont(Me.fontFamily, 11, FontStyle.Bold)
        Printer.Print(StoreName, {PageWidth}, {c.MidCenter})

        Printer.SetFont(Me.fontFamily, 6, FontStyle.Regular)
        Printer.Print(StoreAddress, {PageWidth}, {c.MidCenter})
        Printer.Print(Telpon, {PageWidth}, {c.MidCenter})

        Printer.Print(" ")
        With ds.Tables("struk")
            Dim d As Date = StringToTime(.Rows(0).Item("timestamps").ToString())
            Printer.Print(d.DayOfWeek.ToString() & ", " & d.ToLongDateString, {PageWidth}, {c.TopLeft})
            Printer.Print(d.ToLongTimeString, {PageWidth}, {c.TopLeft})

            Printer.SetFont(Me.fontFamily, 6, FontStyle.Bold)
            Printer.Print(.Rows(0).Item("kode").ToString(), {PageWidth}, {c.MidCenter})


            Printer.Print(" ")
            Printer.SetFont(Me.fontFamily, 7, FontStyle.Bold) 'Setting Font
            Dim d1, d2, d3 As Integer
            d1 = PageWidth * (itemSize / 100)
            d2 = PageWidth * (qtySize / 100)
            d3 = PageWidth * (priceSize / 100)
            arrWidth = {d1, d2, d3} 'array for column width | array untuk lebar kolom
            arrFormat = {c.MidLeft, c.MidCenter, c.MidRight} 'array alignment 

            'column header split by ; | nama kolom dipisah dengan;
            Printer.Print("Produk;Qty;Harga", arrWidth, arrFormat)
            Printer.SetFont(Me.fontFamily, 6, FontStyle.Regular) 'Setting Font
            Printer.Print("---------------------------------------") 'line

            'looping item sales | loop item penjualan
            For Each ro As DataRow In .Rows
                Printer.Print(ro.Item("nama_barang").ToString() & ";" &
                              ro.Item("qty").ToString() & ";" &
                              "Rp." & FormatNumber(ro.Item("harga").ToString(), 0),
                              arrWidth, arrFormat)
            Next

            Printer.Print("---------------------------------------")
            arrWidth = {Integer.Parse(PageWidth / 2), Integer.Parse(PageWidth / 2)} 'array for column width | array untuk lebar kolom
            arrFormat = {c.MidRight, c.MidRight} 'array alignment 

            Printer.Print("SUBTOTAL;" & "Rp." & FormatNumber(.Rows(0).Item("total").ToString(), 0), arrWidth, arrFormat)
            Printer.Print("UANG TUNAI;" & "Rp." & FormatNumber(.Rows(0).Item("bayar").ToString(), 0), arrWidth, arrFormat)
            Printer.Print("---------------------------------------")
            Printer.Print("KEMBALI;" & "Rp." & FormatNumber(.Rows(0).Item("kembali").ToString(), 0), arrWidth, arrFormat)

            Printer.Print(" ") 'spacing
            Printer.SetFont(Me.fontFamily, 7, FontStyle.Bold) 'Setting Font
            Printer.Print("======== TERIMAKASIH ========", {PageWidth}, {c.MidCenter})
            Printer.Print("== SELAMAT BERBELANJA KEMBALI ==", {PageWidth}, {c.MidCenter})
        End With
        'Release the job for actual printing
        Printer.DoPrint()
    End Sub

End Class
