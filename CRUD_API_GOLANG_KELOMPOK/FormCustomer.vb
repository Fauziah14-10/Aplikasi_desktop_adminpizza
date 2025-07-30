Imports System.ComponentModel
Imports System.Net.Http
Imports System.Linq
Imports CRUD_API_GOLANG_KELOMPOK.Model
Imports CRUD_API_GOLANG_KELOMPOK.Model_DatadanTransaksi
Imports CRUD_API_GOLANG_KELOMPOK.Model_Monitoringdata
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1
    Private apiClient As New ApiClient()
    Private apiClientTransaksi As New Api_MenudanTransaksi_Client()
    Private apiClientMonitoring As New ApiMonitoringClient()
    Private adminList As New BindingList(Of Admin)
    Private pelangganList As New BindingList(Of Pelanggan)
    Private pizzaList As New BindingList(Of Pizza)
    Private transaksiList As New BindingList(Of Transaksi)
    Private ulasanList As New BindingList(Of Ulasan)
    Private kurirList As New BindingList(Of Kurir)
    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblUsername.Text = FormLogin.LoggedInAdminName

        ' === Styling Umum ===
        lblUsername.Font = New Font("Segoe UI", 12, FontStyle.Italic)
        lblUsername.ForeColor = Color.DarkRed
        lblUsername.AutoSize = True
        lblUsername.TextAlign = ContentAlignment.MiddleLeft

        ' === Ukuran total konten (ikon + label username) ===
        Dim spacing As Integer = 6
        Dim totalContentWidth As Integer = picUser.Width + spacing + lblUsername.Width

        ' === Posisi X agar konten berada di tengah GroupBox ===
        Dim groupWidth As Integer = GroupBoxUserInfo.Width
        Dim startX As Integer = (groupWidth - totalContentWidth) \ 2


        ' === Tetapkan lokasi relatif terhadap GroupBox ===
        picUser.Location = New Point(startX, 20)
        lblUsername.Location = New Point(picUser.Right + spacing, picUser.Top + (picUser.Height - lblUsername.Height) \ 2)



        lblUsername.TextAlign = ContentAlignment.MiddleCenter
        StyleGroupBox(GroupBoxAdmin, btnInsert, btnUpdate, btnDelete, btnClear)
        StyleGroupBox(GroupBoxPelanggan, Nothing, btnCustomerUpdate, btnCustomerDelete, btnCustomerClear)
        StyleGroupBox(GroupBoxKurir, btnInsertKurir, btnUpdateKurir, btnDeleteKurir, btnClearKurir)
        StyleSidebarButtons()

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
        GroupBoxAdmin.Dock = DockStyle.Fill
        GroupBoxPelanggan.Dock = DockStyle.Fill
        GroupBoxDashboard.Dock = DockStyle.Fill
        GroupBoxKurir.Dock = DockStyle.Fill


        PanelDashboard.Visible = True
        PanelAdmin.Visible = False
        PanelPelanggan.Visible = False
        PanelKurir.Visible = False
        GroupBoxButtonKurir.Visible = False
        PanelBottom.Visible = False


        LoadDashboard()
        Await LoadAdminData()
    End Sub

    Private Sub StyleSidebarButtons()
        Dim sidebarButtons As Button() = {btnDashboard, btnMenuAdmin, btnPelanggan, btnKurir}
        Dim buttonEmojis As String() = {"📊", "👨‍💻", "👥", "🚚"} ' Emoji untuk setiap tombol

        For i As Integer = 0 To sidebarButtons.Length - 1
            Dim btn As Button = sidebarButtons(i)
            With btn
                .Text = $"{buttonEmojis(i)}  {btn.Text}" ' Gabungkan emoji + teks
                .FlatStyle = FlatStyle.Flat
                .FlatAppearance.BorderSize = 0
                .BackColor = Color.Tan
                .ForeColor = Color.FromArgb(102, 51, 0)
                .Font = New Font("Segoe UI Semibold", 11, FontStyle.Bold)
                .TextAlign = ContentAlignment.MiddleLeft
                .Cursor = Cursors.Hand
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

    Private Sub picUser_Paint(sender As Object, e As PaintEventArgs)
        Dim gp As New Drawing2D.GraphicsPath()
        gp.AddEllipse(0, 0, picUser.Width - 1, picUser.Height - 1)
        picUser.Region = New Region(gp)
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

            If btnInsert IsNot Nothing Then
                btnInsert.BackColor = Color.ForestGreen
                btnInsert.ForeColor = Color.White
                btnInsert.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            End If
        Next
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

    '======= DASHBOARD =======
    Private Async Sub LoadDashboard()
        Try
            ' === Tampilan Header Dashboard ===
            PanelDashboard.BackColor = ColorTranslator.FromHtml("#F0E4C1")

            LabelDashboard.Font = New Font("Georgia", 24, FontStyle.Bold)
            LabelDashboard.ForeColor = ColorTranslator.FromHtml("#6E2C00")
            LabelDashboard.Text = "Selamat Datang " & FormLogin.LoggedInAdminName

            ' === Styling Label Statistik Dashboard ===
            Dim labelFont As New Font("Segoe UI", 14, FontStyle.Bold)
            lblMenuPizza.Text = "🍕Jumlah Menu Pizza"
            lblMenuPizza.Font = labelFont
            lblMenuPizza.ForeColor = ColorTranslator.FromHtml("#4B2E2E")
            lblJumlahMenu.Font = labelFont
            lblJumlahMenu.ForeColor = ColorTranslator.FromHtml("#D35400")
            lblJumlahMenu.Width = 50
            lblJumlahMenu.TextAlign = ContentAlignment.MiddleRight


            lblJumlahAdmin.Text = "👥Jumlah Admin"
            lblJumlahAdmin.Font = labelFont
            lblJumlahAdmin.ForeColor = ColorTranslator.FromHtml("#4B2E2E")
            lbladminJumlah.Font = labelFont
            lbladminJumlah.ForeColor = ColorTranslator.FromHtml("#D35400")
            lblJumlahAdmin.Width = 50
            lblJumlahAdmin.TextAlign = ContentAlignment.MiddleRight



            lblPesanan.Text = "📃Jumlah Pesanan"
            lblPesanan.Font = labelFont
            lblPesanan.ForeColor = ColorTranslator.FromHtml("#4B2E2E")
            lblPesananHariIni.Font = labelFont
            lblPesananHariIni.ForeColor = ColorTranslator.FromHtml("#E67E22")
            lblPesananHariIni.Width = 50
            lblPesananHariIni.TextAlign = ContentAlignment.MiddleRight

            lblUlasan.Text = "💬Jumlah Ulasan Masuk"
            lblUlasan.Font = labelFont
            lblUlasan.ForeColor = ColorTranslator.FromHtml("#4B2E2E")
            lblUlasanMasuk.Font = labelFont
            lblUlasanMasuk.ForeColor = ColorTranslator.FromHtml("#D35400")
            lblUlasanMasuk.Width = 50
            lblUlasanMasuk.TextAlign = ContentAlignment.MiddleRight

            lblRiwayatLogin.Font = New Font("Segoe UI", 16, FontStyle.Bold)
            lblRiwayatLogin.ForeColor = ColorTranslator.FromHtml("#4B2E2E")
            'lblRiwayatLogin.TextAlign = ContentAlignment.MiddleLeft'

            ' === Nama & Waktu Login
            Dim waktuLogin As String = DateTime.Now.ToString("HH:mm") & " WIB"
            lblnameAdmin.Text = "- " & FormLogin.LoggedInAdminName & " (" & waktuLogin & ")"
            lblnameAdmin.Font = New Font("Segoe UI", 12, FontStyle.Italic)
            lblnameAdmin.ForeColor = ColorTranslator.FromHtml("#6E2C00")
            lblnameAdmin.TextAlign = ContentAlignment.MiddleCenter

            ' === Riwayat Login Sebelumnya ===
            lblLastLogin.Font = New Font("Segoe UI", 10, FontStyle.Regular)
            lblLastLogin.ForeColor = ColorTranslator.FromHtml("#7B241C") ' Warna merah coklat

            If Not String.IsNullOrEmpty(ClassLoginHistory.LastAdminName) Then
                lblLastLogin.Text = "🕒 Login sebelumnya oleh " & ClassLoginHistory.LastAdminName &
                        " (" & ClassLoginHistory.LastLoginTime & ")"
                lblLastLogin.Visible = True
            Else
                lblLastLogin.Visible = False
            End If

            ' === Ambil Data dari API
            Dim pizzaList = Await apiClientTransaksi.GetPizzasAsync()
            Dim adminList = Await apiClient.GetAdminsAsync()
            Dim PesananList = Await apiClientTransaksi.GetPesananAsync()
            Dim transaksiData = Await apiClientMonitoring.GetTransaksiAsync()
            If transaksiData Is Nothing Then Return

            Dim ulasanList = Await apiClientMonitoring.GetUlasanAsync()

            ' === Validasi & Hitung Data Statistik
            transaksiList = New BindingList(Of Transaksi)(transaksiData) ' ✅ Simpan di properti global
            lblJumlahMenu.Text = If(pizzaList IsNot Nothing, pizzaList.Count.ToString(), "0")
            lbladminJumlah.Text = If(adminList IsNot Nothing, adminList.Count.ToString(), "0")
            lblPesananHariIni.Text = If(PesananList IsNot Nothing, PesananList.Count.ToString(), "0")
            lblUlasanMasuk.Text = If(ulasanList IsNot Nothing, ulasanList.Count.ToString(), "0")

            Dim transaksiListPlain As New List(Of Transaksi)(transaksiData)

            Dim today = Date.Today
            ' Simpan transaksi hari ini sebagai list
            Dim transaksiHariIni = transaksiListPlain.
    Where(Function(t) t.tanggal_bayar.HasValue AndAlso
                     t.tanggal_bayar.Value.ToLocalTime().Date = today).
    ToList()


            ' Tampilkan log
            Console.WriteLine("Tanggal Hari Ini: " & today.ToString("yyyy-MM-dd"))
            For Each t In transaksiHariIni
                Console.WriteLine("Transaksi Hari Ini: " & t.id_transaksi & " pada " & t.tanggal_bayar)
            Next

            ' Set ke label
            lblPesananHariIni.Text = transaksiHariIni.Count.ToString()


            ' Prepare the chart
            ChartPenjualan.Series.Clear()
            ChartPenjualan.ChartAreas.Clear()
            ChartPenjualan.ChartAreas.Add("MainArea")
            ChartPenjualan.ChartAreas(0).BackColor = Color.WhiteSmoke
            ChartPenjualan.Titles.Clear()
            ChartPenjualan.Titles.Add("Daily Sales Chart")
            ChartPenjualan.Titles(0).Font = New Font("Georgia", 14, FontStyle.Bold)
            ChartPenjualan.ChartAreas(0).AxisX.Title = "Date"
            ChartPenjualan.ChartAreas(0).AxisY.Title = "Order Count"

            If transaksiListPlain IsNot Nothing AndAlso transaksiListPlain.Any() Then
                Dim groupedData = transaksiListPlain.
        Where(Function(t) t.tanggal_bayar.HasValue).
        GroupBy(Function(t) t.tanggal_bayar.Value.Date).
        Select(Function(g) New With {
            .Date = g.Key,
            .Count = g.Count()
        }).
        OrderBy(Function(x) x.Date).
        ToList()

                Dim series = New DataVisualization.Charting.Series("Sales")
                series.ChartType = DataVisualization.Charting.SeriesChartType.Column
                series.Color = Color.OrangeRed

                For Each item In groupedData
                    series.Points.AddXY(item.Date.ToShortDateString(), item.Count)
                Next

                ChartPenjualan.Series.Add(series)
                ChartPenjualan.Invalidate()
            End If

            ' Dummy data (opsional, bisa dihapus jika tidak diperlukan)
            Dim testSeries = New DataVisualization.Charting.Series("Income")
            testSeries.ChartType = DataVisualization.Charting.SeriesChartType.Column
            testSeries.Points.AddXY("2025-07-10", 3)
            testSeries.Points.AddXY("2025-07-11", 5)
            ChartPenjualan.Series.Add(testSeries)

        Catch ex As Exception
            MessageBox.Show("Failed to load dashboard data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    '======= ADMIN =======
    Private Async Function LoadAdminData() As Task
        Try
            DataGridView1.DataSource = Nothing
            Dim data = Await apiClient.GetAdminsAsync()
            adminList = New BindingList(Of Model.Admin)(data)
            DataGridView1.DataSource = adminList
            With DataGridView1
                If .Columns.Count > 0 Then
                    .Columns("id_admin").HeaderText = "ID Admin"
                    .Columns("id_admin").Width = 80

                    .Columns("nama").HeaderText = "Nama"
                    .Columns("nama").Width = 150

                    .Columns("email").HeaderText = "Email"
                    .Columns("email").Width = 150

                    .Columns("password").HeaderText = "Password"
                    .Columns("password").Width = 90

                    .Columns("status").HeaderText = "Status"
                    .Columns("status").Width = 90

                    .Columns("DibuatPada").HeaderText = "Dibuat Pada"
                    .Columns("DibuatPada").Width = 150

                    .Columns("DiperbaruiPada").HeaderText = "Diperbarui"
                    .Columns("DiperbaruiPada").Width = 150

                    .Columns("DihapusPada").HeaderText = "Dihapus Pada"
                    .Columns("DihapusPada").Width = 150


                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Failed to retrieve admin data: " & ex.Message)
        End Try
    End Function

    Private Async Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Try
            Dim newAdmin As New Model.Admin With {
                .nama = txtNama.Text,
                .email = txtEmail.Text,
                .password = txtPassword.Text,
                .status = "aktif"
            }
            Await apiClient.CreateAdminAsync(newAdmin)
            MessageBox.Show("Admin has been successfully inserted.", "Success")
            Await LoadAdminData()
        Catch ex As Exception
            MessageBox.Show("Failed to insert admin: " & ex.Message, "Error")
        End Try
    End Sub

    Private Async Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If DataGridView1.CurrentRow Is Nothing Then Return
        Dim selectedAdmin = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model.Admin)
        If selectedAdmin Is Nothing Then Return
        selectedAdmin.nama = txtNama.Text
        selectedAdmin.email = txtEmail.Text
        selectedAdmin.password = txtPassword.Text
        selectedAdmin.status = "aktif"
        Try
            Await apiClient.UpdateAdminAsync(selectedAdmin)
            MessageBox.Show("Admin has been successfully updated.", "Success")
            Await LoadAdminData()
        Catch ex As Exception
            MessageBox.Show("Failed to update admin: " & ex.Message, "Error")
        End Try
    End Sub

    Private Async Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DataGridView1.CurrentRow Is Nothing Then Return
        Dim selectedAdmin = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model.Admin)
        If selectedAdmin Is Nothing Then Return
        Try
            Await apiClient.DeleteAdminAsync(selectedAdmin.id_admin)
            MessageBox.Show("Admin has been successfully deleted.", "Success")
            Await LoadAdminData()
        Catch ex As Exception
            MessageBox.Show("Failed to delete admin: " & ex.Message, "Error")
        End Try
    End Sub

    '======= PELANGGAN =======
    Private Async Function LoadPelangganData() As Task
        Try
            DataGridView1.DataSource = Nothing
            Dim data = Await apiClient.GetPelangganAsync()
            pelangganList = New BindingList(Of Model.Pelanggan)(data)
            DataGridView1.DataSource = pelangganList
            With DataGridView1
                If .Columns.Count > 0 Then
                    .Columns("id_pelanggan").HeaderText = "ID Pelanggan"
                    .Columns("id_pelanggan").Width = 80

                    .Columns("nama").HeaderText = "Nama"
                    .Columns("nama").Width = 150

                    .Columns("email").HeaderText = "Email"
                    .Columns("email").Width = 150

                    .Columns("password").HeaderText = "Password"
                    .Columns("password").Width = 100

                    .Columns("no_hp").HeaderText = "No HP"
                    .Columns("no_hp").Width = 100

                    .Columns("tanggal_lahir").HeaderText = "Tanggal Lahir"
                    .Columns("tanggal_lahir").Width = 150

                    .Columns("status").HeaderText = "Status"
                    .Columns("status").Width = 100

                    .Columns("DibuatPada").HeaderText = "Dibuat Pada"
                    .Columns("DibuatPada").Width = 100

                    .Columns("DiperbaruiPada").HeaderText = "Diperbarui"
                    .Columns("DiperbaruiPada").Width = 100

                    .Columns("DihapusPada").HeaderText = "Dihapus Pada"
                    .Columns("DihapusPada").Width = 100
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Failed to retrieve pelanggan data: " & ex.Message)
        End Try
    End Function

    Private Async Sub btnCustomerUpdate_Click(sender As Object, e As EventArgs) Handles btnCustomerUpdate.Click
        If DataGridView1.CurrentRow Is Nothing Then Return

        Dim selectedPelanggan = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model.Pelanggan)
        If selectedPelanggan Is Nothing Then Return

        ' Perbarui data dari form input
        selectedPelanggan.nama = txtcusname.Text
        selectedPelanggan.email = txtcusemail.Text
        selectedPelanggan.tanggal_lahir = dtpTanggalLahir.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")
        selectedPelanggan.password = txtcuspassword.Text
        selectedPelanggan.no_hp = txtcusphone.Text
        selectedPelanggan.status = "aktif"

        Try
            Dim response = Await apiClient.UpdatePelangganAsync(selectedPelanggan)

            If response.IsSuccessStatusCode Then
                MessageBox.Show("Customer has been successfully updated.", "Success")
                Await LoadPelangganData()
            Else
                Dim errorContent = Await response.Content.ReadAsStringAsync()
                MessageBox.Show($"Failed to update customer: {response.StatusCode} - {errorContent}", "Error")
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to update customer: " & ex.Message, "Error")
        End Try

    End Sub

    Private Async Sub btnCustomerDelete_Click(sender As Object, e As EventArgs) Handles btnCustomerDelete.Click
        If DataGridView1.CurrentRow Is Nothing Then Return

        Dim selectedPelanggan = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model.Pelanggan)
        If selectedPelanggan Is Nothing Then Return

        Dim id_admin = FormLogin.currentAdminId ' atau variabel global kamu

        ' (Opsional) konfirmasi
        If MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If

        Try
            Await apiClient.DeletePelangganAsync(selectedPelanggan.id_pelanggan, id_admin)
            MessageBox.Show("Customer has been successfully deleted.", "Success")
            Await LoadPelangganData()
        Catch ex As Exception
            MessageBox.Show("Failed to delete customer: " & ex.Message, "Error")
        End Try
    End Sub


    '======= KURIR =======
    Private Async Function LoadKurirData() As Task
        Try
            DataGridView1.DataSource = Nothing
            Dim data = Await apiClient.GetKurirsAsync()
            kurirList = New BindingList(Of Model.Kurir)(data)

            DataGridView1.DataSource = kurirList
            With DataGridView1
                If .Columns.Count > 0 Then
                    .Columns("id_kurir").HeaderText = "ID Kurir"
                    .Columns("id_kurir").Width = 80

                    .Columns("nama").HeaderText = "Nama"
                    .Columns("nama").Width = 150

                    .Columns("email").HeaderText = "Email"
                    .Columns("email").Width = 150

                    .Columns("password").HeaderText = "Password"
                    .Columns("password").Width = 100

                    .Columns("no_hp").HeaderText = "No HP"
                    .Columns("no_hp").Width = 100

                    .Columns("no_plat").HeaderText = "No Plat"
                    .Columns("no_plat").Width = 100

                    .Columns("foto_profil").HeaderText = "Foto Profil"
                    .Columns("foto_profil").Width = 150

                    .Columns("status").HeaderText = "Status"
                    .Columns("status").Width = 100

                    .Columns("latitude").Visible = False
                    .Columns("longitude").Visible = False
                    .Columns("lokasi_terakhir_update").Visible = False

                    .Columns("DibuatPada").HeaderText = "Dibuat Pada"
                    .Columns("DibuatPada").Width = 100

                    .Columns("DiperbaruiPada").HeaderText = "Diperbarui"
                    .Columns("DiperbaruiPada").Width = 100

                    .Columns("DihapusPada").HeaderText = "Dihapus Pada"
                    .Columns("DihapusPada").Width = 100

                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Failed to retrieve kurir data: " & ex.Message)
        End Try
    End Function

    Private Async Sub btnInsertKurir_Click(sender As Object, e As EventArgs) Handles btnInsertKurir.Click
        Try
            Dim lat As Double = 0
            Dim lng As Double = 0

            If Not Double.TryParse(txtLatitude.Text, lat) Then
                MessageBox.Show("Latitude harus berupa angka.", "Error")
                Return
            End If
            If Not Double.TryParse(txtLongitude.Text, lng) Then
                MessageBox.Show("Longitude harus berupa angka.", "Error")
                Return
            End If

            Dim newKurir As New Model.Kurir With {
            .nama = txtNamaKurir.Text,
            .email = txtEmailKurir.Text,
            .password = txtPasswordKurir.Text,
            .no_hp = txtHpKurir.Text,
            .no_plat = txtPlat.Text,
            .foto_profil = txtProfil.Text,
            .status = txtStatusKurir.Text,
            .latitude = lat,
            .longitude = lng
        }

            Await apiClient.CreateKurirAsync(newKurir)
            MessageBox.Show("Courier inserted successfully.", "Success")
            Await LoadKurirData()

        Catch ex As Exception
            MessageBox.Show("Failed to insert courier: " & ex.Message, "Error")
        End Try
    End Sub


    Private Async Sub btnUpdateKurir_Click(sender As Object, e As EventArgs) Handles btnUpdateKurir.Click
        If DataGridView1.CurrentRow Is Nothing Then
            MessageBox.Show("Please select the courier you wish to update.", "Info")
            Return
        End If

        Dim selectedKurir = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model.Kurir)
        If selectedKurir Is Nothing Then
            MessageBox.Show("Courier data is invalid.", "Error")
            Return
        End If

        ' Validasi latitude & longitude
        Dim lat As Double
        Dim lng As Double
        If Not Double.TryParse(txtLatitude.Text, lat) Then
            MessageBox.Show("Latitude must be a decimal number.", "Error")
            Return
        End If
        If Not Double.TryParse(txtLongitude.Text, lng) Then
            MessageBox.Show("Longitude must be a decimal number.", "Error")
            Return
        End If

        ' Isi ulang data kurir
        selectedKurir.nama = txtNamaKurir.Text
        selectedKurir.email = txtEmailKurir.Text
        selectedKurir.password = txtPasswordKurir.Text
        selectedKurir.no_hp = txtHpKurir.Text
        selectedKurir.no_plat = txtPlat.Text
        selectedKurir.foto_profil = txtProfil.Text
        selectedKurir.status = txtStatusKurir.Text
        selectedKurir.latitude = lat
        selectedKurir.longitude = lng

        Try
            Await apiClient.UpdateKurirAsync(selectedKurir)
            MessageBox.Show("Courier data successfully updated.", "Success")
            Await LoadKurirData()
        Catch ex As Exception
            MessageBox.Show("Failed to update courier data: " & ex.Message, "Error")
        End Try
    End Sub


    Private Async Sub btnDeleteKurir_Click(sender As Object, e As EventArgs) Handles btnDeleteKurir.Click
        If DataGridView1.CurrentRow Is Nothing Then
            MessageBox.Show("Please select the courier you want to delete..", "Info")
            Return
        End If

        Dim selectedKurir = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model.Kurir)
        If selectedKurir Is Nothing Then
            MessageBox.Show("Courier data is invalid.", "Error")
            Return
        End If

        Dim result = MessageBox.Show("Are you sure you want to delete this courier?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Try
                Await apiClient.DeleteKurirAsync(selectedKurir.id_kurir)
                MessageBox.Show("Courier data successfully deleted.", "Success")
                Await LoadKurirData()
            Catch ex As Exception
                MessageBox.Show("Failed to delete courier: " & ex.Message, "Error")
            End Try
        End If
    End Sub



    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtNama.Clear()
        txtEmail.Clear()
        txtPassword.Clear()
        txtAdmintype.Clear()
    End Sub
    Private Sub btnCustomerClear_Click(sender As Object, e As EventArgs) Handles btnCustomerClear.Click
        txtcusname.Clear()
        txtcusemail.Clear()
        txtcuspassword.Clear()
        txtcusphone.Clear()
        txtStatusPelanggan.Clear()
    End Sub

    Private Sub btnKurirClear_Click(sender As Object, e As EventArgs) Handles btnClearKurir.Click
        txtNamaKurir.Clear()
        txtEmailKurir.Clear()
        txtPasswordKurir.Clear()
        txtHpKurir.Clear()
        txtPlat.Clear()
        txtProfil.Clear()
        txtStatusKurir.Clear()
        txtLatitude.Clear() ' Assuming you have a TextBox for latitude
        txtLongitude.Clear() ' Assuming you have a TextBox for longitude

    End Sub


    '================ MENU SWITCH ================'
    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        ShowPanel(PanelDashboard, GroupBoxDashboard)
        LoadDashboard()
    End Sub
    Private Async Sub btnMenuAdmin_Click(sender As Object, e As EventArgs) Handles btnMenuAdmin.Click
        ShowPanel(PanelAdmin, GroupBoxAdmin)
        Await LoadAdminData()
    End Sub

    Private Async Sub btnMenuPelanggan_Click(sender As Object, e As EventArgs) Handles btnPelanggan.Click
        ShowPanel(PanelPelanggan, GroupBoxPelanggan)
        Await LoadPelangganData()
    End Sub
    Private Async Sub btnKurir_Click(sender As Object, e As EventArgs) Handles btnKurir.Click
        ShowPanel(PanelKurir, GroupBoxKurir, GroupBoxButtonKurir)
        Await LoadKurirData()
    End Sub

    '================ SELECTION SHARED ================'
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.CurrentRow Is Nothing Then Return

        If PanelAdmin.Visible Then
            Dim admin = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model.Admin)
            If admin IsNot Nothing Then
                txtNama.Text = admin.nama
                txtEmail.Text = admin.email
                txtPassword.Text = admin.password
                txtAdmintype.Text = admin.status
            End If
        ElseIf PanelPelanggan.Visible Then
            Dim customer = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model.Pelanggan)
            If customer IsNot Nothing Then
                txtcusname.Text = customer.nama
                txtcusemail.Text = customer.email
                txtcuspassword.Text = customer.password
                txtcusphone.Text = customer.no_hp
                txtStatusPelanggan.Text = customer.status
            End If
        ElseIf PanelKurir.Visible Then
            Dim kurir = TryCast(DataGridView1.CurrentRow.DataBoundItem, Model.Kurir)
            If kurir IsNot Nothing Then
                txtNamaKurir.Text = kurir.nama
                txtEmailKurir.Text = kurir.email
                txtPasswordKurir.Text = kurir.password
                txtHpKurir.Text = kurir.no_hp
                txtPlat.Text = kurir.no_plat
                txtProfil.Text = kurir.foto_profil
                txtStatusKurir.Text = kurir.status
                txtLatitude.Text = kurir.latitude.ToString() ' Assuming you have a TextBox for latitude
                txtLongitude.Text = kurir.longitude.ToString() ' Assuming you have a TextBox for longitude
            End If
        End If
    End Sub

    Private Sub ShowPanel(targetPanel As Panel, targetGroupBox As GroupBox, Optional targetButtonGroup As GroupBox = Nothing)
        PanelDashboard.Visible = False
        PanelAdmin.Visible = False
        GroupBoxAdmin.Visible = False
        PanelPelanggan.Visible = False
        GroupBoxPelanggan.Visible = False
        PanelKurir.Visible = False
        GroupBoxKurir.Visible = False
        GroupBoxButtonKurir.Visible = False

        If targetPanel Is PanelDashboard Then
            PanelBottom.Visible = False ' Ganti dengan nama panel bawah Anda
        Else
            PanelBottom.Visible = True ' Tampilkan panel bawah untuk menu lainnya
        End If

        targetPanel.Visible = True
        targetGroupBox.Visible = True
        If targetButtonGroup IsNot Nothing Then
            targetButtonGroup.Visible = True
        End If


        targetPanel.BringToFront()
        targetGroupBox.BringToFront()
        If targetButtonGroup IsNot Nothing Then
            targetButtonGroup.BringToFront()
        End If

    End Sub

    Private Sub btnlogout_Click(sender As Object, e As EventArgs) Handles btnlogout.Click
        Dim confirm As DialogResult = MessageBox.Show(
       "Are you sure you want to logout?",
       "Logout Confirmation",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question,
       MessageBoxDefaultButton.Button2
   )
        If confirm = DialogResult.Yes Then
            MessageBox.Show("You have been logged out. See you next time!", "Logout Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            FormLogin.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles PanelHeader.Paint

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnNotifikasi.Click
        Dim frm3 As New FormMonitoring_dan_laporan()
        frm3.Show()
        Me.Hide()

    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        Dim frm2 As New FormTransaksi__Menu__Promo()
        frm2.Show()
        Me.Hide()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

End Class