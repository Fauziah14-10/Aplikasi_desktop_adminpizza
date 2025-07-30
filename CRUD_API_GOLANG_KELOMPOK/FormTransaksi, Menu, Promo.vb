Imports System.ComponentModel
Imports CRUD_API_GOLANG_KELOMPOK.Model_DatadanTransaksi


Public Class FormTransaksi__Menu__Promo
    Private apiClient As New Api_MenudanTransaksi_Client()
    Private pizzaList As New BindingList(Of Pizza)
    Private pesananList As New BindingList(Of Pesanan)
    Private promoList As New BindingList(Of Promo)
    Private metodePembayaranList As New BindingList(Of MetodePembayaran)
    Private notifikasiList As New BindingList(Of Notifikasi)

    Private Async Sub FormTransaksi__Menu__Promo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmbStatusPesanan.Items.AddRange(New String() {"pending", "dikirim", "selesai", "dibatalkan"})

        StyleSidebarButtons()
        StyleGroupBox(GroupBoxPizza, btnPizzaInsert, btnPizzaUpdate, btnPizzaDelete, btnPizzaClear)
        StyleGroupBox(GroupBoxPesanan, Nothing, btnOrderUpdate, btnOrderDelete, btnOrderClear)
        StyleGroupBox(GroupBoxPromo, btnInsertPromo, btnUpdatePromo, btnDeletePromo, btnClearPromo)
        StyleGroupBox(GroupBoxPembayaran, btnInsertPembayaran, btnUpdatePembayaran, btnDeletePembayaran, btnClearPembayaran)
        StyleGroupBox(GroupBoxNotifikasi, btnInsertNotifikasi, btnUpdateNotifikasi, btnDeleteNotifikasi, btnClearNotifikasi)

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
            .Enabled = True
        End With

        ' Set Dock agar GroupBox pas dengan Panel
        GroupBoxPesanan.Dock = DockStyle.Fill
        GroupBoxPizza.Dock = DockStyle.Fill
        GroupBoxPromo.Dock = DockStyle.Fill
        GroupBoxPembayaran.Dock = DockStyle.Fill
        GroupBoxNotifikasi.Dock = DockStyle.Fill


        PanelPizza.Visible = True
        PanelPesanan.Visible = False
        PanelPromo.Visible = False
        PanelMetodePembayaran.Visible = False
        PanelNotifikasi.Visible = False
        GroupBoxButtonNotifikasi.Visible = False
        Await LoadPizzaData()
    End Sub

    Private Sub StyleSidebarButtons()
        Dim sidebarButtons As Button() = {
        btnPizza, btnPesanan, btnMetodePembayaran, btnPromo, btnNotifikasi
    }

        ' Emoji untuk setiap tombol
        Dim buttonEmojis As String() = {"🍕", "📋", "💳", "🎉", "🔔"} ' Emoji untuk setiap tombol

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
                .TextAlign = ContentAlignment.MiddleLeft ' Align text to the left for emoji
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

    Private Sub StyleGroupBox(gb As GroupBox, btnInsert As Button, btnUpdate As Button, btnDelete As Button, btnClear As Button)
        gb.BackColor = Color.FromArgb(243, 220, 171)
        gb.ForeColor = Color.SaddleBrown
        gb.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        For Each ctrl As Control In gb.Controls
            If TypeOf ctrl Is Label Then
                ctrl.ForeColor = Color.SaddleBrown
                ctrl.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            ElseIf TypeOf ctrl Is TextBox Then
                ctrl.BackColor = Color.White
                ctrl.Font = New Font("Segoe UI", 10)
            End If
        Next

        If btnInsert IsNot Nothing Then
            btnInsert.BackColor = Color.ForestGreen
            btnInsert.ForeColor = Color.White
            btnInsert.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        End If

        btnUpdate.BackColor = Color.Yellow
        btnUpdate.ForeColor = Color.Black
        btnUpdate.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnDelete.BackColor = Color.Red
        btnDelete.ForeColor = Color.White
        btnDelete.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnClear.BackColor = Color.WhiteSmoke
        btnClear.ForeColor = Color.Black
        btnClear.Font = New Font("Segoe UI", 10, FontStyle.Bold)
    End Sub

    '======= PIZZA =======
    Private Async Function LoadPizzaData() As Task
        Try
            DataGridView1.DataSource = Nothing
            Dim data = Await apiClient.GetPizzasAsync()
            pizzaList = New BindingList(Of Model_DatadanTransaksi.Pizza)(data)
            DataGridView1.DataSource = pizzaList
            With DataGridView1
                If .Columns.Count > 0 Then
                    .Columns("id_pizza").HeaderText = "ID Pizza"
                    .Columns("id_pizza").Width = 80

                    .Columns("nama").HeaderText = "Nama"
                    .Columns("nama").Width = 200

                    .Columns("deskripsi").HeaderText = "Deskripsi"
                    .Columns("deskripsi").Width = 200

                    .Columns("harga").HeaderText = "Harga"
                    .Columns("harga").Width = 100

                    .Columns("url_gambar").HeaderText = "URL Gambar"
                    .Columns("url_gambar").Width = 150

                    .Columns("status").HeaderText = "Status"
                    .Columns("status").Width = 100

                    .Columns("DibuatPada").HeaderText = "Dibuat Pada"
                    .Columns("DibuatPada").Width = 150

                    .Columns("DiperbaruiPada").HeaderText = "Diperbarui"
                    .Columns("DiperbaruiPada").Width = 150

                    .Columns("DihapusPada").HeaderText = "Dihapus Pada"
                    .Columns("DihapusPada").Width = 150

                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Failed to retrieve pizza data: " & ex.Message)
        End Try
    End Function

    Private Async Sub btnPizzaInsert_Click(sender As Object, e As EventArgs) Handles btnPizzaInsert.Click
        Try
            Dim newPizza As New Model_DatadanTransaksi.Pizza With {
                .nama = txtPizzaName.Text,
                .deskripsi = txtPizzaDesc.Text,
                .harga = Double.Parse(txtPizzaPrice.Text),
                .url_gambar = txtPizzaImage.Text,
                .status = txtPizzaStatus.Text
            }
            Await ApiClient.CreatePizzaAsync(newPizza)
            MessageBox.Show("Pizza has been successfully inserted.", "Success")
            Await LoadPizzaData()
        Catch ex As Exception
            MessageBox.Show("Failed to insert pizza: " & ex.Message, "Error")
        End Try
    End Sub

    Private Async Sub btnPizzaUpdate_Click(sender As Object, e As EventArgs) Handles btnPizzaUpdate.Click
        If DataGridView1.CurrentRow Is Nothing Then Return
        Dim selectedPizza = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model_DatadanTransaksi.Pizza)
        If selectedPizza Is Nothing Then Return
        selectedPizza.nama = txtPizzaName.Text
        selectedPizza.deskripsi = txtPizzaDesc.Text
        selectedPizza.harga = Double.Parse(txtPizzaPrice.Text)
        selectedPizza.url_gambar = txtPizzaImage.Text
        selectedPizza.status = txtPizzaStatus.Text
        Try
            Await ApiClient.UpdatePizzaAsync(selectedPizza)
            MessageBox.Show("Pizza has been successfully updated.", "Success")
            Await LoadPizzaData()
        Catch ex As Exception
            MessageBox.Show("Failed to update pizza: " & ex.Message, "Error")
        End Try
    End Sub

    Private Async Sub btnPizzaDelete_Click(sender As Object, e As EventArgs) Handles btnPizzaDelete.Click
        If DataGridView1.CurrentRow Is Nothing Then Return
        Dim selectedPizza = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model_DatadanTransaksi.Pizza)
        If selectedPizza Is Nothing Then Return
        Try
            Await ApiClient.DeletePizzaAsync(selectedPizza.id_pizza)
            MessageBox.Show("Pizza has been successfully deleted.", "Success")
            Await LoadPizzaData()
        Catch ex As Exception
            MessageBox.Show("Failed to delete pizza: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub btnPizzaClear_Click(sender As Object, e As EventArgs) Handles btnPizzaClear.Click
        txtPizzaName.Clear()
        txtPizzaDesc.Clear()
        txtPizzaPrice.Clear()
        txtPizzaImage.Clear()
        txtPizzaStatus.Clear()
    End Sub

    '======= PESANAN =======
    Private Async Function LoadPesananData() As Task
        Try
            DataGridView1.DataSource = Nothing
            Dim data = Await ApiClient.GetPesananAsync()
            pesananList = New BindingList(Of Model_DatadanTransaksi.Pesanan)(data)
            DataGridView1.DataSource = pesananList
            With DataGridView1
                If .Columns.Count > 0 Then
                    .Columns("id_pesanan").HeaderText = "ID Pesanan"
                    .Columns("id_pesanan").Width = 80

                    .Columns("id_pelanggan").HeaderText = "ID Pelanggan"
                    .Columns("id_pelanggan").Width = 100

                    .Columns("id_promo").HeaderText = "ID Promo"
                    .Columns("id_promo").Width = 100

                    .Columns("id_kurir").HeaderText = "ID Kurir"
                    .Columns("id_kurir").Width = 100

                    .Columns("id_alamat_pengiriman").HeaderText = "ID Alamat"
                    .Columns("id_alamat_pengiriman").Width = 100

                    .Columns("tanggal_pesan").HeaderText = "Tanggal Pesan"
                    .Columns("tanggal_pesan").Width = 150

                    .Columns("status").HeaderText = "Status"
                    .Columns("status").Width = 100

                    .Columns("id_metode_pembayaran").HeaderText = "ID Metode Pembayaran"
                    .Columns("id_metode_pembayaran").Width = 150

                    .Columns("DibuatPada").HeaderText = "Dibuat Pada"
                    .Columns("DibuatPada").Width = 150

                    .Columns("DiperbaruiPada").HeaderText = "Diperbarui"
                    .Columns("DiperbaruiPada").Width = 150

                    .Columns("DihapusPada").HeaderText = "Dihapus Pada"
                    .Columns("DihapusPada").Width = 150
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Failed to retrieve pesanan data: " & ex.Message)
        End Try
    End Function

    Private Async Sub btnOrderUpdate_Click(sender As Object, e As EventArgs) Handles btnOrderUpdate.Click
        If DataGridView1.CurrentRow Is Nothing Then Return

        Dim selectedOrder = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model_DatadanTransaksi.Pesanan)
        If selectedOrder Is Nothing Then Return

        selectedOrder.id_pelanggan = ULong.Parse(txtCustomerId.Text)
        selectedOrder.id_kurir = If(String.IsNullOrEmpty(txtKurirID.Text), CType(Nothing, ULong?), ULong.Parse(txtKurirID.Text))

        If Not String.IsNullOrWhiteSpace(txtPromoID.Text) AndAlso IsNumeric(txtPromoID.Text) Then
            selectedOrder.id_promo = ULong.Parse(txtPromoID.Text)
        Else
            selectedOrder.id_promo = Nothing
        End If

        Dim paymentMethodId As ULong
        If ULong.TryParse(txtMetodePembayaranPesanan.Text.Trim(), paymentMethodId) Then
            selectedOrder.id_metode_pembayaran = paymentMethodId
        Else
            MessageBox.Show("Payment method must be a number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' ✅ Tambahkan baris untuk mengupdate status
        selectedOrder.status = cmbStatusPesanan.Text.Trim()

        ' ✅ Call update to the server
        Try
            Await apiClient.UpdatePesananAsync(selectedOrder)
            MessageBox.Show("Order successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Failed to update order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Async Sub btnOrderDelete_Click(sender As Object, e As EventArgs) Handles btnOrderDelete.Click
        If DataGridView1.CurrentRow Is Nothing Then Return
        Dim selectedPesanan = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model_DatadanTransaksi.Pesanan)
        If selectedPesanan Is Nothing Then Return
        Try
            Await apiClient.DeletePesananAsync(selectedPesanan.id_pesanan)
            MessageBox.Show("Order has been successfully deleted.", "Success")
            Await LoadPesananData()
        Catch ex As Exception
            MessageBox.Show("Failed to delete order: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub btnOrderClear_Click(sender As Object, e As EventArgs) Handles btnOrderClear.Click
        txtCustomerId.Clear()
        txtPromoID.Clear()
        txtKurirID.Clear()
        txtAlamatPengirimanID.Clear()
        dtpOrderDate.Value = DateTime.Now
        cmbStatusPesanan.SelectedIndex = -1 ' Clear the selected index
        txtMetodePembayaranPesanan.Clear()

    End Sub

    '======= PROMO =======
    Private Async Function LoadPromoData() As Task
        Try
            DataGridView1.DataSource = Nothing
            Dim data = Await apiClient.GetPromosAsync()
            promoList = New BindingList(Of Model_DatadanTransaksi.Promo)(data)
            DataGridView1.DataSource = promoList
            With DataGridView1
                If .Columns.Count > 0 Then
                    .Columns("id_promo").HeaderText = "ID Promo"
                    .Columns("id_promo").Width = 80

                    .Columns("nama_promo").HeaderText = "Nama Promo"
                    .Columns("nama_promo").Width = 150

                    .Columns("deskripsi").HeaderText = "Deskripsi"
                    .Columns("deskripsi").Width = 150

                    .Columns("kode").HeaderText = "Kode"
                    .Columns("kode").Width = 80

                    .Columns("diskon").HeaderText = "Diskon"
                    .Columns("diskon").Width = 60

                    .Columns("valid_dari").HeaderText = "Valid Dari"
                    .Columns("valid_dari").Width = 150

                    .Columns("valid_sampai").HeaderText = "Valid Sampai"
                    .Columns("valid_sampai").Width = 150

                    .Columns("status").HeaderText = "Status"
                    .Columns("status").Width = 80

                    .Columns("DibuatPada").HeaderText = "Dibuat Pada"
                    .Columns("DibuatPada").Width = 150

                    .Columns("DiperbaruiPada").HeaderText = "Diperbarui"
                    .Columns("DiperbaruiPada").Width = 150

                    .Columns("DihapusPada").HeaderText = "Dihapus Pada"
                    .Columns("DihapusPada").Width = 150
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Failed to retrieve promo data: " & ex.Message)
        End Try
    End Function

    Private Async Sub btnPromoInsert_Click(sender As Object, e As EventArgs) Handles btnInsertPromo.Click
        Try
            Dim newPromo As New Model_DatadanTransaksi.Promo With {
                .nama_promo = txtNamaPromo.Text,
                .deskripsi = txtDeskripsiPromo.Text,
                .kode = txtKodePromo.Text,
                .diskon = Double.Parse(txtDiskon.Text),
                .valid_dari = dtpValidDari.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"),
                .valid_sampai = dtpValidSampai.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"),
                .status = txtStatusPromo.Text
            }

            Await apiClient.CreatePromoAsync(newPromo)
            MessageBox.Show("Promo successfully inserted.", "Success")
            Await LoadPromoData()
        Catch ex As Exception
            MessageBox.Show("Failed to insert promo: " & ex.Message, "Error")
        End Try

    End Sub

    Private Async Sub btnPromoUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdatePromo.Click
        If DataGridView1.CurrentRow Is Nothing Then Return
        Dim selectedPromo = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model_DatadanTransaksi.Promo)
        If selectedPromo Is Nothing Then Return
        selectedPromo.nama_promo = txtNamaPromo.Text
        selectedPromo.deskripsi = txtDeskripsiPromo.Text
        selectedPromo.kode = txtKodePromo.Text
        selectedPromo.diskon = Double.Parse(txtDiskon.Text)
        selectedPromo.valid_dari = dtpValidDari.Value
        selectedPromo.valid_sampai = dtpValidSampai.Value
        selectedPromo.status = txtStatusPromo.Text
        Try
            Await apiClient.UpdatePromoAsync(selectedPromo)
            MessageBox.Show("Promo successfully updated.", "Success")
            Await LoadPromoData()
        Catch ex As Exception
            MessageBox.Show("Failed to update promo: " & ex.Message, "Error")
        End Try
    End Sub

    Private Async Sub btnPromoDelete_Click(sender As Object, e As EventArgs) Handles btnDeletePromo.Click
        If DataGridView1.CurrentRow Is Nothing Then Return
        Dim selectedPromo = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model_DatadanTransaksi.Promo)
        If selectedPromo Is Nothing Then Return
        Try
            Await apiClient.DeletePromoAsync(selectedPromo.id_promo)
            MessageBox.Show("Promo successfully deleted.", "Success")
            Await LoadPromoData()
        Catch ex As Exception
            MessageBox.Show("Failed to delete promo: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub btnPromoClear_Click(sender As Object, e As EventArgs) Handles btnClearPromo.Click
        txtNamaPromo.Clear()
        txtDeskripsiPromo.Clear()
        txtKodePromo.Clear()
        txtDiskon.Clear()
        txtStatusPromo.Clear()
        dtpValidDari.Value = DateTime.Now
        dtpValidSampai.Value = DateTime.Now
    End Sub

    '======= METODE PEMBAYARAN =======
    Private Async Function LoadMetodeData() As Task
        Try
            DataGridView1.DataSource = Nothing
            Dim data = Await apiClient.GetMetodePembayaranAsync()
            metodePembayaranList = New BindingList(Of Model_DatadanTransaksi.MetodePembayaran)(data)
            DataGridView1.DataSource = metodePembayaranList
            With DataGridView1
                If .Columns.Count > 0 Then
                    .Columns("id_metode_pembayaran").HeaderText = "ID Metode"
                    .Columns("id_metode_pembayaran").Width = 100

                    .Columns("metode_pembayaran").HeaderText = "Metode"
                    .Columns("metode_pembayaran").Width = 250

                    .Columns("keterangan").HeaderText = "Keterangan"
                    .Columns("keterangan").Width = 250

                    .Columns("DibuatPada").HeaderText = "Dibuat Pada"
                    .Columns("DibuatPada").Width = 150

                    .Columns("DiperbaruiPada").HeaderText = "Diperbarui"
                    .Columns("DiperbaruiPada").Width = 150

                    .Columns("DihapusPada").HeaderText = "Dihapus Pada"
                    .Columns("DihapusPada").Width = 150
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Failed to retrieve metode pembayaran data: " & ex.Message)
        End Try
    End Function

    Private Async Sub btnMetodeInsert_Click(sender As Object, e As EventArgs) Handles btnInsertPembayaran.Click
        Try
            Dim newMetode As New Model_DatadanTransaksi.MetodePembayaran With {
                .metode_pembayaran = txtMetodePembayaran.Text,
                .keterangan = txtKeterangan.Text
            }
            Await apiClient.CreateMetodePembayaranAsync(newMetode)
            MessageBox.Show("Metode pembayaran successfully inserted.", "Success")
            Await LoadMetodeData()
        Catch ex As Exception
            MessageBox.Show("Failed to insert metode pembayaran: " & ex.Message, "Error")
        End Try
    End Sub

    Private Async Sub btnMetodeUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdatePembayaran.Click
        If DataGridView1.CurrentRow Is Nothing Then Return
        Dim selectedMetode = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model_DatadanTransaksi.MetodePembayaran)
        If selectedMetode Is Nothing Then Return
        selectedMetode.metode_pembayaran = txtMetodePembayaran.Text
        selectedMetode.keterangan = txtKeterangan.Text
        Try
            Await apiClient.UpdateMetodePembayaranAsync(selectedMetode)
            MessageBox.Show("Metode pembayaran successfully updated.", "Success")
            Await LoadMetodeData()
        Catch ex As Exception
            MessageBox.Show("Failed to update metode pembayaran: " & ex.Message, "Error")
        End Try
    End Sub

    Private Async Sub btnMetodeDelete_Click(sender As Object, e As EventArgs) Handles btnDeletePembayaran.Click
        If DataGridView1.CurrentRow Is Nothing Then Return
        Dim selectedMetode = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model_DatadanTransaksi.MetodePembayaran)
        If selectedMetode Is Nothing Then Return
        Try
            Await apiClient.DeleteMetodePembayaranAsync(selectedMetode.id_metode_pembayaran)
            MessageBox.Show("Metode pembayaran successfully deleted.", "Success")
            Await LoadMetodeData()
        Catch ex As Exception
            MessageBox.Show("Failed to delete metode pembayaran: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub btnMetodeClear_Click(sender As Object, e As EventArgs) Handles btnClearPembayaran.Click
        txtMetodePembayaran.Clear()
        txtKeterangan.Clear()
    End Sub

    '======= NOTIFIKASI =======
    Private Async Function LoadNotifikasiData() As Task
        Try
            DataGridView1.DataSource = Nothing
            Dim data = Await apiClient.GetAllNotifikasiAsync()
            notifikasiList = New BindingList(Of Model_DatadanTransaksi.Notifikasi)(data)
            DataGridView1.DataSource = notifikasiList

            With DataGridView1
                If .Columns.Count > 0 Then
                    .Columns("id_notifikasi").HeaderText = "ID Notif"
                    .Columns("id_notifikasi").Width = 80

                    .Columns("id_pesanan").HeaderText = "ID Pesanan"
                    .Columns("id_pesanan").Width = 80

                    .Columns("id_pengirim").HeaderText = "ID Pengirim"
                    .Columns("id_pengirim").Width = 80

                    .Columns("id_penerima").HeaderText = "ID Penerima"
                    .Columns("id_penerima").Width = 80

                    .Columns("jenis_pengirim").HeaderText = "Jenis Pengirim"
                    .Columns("jenis_pengirim").Width = 100

                    .Columns("jenis_penerima").HeaderText = "Jenis Penerima"
                    .Columns("jenis_penerima").Width = 100

                    .Columns("judul").HeaderText = "Judul"
                    .Columns("judul").Width = 150

                    .Columns("pesan").HeaderText = "Pesan"
                    .Columns("pesan").Width = 250

                    .Columns("jenis_notif").HeaderText = "Jenis Notif"
                    .Columns("jenis_notif").Width = 100

                    .Columns("status").HeaderText = "Status"
                    .Columns("status").Width = 150

                    .Columns("DibuatPada").HeaderText = "Dibuat Pada"
                    .Columns("DibuatPada").Width = 150

                    .Columns("DiperbaruiPada").HeaderText = "Diperbarui"
                    .Columns("DiperbaruiPada").Width = 150

                    .Columns("DihapusPada").HeaderText = "Dihapus Pada"
                    .Columns("DihapusPada").Width = 150
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Failed to retrieve notifikasi data: " & ex.Message)
        End Try
    End Function
    Private Async Sub btnNotifikasiInsert_Click(sender As Object, e As EventArgs) Handles btnInsertNotifikasi.Click
        Try
            Dim newNotifikasi As New Model_DatadanTransaksi.Notifikasi With {
            .id_pesanan = If(String.IsNullOrWhiteSpace(txtPesanan.Text), Nothing, ULong.Parse(txtPesanan.Text)),
            .id_pengirim = ULong.Parse(txtPengirim.Text),         ' <-- ID admin
            .id_penerima = ULong.Parse(txtPenerima.Text),         ' <-- ID pelanggan/kurir
            .jenis_pengirim = "admin",                            ' <-- atau dari input
            .jenis_penerima = "pelanggan",                        ' <-- atau "kurir"
            .judul = txtJudul.Text,
            .pesan = txtPesan.Text,
            .jenis_notif = txtJenisNotif.Text,
            .status = txtStatusNotifikasi.Text
        }

            Await apiClient.CreateNotifikasiAsync(newNotifikasi)
            MessageBox.Show("Notifikasi berhasil ditambahkan.", "Success")

            Await LoadNotifikasiData()
        Catch ex As Exception
            MessageBox.Show("Gagal menambahkan notifikasi: " & ex.Message, "Error")
        End Try
    End Sub

    Private Async Sub btnNotifikasiUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdateNotifikasi.Click
        If DataGridView1.CurrentRow Is Nothing Then Return

        Dim selectedNotifikasi = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model_DatadanTransaksi.Notifikasi)
        If selectedNotifikasi Is Nothing Then Return

        Try
            selectedNotifikasi.id_pesanan = If(String.IsNullOrWhiteSpace(txtPesanan.Text), Nothing, ULong.Parse(txtPesanan.Text))
            selectedNotifikasi.id_pengirim = ULong.Parse(txtPengirim.Text)
            selectedNotifikasi.id_penerima = ULong.Parse(txtPenerima.Text)
            selectedNotifikasi.jenis_pengirim = "admin" ' Atau dari input
            selectedNotifikasi.jenis_penerima = "pelanggan" ' Atau "kurir", sesuai kebutuhan
            selectedNotifikasi.judul = txtJudul.Text
            selectedNotifikasi.pesan = txtPesan.Text
            selectedNotifikasi.jenis_notif = txtJenisNotif.Text
            selectedNotifikasi.status = txtStatusNotifikasi.Text

            Await apiClient.UpdateNotifikasiAsync(selectedNotifikasi)
            MessageBox.Show("Notifikasi marked as read.", "Success")
            Await LoadNotifikasiData()
        Catch ex As Exception
            MessageBox.Show("Failed to update notifikasi: " & ex.Message, "Error")
        End Try
    End Sub

    Private Async Sub btnNotifikasiDelete_Click(sender As Object, e As EventArgs) Handles btnDeleteNotifikasi.Click
        If DataGridView1.CurrentRow Is Nothing Then Return

        Dim selectedNotifikasi = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model_DatadanTransaksi.Notifikasi)
        If selectedNotifikasi Is Nothing Then Return

        Try
            Await apiClient.DeleteNotifikasiAsync(selectedNotifikasi.id_notifikasi)
            MessageBox.Show("Notifikasi successfully deleted.", "Success")
            Await LoadNotifikasiData()
        Catch ex As Exception
            MessageBox.Show("Failed to delete notifikasi: " & ex.Message, "Error")
        End Try
    End Sub


    Private Sub btnNotifikasiClear_Click(sender As Object, e As EventArgs) Handles btnClearNotifikasi.Click
        txtPesanan.Clear()
        txtPengirim.Clear()
        txtPenerima.Clear()
        txtJenisPengirim.Clear()
        txtJenisPenerima.Clear()
        txtJudul.Clear()
        txtPesan.Clear()
        txtJenisNotif.Clear()
        txtStatusNotifikasi.Clear()
    End Sub

    ' Panel Show and navigation
    Private Async Sub btnPizza_Click(sender As Object, e As EventArgs) Handles btnPizza.Click
        ShowPanel(PanelPizza, GroupBoxPizza)
        Await LoadPizzaData()
    End Sub
    Private Async Sub btnMenuOrder_Click(sender As Object, e As EventArgs) Handles btnPesanan.Click
        ShowPanel(PanelPesanan, GroupBoxPesanan)
        Await LoadPesananData()
    End Sub
    Private Async Sub btnPromo_Click(sender As Object, e As EventArgs) Handles btnPromo.Click
        ShowPanel(PanelPromo, GroupBoxPromo)
        Await LoadPromoData()
    End Sub
    Private Async Sub btnMetode_Click(sender As Object, e As EventArgs) Handles btnMetodePembayaran.Click
        ShowPanel(PanelMetodePembayaran, GroupBoxPembayaran)
        Await LoadMetodeData()
    End Sub
    Private Async Sub btnNotifikasi_Click(sender As Object, e As EventArgs) Handles btnNotifikasi.Click
        ShowPanel(PanelNotifikasi, GroupBoxNotifikasi, GroupBoxButtonNotifikasi)
        Await LoadNotifikasiData()

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.CurrentRow Is Nothing Then Return
        If PanelPizza.Visible Then
            Dim pizza = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model_DatadanTransaksi.Pizza)
            If pizza IsNot Nothing Then
                txtPizzaName.Text = pizza.nama
                txtPizzaDesc.Text = pizza.deskripsi
                txtPizzaPrice.Text = pizza.harga.ToString()
                txtPizzaImage.Text = pizza.url_gambar
                txtPizzaStatus.Text = pizza.status
            End If
        ElseIf PanelPesanan.Visible Then
            Dim order = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model_DatadanTransaksi.Pesanan)
            If order IsNot Nothing Then
                txtCustomerId.Text = order.id_pelanggan.ToString()
                txtPromoID.Text = order.id_promo.ToString()
                txtKurirID.Text = order.id_kurir.ToString()
                txtAlamatPengirimanID.Text = order.id_alamat_pengiriman.ToString()
                dtpOrderDate.Value = order.tanggal_pesan
                cmbStatusPesanan.SelectedItem = order.status
            End If
        ElseIf PanelPromo.Visible Then
            Dim promo = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model_DatadanTransaksi.Promo)
            If promo IsNot Nothing Then
                txtNamaPromo.Text = promo.nama_promo
                txtDeskripsiPromo.Text = promo.deskripsi
                txtKodePromo.Text = promo.kode
                txtDiskon.Text = promo.diskon.ToString()
                dtpValidDari.Value = promo.valid_dari
                dtpValidSampai.Value = promo.valid_sampai
                txtStatusPromo.Text = promo.status
            End If
        ElseIf PanelMetodePembayaran.Visible Then
            Dim metode = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model_DatadanTransaksi.MetodePembayaran)
            If metode IsNot Nothing Then
                txtMetodePembayaran.Text = metode.metode_pembayaran
                txtKeterangan.Text = metode.keterangan
            End If
        ElseIf PanelNotifikasi.Visible Then
            Dim notif = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model_DatadanTransaksi.Notifikasi)
            If notif IsNot Nothing Then
                txtPesanan.Text = notif.id_pesanan.ToString()
                txtPengirim.Text = notif.id_pengirim.ToString()
                txtPenerima.Text = notif.id_penerima.ToString()
                txtJenisPengirim.Text = notif.jenis_pengirim
                txtJenisPenerima.Text = notif.jenis_penerima
                txtJudul.Text = notif.judul
                txtPesan.Text = notif.pesan
                txtStatusNotifikasi.Text = notif.status
                txtJenisNotif.Text = notif.jenis_notif
            End If
        End If
    End Sub

    Private Sub ShowPanel(targetPanel As Panel, targetGroupBox As GroupBox, Optional targetButtonGroup As GroupBox = Nothing)
        PanelPizza.Visible = False : GroupBoxPizza.Visible = False
        PanelPesanan.Visible = False : GroupBoxPesanan.Visible = False
        PanelPromo.Visible = False : GroupBoxPromo.Visible = False
        PanelMetodePembayaran.Visible = False : GroupBoxPembayaran.Visible = False
        PanelNotifikasi.Visible = False : GroupBoxNotifikasi.Visible = False : GroupBoxButtonNotifikasi.Visible = False

        targetPanel.Visible = True
        targetGroupBox.Visible = True
        If targetButtonGroup IsNot Nothing Then
            targetButtonGroup.Visible = True
        End If

        targetPanel.BringToFront()
        targetGroupBox.BringToFront()
        If targetButtonGroup IsNot Nothing Then
            targetButtonGroup.Visible = True
        End If
    End Sub

    Private Sub btnKembaliForm1_Click(sender As Object, e As EventArgs) Handles btnKembaliForm1.Click
        Dim form1 As New Form1()
        form1.Show()
        Me.Hide()
    End Sub

    Private Sub btnKeForm3_Click(sender As Object, e As EventArgs) Handles btnKeForm3.Click
        Dim form3 As New FormMonitoring_dan_laporan()
        form3.Show()
        Me.Hide()
    End Sub
End Class