using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V_CAU3
{
    public class GiaDung : HangHoa
    {

        private string _nhasanxua;
        private DateTime _ngaynhap;
        private string _loai;
        public GiaDung() { }

        public GiaDung(string mahang, string tenhang, int slton, double dongia, string nhasanxuat, DateTime ngaynhap, string loai)
            : base(mahang, tenhang, slton, dongia)
        {
            _nhasanxua = nhasanxuat;
            _ngaynhap = ngaynhap;
            _loai = loai;
        }

        public string nhasanxuat { get; set; }
        public DateTime ngaynhap { get; set; }
        public string loai { get; set; }

        public override void Show()
        {

            base.Show();
            Console.WriteLine($"Nhà Sản Xuất: {nhasanxuat}");
            Console.WriteLine($"Ngày nhập vào siêu thị: {ngaynhap.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Loại: {loai}");

        }

        public override void NhapHang()
        {
            base.NhapHang();
            Console.Write("Nhập nhà sản xuất: ");
            nhasanxuat = Console.ReadLine();
            Console.Write("Nhập Ngày/Tháng/Năm của mặt hàng được nhập vào: ");
            ngaynhap = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Nhập Loại (ly, chén, nồi...): ");
            loai = Console.ReadLine();
        }

        public override bool KtTonKho()
        {
            if (slton < 5)
                return false;
            return true;

        }
        public override double TinhThanhTien(int n)
        {
            slton -= n;
            return n * dongia * 1.05;
        }
    }
}