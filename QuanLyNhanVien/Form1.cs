using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuanLyNhanVien
{
    public partial class Form1 : Form
    {
        private BindingList<NhanVien> listNhanVien = new BindingList<NhanVien>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listNhanVien.Add(new NhanVien("NV001", "Nguyễn Thị Thu Hiền", 8500000));
            listNhanVien.Add(new NhanVien("NV002", "Nguyễn Trần Minh Triết", 6500000));

            dgvNhanVien.DataSource = listNhanVien;

            dgvNhanVien.Columns["MSNV"].HeaderText = "MSNV";
            dgvNhanVien.Columns["TenNV"].HeaderText = "Tên NV";
            dgvNhanVien.Columns["LuongCB"].HeaderText = "Lương CB";
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmNhanVien formNV = new frmNhanVien();
            formNV.ShowDialog();
            {
                listNhanVien.Add(formNV.NhanVienInfo);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow != null)
            {
                NhanVien nvSelected = (NhanVien)dgvNhanVien.CurrentRow.DataBoundItem;

                frmNhanVien formNV = new frmNhanVien(nvSelected);
                if (formNV.ShowDialog() == DialogResult.OK)
                {
                    // Cập nhật lại thông tin
                    nvSelected.TenNV = formNV.NhanVienInfo.TenNV;
                    nvSelected.LuongCB = formNV.NhanVienInfo.LuongCB;

                    dgvNhanVien.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    NhanVien nvSelected = (NhanVien)dgvNhanVien.CurrentRow.DataBoundItem;
                    listNhanVien.Remove(nvSelected);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}