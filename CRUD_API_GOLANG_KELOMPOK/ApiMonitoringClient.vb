Imports CRUD_API_GOLANG_KELOMPOK.Model_Monitoringdata
Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Text

Public Class ApiMonitoringClient
    Private ReadOnly client As HttpClient
    Private ReadOnly ulasanUrl As String = "https://jx4zldbn-8082.asse.devtunnels.ms/api/ulasan"
    Private ReadOnly transaksiUrl As String = "https://jx4zldbn-8082.asse.devtunnels.ms/api/pembayaran"
    Private ReadOnly alamatPengirimanUrl As String = "https://jx4zldbn-8082.asse.devtunnels.ms/api/alamat_pengiriman"

    Public Sub New()
        client = New HttpClient()
    End Sub

    ' --- Get Alamat Pengiriman by Pelanggan ---
    Public Async Function GetAlamatPengirimanAsync() As Task(Of List(Of AlamatPengiriman))
        Dim response = Await client.GetAsync(alamatPengirimanUrl)
        response.EnsureSuccessStatusCode()
        Dim json = Await response.Content.ReadAsStringAsync()
        Return JsonConvert.DeserializeObject(Of List(Of AlamatPengiriman))(json)
    End Function
    Public Async Function DeleteAlamatPengirimanAsync(id As ULong) As Task
        Dim response = Await client.DeleteAsync($"{alamatPengirimanUrl}/{id}")
        response.EnsureSuccessStatusCode()
    End Function

    ' --- Ulasan API ---
    Public Async Function GetUlasanAsync() As Task(Of List(Of Ulasan))
        Dim response = Await client.GetAsync(ulasanUrl)
        response.EnsureSuccessStatusCode()
        Dim json = Await response.Content.ReadAsStringAsync()
        Return JsonConvert.DeserializeObject(Of List(Of Ulasan))(json)
    End Function
    Public Async Function DeleteUlasanAsync(id As ULong) As Task
        Dim response = Await client.DeleteAsync($"{ulasanUrl}/{id}")
        response.EnsureSuccessStatusCode()
    End Function

    ' --- Transaksi API ---
    Public Async Function GetTransaksiAsync() As Task(Of List(Of Transaksi))
        Dim response = Await client.GetAsync(transaksiUrl)
        response.EnsureSuccessStatusCode()
        Dim json = Await response.Content.ReadAsStringAsync()
        Return JsonConvert.DeserializeObject(Of List(Of Transaksi))(json)
    End Function

    Public Async Function UpdateTransaksiAsync(transaksi As Transaksi) As Task(Of HttpResponseMessage)
        ' Serialisasi objek transaksi ke format JSON
        Dim jsonBody As String = JsonConvert.SerializeObject(transaksi)

        ' Siapkan konten HTTP
        Dim content As New StringContent(jsonBody, Encoding.UTF8, "application/json")

        ' Kirim PUT request ke endpoint /api/transaksi/{id}
        Dim response = Await client.PutAsync($"{transaksiUrl}/{transaksi.id_transaksi}", content)

        ' Kembalikan response untuk ditangani pemanggil
        Return response
    End Function


    Public Async Function DeleteTransaksiAsync(id As ULong) As Task
        Dim response = Await client.DeleteAsync($"{transaksiUrl}/{id}")
        response.EnsureSuccessStatusCode()
    End Function

    ' --- Riwayat Harga API Berdasarkan PizzaID ---
    Public Async Function GetRiwayatHargaByPizzaIdAsync(idPizza As ULong) As Task(Of List(Of RiwayatHargaPizza))
        Dim url = $"https://jx4zldbn-8082.asse.devtunnels.ms/api/pizza/{idPizza}/riwayat-harga"
        Dim response = Await client.GetAsync(url)
        response.EnsureSuccessStatusCode()
        Dim json = Await response.Content.ReadAsStringAsync()
        Return JsonConvert.DeserializeObject(Of List(Of RiwayatHargaPizza))(json)
    End Function

    Public Async Function DeleteRiwayatHargaAsync(id As ULong) As Task
        Dim response = Await client.DeleteAsync($"https://jx4zldbn-8082.asse.devtunnels.ms/api/pizza/riwayat-harga/{id}")
        response.EnsureSuccessStatusCode()
    End Function

    ' --- Detail Pesanan API ---
    Public Async Function GetDetailPesananAsync(id_pesanan As ULong) As Task(Of List(Of DetailPesanan))
        Dim url = $"https://jx4zldbn-8082.asse.devtunnels.ms/api/pesanan/{id_pesanan}/item"
        Dim response = Await client.GetAsync(url)
        response.EnsureSuccessStatusCode()
        Dim json = Await response.Content.ReadAsStringAsync()
        Return JsonConvert.DeserializeObject(Of List(Of DetailPesanan))(json)
    End Function

    'Public Async Function DeleteDetailPesananAsync(id As ULong) As Task
    'Dim response = Await client.DeleteAsync($"{detailPesananUrl}/{id}")
    'response.EnsureSuccessStatusCode()
    'End Function

    ' --- Riwayat Pesanan API ---
    Public ReadOnly baseUrl As String = "https://jx4zldbn-8082.asse.devtunnels.ms"

    Public Async Function GetFilteredRiwayatPesananAsync(filterUrl As String) As Task(Of List(Of RiwayatPesanan))
        Dim fullUrl As String = If(filterUrl.StartsWith("http"), filterUrl, $"{baseUrl}/{filterUrl.TrimStart("/"c)}")
        Dim response = Await client.GetAsync(fullUrl)

        response.EnsureSuccessStatusCode()

        Dim jsonString = Await response.Content.ReadAsStringAsync()
        Return JsonConvert.DeserializeObject(Of List(Of RiwayatPesanan))(jsonString)
    End Function


    Public Async Function GetRiwayatPesananByIdAsync(id As Integer) As Task(Of List(Of DetailPesanan))
        Dim response = Await client.GetAsync($"/api/admin/detail-pesanan/{id}")
        response.EnsureSuccessStatusCode()

        Dim jsonString = Await response.Content.ReadAsStringAsync()

        ' Gunakan Newtonsoft.Json
        Return JsonConvert.DeserializeObject(Of List(Of DetailPesanan))(jsonString)
    End Function


    Public Async Function GetRiwayatPesananAsync() As Task(Of List(Of Model_Monitoringdata.RiwayatPesanan))
            Try
                Using client As New HttpClient()
                    client.Timeout = TimeSpan.FromSeconds(30)

                    ' Panggil endpoint riwayat pesanan admin
                    Dim response As HttpResponseMessage = Await client.GetAsync($"{baseUrl}/api/admin/riwayat-pesanan")

                    If response.IsSuccessStatusCode Then
                        Dim jsonData As String = Await response.Content.ReadAsStringAsync()
                        Return JsonConvert.DeserializeObject(Of List(Of Model_Monitoringdata.RiwayatPesanan))(jsonData)
                    Else
                        Throw New Exception($"API Error: {response.StatusCode} - {response.ReasonPhrase}")
                    End If
                End Using

            Catch ex As Exception
            Throw New Exception("Error getting riwayat pesanan: " & ex.Message)
        End Try
    End Function

        Public Async Function GetRiwayatPesananByStatusAsync(status As String) As Task(Of List(Of Model_Monitoringdata.RiwayatPesanan))
            Try
                Using client As New HttpClient()
                    client.Timeout = TimeSpan.FromSeconds(30)

                    ' Panggil endpoint dengan filter status
                    Dim response As HttpResponseMessage = Await client.GetAsync($"{baseUrl}/api/admin/riwayat-pesanan/status/{status}")

                    If response.IsSuccessStatusCode Then
                        Dim jsonData As String = Await response.Content.ReadAsStringAsync()
                        Return JsonConvert.DeserializeObject(Of List(Of Model_Monitoringdata.RiwayatPesanan))(jsonData)
                    Else
                        Throw New Exception($"API Error: {response.StatusCode} - {response.ReasonPhrase}")
                    End If
                End Using

            Catch ex As Exception
                Throw New Exception($"Error getting riwayat pesanan by status: {ex.Message}")
            End Try
        End Function

    Public Async Function GetRiwayatPesananByPelangganAsync(pelangganId As Integer) As Task(Of List(Of Model_Monitoringdata.RiwayatPesanan))
        Try
            Using client As New HttpClient()
                client.Timeout = TimeSpan.FromSeconds(30)

                ' Panggil endpoint riwayat pelanggan
                Dim response As HttpResponseMessage = Await client.GetAsync($"{baseUrl}/api/riwayat/pelanggan/{pelangganId}")

                If response.IsSuccessStatusCode Then
                    Dim jsonData As String = Await response.Content.ReadAsStringAsync()
                    Return JsonConvert.DeserializeObject(Of List(Of Model_Monitoringdata.RiwayatPesanan))(jsonData)
                Else
                    Throw New Exception($"API Error: {response.StatusCode} - {response.ReasonPhrase}")
                End If
            End Using

        Catch ex As Exception
            Throw New Exception($"Error getting riwayat pesanan by pelanggan: {ex.Message}")
        End Try
    End Function

    Public Async Function GetDetailPesananByPesananIdAsync(pesananId As Integer) As Task(Of List(Of DetailPesanan))
        Dim url = $"{baseUrl}/api/detail_pesanan/pesanan/{pesananId}"
        Dim response = Await client.GetAsync(url)
        response.EnsureSuccessStatusCode()
        Dim json = Await response.Content.ReadAsStringAsync()
        Return JsonConvert.DeserializeObject(Of List(Of DetailPesanan))(json)
    End Function

End Class
