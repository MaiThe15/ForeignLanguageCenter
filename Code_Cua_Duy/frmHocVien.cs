using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class frmHocVien : Form
    {
        public frmHocVien()
        {
            InitializeComponent();
        }

        private void frmHocVien_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
        }

        private void LoadDanhSach()
        {
            try
            {
                SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM HocVien", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHocVien.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaHV.Text == "" || txtTen.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSDT.Text.Length != 10)
            {
                MessageBox.Show("SĐT phải 10 số ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO HocVien VALUES  (@MaHV,@Ten,@SDT,@TrangThai)", con);
                cmd.Parameters.AddWithValue("@MaHV", txtMaHV.Text);
                cmd.Parameters.AddWithValue("@Ten", txtTen.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@TrangThai", txtTrangThai.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Thêm  thành công!");
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

            if (txtMaHV.Text == "")
            {
                MessageBox.Show("Chọn học viên cần Sửa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                SqlConnection con = DatabaseConnection.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE HocVIen SET Ten=@Ten,SDT=@SDT,TrangThai=@TrangThai WHERE MaHV=@MaHV ", con);
                cmd.Parameters.AddWithValue("@MaHV", txtMaHV.Text);
                cmd.Parameters.AddWithValue("@Ten", txtTen.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@TrangThai", txtTrangThai.Text);
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
            if (txtMaHV.Text == "")
            {
                MessageBox.Show("Chọn học viên cần xóa ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Xóa học viên này? ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ;

            {
                try
                {

                    SqlConnection con = DatabaseConnection.GetConnection();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM HocVien WHERE MaHV=@MaHV", con);
                    cmd.Parameters.AddWithValue("@MaHV", txtMaHV.Text);
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
            txtMaHV.Text = "";
            txtTen.Text = "";
            txtSDT.Text = "";
            txtTrangThai.Text = "";
            txtMaHV.Focus();
        }
        private void dgvHocVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaHV.Text = dgvHocVien.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTen.Text = dgvHocVien.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSDT.Text = dgvHocVien.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTrangThai.Text = dgvHocVien.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void dgvHocVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
                txtMaHV.Text = dgvHocVien.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTen.Text = dgvHocVien.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSDT.Text = dgvHocVien.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTrangThai.Text = dgvHocVien.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }
    }
    }
