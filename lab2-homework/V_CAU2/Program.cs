using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V_CAU2
{
    class Program
    {
        public static void NhapHangList(List<HangHoa> list)
        {
            string maHang;

            int i = 1;
            do
            {
                Console.WriteLine("\nNhập vào mặt hàng thứ " + (i++) + ": ");
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
            Console.WriteLine("\n============Danh sách các mặt hàng cần nhập hàng============");
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
        public static void Main()
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<HangHoa> l = new List<HangHoa>();
            Console.WriteLine("---------------NHẬP LIST HÀNG HÓA-----------------");
            NhapHangList(l);

            Console.WriteLine("\n============Danh sách các loại hàng hóa============");
            foreach (HangHoa hangHoa in l)
            {
                hangHoa.Show();
                Console.WriteLine("---------------------------------");
            }
            XuatDSCanNhapHang(l);


            Console.ReadKey();
        }
    }
}
