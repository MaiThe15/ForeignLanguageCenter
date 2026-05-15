namespace WinFormsApp1
{
    partial class frmHocVien
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
            groupBox1 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtTrangThai = new TextBox();
            txtSDT = new TextBox();
            txtTen = new TextBox();
            txtMaHV = new TextBox();
            label1 = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvHocVien = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHocVien).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtTrangThai);
            groupBox1.Controls.Add(txtSDT);
            groupBox1.Controls.Add(txtTen);
            groupBox1.Controls.Add(txtMaHV);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(753, 323);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin học viên ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 267);
            label4.Name = "label4";
            label4.Size = new Size(125, 32);
            label4.TabIndex = 7;
            label4.Text = "Trạng thái:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 199);
            label3.Name = "label3";
            label3.Size = new Size(161, 32);
            label3.TabIndex = 6;
            label3.Text = "Số điện thoại:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 134);
            label2.Name = "label2";
            label2.Size = new Size(95, 32);
            label2.TabIndex = 5;
            label2.Text = "Họ Tên:";
            // 
            // txtTrangThai
            // 
            txtTrangThai.Location = new Point(238, 267);
            txtTrangThai.Name = "txtTrangThai";
            txtTrangThai.Size = new Size(411, 39);
            txtTrangThai.TabIndex = 4;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(238, 199);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(411, 39);
            txtSDT.TabIndex = 3;
            // 
            // txtTen
            // 
            txtTen.Location = new Point(238, 131);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(411, 39);
            txtTen.TabIndex = 2;
            // 
            // txtMaHV
            // 
            txtMaHV.Location = new Point(238, 55);
            txtMaHV.Name = "txtMaHV";
            txtMaHV.Size = new Size(411, 39);
            txtMaHV.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 62);
            label1.Name = "label1";
            label1.Size = new Size(92, 32);
            label1.TabIndex = 0;
            label1.Text = "Mã HV:";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(28, 356);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(150, 46);
            btnThem.TabIndex = 1;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(211, 356);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(150, 46);
            btnSua.TabIndex = 2;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(401, 356);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(150, 46);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(584, 356);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(150, 46);
            btnLamMoi.TabIndex = 4;
            btnLamMoi.Text = "Làm Mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // dgvHocVien
            // 
            dgvHocVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHocVien.Dock = DockStyle.Bottom;
            dgvHocVien.Location = new Point(0, 454);
            dgvHocVien.Name = "dgvHocVien";
            dgvHocVien.RowHeadersWidth = 82;
            dgvHocVien.Size = new Size(1400, 340);
            dgvHocVien.TabIndex = 5;
            dgvHocVien.CellContentClick += dgvHocVien_CellContentClick;
            // 
            // frmHocVien
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 794);
            Controls.Add(dgvHocVien);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(groupBox1);
            Name = "frmHocVien";
            Text = "frmHocVien";
            Load += frmHocVien_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHocVien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtTrangThai;
        private TextBox txtSDT;
        private TextBox txtTen;
        private TextBox txtMaHV;
        private Label label1;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private DataGridView dgvHocVien;
    }
}