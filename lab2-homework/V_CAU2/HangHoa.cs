using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V_CAU2
{
    public abstract class HangHoa
    {
        private string _mahang;
        private string _tenhang;
        private int _slton;
        private double _dongia;

        public string mahang { get { return _mahang; } set { _mahang = value; } }
        public string tenhang { get { return _tenhang; } set { _tenhang = value; } }
        public int slton { get { return _slton; } set { _slton = value; } }
        public double dongia { get { return _dongia; } set { _dongia = value; } }

        public HangHoa()
        {

        }

        public HangHoa(string mahang, string tenhang, int slton, double dongia)
        {
            this._mahang = mahang;
            this._tenhang = tenhang;
            this._slton = slton;
            this._dongia = dongia;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Mã hàng: {mahang}");
            Console.WriteLine($"Tên hàng: {tenhang}");
            Console.WriteLine($"Số lượng tồn kho: {slton}");
            Console.WriteLine($"Đơn giá: {dongia}");
        }
        public virtual void NhapHang()
        {
            Console.Write("Nhập tên hàng: ");
            tenhang = Console.ReadLine();
            do
            {
                Console.Write("Nhập số lượng tồn kho: ");
                slton = Convert.ToInt32(Console.ReadLine());
            } while (slton <= 0);
            Console.Write("Nhập đơn giá: ");
            dongia = double.Parse(Console.ReadLine());
        }
        public abstract bool KtTonKho();
        public abstract double TinhThanhTien(int n);
    }
}
