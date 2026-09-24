using System;
using System.Windows.Forms;

namespace QuanLyNhanVien
{
    public partial class frmNhanVien : Form
    {
        public NhanVien NhanVienInfo { get; private set; }

        public frmNhanVien()
        {
            InitializeComponent();
        }

        public frmNhanVien(NhanVien nv) : this()
        {
            if (nv != null)
            {
                txtMSNV.Text = nv.MSNV;
                txtTenNV.Text = nv.TenNV;
                txtLuongCB.Text = nv.LuongCB.ToString();

                txtMSNV.ReadOnly = true;
            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMSNV.Text) || string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double luong = 0;
            double.TryParse(txtLuongCB.Text, out luong);

            NhanVienInfo = new NhanVien(txtMSNV.Text.Trim(), txtTenNV.Text.Trim(), luong);

            this.DialogResult = DialogResult.OK; // Đánh dấu là thành công
            this.Close();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnDongY_Click_1(object sender, EventArgs e)
        {

        }

        private void btnBoQua_Click_1(object sender, EventArgs e)
        {

        }
    }
}