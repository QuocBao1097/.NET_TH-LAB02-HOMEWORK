using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V_CAU1
{
    class Program
    {
        public static void NhapDS(List<KhachHang> list)
        {
            string MaKH = "";
            string TenKH;
            DateTime NgayHD = new DateTime(1, 1, 1);

            int i = 1;
            do
            {
                Console.WriteLine("\nNhập vào khách hàng thứ " + (i++) + ": ");

                int luaChon;

                Console.Write("Nhập mã khách hàng: ");
                MaKH = Console.ReadLine();

                if (MaKH.Equals(""))
                {
                    break;
                }

                do
                {
                    Console.Write("Nhập tên khách hàng: ");
                    TenKH = Console.ReadLine();

                    if (TenKH.Equals(""))
                    {
                        Console.WriteLine("Tên khách hàng không được để trống !!!");
                    }
                } while (TenKH.Equals(""));

                int check;
                do
                {
                    check = 0;
                    Console.Write("Nhập dd/mm/yyyy của hóa đơn: ");
                    NgayHD = Convert.ToDateTime(Console.ReadLine());

                    Console.WriteLine("Chọn loại điện sử dụng: ");
                    Console.WriteLine("1. Điện sinh hoạt");
                    Console.WriteLine("2. Điện kinh doanh");
                    Console.WriteLine("3. Điện sản xuất");
                    do
                    {
                        Console.Write("\nNhập lựa chọn: ");
                        luaChon = int.Parse(Console.ReadLine());
                    } while (luaChon < 1 || luaChon > 3);

                    foreach (KhachHang c in list)
                    {
                        int loai = 0;
                        if (c.GetType() == typeof(SinhHoat))
                        {
                            loai = 1;
                        }
                        else if (c.GetType() == typeof(KinhDoanh))
                        {
                            loai = 2;
                        }
                        else if (c.GetType() == typeof(SanXuat))
                        {
                            loai = 3;
                        }

                        if (c.MaKH.Equals(MaKH) && c.TenKH.Equals(TenKH))
                        {
                            if (loai == luaChon && DateTime.Compare(NgayHD, c.NgayHD) == 0)
                            {
                                check = 1;
                            }
                        }

                        if (check == 1)
                        {
                            Console.WriteLine("Khách hàng đã tồn tại. Phải chọn cùng loại điện và khác ngày hóa đơn!!!\n");
                        }
                    }
                } while (check == 1);

                switch (luaChon)
                {
                    case 1:
                        {
                            SinhHoat sh = new SinhHoat();
                            sh.MaKH = MaKH;
                            sh.TenKH = TenKH;
                            sh.NgayHD = NgayHD;

                            sh.Input();

                            sh.TinhThanhTien();
                            list.Add(sh);
                            break;
                        }
                    case 2:
                        {
                            KinhDoanh kd = new KinhDoanh();
                            kd.MaKH = MaKH;
                            kd.TenKH = TenKH;
                            kd.NgayHD = NgayHD;

                            kd.Input();

                            kd.TinhThanhTien();
                            list.Add(kd);
                            break;
                        }
                    case 3:
                        {
                            SanXuat sx = new SanXuat();
                            sx.MaKH = MaKH;
                            sx.TenKH = TenKH;
                            sx.NgayHD = NgayHD;

                            sx.Input();

                            sx.TinhThanhTien();
                            list.Add(sx);
                            break;
                        }
                    default: break;
                }
            } while (!MaKH.Equals(""));
        }

        public static void XuatHD(List<KhachHang> list)
        {
            int dem = 0, thang, nam;
            do
            {
                Console.Write("Nhập tháng hóa đơn: ");
                thang = Convert.ToInt32(Console.ReadLine());
            } while (thang <= 0 || thang > 12);

            do
            {
                Console.Write("Nhập năm hóa đơn: ");
                nam = Convert.ToInt32(Console.ReadLine());
            } while (nam <= 0);

            foreach (KhachHang c in list)
            {
                if (c.NgayHD.Month == thang && c.NgayHD.Year == nam)
                {
                    Console.WriteLine($"\nMã khách hàng: {c.MaKH}" +
                        $"\nTên khách hàng: {c.TenKH}" +
                        $"\nSố lượng điện: {c.SLDien}" +
                        $"\nThành tiền: {c.ThanhTien}");
                }
                dem++;
            }

            if (dem == 0)
            {
                Console.WriteLine("Không tồn tại hóa đơn trùng với thời gian nhập vào!!!");
            }
        }

        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<KhachHang> l = new List<KhachHang>();

            Console.WriteLine("\n------NHẬP DANH SÁCH HÓA ĐƠN------");
            NhapDS(l);

            Console.WriteLine("\n------XUẤT DANH SÁCH HÓA ĐƠN------");
            foreach (KhachHang c in l)
            {
                c.Show();
                Console.WriteLine("\n");
            }

            Console.WriteLine("------TÌM HÓA ĐƠN------");
            XuatHD(l);
            Console.Write("Enter de ket thuc...");

            Console.ReadKey();
        }
    }
}
