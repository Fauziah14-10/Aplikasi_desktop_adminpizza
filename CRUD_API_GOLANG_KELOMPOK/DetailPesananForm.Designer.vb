<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DetailPesananForm
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
        Me.PanelDetailPesanan = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlDetailPesanan = New System.Windows.Forms.Panel()
        Me.txtTanggal = New System.Windows.Forms.TextBox()
        Me.txtNamaPelanggan = New System.Windows.Forms.TextBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtTotalHarga = New System.Windows.Forms.TextBox()
        Me.txtNamaKurir = New System.Windows.Forms.TextBox()
        Me.txtIdPesanan = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PanelDetailPesanan.SuspendLayout()
        Me.pnlDetailPesanan.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelDetailPesanan
        '
        Me.PanelDetailPesanan.BackColor = System.Drawing.Color.Tan
        Me.PanelDetailPesanan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PanelDetailPesanan.Controls.Add(Me.Label8)
        Me.PanelDetailPesanan.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelDetailPesanan.Location = New System.Drawing.Point(0, 0)
        Me.PanelDetailPesanan.Name = "PanelDetailPesanan"
        Me.PanelDetailPesanan.Size = New System.Drawing.Size(540, 139)
        Me.PanelDetailPesanan.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(130, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(304, 46)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "Detail Pesanan"
        '
        'pnlDetailPesanan
        '
        Me.pnlDetailPesanan.BackColor = System.Drawing.Color.Wheat
        Me.pnlDetailPesanan.Controls.Add(Me.txtTanggal)
        Me.pnlDetailPesanan.Controls.Add(Me.txtNamaPelanggan)
        Me.pnlDetailPesanan.Controls.Add(Me.txtStatus)
        Me.pnlDetailPesanan.Controls.Add(Me.txtTotalHarga)
        Me.pnlDetailPesanan.Controls.Add(Me.txtNamaKurir)
        Me.pnlDetailPesanan.Controls.Add(Me.txtIdPesanan)
        Me.pnlDetailPesanan.Controls.Add(Me.Label7)
        Me.pnlDetailPesanan.Controls.Add(Me.Label5)
        Me.pnlDetailPesanan.Controls.Add(Me.Label4)
        Me.pnlDetailPesanan.Controls.Add(Me.Label1)
        Me.pnlDetailPesanan.Controls.Add(Me.Label6)
        Me.pnlDetailPesanan.Controls.Add(Me.Label2)
        Me.pnlDetailPesanan.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDetailPesanan.Location = New System.Drawing.Point(0, 139)
        Me.pnlDetailPesanan.Name = "pnlDetailPesanan"
        Me.pnlDetailPesanan.Size = New System.Drawing.Size(540, 472)
        Me.pnlDetailPesanan.TabIndex = 2
        '
        'txtTanggal
        '
        Me.txtTanggal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTanggal.Location = New System.Drawing.Point(287, 89)
        Me.txtTanggal.Name = "txtTanggal"
        Me.txtTanggal.Size = New System.Drawing.Size(212, 27)
        Me.txtTanggal.TabIndex = 58
        '
        'txtNamaPelanggan
        '
        Me.txtNamaPelanggan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaPelanggan.Location = New System.Drawing.Point(287, 150)
        Me.txtNamaPelanggan.Name = "txtNamaPelanggan"
        Me.txtNamaPelanggan.Size = New System.Drawing.Size(212, 27)
        Me.txtNamaPelanggan.TabIndex = 57
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(287, 325)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(212, 27)
        Me.txtStatus.TabIndex = 55
        '
        'txtTotalHarga
        '
        Me.txtTotalHarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalHarga.Location = New System.Drawing.Point(287, 276)
        Me.txtTotalHarga.Name = "txtTotalHarga"
        Me.txtTotalHarga.Size = New System.Drawing.Size(212, 27)
        Me.txtTotalHarga.TabIndex = 54
        '
        'txtNamaKurir
        '
        Me.txtNamaKurir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaKurir.Location = New System.Drawing.Point(287, 216)
        Me.txtNamaKurir.Name = "txtNamaKurir"
        Me.txtNamaKurir.Size = New System.Drawing.Size(212, 27)
        Me.txtNamaKurir.TabIndex = 53
        '
        'txtIdPesanan
        '
        Me.txtIdPesanan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdPesanan.Location = New System.Drawing.Point(287, 28)
        Me.txtIdPesanan.Name = "txtIdPesanan"
        Me.txtIdPesanan.Size = New System.Drawing.Size(212, 27)
        Me.txtIdPesanan.TabIndex = 52
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(27, 149)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(190, 25)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Nama Pelanggan :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(31, 275)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(138, 25)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Total Harga :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(31, 325)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 25)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Status :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(27, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 25)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "ID Pesanan :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(31, 215)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(133, 25)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Nama Kurir :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(27, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 25)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Tanggal :"
        '
        'DetailPesananForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(540, 611)
        Me.Controls.Add(Me.pnlDetailPesanan)
        Me.Controls.Add(Me.PanelDetailPesanan)
        Me.Name = "DetailPesananForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DetailPesananForm"
        Me.PanelDetailPesanan.ResumeLayout(False)
        Me.PanelDetailPesanan.PerformLayout()
        Me.pnlDetailPesanan.ResumeLayout(False)
        Me.pnlDetailPesanan.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelDetailPesanan As Panel
    Friend WithEvents pnlDetailPesanan As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtTanggal As TextBox
    Friend WithEvents txtNamaPelanggan As TextBox
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents txtTotalHarga As TextBox
    Friend WithEvents txtNamaKurir As TextBox
    Friend WithEvents txtIdPesanan As TextBox
End Class
