using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V_CAU3
{
    public class ThucPham : HangHoa
    {

        private DateTime _ngaysanxuat;
        private DateTime _ngayhethan;
        private string _nhacungcap;
        public ThucPham() { }

        public ThucPham(string mahang, string tenhang, int slton, double dongia, DateTime ngaysanxuat, DateTime ngayhethan, string nhacungcap)
            : base(mahang, tenhang, slton, dongia)
        {
            this._ngaysanxuat = ngaysanxuat;
            this._ngayhethan = ngayhethan;
            this._nhacungcap = nhacungcap;
        }

        public DateTime ngaysanxuat { get; set; }
        public DateTime ngayhethan { get; set; }
        public string nhacungcap { get; set; }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Ngày sản xuất: {ngaysanxuat.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Ngày hết hạn: {ngayhethan.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Nhà cung cấp: {nhacungcap}");

        }

        public override void NhapHang()
        {
            base.NhapHang();
            Console.Write("Nhập Ngày/Tháng/Năm sản xuất: ");
            ngaysanxuat = Convert.ToDateTime(Console.ReadLine());
            do
            {
                Console.Write("Nhập Ngày/Tháng/Năm hết hạn: ");
                ngayhethan = Convert.ToDateTime(Console.ReadLine());
                if (ngaysanxuat > ngayhethan)
                {
                    Console.WriteLine("Ngày hết hạn phải bằng hoặc sau ngày sản xuất");
                }

            } while (ngaysanxuat > ngayhethan);

            Console.Write("Nhập Nhà cung cấp: ");
            nhacungcap = Console.ReadLine();
        }

        public override bool KtTonKho()
        {
            if (DateTime.Now >= ngayhethan)
                return false;
            return true;
        }
        public override double TinhThanhTien(int n)
        {
            slton -= n;
            return n * dongia * 1.1;
        }
    }
}
