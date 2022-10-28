using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V_CAU1
{
    public class SanXuat : KhachHang
    {
        private bool _loaidien;

        public SanXuat() : base()
        {
            _loaidien = true;
        }

        public SanXuat(string MaKH, string TenKH, DateTime NgayHD, float SLDien, float DonGia, double ThanhTien, bool LoaiDien)
            : base(MaKH, TenKH, NgayHD, SLDien, DonGia, ThanhTien)
        {
            _loaidien = LoaiDien;
        }

        public bool LoaiDien
        {
            get { return _loaidien; }
            set { _loaidien = value; }
        }

        public override void TinhThanhTien()
        {
            if (LoaiDien)
            {
                if (SLDien <= 200)
                {
                    ThanhTien = SLDien * DonGia;
                }
                else
                {
                    ThanhTien = SLDien * DonGia * 0.98;
                }
            }
            else
            {
                if (SLDien <= 150)
                {
                    ThanhTien = SLDien * DonGia;
                }
                else
                {
                    ThanhTien = SLDien * DonGia * 0.97;
                }
            }
        }

        public override void Show()
        {
            base.Show();
            Console.Write($"Loại điện: ");
            if (LoaiDien)
            {
                Console.WriteLine("Điện 2 pha");
            }
            else
            {
                Console.WriteLine("Điện 3 pha");
            }

            TinhThanhTien();
            Console.WriteLine($"Thành tiền: {ThanhTien}");
        }

        public override void Input()
        {
            base.Input();

            int option;

            do
            {
                Console.WriteLine("Chọn loại điện");
                Console.WriteLine("0. Điện 2 pha ");
                Console.WriteLine("1. Điện 3 pha ");
                Console.WriteLine("Nhập lựa chọn: ");
                option = int.Parse(Console.ReadLine());
            } while (option < 0 || option > 1);

            if (option == 0)
            {
                LoaiDien = true;
            }
            else
            {
                LoaiDien = false;
            }
        }
    }
}
