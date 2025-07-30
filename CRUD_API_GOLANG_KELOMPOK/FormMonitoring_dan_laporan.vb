Imports System.ComponentModel
Imports System.Windows.Forms.VisualStyles
Imports CRUD_API_GOLANG_KELOMPOK.Model_Monitoringdata

Public Class FormMonitoring_dan_laporan
    Private apiClient As New ApiMonitoringClient()
    Private ulasanList As BindingList(Of Ulasan)
    Private transaksiList As BindingList(Of Transaksi)
    Private alamatList As BindingList(Of AlamatPengiriman)
    Private detailPesananList As BindingList(Of DetailPesanan)
    Private riwayatHargaList As BindingList(Of RiwayatHargaPizza)
    Private riwayatPesananList As BindingList(Of RiwayatPesanan)

    Private currentMenu As String = ""

    Private Sub FormMonitoring_dan_laporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbStatusPembayaran.Items.AddRange(New String() {"pending", "dikirim", "selesai", "dibatalkan"})

        StyleSidebarButtons()
        StyleDataGridView()

        PanelRiwayatPesanan.Visible = False
        GroupBoxUpdateTransaksi.Visible = False
        LoadUlasanData()



    End Sub

    Private Sub StyleSidebarButtons()
        Dim sidebarButtons As Button() = {
        btnAlamatPengiriman, btnUlasan, btnTransaksi, btnRiwayatHarga, btnRiwayatPesanan
    }

        ' Emoji untuk setiap tombol
        Dim buttonEmojis As String() = {"🏠", "📝", "💰", "📈", "📦"} ' Emoji untuk setiap tombol

        For i As Integer = 0 To sidebarButtons.Length - 1
            Dim btn As Button = sidebarButtons(i)
            With btn
                .Text = $"{buttonEmojis(i)}  {btn.Text}" ' Gabungkan emoji + teks
                .FlatStyle = FlatStyle.Flat
                .FlatAppearance.BorderSize = 0
                .BackColor = Color.Tan ' Warna krem seperti gambar
                .ForeColor = Color.FromArgb(102, 51, 0) ' Coklat tua (teks)
                .Font = New Font("Segoe UI Semibold", 11, FontStyle.Bold)
                .Height = 48
                .Width = 180
                .TextAlign = ContentAlignment.Center ' Pastikan ini adalah enum yang valid
                .Cursor = Cursors.Hand
                .FlatAppearance.MouseOverBackColor = Color.FromArgb(199, 164, 128) ' Hover lebih gelap sedikit
            End With

            AddHandler btn.MouseEnter, AddressOf SidebarHoverEnter
            AddHandler btn.MouseLeave, AddressOf SidebarHoverLeave
        Next
    End Sub

    Private Sub SidebarHoverEnter(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        btn.BackColor = Color.FromArgb(199, 164, 128)
    End Sub

    Private Sub SidebarHoverLeave(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        btn.BackColor = Color.FromArgb(221, 184, 146)
    End Sub


    Private Sub ButtonHoverEnter(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        btn.BackColor = Color.Peru
    End Sub

    Private Sub ButtonHoverLeave(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        btn.BackColor = Color.BurlyWood
    End Sub



    Private Sub StyleDataGridView()
        With DataGridView1
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.SaddleBrown
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Linen
            .DefaultCellStyle.SelectionBackColor = Color.Chocolate
            .DefaultCellStyle.SelectionForeColor = Color.White
            .Font = New Font("Segoe UI", 10)
            .ScrollBars = ScrollBars.Both
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True
        End With
    End Sub

    Private Sub ApplyStatusColorCoding()
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow Then
                Dim status As String = row.Cells("status").Value?.ToString().ToLower()

                Select Case status
                    Case "selesai"
                        row.Cells("status").Style.BackColor = Color.LightGreen
                        row.Cells("status").Style.ForeColor = Color.DarkGreen
                    Case "dibatalkan"
                        row.Cells("status").Style.BackColor = Color.LightCoral
                        row.Cells("status").Style.ForeColor = Color.DarkRed
                    Case Else
                        row.Cells("status").Style.BackColor = Color.LightGray
                        row.Cells("status").Style.ForeColor = Color.Black
                End Select
            End If
        Next
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If currentMenu = "riwayat" AndAlso e.RowIndex >= 0 Then
            Dim selectedRow = TryCast(DataGridView1.Rows(e.RowIndex).DataBoundItem, Model_Monitoringdata.RiwayatPesanan)

            If selectedRow IsNot Nothing AndAlso TypeOf selectedRow Is Model_Monitoringdata.RiwayatPesanan Then
                If DataGridView1.Columns.Contains("action") AndAlso e.ColumnIndex = DataGridView1.Columns("action").Index Then
                    Dim formDetail As New DetailPesananForm(selectedRow.id_pesanan)
                    formDetail.ShowDialog()
                End If

                ' Isi field-field form/filter
                txtOrderId.Text = selectedRow.id_pesanan.ToString()
                txtCustomerSearch.Text = selectedRow.pelanggan_nama

                ' Set tanggal pesan jika ada
                If selectedRow.tanggal_pesan > Date.MinValue Then
                    dtpStart.Value = selectedRow.tanggal_pesan
                    dtpEnd.Value = selectedRow.tanggal_pesan
                End If
            End If
        End If
    End Sub

    Private Async Sub ApplyFilters()
        Try
            Dim status As String = txtStatus.Text.Trim().ToLower()
            Dim startDate As String = dtpStart.Value.ToString("yyyy-MM-dd")
            Dim endDate As String = dtpEnd.Value.ToString("yyyy-MM-dd")
            Dim customerSearch As String = txtCustomerSearch.Text.Trim()
            Dim orderId As String = txtOrderId.Text.Trim()

            ' Build filter parameters
            Dim parameters As New List(Of String)

            If Not String.IsNullOrEmpty(status) AndAlso status <> "Semua" Then
                parameters.Add($"status={status.ToLower()}")
            End If

            If Not String.IsNullOrEmpty(startDate) Then
                parameters.Add($"start_date={startDate}")
            End If

            If Not String.IsNullOrEmpty(endDate) Then
                parameters.Add($"end_date={endDate}")
            End If

            If Not String.IsNullOrEmpty(customerSearch) Then
                parameters.Add($"customer={customerSearch}")
            End If

            If Not String.IsNullOrEmpty(orderId) Then
                parameters.Add($"order_id={orderId}")
            End If

            ' Load filtered data
            Dim data As List(Of Model_Monitoringdata.RiwayatPesanan)

            If parameters.Count > 0 Then
                ' Gunakan endpoint dengan filter
                Dim filterUrl As String = $"{apiClient.baseUrl}/api/admin/riwayat-pesanan?{String.Join("&", parameters)}"
                data = Await apiClient.GetFilteredRiwayatPesananAsync(filterUrl)
            Else
                ' Load semua data
                data = Await apiClient.GetRiwayatPesananAsync()
            End If

            ' Update DataGridView
            riwayatPesananList = New BindingList(Of Model_Monitoringdata.RiwayatPesanan)(data)
            DataGridView1.DataSource = riwayatPesananList
            ApplyStatusColorCoding()

            ' Update status
            lbl.Text = $"Total: {data.Count} pesanan"

        Catch ex As Exception
            MessageBox.Show($"Error applying filters: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Sub LoadUlasanData()
        Try
            currentMenu = "ulasan"
            DataGridView1.DataSource = Nothing

            Dim data = Await apiClient.GetUlasanAsync()

            ' Jika data kosong, buat list kosong dari struktur UlasanView
            If data Is Nothing OrElse data.Count = 0 Then
                ulasanList = New BindingList(Of Model_Monitoringdata.Ulasan)()
            Else
                ulasanList = New BindingList(Of Model_Monitoringdata.Ulasan)(data)
            End If

            Dim ulasanView = ulasanList.Select(Function(u) New With {
                    .ID_Ulasan = u.id_ulasan,
                    .ID_Pesanan = u.id_pesanan,
                    .ID_Pelanggan = u.id_pelanggan,
                    .Rating = u.rating,
                    .Komen = u.komen,
                    .Tanggal = If(u.tanggal.HasValue, u.tanggal.Value.ToString("yyyy-MM-dd"), ""),
                    .DibuatPada = If(u.DibuatPada.HasValue, u.DibuatPada.Value.ToString("yyyy-MM-dd HH:mm:ss"), ""),
                    .DiperbaruiPada = If(u.DiperbaruiPada.HasValue, u.DiperbaruiPada.Value.ToString("yyyy-MM-dd HH:mm:ss"), ""),
                    .DihapusPada = If(u.DihapusPada.HasValue, u.DihapusPada.Value.ToString("yyyy-MM-dd HH:mm:ss"), "")}
).ToList()


            DataGridView1.DataSource = ulasanView

            With DataGridView1
                If .Columns.Count > 0 Then
                    .Columns("ID_Ulasan").HeaderText = "ID Ulasan"
                    .Columns("ID_Ulasan").Width = 80

                    .Columns("ID_Pesanan").HeaderText = "ID Pesanan"
                    .Columns("ID_Pesanan").Width = 100

                    .Columns("ID_Pelanggan").HeaderText = "ID Pelanggan"
                    .Columns("ID_Pelanggan").Width = 100

                    .Columns("Rating").HeaderText = "Rating"
                    .Columns("Rating").Width = 60

                    .Columns("Komen").HeaderText = "Komen"
                    .Columns("Komen").Width = 200

                    .Columns("Tanggal").HeaderText = "Tanggal"
                    .Columns("Tanggal").Width = 100

                    .Columns("DibuatPada").HeaderText = "Dibuat Pada"
                    .Columns("DibuatPada").Width = 150

                    .Columns("DiperbaruiPada").HeaderText = "Diperbarui"
                    .Columns("DiperbaruiPada").Width = 150

                    .Columns("DihapusPada").HeaderText = "Dihapus Pada"
                    .Columns("DihapusPada").Width = 150
                End If
            End With

            If ulasanView.Count = 0 Then
                MessageBox.Show("No ulasan data found.")
            End If

        Catch ex As Exception
            MessageBox.Show("Failed to retrieve ulasan data: " & ex.Message)
        End Try
    End Sub


    Private Async Function LoadTransaksiData() As Task
        Try
            currentMenu = "transaksi"
            DataGridView1.DataSource = Nothing
            Dim data = Await apiClient.GetTransaksiAsync()
            transaksiList = New BindingList(Of Model_Monitoringdata.Transaksi)(data)
            DataGridView1.DataSource = transaksiList
            With DataGridView1
                If .Columns.Count > 0 Then
                    .Columns("id_transaksi").HeaderText = "ID Transaksi"
                    .Columns("id_transaksi").Width = 80

                    .Columns("id_pesanan").HeaderText = "ID Pesanan"
                    .Columns("id_pesanan").Width = 250

                    .Columns("id_promo").HeaderText = "ID Promo"
                    .Columns("id_promo").Width = 300

                    .Columns("id_admin").HeaderText = "ID Admin"
                    .Columns("id_admin").Width = 100

                    .Columns("tanggal_bayar").HeaderText = "Tanggal Bayar"
                    .Columns("tanggal_bayar").Width = 200

                    .Columns("status_pembayaran").HeaderText = "Status Pembayaran"
                    .Columns("status_pembayaran").Width = 150

                    .Columns("DibuatPada").HeaderText = "Dibuat Pada"
                    .Columns("DibuatPada").Width = 150

                    .Columns("DiperbaruiPada").HeaderText = "Diperbarui"
                    .Columns("DiperbaruiPada").Width = 150

                    .Columns("DihapusPada").HeaderText = "Dihapus Pada"
                    .Columns("DihapusPada").Width = 150

                End If
            End With

        Catch ex As Exception
            MessageBox.Show("Failed to retrieve ulasan data: " & ex.Message)
        End Try
    End Function

    Private Async Sub btnTransaksiUpdateStatus_Click(sender As Object, e As EventArgs) Handles btnUpdateStatusPembayaran.Click
        If DataGridView1.CurrentRow Is Nothing Then Return

        Dim selectedTransaksi = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model_Monitoringdata.Transaksi)
        If selectedTransaksi Is Nothing Then Return

        ' Ubah hanya status pembayaran (misalnya dari dropdown atau textbox)
        selectedTransaksi.status_pembayaran = cmbStatusPembayaran.Text.Trim() ' atau cmbStatusPembayaran.Text

        Try
            Await apiClient.UpdateTransaksiAsync(selectedTransaksi)
            MessageBox.Show("Transaction status successfully updated.", "Success")
            Await LoadTransaksiData()
        Catch ex As Exception
            MessageBox.Show("Failed to update transaction status: " & ex.Message, "Error")
        End Try
    End Sub


    Private Async Sub LoadAlamatPengirimanData()
        Try
            currentMenu = "alamat_pengiriman"
            DataGridView1.DataSource = Nothing

            ' Ambil semua data alamat pengiriman
            Dim data = Await apiClient.GetAlamatPengirimanAsync() ' ← Ganti method sesuai API kamu

            alamatList = New BindingList(Of Model_Monitoringdata.AlamatPengiriman)(data)
            DataGridView1.DataSource = alamatList
            With DataGridView1
                If .Columns.Count > 0 Then
                    .Columns("id_alamat_pengiriman").HeaderText = "ID Alamat"
                    .Columns("id_alamat_pengiriman").Width = 80

                    .Columns("id_pelanggan").HeaderText = "ID Pelanggan"
                    .Columns("id_pelanggan").Width = 250

                    .Columns("nama_penerima").HeaderText = "Nama Penerima"
                    .Columns("nama_penerima").Width = 200

                    .Columns("no_hp_penerima").HeaderText = "No HP Penerima"
                    .Columns("no_hp_penerima").Width = 150

                    .Columns("alamat_lengkap").HeaderText = "Alamat Lengkap"
                    .Columns("alamat_lengkap").Width = 300

                    .Columns("catatan").HeaderText = "Catatan"
                    .Columns("catatan").Width = 200

                    .Columns("kode_pos").HeaderText = "Kode Pos"
                    .Columns("kode_pos").Width = 100

                    .Columns("kota").HeaderText = "Kota"
                    .Columns("kota").Width = 150

                    .Columns("provinsi").HeaderText = "Provinsi"
                    .Columns("provinsi").Width = 150

                    .Columns("DibuatPada").HeaderText = "Dibuat Pada"
                    .Columns("DibuatPada").Width = 150

                    .Columns("DiperbaruiPada").HeaderText = "Diperbarui"
                    .Columns("DiperbaruiPada").Width = 150

                    .Columns("DihapusPada").HeaderText = "Dihapus Pada"
                    .Columns("DihapusPada").Width = 150
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Failed to retrieve alamat pengiriman data: " & ex.Message)
        End Try
    End Sub

    Private Async Sub LoadRiwayatPesananData()
        Try
            currentMenu = "riwayat"
            DataGridView1.DataSource = Nothing

            ' Panggil API untuk mendapatkan semua riwayat pesanan
            Dim data = Await apiClient.GetRiwayatPesananAsync()
            riwayatPesananList = New BindingList(Of Model_Monitoringdata.RiwayatPesanan)(data)
            DataGridView1.DataSource = riwayatPesananList

            With DataGridView1
                If .Columns.Count > 0 Then
                    ' Kolom utama riwayat pesanan
                    .Columns("id_pesanan").HeaderText = "ID Pesanan"
                    .Columns("id_pesanan").Width = 100

                    .Columns("tanggal_pesan").HeaderText = "Tanggal Pesan"
                    .Columns("tanggal_pesan").Width = 150
                    .Columns("tanggal_pesan").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"

                    .Columns("status").HeaderText = "Status"
                    .Columns("status").Width = 100

                    .Columns("total_harga").HeaderText = "Total Harga"
                    .Columns("total_harga").Width = 120
                    .Columns("total_harga").DefaultCellStyle.Format = "N0"

                    ' Kolom relasi (jika ada)
                    If .Columns.Contains("pelanggan_nama") Then
                        .Columns("pelanggan_nama").HeaderText = "Nama Pelanggan"
                        .Columns("pelanggan_nama").Width = 150
                    End If

                    If .Columns.Contains("kurir_nama") Then
                        .Columns("kurir_nama").HeaderText = "Nama Kurir"
                        .Columns("kurir_nama").Width = 120
                    End If

                    If .Columns.Contains("metode_pembayaran_nama") Then
                        .Columns("metode_pembayaran_nama").HeaderText = "Metode Pembayaran"
                        .Columns("metode_pembayaran_nama").Width = 130
                    End If

                    ' Kolom audit trail
                    .Columns("DibuatPada").HeaderText = "Dibuat Pada"
                    .Columns("DibuatPada").Width = 150

                    .Columns("DiperbaruiPada").HeaderText = "Diperbarui"
                    .Columns("DiperbaruiPada").Width = 150

                    .Columns("DihapusPada").HeaderText = "Dihapus Pada"
                    .Columns("DihapusPada").Width = 150

                    ' Sembunyikan kolom yang tidak perlu ditampilkan
                    If .Columns.Contains("dihapus_pada") Then
                        .Columns("dihapus_pada").Visible = False
                    End If

                    If .Columns.Contains("dihapus_oleh") Then
                        .Columns("dihapus_oleh").Visible = False
                    End If

                    ' Tambahkan kolom aksi
                    Dim actionColumn As New DataGridViewButtonColumn()
                    actionColumn.HeaderText = "Aksi"
                    actionColumn.Name = "action"
                    actionColumn.Text = "👁 Detail"
                    actionColumn.UseColumnTextForButtonValue = True
                    actionColumn.Width = 80
                    .Columns.Add(actionColumn)

                    ' Set style untuk status
                    .Columns("status").DefaultCellStyle.BackColor = Color.LightGray
                End If
            End With

            ' Apply color coding untuk status
            ApplyStatusColorCoding()

        Catch ex As Exception
            MessageBox.Show("Failed to retrieve riwayat pesanan data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Async Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            ' Reset all filter inputs
            txtStatus.Clear()
            dtpStart.Value = DateTime.Today.AddDays(-7) ' default to 7 days ago
            dtpEnd.Value = DateTime.Today
            txtCustomerSearch.Clear()
            txtOrderId.Clear()

            ' Fetch all order history data without any filters
            Dim data = Await apiClient.GetRiwayatPesananAsync()
            riwayatPesananList = New BindingList(Of Model_Monitoringdata.RiwayatPesanan)(data)
            DataGridView1.DataSource = riwayatPesananList

            ' Apply color coding and update total label
            ApplyStatusColorCoding()
            lblStatus.Text = $"Total: {data.Count} orders"

        Catch ex As Exception
            MessageBox.Show("Failed to reset filters: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Async Sub LoadRiwayatHargaPizzaData()
        Try
            currentMenu = "riwayat_harga"
            DataGridView1.DataSource = Nothing

            Dim idPizza As ULong = 1
            Dim data = Await apiClient.GetRiwayatHargaByPizzaIdAsync(idPizza)

            riwayatHargaList = New BindingList(Of Model_Monitoringdata.RiwayatHargaPizza)(data)

            Dim riwayatView = riwayatHargaList.Select(Function(r) New With {
            .ID_Riwayat = r.id_riwayat_harga,
            .ID_Pizza = r.id_pizza,
            .Nama_Pizza = If(r.pizza IsNot Nothing, r.pizza.nama, ""),
            .ID_Admin = r.id_admin,
            .Nama_Admin = If(r.admin IsNot Nothing, r.admin.nama, ""),
            .Harga_Lama = r.harga_lama,
            .Harga_Baru = r.harga_baru,
            .Tanggal_Ubah = r.tanggal_ubah,
            .Dibuat_Pada = r.DibuatPada,
            .Diperbarui_Pada = r.DiperbaruiPada,
            .Dihapus_Pada = r.DihapusPada}
            ).ToList()

            DataGridView1.DataSource = riwayatView

            With DataGridView1
                If .Columns.Count > 0 Then
                    .Columns("ID_Riwayat").HeaderText = "ID Riwayat"
                    .Columns("ID_Riwayat").Width = 80

                    .Columns("ID_Pizza").HeaderText = "ID Pizza"
                    .Columns("ID_Pizza").Width = 100

                    .Columns("Nama_Pizza").HeaderText = "Nama Pizza"
                    .Columns("Nama_Pizza").Width = 150

                    .Columns("ID_Admin").HeaderText = "ID Admin"
                    .Columns("ID_Admin").Width = 100

                    .Columns("Nama_Admin").HeaderText = "Nama Admin"
                    .Columns("Nama_Admin").Width = 150

                    .Columns("Harga_Lama").HeaderText = "Harga Lama"
                    .Columns("Harga_Lama").Width = 120

                    .Columns("Harga_Baru").HeaderText = "Harga Baru"
                    .Columns("Harga_Baru").Width = 120

                    .Columns("Tanggal_Ubah").HeaderText = "Tanggal Ubah"
                    .Columns("Tanggal_Ubah").Width = 150

                    If DataGridView1.Columns.Contains("CreatedAt") Then
                        DataGridView1.Columns("CreatedAt").DefaultCellStyle.Format = "dd MMM yyyy"
                    End If

                    If DataGridView1.Columns.Contains("CreatedAt") Then
                        DataGridView1.Columns("CreatedAt").DefaultCellStyle.Format = "dd MMM yyyy"
                    End If

                    If DataGridView1.Columns.Contains("CreatedAt") Then
                        DataGridView1.Columns("CreatedAt").DefaultCellStyle.Format = "dd MMM yyyy"
                    End If
                End If
            End With

        Catch ex As Exception
            MessageBox.Show("Failed to retrieve riwayat harga pizza data: " & ex.Message)
        End Try
    End Sub



    Private Async Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDeleteUniversal.Click
        If DataGridView1.CurrentRow Is Nothing Then
            MessageBox.Show("Please select a row to delete.")
            Exit Sub
        End If

        Dim result = MessageBox.Show("Are you sure you want to delete this item?", "Delete Confirmation", MessageBoxButtons.YesNo)
        If result <> DialogResult.Yes Then Exit Sub

        Try
            Select Case currentMenu
                Case "ulasan"
                    Dim item = CType(DataGridView1.CurrentRow.DataBoundItem, Ulasan)
                    Await apiClient.DeleteUlasanAsync(item.id_ulasan)
                    ulasanList.Remove(item)

                Case "transaksi"
                    Dim item = CType(DataGridView1.CurrentRow.DataBoundItem, Transaksi)
                    Await apiClient.DeleteTransaksiAsync(item.id_transaksi)
                    transaksiList.Remove(item)

                Case "alamat_pengiriman"
                    Dim item = CType(DataGridView1.CurrentRow.DataBoundItem, AlamatPengiriman)
                    Await apiClient.DeleteAlamatPengirimanAsync(item.id_alamat_pengiriman)
                    alamatList.Remove(item)

                    'Case "riayat"
                    'Dim item = CType(DataGridView1.CurrentRow.DataBoundItem, RiwayatPesanan)
                    'Await apiClient.DeleteDetailPesananAsync(item.id_pesanan)
                    'riwayatPesananList.Remove(item)

                Case "riwayat_harga"
                    Dim item = CType(DataGridView1.CurrentRow.DataBoundItem, RiwayatHargaPizza)
                    Await apiClient.DeleteRiwayatHargaAsync(item.id_riwayat_harga)
                    riwayatHargaList.Remove(item)

                Case Else
                    MessageBox.Show("Unknown menu type.")
            End Select

            MessageBox.Show("Item successfully deleted.")
        Catch ex As Exception
            MessageBox.Show("Failed to delete item: " & ex.Message)
        End Try
    End Sub

    Private Sub btnUlasan_Click(sender As Object, e As EventArgs) Handles btnUlasan.Click
        GroupBoxUpdateTransaksi.Visible = False
        LoadUlasanData()
    End Sub
    Private Async Sub btnTransaksi_Click(sender As Object, e As EventArgs) Handles btnTransaksi.Click
        GroupBoxUpdateTransaksi.Visible = True
        Await LoadTransaksiData()
    End Sub
    Private Sub btnAlamatPengiriman_Click(sender As Object, e As EventArgs) Handles btnAlamatPengiriman.Click
        GroupBoxUpdateTransaksi.Visible = False
        LoadAlamatPengirimanData()
    End Sub
    Private Sub btnRiwayatPesanan_Click(sender As Object, e As EventArgs) Handles btnRiwayatPesanan.Click
        ' Load riwayat pesanan ketika tombol menu diklik
        GroupBoxUpdateTransaksi.Visible = False

        PanelRiwayatPesanan.Visible = True
        btnDeleteUniversal.Visible = False
        LoadRiwayatPesananData()
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        ' Terapkan filter
        ApplyFilters()
    End Sub

    Private Sub btnKembaliForm2_Click(sender As Object, e As EventArgs) Handles btnKembaliForm2.Click
        Dim form2 As New FormTransaksi__Menu__Promo()
        form2.Show()
        Me.Hide()
    End Sub

    Private Sub btnRiwayatHarga_Click(sender As Object, e As EventArgs) Handles btnRiwayatHarga.Click
        LoadRiwayatHargaPizzaData()
    End Sub


End Class