namespace WinFormsApp1
{
    partial class frmLopHoc
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtMaLop = new TextBox();
            txtTenKhoa = new TextBox();
            txtHocPhi = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvLopHoc = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLopHoc).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtHocPhi);
            groupBox1.Controls.Add(txtTenKhoa);
            groupBox1.Controls.Add(txtMaLop);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(843, 284);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin lớp học ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 73);
            label1.Name = "label1";
            label1.Size = new Size(101, 32);
            label1.TabIndex = 0;
            label1.Text = "Mã lớp: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 135);
            label2.Name = "label2";
            label2.Size = new Size(118, 32);
            label2.TabIndex = 1;
            label2.Text = "Tên Khóa:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1190, 47);
            label3.Name = "label3";
            label3.Size = new Size(78, 32);
            label3.TabIndex = 2;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 203);
            label4.Name = "label4";
            label4.Size = new Size(109, 32);
            label4.TabIndex = 3;
            label4.Text = "Học phí: ";
            // 
            // txtMaLop
            // 
            txtMaLop.Location = new Point(244, 66);
            txtMaLop.Name = "txtMaLop";
            txtMaLop.Size = new Size(454, 39);
            txtMaLop.TabIndex = 4;
            // 
            // txtTenKhoa
            // 
            txtTenKhoa.Location = new Point(244, 135);
            txtTenKhoa.Name = "txtTenKhoa";
            txtTenKhoa.Size = new Size(454, 39);
            txtTenKhoa.TabIndex = 5;
            // 
            // txtHocPhi
            // 
            txtHocPhi.Location = new Point(243, 197);
            txtHocPhi.Name = "txtHocPhi";
            txtHocPhi.Size = new Size(455, 39);
            txtHocPhi.TabIndex = 6;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(63, 321);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(150, 46);
            btnThem.TabIndex = 1;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(255, 321);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(150, 46);
            btnSua.TabIndex = 2;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(456, 321);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(150, 46);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(663, 321);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(150, 46);
            btnLamMoi.TabIndex = 4;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // dgvLopHoc
            // 
            dgvLopHoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLopHoc.Dock = DockStyle.Bottom;
            dgvLopHoc.Location = new Point(0, 447);
            dgvLopHoc.Name = "dgvLopHoc";
            dgvLopHoc.RowHeadersWidth = 82;
            dgvLopHoc.Size = new Size(1771, 300);
            dgvLopHoc.TabIndex = 5;
            dgvLopHoc.CellClick += dgvLopHoc_CellClick;
            // 
            // frmLopHoc
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1771, 747);
            Controls.Add(dgvLopHoc);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(groupBox1);
            Name = "frmLopHoc";
            Text = "frmLopHoc";
            Load += frmLopHoc_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLopHoc).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtHocPhi;
        private TextBox txtTenKhoa;
        private TextBox txtMaLop;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private DataGridView dgvLopHoc;
    }
}