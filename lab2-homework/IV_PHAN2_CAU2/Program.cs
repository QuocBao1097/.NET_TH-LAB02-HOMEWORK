using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV_PHAN2_CAU2
{
    class Program
    {
        public class ChuyenXe
        {
            private string _maChuyen;
            private string _hotentaixe;
            private string _soxe;
            private double _khoiluongHH;
            private double _doanhthu;

            public ChuyenXe()
            {
            }

            public ChuyenXe(string maChuyen, string hotentaixe, string soxe, double khoiluongHH, double doanhthu)
            {
                this._maChuyen = maChuyen;
                this._hotentaixe = hotentaixe;
                this._soxe = soxe;
                this._khoiluongHH = khoiluongHH;
                this._doanhthu = doanhthu;
            }

            public string maChuyen { set; get; }
            public string hotentaixe { set; get; }
            public string soxe { set; get; }
            public double khoiluongHH { set; get; }
            public double doanhthu { set; get; }
            

            public virtual void nhap()
            {
                Console.Write("Nhập mã chuyến xe: ");
                this.maChuyen = Console.ReadLine();
                Console.Write("Nhập họ tên tài xế: ");
                this.hotentaixe = Console.ReadLine();
                Console.Write("Nhập số xe: ");
                this.soxe = Console.ReadLine();
                Console.Write("Nhập khối lượng hàng hóa: ");
                this.khoiluongHH = double.Parse(Console.ReadLine());
                Console.Write("Nhập doanh thu: ");
                this.doanhthu = double.Parse(Console.ReadLine());

            }

            public virtual void inthongtin()
            {

                Console.WriteLine("Mã chuyến xe: " + maChuyen);
                Console.WriteLine("Họ tên tài xế: " + hotentaixe);
                Console.WriteLine("Số xe: " +soxe);
                Console.WriteLine("Khối lượng hàng hóa: " + khoiluongHH);
                Console.WriteLine("Doanh thu: " + doanhthu);
            }
        }

        //---------------------------------------------------
        public class ChuyenNoiThanh : ChuyenXe
        {
            private double _quangduong;

            public ChuyenNoiThanh() : base()
            {
            }

      
            public ChuyenNoiThanh(double quangduong, string maChuyen, string hotentaixe, string soxe, double khoiluongHH, double doanhthu)
                : base(maChuyen, hotentaixe, soxe, khoiluongHH, doanhthu)
            {
                this._quangduong = quangduong;
            }
            public double quangduong { get { return _quangduong; } set { _quangduong = value; } }
      
            public override void nhap()
            {
                base.nhap();
                Console.Write("Nhập quãng đường đi(km): ");
                this.quangduong = double.Parse(Console.ReadLine());

            }

            public override void inthongtin()
            {
                Console.WriteLine("Thông tin chuyến xe nội thành");
                Console.WriteLine("--------------------------");
                base.inthongtin();
                Console.WriteLine("Quãng đường đi: " + quangduong);

            }
        }

        public class ChuyenNgoaiThanh : ChuyenXe
        {
            private string _noiden;
            private double _songayvanchuyen;

            public ChuyenNgoaiThanh() : base()
            {
            }

            public ChuyenNgoaiThanh(string noiden, double songayvanchuyen, string maChuyen, string hotentaixe, string soxe, double khoiluongHH, double doanhthu)
                : base(maChuyen, hotentaixe, soxe, khoiluongHH, doanhthu)
            {
                this._noiden = noiden;
                this._songayvanchuyen = songayvanchuyen;
            }

            public string noiden { get { return _noiden; } set { _noiden = value; } }
            public double songayvanchuyen { get { return _songayvanchuyen; } set { _songayvanchuyen = value; } }
        
            public override void nhap()
            {
                base.nhap();
                Console.Write("Nhập nơi đến: ");
                this.noiden = Console.ReadLine();
                Console.Write("Nhập số ngày vận chuyển: ");
                this.songayvanchuyen = double.Parse(Console.ReadLine());

            }

            public override void inthongtin()
            {
                Console.WriteLine("Thông tin chuyến xe ngoại thành");
                Console.WriteLine("--------------------------");
                base.inthongtin();
                Console.WriteLine("Nơi đến: " + noiden);
                Console.WriteLine("Số ngày vận chuyển: " + songayvanchuyen);

            }
        }

        public class ListChuyenXe
        {
            private List<ChuyenXe> dsChuyen = new List<ChuyenXe>();
            int soChuyen;
            double DoanhThuCNNT = 0;
            string maChuyenNT = "";
            string maChuyenNgT = "";
            double DoanhThuCNNgT = 0;
            double TongDoanhThuNoiThanh = 0;
            double TongDoanhThuNgoaiThanh = 0;

            public ListChuyenXe()
            {
            }

            public ListChuyenXe(int soChuyen)
            {
                this.soChuyen = soChuyen;
            }
            public void nhapchuyen()
            {
                do
                {
                    Console.Write("Nhập số lượng chuyến xe: ");
                    soChuyen = int.Parse(Console.ReadLine());

                    if (this.soChuyen < 1 || this.soChuyen > 20)
                    {
                        Console.WriteLine("Vui lòng nhập lại số chuyến xe!");
                    }
                } while (this.soChuyen < 1 || this.soChuyen > 20);


                for (int k = 0; k < soChuyen; k++)
                {
                    Console.WriteLine("--------------------Nhập thông tin chuyến xe thứ " + (k + 1) + "----------------------");
                    int luachon;

                    Console.WriteLine("Chọn loại chuyến xe : ");
                    Console.WriteLine("1.Chuyến nội thành");
                    Console.WriteLine("2.Chuyến ngoại thành");
                    Console.Write("Lựa chọn: ");
                    luachon = int.Parse(Console.ReadLine());
                    while (luachon != 1 && luachon != 2)
                    {
                        Console.Write("Vui lòng chọn lại: ");
                        luachon = int.Parse(Console.ReadLine());
                    }
                    switch (luachon)
                    {
                        case 1:
                            {

                                ChuyenXe chuyennoithanh = new ChuyenNoiThanh();
                                chuyennoithanh.nhap();
                                dsChuyen.Add(chuyennoithanh);
                                this.TongDoanhThuNoiThanh += chuyennoithanh.doanhthu;
                                if (this.DoanhThuCNNT < chuyennoithanh.doanhthu)
                                {
                                    this.DoanhThuCNNT = chuyennoithanh.doanhthu;
                                    this.maChuyenNT = chuyennoithanh.maChuyen;
                                }
                                break;
                            }
                        case 2:
                            {

                                ChuyenXe chuyenngoaithanh = new ChuyenNgoaiThanh();
                                chuyenngoaithanh.nhap();
                                dsChuyen.Add(chuyenngoaithanh);
                                this.TongDoanhThuNgoaiThanh += chuyenngoaithanh.doanhthu;
                                if (this.DoanhThuCNNgT < chuyenngoaithanh.doanhthu)
                                {
                                    this.DoanhThuCNNgT = chuyenngoaithanh.doanhthu;
                                    this.maChuyenNgT = chuyenngoaithanh.maChuyen;
                                }
                                break;
                            }

                    }
                }

            }

            public void xuatchuyen()
            {
                Console.WriteLine("\n----Thông tin các Chuyến xe----- ");
                foreach (var s in dsChuyen)
                {
                    s.inthongtin();
                }
            }

            public void TongDoanhThu()
            {
                Console.WriteLine("Tổng doanh thu chuyến nội thành: " + this.TongDoanhThuNoiThanh);
                Console.WriteLine("Tổng doanh thu chuyến ngoại thành: " + this.TongDoanhThuNgoaiThanh);

            }

            public void DoanhThuCaoNhat()
            {
                Console.WriteLine("\n---Chuyến xe nội thành có doanh thu cao nhất---");
                foreach (var x in dsChuyen)
                {
                    if (this.maChuyenNT == x.maChuyen && this.DoanhThuCNNT == x.doanhthu)
                    {
                        x.inthongtin();
                    }
                }

                Console.WriteLine("\n---Chuyến xe ngoại thành có doanh thu cao nhất---");
                foreach (var x in dsChuyen)
                {
                    if (this.maChuyenNgT == x.maChuyen && this.DoanhThuCNNgT == x.doanhthu)
                    {
                        x.inthongtin();
                    }
                }

            }

            public void main()
            {
                this.nhapchuyen();
                this.xuatchuyen();
                this.TongDoanhThu();
                this.DoanhThuCaoNhat();
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            ListChuyenXe listChuyen = new ListChuyenXe();
            listChuyen.main();
            Console.ReadKey();
        }
    }
}
