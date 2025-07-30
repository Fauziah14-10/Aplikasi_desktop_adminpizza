Public Class DetailPesananForm
    Private ReadOnly pesananId As Integer
    Private ReadOnly apiClient As New ApiMonitoringClient()
    Private ReadOnly apiCLient2 As New Api_MenudanTransaksi_Client()

    Public Sub New(idPesanan As Integer)
        InitializeComponent()
        Me.pesananId = idPesanan
    End Sub

    Private Async Sub DetailPesananForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Ambil data riwayat pesanan (header)
            Dim riwayatList = Await apiClient.GetRiwayatPesananAsync()
            Dim riwayat = riwayatList.FirstOrDefault(Function(p) p.id_pesanan = pesananId)

            If riwayat Is Nothing Then
                MessageBox.Show("Pesanan tidak ditemukan.")
                Me.Close()
                Return
            End If

            ' Tampilkan data header
            txtIdPesanan.Text = riwayat.id_pesanan.ToString()
            txtNamaPelanggan.Text = riwayat.pelanggan_nama
            txtTanggal.Text = If(riwayat.tanggal_pesan.HasValue,
                     riwayat.tanggal_pesan.Value.ToString("dd/MM/yyyy HH:mm"),
                     "-")
            txtNamaKurir.Text = riwayat.kurir_nama
            txtStatus.Text = riwayat.status
            txtTotalHarga.Text = $"Rp {riwayat.total_harga:N0}"

            ' Ambil detail pesanan (item)
            ' Ambil detail pesanan (item)
            Dim detailList = Await apiClient.GetDetailPesananAsync(pesananId)

            If detailList Is Nothing OrElse detailList.Count = 0 Then
                MessageBox.Show("Detail pesanan kosong.")
                Return
            End If

            Dim detailView = detailList.Select(Function(d)
                                                   Return New With {
                                                          .Nama_Pizza = If(d.pizza IsNot Nothing, d.pizza.nama, $"Pizza #{d.id_pizza}"),
                                                          .Harga = d.harga_asli,
                                                          .Jumlah = d.jumlah,
                                                          .Subtotal = d.jumlah * d.harga_asli
                                                      }
                                               End Function).ToList()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat detail pesanan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
