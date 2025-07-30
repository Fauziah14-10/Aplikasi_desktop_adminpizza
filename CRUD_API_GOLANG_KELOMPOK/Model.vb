Public Class Model
    ' ===== ADMIN =====
    Public Class Admin
        Public Property id_admin As ULong
        Public Property nama As String
        Public Property email As String
        Public Property password As String
        Public Property status As String

        ' Gunakan Nullable(Of DateTime) untuk semua field waktu yang bisa null
        Public Property DibuatPada As Nullable(Of DateTime)
        Public Property DiperbaruiPada As Nullable(Of DateTime)
        Public Property DihapusPada As Nullable(Of DateTime)

    End Class


    ' ===== PELANGGAN =====
    Public Class Pelanggan
        Public Property id_pelanggan As ULong
        Public Property nama As String
        Public Property email As String
        Public Property password As String
        Public Property no_hp As String
        Public Property tanggal_lahir As DateTime
        Public Property status As String
        Public Property DibuatPada As Nullable(Of DateTime)
        Public Property DiperbaruiPada As Nullable(Of DateTime)
        Public Property DihapusPada As Nullable(Of DateTime)

    End Class

    ' ===== Kurir =====
    Public Class Kurir
        ' Informasi Personal & Kredensial
        Public Property id_kurir As ULong
        Public Property nama As String
        Public Property email As String
        Public Property password As String
        Public Property no_hp As String

        ' Informasi Spesifik Kurir
        Public Property no_plat As String
        Public Property foto_profil As String

        ' Status Operasional
        Public Property status As String
        Public Property latitude As Double
        Public Property longitude As Double
        Public Property lokasi_terakhir_update As DateTime?
        ' Timestamp Standar
        Public Property DibuatPada As Nullable(Of DateTime)
        Public Property DiperbaruiPada As Nullable(Of DateTime)
        Public Property DihapusPada As Nullable(Of DateTime)


    End Class


End Class