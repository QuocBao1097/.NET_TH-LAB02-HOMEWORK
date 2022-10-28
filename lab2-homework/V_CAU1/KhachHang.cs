using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V_CAU1
{

    public abstract class KhachHang
    {
        private string _makh, _tenkh;
        private DateTime _ngayhoadon;
        private float _slDien, _dongia;
        private double _thanhtien;


        public KhachHang()
        {
            MaKH = "";
            TenKH = "";
            NgayHD = new DateTime(1, 1, 1);
            SLDien = DonGia = 0;
            ThanhTien = 0;
        }

        public KhachHang(string MaKH, string TenKH, DateTime NgayHD, float SLDien, float DonGia, double ThanhTien)
        {
            this._makh = MaKH;
            this._tenkh = TenKH;
            this._ngayhoadon = NgayHD;
            this._slDien = SLDien;
            this._dongia = DonGia;
            this._thanhtien = ThanhTien;
        }
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public DateTime NgayHD { get; set; }
        public float SLDien { get; set; }
        public float DonGia { get; set; }
        public double ThanhTien { get; set; }



        public abstract void TinhThanhTien();

        public virtual void Show()
        {
            Console.WriteLine($"Mã khách hàng: {MaKH}");
            Console.WriteLine($"Tên khách hàng: {TenKH}");
            Console.WriteLine($"Ngày hóa đơn: {NgayHD.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Số lượng điện: {SLDien}");
            Console.WriteLine($"Đơn giá: {DonGia}");
        }

        public virtual void Input()
        {
            do
            {
                Console.Write("Nhập số lượng điện: ");
                SLDien = float.Parse(Console.ReadLine());
            } while (SLDien <= 0);


            do
            {
                Console.Write("Nhập đơn giá điện: ");
                DonGia = float.Parse(Console.ReadLine());
            } while (DonGia <= 0);
        }
    }
}
