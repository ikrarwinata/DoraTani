Imports MySql.Data.MySqlClient

Module ModDB
    Public koneksi As New MySqlConnection
    Public datareader As MySqlDataReader
    Public dataadapter As MySqlDataAdapter
    Public cmd As New MySqlCommand
    Public username, nama, password, level As String

    Public Sub HubungkanDatabase()
        If koneksi.State = ConnectionState.Open Then Exit Sub
        Try
            koneksi.ConnectionString = "server=127.0.0.1;" _
                           & "user id=root;" _
                           & "password=;" _
                           & "Database=doratani"
            koneksi.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function StringToTime(ByVal timestamps As String) As Date
        Dim dt As DateTime = New DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)
        dt = dt.AddMilliseconds(timestamps).ToLocalTime()
        Return dt
    End Function

    Public Function TimeToString(ByVal d As Date) As String
        Return CLng(d.Subtract(New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds)
    End Function

    Public Function IsExist(ByVal namatabel As String, ByVal namafield As String, ByVal value As String)
        cmd = New MySqlCommand("SELECT " & namafield & " FROM " & namatabel & " WHERE " & namafield & " = '" & value & "' LIMIT 1 OFFSET 0", koneksi)
        datareader = cmd.ExecuteReader()
        datareader.Read()
        Dim res As Boolean = datareader.HasRows
        datareader.Close()
        Return res
    End Function

    Public Function IsExist(ByVal namatabel As String, ByVal kondisi As String)
        cmd = New MySqlCommand("SELECT * FROM " & namatabel & " WHERE " & kondisi & " LIMIT 1 OFFSET 0", koneksi)
        datareader = cmd.ExecuteReader()
        datareader.Read()
        Dim res As Boolean = datareader.HasRows
        datareader.Close()
        Return res
    End Function

    Public Function GetData(ByVal namatabel As String, ByVal namafield As String, ByVal field As String, ByVal kondisifield As String) As Object
        cmd = New MySqlCommand("SELECT " & namafield & " FROM " & namatabel & " WHERE " & field & " = '" & kondisifield & "' LIMIT 1 OFFSET 0", koneksi)
        datareader = cmd.ExecuteReader()
        datareader.Read()

        Dim res As Object = Nothing
        If datareader.HasRows Then
            res = datareader.Item(namafield)
        End If
        datareader.Close()
        Return res
    End Function

    Public Function Table(ByVal namatabel As String, ByVal namafield As String, ByVal field As String, ByVal kondisifield As String) As DataTable
        cmd = New MySqlCommand("SELECT " & namafield & " FROM " & namatabel & " WHERE " & field & " = '" & kondisifield & "' LIMIT 1 OFFSET 0", koneksi)
        Dim res As DataSet = New DataSet
        dataadapter = New MySqlDataAdapter(cmd)
        dataadapter.Fill(res, namatabel)
        Return res.Tables(namatabel)
    End Function

    Public Function Table(ByVal namatabel As String, ByVal query As String) As DataTable
        cmd = New MySqlCommand(query, koneksi)
        Dim res As DataSet = New DataSet
        dataadapter = New MySqlDataAdapter(cmd)
        dataadapter.Fill(res, namatabel)
        Return res.Tables(namatabel)
    End Function

    Public Function Table(ByVal namatabel As String) As DataTable
        cmd = New MySqlCommand("SELECT * FROM " & namatabel, koneksi)
        Dim res As DataSet = New DataSet
        dataadapter = New MySqlDataAdapter(cmd)
        dataadapter.Fill(res, namatabel)
        Return res.Tables(0)
    End Function

    Public Function UCFirst(ByVal st As String) As String
        If String.IsNullOrEmpty(st) Then Return ""
        Return (st.Substring(0, 1).ToUpper() & st.Substring(1))
    End Function

    Public Function SentenceCase(ByVal st As String) As String
        If String.IsNullOrEmpty(st) Then Return ""
        Dim res As String
        If st.Contains(" ") Then
            Dim s As String() = st.Split(" ")
            For Each item As String In s
                item = UCFirst(item)
            Next
            res = String.Join(" ", s)
        Else
            res = UCFirst(st)
        End If

        Return res
    End Function
End Module
