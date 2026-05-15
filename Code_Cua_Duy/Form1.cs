namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void họcViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            frmHocVien frm = new frmHocVien();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(frm);
            frm.Show();
        }

        private void lớpHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            frmLopHoc frm = new frmLopHoc();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(frm);
            frm.Show();
        }

        private void giaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            frmGiaoDich frm = new frmGiaoDich();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(frm);
            frm.Show();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            frmTimKiem frm = new frmTimKiem();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(frm);
            frm.Show();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            frmThongKe frm = new frmThongKe();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(frm);
            frm.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}