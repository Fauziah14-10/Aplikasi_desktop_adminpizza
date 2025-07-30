<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMonitoring_dan_laporan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PanelSidebar = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.btnKembaliForm2 = New System.Windows.Forms.Button()
        Me.btnRiwayatPesanan = New System.Windows.Forms.Button()
        Me.btnAlamatPengiriman = New System.Windows.Forms.Button()
        Me.btnRiwayatHarga = New System.Windows.Forms.Button()
        Me.btnUlasan = New System.Windows.Forms.Button()
        Me.btnTransaksi = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnDeleteUniversal = New System.Windows.Forms.Button()
        Me.GroupBoxUpdateTransaksi = New System.Windows.Forms.GroupBox()
        Me.btnUpdateStatusPembayaran = New System.Windows.Forms.Button()
        Me.PanelRiwayatPesanan = New System.Windows.Forms.Panel()
        Me.GroupBoxRiwayatPesanan = New System.Windows.Forms.GroupBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.txtCustomerSearch = New System.Windows.Forms.TextBox()
        Me.txtOrderId = New System.Windows.Forms.TextBox()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.lbl = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.cmbStatusPembayaran = New System.Windows.Forms.ComboBox()
        Me.PanelSidebar.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.GroupBoxUpdateTransaksi.SuspendLayout()
        Me.PanelRiwayatPesanan.SuspendLayout()
        Me.GroupBoxRiwayatPesanan.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelSidebar
        '
        Me.PanelSidebar.BackColor = System.Drawing.Color.Tan
        Me.PanelSidebar.Controls.Add(Me.Button5)
        Me.PanelSidebar.Controls.Add(Me.btnKembaliForm2)
        Me.PanelSidebar.Controls.Add(Me.btnRiwayatPesanan)
        Me.PanelSidebar.Controls.Add(Me.btnAlamatPengiriman)
        Me.PanelSidebar.Controls.Add(Me.btnRiwayatHarga)
        Me.PanelSidebar.Controls.Add(Me.btnUlasan)
        Me.PanelSidebar.Controls.Add(Me.btnTransaksi)
        Me.PanelSidebar.Controls.Add(Me.Button3)
        Me.PanelSidebar.Controls.Add(Me.FlowLayoutPanel1)
        Me.PanelSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelSidebar.Location = New System.Drawing.Point(0, 0)
        Me.PanelSidebar.Name = "PanelSidebar"
        Me.PanelSidebar.Size = New System.Drawing.Size(286, 1055)
        Me.PanelSidebar.TabIndex = 42
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Tan
        Me.Button5.BackgroundImage = Global.CRUD_API_GOLANG_KELOMPOK.My.Resources.Resources.pizzaaa_resized_275x284
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button5.Location = New System.Drawing.Point(-113, -16)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(513, 300)
        Me.Button5.TabIndex = 24
        Me.Button5.UseVisualStyleBackColor = False
        '
        'btnKembaliForm2
        '
        Me.btnKembaliForm2.FlatAppearance.BorderSize = 0
        Me.btnKembaliForm2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKembaliForm2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKembaliForm2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnKembaliForm2.Location = New System.Drawing.Point(0, 813)
        Me.btnKembaliForm2.Name = "btnKembaliForm2"
        Me.btnKembaliForm2.Size = New System.Drawing.Size(91, 45)
        Me.btnKembaliForm2.TabIndex = 23
        Me.btnKembaliForm2.Text = "<"
        Me.btnKembaliForm2.UseVisualStyleBackColor = True
        '
        'btnRiwayatPesanan
        '
        Me.btnRiwayatPesanan.FlatAppearance.BorderSize = 0
        Me.btnRiwayatPesanan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRiwayatPesanan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRiwayatPesanan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnRiwayatPesanan.Location = New System.Drawing.Point(0, 570)
        Me.btnRiwayatPesanan.Name = "btnRiwayatPesanan"
        Me.btnRiwayatPesanan.Size = New System.Drawing.Size(284, 57)
        Me.btnRiwayatPesanan.TabIndex = 22
        Me.btnRiwayatPesanan.Text = "Riwayat Pesanan"
        Me.btnRiwayatPesanan.UseVisualStyleBackColor = True
        '
        'btnAlamatPengiriman
        '
        Me.btnAlamatPengiriman.FlatAppearance.BorderSize = 0
        Me.btnAlamatPengiriman.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlamatPengiriman.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlamatPengiriman.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAlamatPengiriman.Location = New System.Drawing.Point(3, 445)
        Me.btnAlamatPengiriman.Name = "btnAlamatPengiriman"
        Me.btnAlamatPengiriman.Size = New System.Drawing.Size(284, 56)
        Me.btnAlamatPengiriman.TabIndex = 21
        Me.btnAlamatPengiriman.Text = "Alamat Pengiriman"
        Me.btnAlamatPengiriman.UseVisualStyleBackColor = True
        '
        'btnRiwayatHarga
        '
        Me.btnRiwayatHarga.FlatAppearance.BorderSize = 0
        Me.btnRiwayatHarga.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRiwayatHarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRiwayatHarga.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnRiwayatHarga.Location = New System.Drawing.Point(0, 507)
        Me.btnRiwayatHarga.Name = "btnRiwayatHarga"
        Me.btnRiwayatHarga.Size = New System.Drawing.Size(284, 57)
        Me.btnRiwayatHarga.TabIndex = 20
        Me.btnRiwayatHarga.Text = "Riwayat Harga"
        Me.btnRiwayatHarga.UseVisualStyleBackColor = True
        '
        'btnUlasan
        '
        Me.btnUlasan.FlatAppearance.BorderSize = 0
        Me.btnUlasan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUlasan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUlasan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnUlasan.Location = New System.Drawing.Point(0, 321)
        Me.btnUlasan.Name = "btnUlasan"
        Me.btnUlasan.Size = New System.Drawing.Size(284, 56)
        Me.btnUlasan.TabIndex = 19
        Me.btnUlasan.Text = "Ulasan"
        Me.btnUlasan.UseVisualStyleBackColor = True
        '
        'btnTransaksi
        '
        Me.btnTransaksi.FlatAppearance.BorderSize = 0
        Me.btnTransaksi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransaksi.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransaksi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnTransaksi.Location = New System.Drawing.Point(0, 383)
        Me.btnTransaksi.Name = "btnTransaksi"
        Me.btnTransaksi.Size = New System.Drawing.Size(284, 56)
        Me.btnTransaksi.TabIndex = 17
        Me.btnTransaksi.Text = "Transaksi"
        Me.btnTransaksi.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.Sienna
        Me.Button3.Location = New System.Drawing.Point(0, 290)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(284, 10)
        Me.Button3.TabIndex = 15
        Me.Button3.UseVisualStyleBackColor = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(284, 65)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(960, 588)
        Me.FlowLayoutPanel1.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Tan
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(286, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1638, 183)
        Me.Panel2.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(502, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(848, 46)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Manajemen Transaksi dan Riwayat Pesanan"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Wheat
        Me.Panel5.Controls.Add(Me.btnDeleteUniversal)
        Me.Panel5.Controls.Add(Me.GroupBoxUpdateTransaksi)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(286, 813)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1638, 242)
        Me.Panel5.TabIndex = 88
        '
        'btnDeleteUniversal
        '
        Me.btnDeleteUniversal.BackColor = System.Drawing.Color.Red
        Me.btnDeleteUniversal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteUniversal.ForeColor = System.Drawing.Color.White
        Me.btnDeleteUniversal.Location = New System.Drawing.Point(1435, 37)
        Me.btnDeleteUniversal.Name = "btnDeleteUniversal"
        Me.btnDeleteUniversal.Size = New System.Drawing.Size(200, 62)
        Me.btnDeleteUniversal.TabIndex = 1
        Me.btnDeleteUniversal.Text = "Delete"
        Me.btnDeleteUniversal.UseVisualStyleBackColor = False
        '
        'GroupBoxUpdateTransaksi
        '
        Me.GroupBoxUpdateTransaksi.Controls.Add(Me.cmbStatusPembayaran)
        Me.GroupBoxUpdateTransaksi.Controls.Add(Me.btnUpdateStatusPembayaran)
        Me.GroupBoxUpdateTransaksi.Location = New System.Drawing.Point(6, 6)
        Me.GroupBoxUpdateTransaksi.Name = "GroupBoxUpdateTransaksi"
        Me.GroupBoxUpdateTransaksi.Size = New System.Drawing.Size(522, 167)
        Me.GroupBoxUpdateTransaksi.TabIndex = 3
        Me.GroupBoxUpdateTransaksi.TabStop = False
        '
        'btnUpdateStatusPembayaran
        '
        Me.btnUpdateStatusPembayaran.BackColor = System.Drawing.Color.Gold
        Me.btnUpdateStatusPembayaran.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateStatusPembayaran.ForeColor = System.Drawing.Color.Black
        Me.btnUpdateStatusPembayaran.Location = New System.Drawing.Point(298, 52)
        Me.btnUpdateStatusPembayaran.Name = "btnUpdateStatusPembayaran"
        Me.btnUpdateStatusPembayaran.Size = New System.Drawing.Size(198, 59)
        Me.btnUpdateStatusPembayaran.TabIndex = 2
        Me.btnUpdateStatusPembayaran.Text = "Update"
        Me.btnUpdateStatusPembayaran.UseVisualStyleBackColor = False
        '
        'PanelRiwayatPesanan
        '
        Me.PanelRiwayatPesanan.BackColor = System.Drawing.Color.Wheat
        Me.PanelRiwayatPesanan.Controls.Add(Me.GroupBoxRiwayatPesanan)
        Me.PanelRiwayatPesanan.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelRiwayatPesanan.Location = New System.Drawing.Point(1577, 183)
        Me.PanelRiwayatPesanan.Name = "PanelRiwayatPesanan"
        Me.PanelRiwayatPesanan.Size = New System.Drawing.Size(347, 630)
        Me.PanelRiwayatPesanan.TabIndex = 91
        '
        'GroupBoxRiwayatPesanan
        '
        Me.GroupBoxRiwayatPesanan.Controls.Add(Me.lblStatus)
        Me.GroupBoxRiwayatPesanan.Controls.Add(Me.btnFilter)
        Me.GroupBoxRiwayatPesanan.Controls.Add(Me.txtStatus)
        Me.GroupBoxRiwayatPesanan.Controls.Add(Me.btnReset)
        Me.GroupBoxRiwayatPesanan.Controls.Add(Me.txtCustomerSearch)
        Me.GroupBoxRiwayatPesanan.Controls.Add(Me.txtOrderId)
        Me.GroupBoxRiwayatPesanan.Controls.Add(Me.dtpEnd)
        Me.GroupBoxRiwayatPesanan.Controls.Add(Me.Label4)
        Me.GroupBoxRiwayatPesanan.Controls.Add(Me.dtpStart)
        Me.GroupBoxRiwayatPesanan.Controls.Add(Me.lbl)
        Me.GroupBoxRiwayatPesanan.Controls.Add(Me.Label3)
        Me.GroupBoxRiwayatPesanan.Controls.Add(Me.Label2)
        Me.GroupBoxRiwayatPesanan.Controls.Add(Me.Label7)
        Me.GroupBoxRiwayatPesanan.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBoxRiwayatPesanan.Location = New System.Drawing.Point(0, 0)
        Me.GroupBoxRiwayatPesanan.Name = "GroupBoxRiwayatPesanan"
        Me.GroupBoxRiwayatPesanan.Size = New System.Drawing.Size(347, 630)
        Me.GroupBoxRiwayatPesanan.TabIndex = 0
        Me.GroupBoxRiwayatPesanan.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(31, 377)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(67, 25)
        Me.lblStatus.TabIndex = 33
        Me.lblStatus.Text = "Order"
        '
        'btnFilter
        '
        Me.btnFilter.BackColor = System.Drawing.Color.OrangeRed
        Me.btnFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.ForeColor = System.Drawing.Color.Black
        Me.btnFilter.Location = New System.Drawing.Point(36, 492)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(289, 52)
        Me.btnFilter.TabIndex = 32
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = False
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(36, 56)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(277, 27)
        Me.txtStatus.TabIndex = 31
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.White
        Me.btnReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.ForeColor = System.Drawing.Color.Black
        Me.btnReset.Location = New System.Drawing.Point(36, 425)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(289, 45)
        Me.btnReset.TabIndex = 30
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'txtCustomerSearch
        '
        Me.txtCustomerSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerSearch.Location = New System.Drawing.Point(153, 313)
        Me.txtCustomerSearch.Name = "txtCustomerSearch"
        Me.txtCustomerSearch.Size = New System.Drawing.Size(172, 27)
        Me.txtCustomerSearch.TabIndex = 28
        '
        'txtOrderId
        '
        Me.txtOrderId.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrderId.Location = New System.Drawing.Point(36, 313)
        Me.txtOrderId.Name = "txtOrderId"
        Me.txtOrderId.Size = New System.Drawing.Size(69, 27)
        Me.txtOrderId.TabIndex = 27
        '
        'dtpEnd
        '
        Me.dtpEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEnd.Location = New System.Drawing.Point(36, 216)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(289, 28)
        Me.dtpEnd.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(160, 191)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 22)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "s/d"
        '
        'dtpStart
        '
        Me.dtpStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStart.Location = New System.Drawing.Point(36, 154)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(289, 28)
        Me.dtpStart.TabIndex = 24
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(31, 28)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(74, 25)
        Me.lbl.TabIndex = 22
        Me.lbl.Text = "Status"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(31, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(211, 25)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Tanggal Pemesanan"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(50, 276)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 25)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "ID"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(148, 276)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(177, 25)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Nama Pelanggan"
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(286, 183)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1291, 630)
        Me.DataGridView1.TabIndex = 92
        '
        'cmbStatusPembayaran
        '
        Me.cmbStatusPembayaran.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStatusPembayaran.FormattingEnabled = True
        Me.cmbStatusPembayaran.Location = New System.Drawing.Point(51, 60)
        Me.cmbStatusPembayaran.Name = "cmbStatusPembayaran"
        Me.cmbStatusPembayaran.Size = New System.Drawing.Size(208, 39)
        Me.cmbStatusPembayaran.TabIndex = 3
        '
        'FormMonitoring_dan_laporan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.PanelRiwayatPesanan)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PanelSidebar)
        Me.Name = "FormMonitoring_dan_laporan"
        Me.Text = "FormMonitoring_dan_laporan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PanelSidebar.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.GroupBoxUpdateTransaksi.ResumeLayout(False)
        Me.PanelRiwayatPesanan.ResumeLayout(False)
        Me.GroupBoxRiwayatPesanan.ResumeLayout(False)
        Me.GroupBoxRiwayatPesanan.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelSidebar As Panel
    Friend WithEvents btnKembaliForm2 As Button
    Friend WithEvents btnRiwayatPesanan As Button
    Friend WithEvents btnAlamatPengiriman As Button
    Friend WithEvents btnRiwayatHarga As Button
    Friend WithEvents btnUlasan As Button
    Friend WithEvents btnTransaksi As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnDeleteUniversal As Button
    Friend WithEvents PanelRiwayatPesanan As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents GroupBoxRiwayatPesanan As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpStart As DateTimePicker
    Friend WithEvents lbl As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCustomerSearch As TextBox
    Friend WithEvents txtOrderId As TextBox
    Friend WithEvents dtpEnd As DateTimePicker
    Friend WithEvents btnReset As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents btnFilter As Button
    Friend WithEvents btnUpdateStatusPembayaran As Button
    Friend WithEvents GroupBoxUpdateTransaksi As GroupBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents cmbStatusPembayaran As ComboBox
End Class
