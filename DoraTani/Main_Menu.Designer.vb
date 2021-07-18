<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main_Menu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.btnTransaksi = New System.Windows.Forms.Button()
        Me.btnUsers = New System.Windows.Forms.Button()
        Me.btnBarang = New System.Windows.Forms.Button()
        Me.btnSuplier = New System.Windows.Forms.Button()
        Me.btnMaster = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Rockwell", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(864, 62)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Dora Tani"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(840, 327)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnReport, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnTransaksi, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnUsers, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnBarang, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSuplier, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnMaster, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 19)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(828, 302)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnReport
        '
        Me.btnReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan
        Me.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack
        Me.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport.Location = New System.Drawing.Point(279, 154)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(269, 144)
        Me.btnReport.TabIndex = 5
        Me.btnReport.Text = "Report"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'btnTransaksi
        '
        Me.btnTransaksi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan
        Me.btnTransaksi.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack
        Me.btnTransaksi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransaksi.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransaksi.Location = New System.Drawing.Point(3, 3)
        Me.btnTransaksi.Name = "btnTransaksi"
        Me.btnTransaksi.Size = New System.Drawing.Size(269, 144)
        Me.btnTransaksi.TabIndex = 4
        Me.btnTransaksi.Text = "Transaksi"
        Me.btnTransaksi.UseVisualStyleBackColor = True
        '
        'btnUsers
        '
        Me.btnUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan
        Me.btnUsers.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack
        Me.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUsers.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUsers.Location = New System.Drawing.Point(555, 154)
        Me.btnUsers.Name = "btnUsers"
        Me.btnUsers.Size = New System.Drawing.Size(270, 144)
        Me.btnUsers.TabIndex = 3
        Me.btnUsers.Text = "Akun Pengguna"
        Me.btnUsers.UseVisualStyleBackColor = True
        '
        'btnBarang
        '
        Me.btnBarang.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan
        Me.btnBarang.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack
        Me.btnBarang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBarang.Location = New System.Drawing.Point(3, 154)
        Me.btnBarang.Name = "btnBarang"
        Me.btnBarang.Size = New System.Drawing.Size(269, 144)
        Me.btnBarang.TabIndex = 2
        Me.btnBarang.Text = "Barang Masuk"
        Me.btnBarang.UseVisualStyleBackColor = True
        '
        'btnSuplier
        '
        Me.btnSuplier.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan
        Me.btnSuplier.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack
        Me.btnSuplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSuplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSuplier.Location = New System.Drawing.Point(555, 3)
        Me.btnSuplier.Name = "btnSuplier"
        Me.btnSuplier.Size = New System.Drawing.Size(270, 144)
        Me.btnSuplier.TabIndex = 1
        Me.btnSuplier.Text = "Suplier Barang"
        Me.btnSuplier.UseVisualStyleBackColor = True
        '
        'btnMaster
        '
        Me.btnMaster.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan
        Me.btnMaster.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack
        Me.btnMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMaster.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMaster.Location = New System.Drawing.Point(279, 3)
        Me.btnMaster.Name = "btnMaster"
        Me.btnMaster.Size = New System.Drawing.Size(269, 144)
        Me.btnMaster.TabIndex = 0
        Me.btnMaster.Text = "Master Barang"
        Me.btnMaster.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 406)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(864, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel1.Text = "Nama"
        '
        'Main_Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 428)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main_Menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Menu"
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnTransaksi As System.Windows.Forms.Button
    Friend WithEvents btnUsers As System.Windows.Forms.Button
    Friend WithEvents btnBarang As System.Windows.Forms.Button
    Friend WithEvents btnSuplier As System.Windows.Forms.Button
    Friend WithEvents btnMaster As System.Windows.Forms.Button

End Class
