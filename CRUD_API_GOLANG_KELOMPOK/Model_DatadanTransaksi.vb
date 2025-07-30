Imports CRUD_API_GOLANG_KELOMPOK.Model
Imports CRUD_API_GOLANG_KELOMPOK.Model_Monitoringdata

Public Class Model_DatadanTransaksi
    ' ===== PIZZA =====
    Public Class Pizza
        Public Property id_pizza As ULong?
        Public Property nama As String
        Public Property deskripsi As String
        Public Property harga As Double
        Public Property url_gambar As String
        Public Property status As String

        Public Property DibuatPada As Nullable(Of DateTime)
        Public Property DiperbaruiPada As Nullable(Of DateTime)
        Public Property DihapusPada As Nullable(Of DateTime)

    End Class


    ' ===== PESANAN =====
    Public Class Pesanan
        Public Property id_pesanan As ULong?
        Public Property id_pelanggan As ULong?
        Public Property id_promo As ULong?
        Public Property id_kurir As ULong?
        Public Property id_alamat_pengiriman As Nullable(Of ULong)
        Public Property tanggal_pesan As Date?
        Public Property status As String
        Public Property id_metode_pembayaran As ULong?

        Public Property DibuatPada As Nullable(Of DateTime)
        Public Property DiperbaruiPada As Nullable(Of DateTime)
        Public Property DihapusPada As Nullable(Of DateTime)


        ' Properti opsional untuk relasi, bisa diabaikan jika hanya ambil ID
        'Public Property pelanggan As Pelanggan'
        'Public Property metode_pembayaran As MetodePembayaran
        'Public Property kurir As Kurir
        'Public Property alamat_pengiriman As AlamatPengiriman
    End Class


    ' ===== Promo =====
    Public Class Promo
        Public Property id_promo As ULong?
        Public Property nama_promo As String
        Public Property deskripsi As String
        Public Property kode As String
        Public Property diskon As Double
        Public Property valid_dari As DateTime
        Public Property valid_sampai As DateTime
        Public Property status As String

        Public Property DibuatPada As Nullable(Of DateTime)
        Public Property DiperbaruiPada As Nullable(Of DateTime)
        Public Property DihapusPada As Nullable(Of DateTime)

    End Class


    ' ===== Metode Pembayaran =====
    Public Class MetodePembayaran
        Public Property id_metode_pembayaran As ULong?
        Public Property metode_pembayaran As String
        Public Property keterangan As String

        Public Property DibuatPada As DateTime?
        Public Property DiperbaruiPada As DateTime?
        Public Property DihapusPada As DateTime?

    End Class


    ' ===== Notifikasi =====
    Public Class Notifikasi
        Public Property id_notifikasi As ULong?
        Public Property id_pesanan As ULong?
        Public Property id_pengirim As ULong?
        Public Property id_penerima As ULong?
        Public Property jenis_pengirim As String
        Public Property jenis_penerima As String
        Public Property judul As String
        Public Property pesan As String
        Public Property jenis_notif As String
        Public Property status As String
        Public Property DibuatPada As Nullable(Of DateTime)
        Public Property DiperbaruiPada As Nullable(Of DateTime)
        Public Property DihapusPada As Nullable(Of DateTime)

    End Class
End Class
