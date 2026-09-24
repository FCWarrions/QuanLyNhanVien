namespace QuanLyNhanVien
{
    public class NhanVien
    {
        public string MSNV { get; set; }
        public string TenNV { get; set; }
        public double LuongCB { get; set; }

        public NhanVien() { }

        public NhanVien(string msnv, string tenNV, double luongCB)
        {
            MSNV = msnv;
            TenNV = tenNV;
            LuongCB = luongCB;
        }
    }
}