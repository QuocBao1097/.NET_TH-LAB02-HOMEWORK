using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V_CAU1
{
    public class SinhHoat : KhachHang
    {
        private float _dinhmuc;

        public SinhHoat() : base()
        {
            DinhMuc = 0;
        }

        public SinhHoat(string MaKH, string TenKH, DateTime NgayHD, float SLDien, float DonGia, double ThanhTien, float DinhMuc)
            : base(MaKH, TenKH, NgayHD, SLDien, DonGia, ThanhTien)
        {
            _dinhmuc = DinhMuc;
        }

        public float DinhMuc
        {
            get { return _dinhmuc; }
            set { _dinhmuc = value; }
        }

        public override void TinhThanhTien()
        {
            if (SLDien <= DinhMuc)
            {
                ThanhTien = SLDien * DonGia;
            }
            else
            {
                float SLVuot = SLDien - DinhMuc;
                ThanhTien = SLDien * DonGia * DinhMuc + SLVuot * DonGia * 2;
            }
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Định mức điện: {DinhMuc}");

            TinhThanhTien();
            Console.WriteLine($"Thành tiền: {ThanhTien}");
        }


        public override void Input()
        {
            base.Input();

            do
            {
                Console.Write("Nhập định mức điện: ");
                DinhMuc = float.Parse(Console.ReadLine());
            } while (DinhMuc <= 0);
        }
    }
}
