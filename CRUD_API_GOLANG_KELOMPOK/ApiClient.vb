Imports CRUD_API_GOLANG_KELOMPOK.Model
Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Text

Public Class ApiClient
    Private ReadOnly client As HttpClient
    Private ReadOnly adminUrl As String = "https://jx4zldbn-8082.asse.devtunnels.ms/api/admin"
    Private ReadOnly pelangganUrl As String = "https://jx4zldbn-8082.asse.devtunnels.ms/api/pelanggan"
    Private ReadOnly kurirUrl As String = "https://jx4zldbn-8082.asse.devtunnels.ms/api/kurir"
    Public Sub New()
        client = New HttpClient()
    End Sub

    ' --- Admin API ---
    Public Async Function GetAdminsAsync() As Task(Of List(Of Admin))
        Dim response = Await client.GetAsync(adminUrl)
        response.EnsureSuccessStatusCode()
        Dim json = Await response.Content.ReadAsStringAsync()
        Return JsonConvert.DeserializeObject(Of List(Of Admin))(json)
    End Function

    Public Async Function CreateAdminAsync(admin As Admin) As Task
        Dim json = JsonConvert.SerializeObject(admin)
        Dim content = New StringContent(json, Encoding.UTF8, "application/json")
        Dim response = Await client.PostAsync(adminUrl, content)
        response.EnsureSuccessStatusCode()
    End Function

    Public Async Function UpdateAdminAsync(admin As Admin) As Task
        Dim json = JsonConvert.SerializeObject(admin)
        Dim content = New StringContent(json, Encoding.UTF8, "application/json")
        Dim url = $"{adminUrl}/{admin.id_admin}"
        Dim response = Await client.PutAsync(url, content)
        response.EnsureSuccessStatusCode()
    End Function

    Public Async Function DeleteAdminAsync(id As ULong) As Task
        Dim response = Await client.DeleteAsync($"{adminUrl}/{id}")
        response.EnsureSuccessStatusCode()
    End Function

    ' --- Pelanggan API ---
    Public Async Function GetPelangganAsync() As Task(Of List(Of Pelanggan))
        Dim response = Await client.GetAsync(pelangganUrl)
        response.EnsureSuccessStatusCode()
        Dim json = Await response.Content.ReadAsStringAsync()
        Return JsonConvert.DeserializeObject(Of List(Of Pelanggan))(json)
    End Function

    Public Async Function UpdatePelangganAsync(pelanggan As Pelanggan) As Task(Of HttpResponseMessage)
        Dim json = JsonConvert.SerializeObject(pelanggan)
        Dim content = New StringContent(json, Encoding.UTF8, "application/json")
        Dim url = $"{pelangganUrl}/{pelanggan.id_pelanggan}"
        Dim response = Await client.PutAsync(url, content)
        Return response ' Kembalikan respons untuk pemeriksaan lebih lanjut
    End Function

    Public Async Function DeletePelangganAsync(id_pelanggan As ULong, id_admin As ULong) As Task
        Dim url = $"{pelangganUrl}/{id_pelanggan}?id_admin={id_admin}"

        Dim response = Await client.DeleteAsync(url)
        response.EnsureSuccessStatusCode()
    End Function


    ' --- Kurir API ---
    Public Async Function GetKurirsAsync() As Task(Of List(Of Kurir))
        Dim response = Await client.GetAsync(kurirUrl)
        response.EnsureSuccessStatusCode()
        Dim json = Await response.Content.ReadAsStringAsync()
        Return JsonConvert.DeserializeObject(Of List(Of Kurir))(json)
    End Function

    Public Async Function CreateKurirAsync(kurir As Kurir) As Task
        Dim json = JsonConvert.SerializeObject(kurir)
        Dim content = New StringContent(json, Encoding.UTF8, "application/json")
        Dim response = Await client.PostAsync(kurirUrl, content)
        response.EnsureSuccessStatusCode()
    End Function

    Public Async Function UpdateKurirAsync(kurir As Kurir) As Task
        Dim json = JsonConvert.SerializeObject(kurir)
        Dim content = New StringContent(json, Encoding.UTF8, "application/json")
        Dim url = $"{kurirUrl}/{kurir.id_kurir}"
        Dim response = Await client.PutAsync(url, content)
        response.EnsureSuccessStatusCode()
    End Function

    Public Async Function DeleteKurirAsync(id As ULong) As Task
        Dim response = Await client.DeleteAsync($"{kurirUrl}/{id}")
        response.EnsureSuccessStatusCode()
    End Function





End Class