Imports CRUD_API_GOLANG_KELOMPOK.Model
Imports CRUD_API_GOLANG_KELOMPOK.Model_DatadanTransaksi

Public Class Model_Monitoringdata
    ' ===== Ulasan =====
    Public Class Ulasan
        Public Property id_ulasan As ULong
        Public Property id_pesanan As ULong
        Public Property id_pelanggan As ULong
        Public Property rating As Integer
        Public Property komen As String
        Public Property tanggal As DateTime?

        Public Property DibuatPada As Nullable(Of DateTime)
        Public Property DiperbaruiPada As Nullable(Of DateTime)
        Public Property DihapusPada As Nullable(Of DateTime)

        ' Optional: Relasi (hanya digunakan jika JSON menyertakan data relasi)
        Public Property pesanan As Pesanan
        Public Property pelanggan As Pelanggan
    End Class


    ' ===== Alamat Pengiriman =====
    Public Class AlamatPengiriman
        Public Property id_alamat_pengiriman As ULong?
        Public Property id_pelanggan As ULong?
        Public Property nama_penerima As String
        Public Property no_hp_penerima As String
        Public Property alamat_lengkap As String
        Public Property catatan As String
        Public Property kode_pos As String
        Public Property kota As String
        Public Property provinsi As String

        Public Property DibuatPada As Nullable(Of DateTime)
        Public Property DiperbaruiPada As Nullable(Of DateTime)
        Public Property DihapusPada As Nullable(Of DateTime)

        ' Optional: relasi jika JSON menyertakan detail pelanggan
        'Public Property pelanggan As Pelanggan
    End Class


    ' ===== Transaksi =====
    Public Class Transaksi
        Public Property id_transaksi As ULong?
        Public Property id_pesanan As ULong?
        Public Property id_promo As ULong?
        Public Property id_admin As ULong?
        Public Property tanggal_bayar As DateTime?
        Public Property status_pembayaran As String

        Public Property DibuatPada As Nullable(Of DateTime)
        Public Property DiperbaruiPada As Nullable(Of DateTime)
        Public Property DihapusPada As Nullable(Of DateTime)


        ' Optional: relasi (jika backend mengirimkan data nested)
        ' Public Property pesanan As Pesanan
        ' Public Property promo As Promo
        'Public Property admin As Admin
    End Class


    ' ===== Riwayat Harga Pizza =====
    Public Class RiwayatHargaPizza
        Public Property id_riwayat_harga As ULong?
        Public Property id_pizza As ULong?
        Public Property id_admin As ULong?
        Public Property harga_lama As Double
        Public Property harga_baru As Double
        Public Property tanggal_ubah As DateTime?

        Public Property DibuatPada As Nullable(Of DateTime)
        Public Property DiperbaruiPada As Nullable(Of DateTime)
        Public Property DihapusPada As Nullable(Of DateTime)


        ' Optional: relasi (jika backend menyertakan nested objek)
        Public Property pizza As Pizza
        Public Property admin As Admin
    End Class

    ' ===== Riwayat Pesanan =====
    Public Class RiwayatPesanan
        Public Property id_pesanan As Integer
        Public Property tanggal_pesan As DateTime?
        Public Property status As String
        Public Property total_harga As Decimal
        Public Property items As List(Of DetailPesanan)

        ' Relasi dengan tabel lain
        Public Property pelanggan As Pelanggan
        Public Property kurir As Kurir
        Public Property metode_pembayaran As MetodePembayaran
        Public Property alamat_pengiriman As AlamatPengiriman

        ' Audit trail
        Public Property DibuatPada As Nullable(Of DateTime)
        Public Property DiperbaruiPada As Nullable(Of DateTime)
        Public Property DihapusPada As Nullable(Of DateTime)


        ' Computed properties untuk display
        Public ReadOnly Property pelanggan_nama As String
            Get
                Return If(pelanggan?.nama, "N/A")
            End Get
        End Property

        Public ReadOnly Property kurir_nama As String
            Get
                Return If(kurir?.nama, "N/A")
            End Get
        End Property

        Public ReadOnly Property jumlah_item As Integer
            Get
                Return If(items?.Count, 0)
            End Get
        End Property
    End Class

    ' ===== Detail Pesanan =====
    Public Class DetailPesanan
        Public Property id_detail As ULong?
        Public Property id_pesanan As ULong?
        Public Property id_pizza As ULong?
        Public Property jumlah As Integer
        Public Property harga_asli As Double
        Public Property harga_satuan As Double
        Public Property id_promo_pizza As Nullable(Of ULong)
        Public Property diskon As Double
        Public Property diskon_per_item As Double

        Public Property dibuat_pada As Nullable(Of DateTime)
        Public Property diperbarui_pada As Nullable(Of DateTime)
        Public Property dihapus_pada As Nullable(Of DateTime)

        Public Property dibuat_oleh As Nullable(Of ULong)
        Public Property diperbarui_oleh As Nullable(Of ULong)
        Public Property dihapus_oleh As Nullable(Of ULong)

        ' Relasi (opsional)
        Public Property pesanan As Pesanan
        Public Property pizza As Pizza
        Public Property promo_pizza As Promo
    End Class


End Class
