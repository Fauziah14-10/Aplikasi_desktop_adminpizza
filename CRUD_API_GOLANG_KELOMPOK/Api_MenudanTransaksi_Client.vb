Imports CRUD_API_GOLANG_KELOMPOK.Model_DatadanTransaksi
Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Text
Public Class Api_MenudanTransaksi_Client
    Private ReadOnly client As HttpClient
    Private ReadOnly pesananUrl As String = "https://jx4zldbn-8082.asse.devtunnels.ms/api/pesanan"
    Private ReadOnly notifikasiUrl As String = "https://jx4zldbn-8082.asse.devtunnels.ms/api/admin/notifikasi"
    Private ReadOnly metodePembayaranUrl As String = "https://jx4zldbn-8082.asse.devtunnels.ms/api/metode_pembayaran"
    Private ReadOnly promoUrl As String = "https://jx4zldbn-8082.asse.devtunnels.ms/api/promo"
    Private ReadOnly baseUrl As String = "https://jx4zldbn-8082.asse.devtunnels.ms/api/pizza"

    Public Sub New()
        client = New HttpClient()
    End Sub

    ' --- Pizza API ---
    Public Async Function GetPizzasAsync() As Task(Of List(Of Pizza))
        Dim response = Await client.GetAsync(baseUrl)
        response.EnsureSuccessStatusCode()
        Dim json = Await response.Content.ReadAsStringAsync()
        Return JsonConvert.DeserializeObject(Of List(Of Pizza))(json)
    End Function

    Public Async Function CreatePizzaAsync(pizza As Pizza) As Task
        Dim json = JsonConvert.SerializeObject(pizza)
        Dim content = New StringContent(json, Encoding.UTF8, "application/json")
        Dim response = Await client.PostAsync(baseUrl, content)
        response.EnsureSuccessStatusCode()
    End Function

    Public Async Function UpdatePizzaAsync(pizza As Pizza) As Task
        Dim json = JsonConvert.SerializeObject(pizza)
        Dim content = New StringContent(json, Encoding.UTF8, "application/json")
        Dim url = $"{baseUrl}/{pizza.id_pizza}"
        Dim response = Await client.PutAsync(url, content)
        response.EnsureSuccessStatusCode()
    End Function

    Public Async Function DeletePizzaAsync(id As ULong) As Task
        Dim response = Await client.DeleteAsync($"{baseUrl}/{id}")
        response.EnsureSuccessStatusCode()
    End Function

    ' --- Pesanan API ---
    Public Async Function GetPesananAsync() As Task(Of List(Of Pesanan))
        Dim response = Await client.GetAsync(pesananUrl)
        response.EnsureSuccessStatusCode()
        Dim json = Await response.Content.ReadAsStringAsync()
        Return JsonConvert.DeserializeObject(Of List(Of Pesanan))(json)
    End Function

    Public Async Function UpdatePesananAsync(pesanan As Pesanan) As Task
        Dim json = JsonConvert.SerializeObject(pesanan)
        Dim content = New StringContent(json, Encoding.UTF8, "application/json")
        Dim url = $"{pesananUrl}/{pesanan.id_pesanan}"
        Dim response = Await client.PutAsync(url, content)
        response.EnsureSuccessStatusCode()
    End Function

    Public Async Function DeletePesananAsync(id As ULong) As Task
        Dim response = Await client.DeleteAsync($"{pesananUrl}/{id}")
        response.EnsureSuccessStatusCode()
    End Function

    ' --- Notifikasi API ---
    Public Async Function GetAllNotifikasiAsync() As Task(Of List(Of Notifikasi))
        Dim response = Await client.GetAsync(notifikasiUrl)
        response.EnsureSuccessStatusCode()
        Dim json = Await response.Content.ReadAsStringAsync()
        Return JsonConvert.DeserializeObject(Of List(Of Notifikasi))(json)
    End Function

    Public Async Function CreateNotifikasiAsync(notifikasi As Notifikasi) As Task
        Dim json = JsonConvert.SerializeObject(notifikasi)
        Dim content = New StringContent(json, Encoding.UTF8, "application/json")
        Dim response = Await client.PostAsync(notifikasiUrl, content)
        response.EnsureSuccessStatusCode()
    End Function

    ' PUT: Update notifikasi (jika dibutuhkan)
    Public Async Function UpdateNotifikasiAsync(notifikasi As Notifikasi) As Task
        Dim json = JsonConvert.SerializeObject(notifikasi)
        Dim content = New StringContent(json, Encoding.UTF8, "application/json")
        Dim url = $"{notifikasiUrl}/{notifikasi.id_notifikasi}"
        Dim response = Await client.PutAsync(url, content)
        response.EnsureSuccessStatusCode()
    End Function

    Public Async Function DeleteNotifikasiAsync(id As ULong) As Task
        Dim url = $"{notifikasiUrl}/{id}"
        Dim response = Await client.DeleteAsync(url)
        response.EnsureSuccessStatusCode()
    End Function

    ' --- Metode Pembayaran API ---
    Public Async Function GetMetodePembayaranAsync() As Task(Of List(Of MetodePembayaran))
        Dim response = Await client.GetAsync(metodePembayaranUrl)
        response.EnsureSuccessStatusCode()
        Dim json = Await response.Content.ReadAsStringAsync()
        Return JsonConvert.DeserializeObject(Of List(Of MetodePembayaran))(json)
    End Function

    Public Async Function CreateMetodePembayaranAsync(metode As MetodePembayaran) As Task
        Dim json = JsonConvert.SerializeObject(metode)
        Dim content = New StringContent(json, Encoding.UTF8, "application/json")

        Console.WriteLine("JSON dikirim: " & json)

        Dim response = Await client.PostAsync(metodePembayaranUrl, content)
        Dim responseContent = Await response.Content.ReadAsStringAsync()

        If Not response.IsSuccessStatusCode Then
            Throw New Exception($"Status: {response.StatusCode}, Response: {responseContent}")
        End If
    End Function


    Public Async Function UpdateMetodePembayaranAsync(metode As MetodePembayaran) As Task
        Dim json = JsonConvert.SerializeObject(metode)
        Dim content = New StringContent(json, Encoding.UTF8, "application/json")
        Dim url = $"{metodePembayaranUrl}/{metode.id_metode_pembayaran}"
        Dim response = Await client.PutAsync(url, content)
        response.EnsureSuccessStatusCode()
    End Function

    Public Async Function DeleteMetodePembayaranAsync(id As ULong) As Task
        Dim response = Await client.DeleteAsync($"{metodePembayaranUrl}/{id}")
        response.EnsureSuccessStatusCode()
    End Function

    ' --- Promo API ---
    Public Async Function GetPromosAsync() As Task(Of List(Of Promo))
        Dim response = Await client.GetAsync(promoUrl)
        response.EnsureSuccessStatusCode()
        Dim json = Await response.Content.ReadAsStringAsync()
        Return JsonConvert.DeserializeObject(Of List(Of Promo))(json)
    End Function

    Public Async Function CreatePromoAsync(promo As Promo) As Task
        Dim json = JsonConvert.SerializeObject(promo)
        Dim content = New StringContent(json, Encoding.UTF8, "application/json")
        Dim response = Await client.PostAsync(promoUrl, content)
        response.EnsureSuccessStatusCode()
    End Function

    Public Async Function UpdatePromoAsync(promo As Promo) As Task
        Dim json = JsonConvert.SerializeObject(promo)
        Dim content = New StringContent(json, Encoding.UTF8, "application/json")
        Dim url = $"{promoUrl}/{promo.id_promo}"
        Dim response = Await client.PutAsync(url, content)
        response.EnsureSuccessStatusCode()
    End Function

    Public Async Function DeletePromoAsync(id As ULong) As Task
        Dim response = Await client.DeleteAsync($"{promoUrl}/{id}")
        response.EnsureSuccessStatusCode()
    End Function
End Class
