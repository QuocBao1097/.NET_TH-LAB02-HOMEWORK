using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V_CAU1
{
    public class KinhDoanh : KhachHang
    {

        public KinhDoanh() : base()
        {
        }
        public KinhDoanh(string MaKH, string TenKH, DateTime NgayHD, float SLDien, float DonGia, double ThanhTien)
        : base(MaKH, TenKH, NgayHD, SLDien, DonGia, ThanhTien)
        { }

        public override void TinhThanhTien()
        {
            if (SLDien <= 400)
            {
                ThanhTien = SLDien * DonGia;
            }
            else
            {
                float DienVuot = SLDien - 400;
                ThanhTien = 400 * DonGia + DienVuot * DonGia * 0.05;
            }
        }

        public override void Show()
        {
            base.Show();

            TinhThanhTien();
            Console.WriteLine($"Thành tiền: {ThanhTien}");
        }

        public override void Input()
        {
            base.Input();
        }
    }
}

