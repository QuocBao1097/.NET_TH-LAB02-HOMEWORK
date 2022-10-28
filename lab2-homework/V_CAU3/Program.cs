using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace V_CAU3
{
    class Program
    {
        public static void NhapHangList(List<HangHoa> list)
        {
            string maHang;
            int i = 1;
            do
            {
                Console.WriteLine("\n---Nhập vào mặt hàng thứ " + (i++));
                bool check;
                do
                {
                    check = false;
                    Console.Write("Nhập mã hàng (Nhập Chuỗi rỗng để kết thúc...): ");
                    maHang = Console.ReadLine();

                    foreach (HangHoa index in list)
                    {
                        if (index.mahang.Equals(maHang))
                        {
                            Console.WriteLine("Mã hàng đã tồn tại!!!\n");
                            check = true;
                        }
                    }
                } while (check == true);

                if (maHang == "")
                {
                    break;
                }


                int luaChon;
                Console.WriteLine("\nChọn loại hàng hóa muốn nhập vào kho: ");
                Console.WriteLine("1. Hàng điện máy");
                Console.WriteLine("2. Hàng thực phẩm");
                Console.WriteLine("3. Hàng gia dụng");
                do
                {
                    Console.Write("\nNhập lựa chọn: ");
                    luaChon = int.Parse(Console.ReadLine());
                } while (luaChon < 1 || luaChon > 3);

                switch (luaChon)
                {
                    case 1:
                        {
                            DienMay DM = new DienMay();
                            Console.WriteLine("\n--------------NHẬP THÔNG TIN HÀNG ĐIỆN MÁY--------------");
                            DM.mahang = maHang;
                            DM.NhapHang();
                            list.Add(DM);
                            break;
                        }
                    case 2:
                        {
                            ThucPham TP = new ThucPham();
                            Console.WriteLine("\n--------------NHẬP THÔNG TIN HÀNG THỰC PHẨM--------------");
                            TP.mahang = maHang;
                            TP.NhapHang();
                            list.Add(TP);
                            break;
                        }
                    case 3:
                        {
                            GiaDung GD = new GiaDung();
                            Console.WriteLine("\n--------------NHẬP THÔNG TIN HÀNG GIA DỤNG--------------");
                            GD.mahang = maHang;
                            GD.NhapHang();
                            list.Add(GD);
                            break;
                        }
                    default: break;
                }
            } while (!maHang.Equals(""));
        }

        public static void XuatDSCanNhapHang(List<HangHoa> list)
        {
            Console.WriteLine("\n============DS CÁC MẶT HÀNG CẦN PHẢI NHẬP============");
            foreach (HangHoa hangHoa in list)
            {
                if (hangHoa.KtTonKho() == false)
                {
                    Console.WriteLine($"Mã hàng: {hangHoa.mahang}");
                    Console.WriteLine($"Tên hàng: {hangHoa.tenhang}");
                    Console.WriteLine($"Số lượng tồn: {hangHoa.slton}");

                    if (hangHoa.GetType() == typeof(ThucPham))
                    {
                        ThucPham tp = (ThucPham)hangHoa;
                        Console.WriteLine($"Ngày-Tháng-Năm hết hạn: {tp.ngayhethan.ToString("dd/MM/yyyy")}");
                    }

                    Console.Write("\n");
                }
            }
        }

        // thêm 2 chức năng câu 3
        public static void TaoHoaDon(List<HangHoa> list, List<string> maMH, List<int> soLuong)
        {
            int i = 0;
            bool check = true;
            do
            {
                string ma;
                int sl;
                bool flag = true;
                do
                {
                    Console.Write("\nNhập mã hàng hóa: ");
                    ma = Console.ReadLine();

                    if (ma.Equals(""))
                    {
                        Console.WriteLine("Mã hàng hóa không được để trống!!!");
                        flag = false;
                    }
                } while (!flag);

                int dem = 0;
                foreach (HangHoa hh in list)
                {
                    if (ma.Equals(hh.mahang))
                    {
                        dem++;
                    }
                }

                if (dem == 0)
                {
                    check = false;
                    break;
                }

                bool checkSL = true;
                do
                {
                    checkSL = true;
                    Console.Write("Nhập số lượng cần mua: ");
                    sl = int.Parse(Console.ReadLine());

                    foreach (HangHoa hh in list)
                    {
                        if (hh.mahang.Equals(ma))
                        {
                            if (sl > hh.slton)
                            {
                                Console.WriteLine("Số lượng tồn không đủ để cung cấp. Vui lòng nhập lại số lượng cần mua!!!");
                                checkSL = false;
                            }
                        }
                    }
                } while (sl <= 0 || !checkSL);

                maMH.Add(ma);
                soLuong.Add(sl);
                Console.WriteLine("Mua sản phẩm thành công");
            } while (check);
        }

        public static void InHoaDon(List<HangHoa> list, List<string> maHH, List<int> soLuong)
        {

            double tongTien = 0;
            for (int i = 0; i < maHH.Count; i++)
            {
                foreach (HangHoa hh in list)
                {
                    if (hh.mahang.Equals(maHH[i]))
                    {
                        double thanhTien = hh.TinhThanhTien(soLuong[i]);

                        Console.WriteLine($"Mã hàng: {hh.mahang}");
                        Console.WriteLine($"Tên hàng: {hh.mahang}");
                        Console.WriteLine($"Số lượng: {soLuong[i]}");
                        Console.WriteLine($"Đơn giá: {hh.dongia}");
                        Console.WriteLine($"Thành tiền: {thanhTien}");
                        tongTien += thanhTien;
                    }
                }
            }

            if (tongTien > 1000000 && tongTien <= 2000000)
            {
                tongTien -= tongTien * 0.1;
            }
            else if (tongTien > 2000000)
            {
                tongTien -= tongTien * 0.15;
            }

            Console.WriteLine($"Tổng tiền hóa đơn: {tongTien}");
        }
        //--------------------------------------------------------------
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<string> maHH = new List<string>();
            List<int> soLuong = new List<int>();
            List<HangHoa> l = new List<HangHoa>();

            Console.WriteLine("---------------NHẬP DS HÀNG HÓA-----------------");
            NhapHangList(l);

            Console.WriteLine("\n-------------DANH SÁCH CÁC LOẠI HÀNG HÓA-------------");
            foreach (HangHoa hangHoa in l)
            {
                hangHoa.Show();
                Console.WriteLine("---------------------------------");
            }
            XuatDSCanNhapHang(l);
            //--------------------
            Console.WriteLine("\n-------------THÊM 2 CHỨC NĂNG CHO CÂU 3-------------");
            Console.WriteLine("\n-------------TẠO HÓA ĐƠN MUA HÀNG-------------");
            TaoHoaDon(l, maHH, soLuong);
            Console.WriteLine("\n-------------IN HÓA ĐƠN MUA HÀNG-------------");
            InHoaDon(l, maHH, soLuong);

            Console.WriteLine("Enter để kết thức chương trình...");
            Console.ReadKey();
        }
    }
}
