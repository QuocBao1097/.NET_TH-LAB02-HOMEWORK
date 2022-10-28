using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V_CAU2
{
    public class DienMay : HangHoa
    {
        private string _thuonghieu;
        private string _loaimay;
        private int _thoigianbaohanh;

        public DienMay() { }

        public DienMay(string mahang, string tenhang, int slton, double dongia, string thuonghieu, string loaimay, int thoigianbaohanh)
            : base(mahang, tenhang, slton, dongia)
        {


            _thuonghieu = thuonghieu;
            _loaimay = loaimay;
            _thoigianbaohanh = thoigianbaohanh;
        }

        public string thuonghieu { get; set; }
        public string loaimay { get; set; }
        public int thoigianbaohanh { get; set; }
        public override void Show()
        {

            base.Show();
            Console.WriteLine($"Thương hiệu: {thuonghieu}");
            Console.WriteLine($"Loại máy: {loaimay}");
            Console.WriteLine($"Thời gian bảo hành: {thoigianbaohanh}");
        }

        public override void NhapHang()
        {
            base.NhapHang();
            Console.Write("Nhập tên thương hiệu: ");
            thuonghieu = Console.ReadLine();
            Console.Write("Nhập loại máy: ");
            loaimay = Console.ReadLine();
            Console.Write("Nhập thời gian bảo hành (Mấy năm???): ");
            thoigianbaohanh = Convert.ToInt32(Console.ReadLine());
        }

        public override bool KtTonKho()
        {
            if (slton < 3)
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
