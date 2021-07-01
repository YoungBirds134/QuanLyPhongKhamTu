namespace frmMain.GUI
{
    partial class frmTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.dtg_kq = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghichu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.dtg_chitiet = new System.Windows.Forms.DataGridView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btn_xuathoadon = new DevExpress.XtraEditors.SimpleButton();
            this.btn_thanhtoan = new DevExpress.XtraEditors.SimpleButton();
            this.dtg_thanhtoan = new System.Windows.Forms.DataGridView();
            this.matt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.madkdv2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tennv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaylap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dtg_ChoXetNghiem = new System.Windows.Forms.DataGridView();
            this.madkdv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sophieukham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tenbacsi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaylapphieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenphong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangthai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateNgayLap = new System.Windows.Forms.DateTimePicker();
            this.btn_inkq = new DevExpress.XtraEditors.SimpleButton();
            this.btn_suakq = new DevExpress.XtraEditors.SimpleButton();
            this.btn_themkq = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rtb_ghichu = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNhanVien = new System.Windows.Forms.TextBox();
            this.mactdkdv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.madkdv1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tendv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thanhtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_kq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_chitiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_thanhtoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_ChoXetNghiem)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.dtg_kq);
            this.groupControl4.Location = new System.Drawing.Point(821, 319);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(651, 329);
            this.groupControl4.TabIndex = 7;
            this.groupControl4.Text = "Kết Quả Sử Dụng Dịch Vụ";
            // 
            // dtg_kq
            // 
            this.dtg_kq.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtg_kq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_kq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.ghichu});
            this.dtg_kq.Location = new System.Drawing.Point(5, 26);
            this.dtg_kq.Name = "dtg_kq";
            this.dtg_kq.Size = new System.Drawing.Size(622, 255);
            this.dtg_kq.TabIndex = 1;
            this.dtg_kq.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_kq_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MAKQDV";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã KQDV";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MADKDV";
            this.dataGridViewTextBoxColumn2.HeaderText = "Mã DKDV";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TENNV";
            this.dataGridViewTextBoxColumn3.HeaderText = "Tên Nhân Viên";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NGAYLAPKQ";
            this.dataGridViewTextBoxColumn4.HeaderText = "Ngày Lập";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // ghichu
            // 
            this.ghichu.DataPropertyName = "GHICHU";
            this.ghichu.HeaderText = "Kết Quả";
            this.ghichu.Name = "ghichu";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.dtg_chitiet);
            this.groupControl3.Location = new System.Drawing.Point(821, 10);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(506, 294);
            this.groupControl3.TabIndex = 5;
            this.groupControl3.Text = "Chi tiết Dịch Vụ";
            // 
            // dtg_chitiet
            // 
            this.dtg_chitiet.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtg_chitiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_chitiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mactdkdv,
            this.madkdv1,
            this.tendv,
            this.thanhtien});
            this.dtg_chitiet.Location = new System.Drawing.Point(14, 31);
            this.dtg_chitiet.Name = "dtg_chitiet";
            this.dtg_chitiet.Size = new System.Drawing.Size(474, 258);
            this.dtg_chitiet.TabIndex = 1;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btn_xuathoadon);
            this.groupControl2.Controls.Add(this.btn_thanhtoan);
            this.groupControl2.Controls.Add(this.dtg_thanhtoan);
            this.groupControl2.Location = new System.Drawing.Point(31, 324);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(760, 329);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "Thanh Toán";
            // 
            // btn_xuathoadon
            // 
            this.btn_xuathoadon.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xuathoadon.Appearance.Options.UseFont = true;
            this.btn_xuathoadon.Location = new System.Drawing.Point(357, 287);
            this.btn_xuathoadon.Name = "btn_xuathoadon";
            this.btn_xuathoadon.Size = new System.Drawing.Size(131, 37);
            this.btn_xuathoadon.TabIndex = 4;
            this.btn_xuathoadon.Text = "Xuất Hóa Đơn";
            this.btn_xuathoadon.Click += new System.EventHandler(this.btn_xuathoadon_Click);
            // 
            // btn_thanhtoan
            // 
            this.btn_thanhtoan.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thanhtoan.Appearance.Options.UseFont = true;
            this.btn_thanhtoan.Location = new System.Drawing.Point(105, 287);
            this.btn_thanhtoan.Name = "btn_thanhtoan";
            this.btn_thanhtoan.Size = new System.Drawing.Size(119, 37);
            this.btn_thanhtoan.TabIndex = 3;
            this.btn_thanhtoan.Text = "Thanh Toán";
            this.btn_thanhtoan.Click += new System.EventHandler(this.btn_thanhtoan_Click);
            // 
            // dtg_thanhtoan
            // 
            this.dtg_thanhtoan.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtg_thanhtoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_thanhtoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.matt,
            this.madkdv2,
            this.tennv,
            this.ngaylap,
            this.tongtien});
            this.dtg_thanhtoan.Location = new System.Drawing.Point(5, 26);
            this.dtg_thanhtoan.Name = "dtg_thanhtoan";
            this.dtg_thanhtoan.Size = new System.Drawing.Size(744, 255);
            this.dtg_thanhtoan.TabIndex = 1;
            // 
            // matt
            // 
            this.matt.DataPropertyName = "SOHDDV";
            this.matt.HeaderText = "Mã DHDV";
            this.matt.Name = "matt";
            // 
            // madkdv2
            // 
            this.madkdv2.DataPropertyName = "MADKDV";
            this.madkdv2.HeaderText = "Mã DKDV";
            this.madkdv2.Name = "madkdv2";
            // 
            // tennv
            // 
            this.tennv.DataPropertyName = "TENNV";
            this.tennv.HeaderText = "Tên Nhân Viên";
            this.tennv.Name = "tennv";
            this.tennv.Width = 150;
            // 
            // ngaylap
            // 
            this.ngaylap.DataPropertyName = "NGAYLAPHDDV";
            this.ngaylap.HeaderText = "Ngày Lập";
            this.ngaylap.Name = "ngaylap";
            // 
            // tongtien
            // 
            this.tongtien.DataPropertyName = "TONGTIEN";
            this.tongtien.HeaderText = "Tổng Tiền";
            this.tongtien.Name = "tongtien";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dtg_ChoXetNghiem);
            this.groupControl1.Location = new System.Drawing.Point(26, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(765, 294);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Chờ Xét Nghiệm";
            // 
            // dtg_ChoXetNghiem
            // 
            this.dtg_ChoXetNghiem.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtg_ChoXetNghiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_ChoXetNghiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.madkdv,
            this.sophieukham,
            this.Tenbacsi,
            this.ngaylapphieu,
            this.tenphong,
            this.trangthai});
            this.dtg_ChoXetNghiem.Location = new System.Drawing.Point(5, 26);
            this.dtg_ChoXetNghiem.Name = "dtg_ChoXetNghiem";
            this.dtg_ChoXetNghiem.Size = new System.Drawing.Size(749, 266);
            this.dtg_ChoXetNghiem.TabIndex = 1;
            this.dtg_ChoXetNghiem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_ChoXetNghiem_CellClick);
            // 
            // madkdv
            // 
            this.madkdv.DataPropertyName = "MADKDV";
            this.madkdv.HeaderText = "Mã DKDV";
            this.madkdv.Name = "madkdv";
            // 
            // sophieukham
            // 
            this.sophieukham.DataPropertyName = "SOPHIEUKHAM";
            this.sophieukham.HeaderText = "Số Phiếu Khám";
            this.sophieukham.Name = "sophieukham";
            this.sophieukham.Width = 150;
            // 
            // Tenbacsi
            // 
            this.Tenbacsi.DataPropertyName = "TENNV";
            this.Tenbacsi.HeaderText = "Tên Bác Sĩ";
            this.Tenbacsi.Name = "Tenbacsi";
            // 
            // ngaylapphieu
            // 
            this.ngaylapphieu.DataPropertyName = "NGAYLAPPHIEUDK";
            this.ngaylapphieu.HeaderText = "Ngày Lập Phiếu";
            this.ngaylapphieu.Name = "ngaylapphieu";
            this.ngaylapphieu.Width = 150;
            // 
            // tenphong
            // 
            this.tenphong.DataPropertyName = "TENPHONG";
            this.tenphong.HeaderText = "Tên Phòng";
            this.tenphong.Name = "tenphong";
            // 
            // trangthai
            // 
            this.trangthai.DataPropertyName = "TRANGTHAI";
            this.trangthai.HeaderText = "Trạng Thái";
            this.trangthai.Name = "trangthai";
            // 
            // dateNgayLap
            // 
            this.dateNgayLap.Enabled = false;
            this.dateNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayLap.Location = new System.Drawing.Point(1430, 69);
            this.dateNgayLap.Name = "dateNgayLap";
            this.dateNgayLap.Size = new System.Drawing.Size(295, 23);
            this.dateNgayLap.TabIndex = 26;
            this.dateNgayLap.Value = new System.DateTime(2021, 5, 21, 0, 0, 0, 0);
            // 
            // btn_inkq
            // 
            this.btn_inkq.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_inkq.Appearance.Options.UseFont = true;
            this.btn_inkq.Location = new System.Drawing.Point(1626, 221);
            this.btn_inkq.Name = "btn_inkq";
            this.btn_inkq.Size = new System.Drawing.Size(104, 39);
            this.btn_inkq.TabIndex = 25;
            this.btn_inkq.Text = "In Kết Quả";
            this.btn_inkq.Click += new System.EventHandler(this.btn_inkq_Click);
            // 
            // btn_suakq
            // 
            this.btn_suakq.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_suakq.Appearance.Options.UseFont = true;
            this.btn_suakq.Location = new System.Drawing.Point(1502, 221);
            this.btn_suakq.Name = "btn_suakq";
            this.btn_suakq.Size = new System.Drawing.Size(111, 39);
            this.btn_suakq.TabIndex = 24;
            this.btn_suakq.Text = "Sửa Kết Quả";
            this.btn_suakq.Click += new System.EventHandler(this.btn_suakq_Click);
            // 
            // btn_themkq
            // 
            this.btn_themkq.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_themkq.Appearance.Options.UseFont = true;
            this.btn_themkq.Location = new System.Drawing.Point(1376, 221);
            this.btn_themkq.Name = "btn_themkq";
            this.btn_themkq.Size = new System.Drawing.Size(112, 39);
            this.btn_themkq.TabIndex = 23;
            this.btn_themkq.Text = "Thêm Kết Quả";
            this.btn_themkq.Click += new System.EventHandler(this.btn_themkq_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1350, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 21);
            this.label4.TabIndex = 22;
            this.label4.Text = "Kết quả";
            // 
            // rtb_ghichu
            // 
            this.rtb_ghichu.Location = new System.Drawing.Point(1430, 123);
            this.rtb_ghichu.Name = "rtb_ghichu";
            this.rtb_ghichu.Size = new System.Drawing.Size(295, 81);
            this.rtb_ghichu.TabIndex = 21;
            this.rtb_ghichu.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1348, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 21);
            this.label2.TabIndex = 20;
            this.label2.Text = "Ngày Lập";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1345, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 21);
            this.label1.TabIndex = 19;
            this.label1.Text = "Nhân Viên";
            // 
            // txtNhanVien
            // 
            this.txtNhanVien.Enabled = false;
            this.txtNhanVien.Location = new System.Drawing.Point(1430, 19);
            this.txtNhanVien.Name = "txtNhanVien";
            this.txtNhanVien.Size = new System.Drawing.Size(295, 23);
            this.txtNhanVien.TabIndex = 27;
            // 
            // mactdkdv
            // 
            this.mactdkdv.DataPropertyName = "MACTDICHVU";
            this.mactdkdv.HeaderText = "Mã CTDKDV";
            this.mactdkdv.Name = "mactdkdv";
            this.mactdkdv.Width = 120;
            // 
            // madkdv1
            // 
            this.madkdv1.DataPropertyName = "MADKDV";
            this.madkdv1.HeaderText = "Mã DKDV";
            this.madkdv1.Name = "madkdv1";
            // 
            // tendv
            // 
            this.tendv.DataPropertyName = "TENDV";
            this.tendv.HeaderText = "Tên Dịch Vụ";
            this.tendv.Name = "tendv";
            // 
            // thanhtien
            // 
            this.thanhtien.DataPropertyName = "THANHTIEN";
            this.thanhtien.HeaderText = "Thành Tiền";
            this.thanhtien.Name = "thanhtien";
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1749, 696);
            this.Controls.Add(this.txtNhanVien);
            this.Controls.Add(this.dateNgayLap);
            this.Controls.Add(this.btn_inkq);
            this.Controls.Add(this.btn_suakq);
            this.Controls.Add(this.btn_themkq);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtb_ghichu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xét Nghiệm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_kq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_chitiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_thanhtoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_ChoXetNghiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl4;
        private System.Windows.Forms.DataGridView dtg_kq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghichu;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.DataGridView dtg_chitiet;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btn_xuathoadon;
        private DevExpress.XtraEditors.SimpleButton btn_thanhtoan;
        private System.Windows.Forms.DataGridView dtg_thanhtoan;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.DataGridView dtg_ChoXetNghiem;
        private System.Windows.Forms.DateTimePicker dateNgayLap;
        private DevExpress.XtraEditors.SimpleButton btn_inkq;
        private DevExpress.XtraEditors.SimpleButton btn_suakq;
        private DevExpress.XtraEditors.SimpleButton btn_themkq;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtb_ghichu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn madkdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn sophieukham;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tenbacsi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaylapphieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenphong;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangthai;
        private System.Windows.Forms.TextBox txtNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn matt;
        private System.Windows.Forms.DataGridViewTextBoxColumn madkdv2;
        private System.Windows.Forms.DataGridViewTextBoxColumn tennv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaylap;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtien;
        private System.Windows.Forms.DataGridViewTextBoxColumn mactdkdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn madkdv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tendv;
        private System.Windows.Forms.DataGridViewTextBoxColumn thanhtien;
    }
}