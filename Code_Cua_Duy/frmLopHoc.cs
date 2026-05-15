using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class frmLopHoc : Form
    {
        public frmLopHoc()
        {
            InitializeComponent();
        }

        private void frmLopHoc_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
        }

        private void LoadDanhSach()
        {
            try
            {
                SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM LopHoc", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLopHoc.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // Hàm này TV3 sẽ gọi để load danh sách lớp vào ComboBox
        public void LoadComboBox(ComboBox cbo)
        {
            try
            {
                SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM LopHoc", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbo.DataSource = dt;
                cbo.DisplayMember = "TenKhoa";
                cbo.ValueMember = "MaLop";
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load ComboBox: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text == "" || txtTenKhoa.Text == "" || txtHocPhi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO LopHoc VALUES (@MaLop,@TenKhoa,@HocPhi)", con);
                cmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                cmd.Parameters.AddWithValue("@TenKhoa", txtTenKhoa.Text);
                cmd.Parameters.AddWithValue("@HocPhi", txtHocPhi.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Thêm thành công!");
                LoadDanhSach();
                btnLamMoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text == "")
            {
                MessageBox.Show("Chọn lớp cần sửa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE LopHoc SET TenKhoa=@TenKhoa, HocPhi=@HocPhi WHERE MaLop=@MaLop", con);
                cmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                cmd.Parameters.AddWithValue("@TenKhoa", txtTenKhoa.Text);
                cmd.Parameters.AddWithValue("@HocPhi", txtHocPhi.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Sửa thành công!");
                LoadDanhSach();
                btnLamMoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text == "")
            {
                MessageBox.Show("Chọn lớp cần xóa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Xóa lớp học này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlConnection con = DatabaseConnection.GetConnection();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM LopHoc WHERE MaLop=@MaLop", con);
                    cmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Xóa thành công!");
                    LoadDanhSach();
                    btnLamMoi_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaLop.Text = "";
            txtTenKhoa.Text = "";
            txtHocPhi.Text = "";
            txtMaLop.Focus();
        }

        private void dgvLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaLop.Text = dgvLopHoc.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenKhoa.Text = dgvLopHoc.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtHocPhi.Text = dgvLopHoc.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }
    }
}