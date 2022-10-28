using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace IV_PHAN2_CAU4
{
    class Program
    {
        public class Danhba
        {
            private string _sdt;
            private string _dcdk;

            public Danhba()
            {
            }

            public Danhba(string sdt, string dcdk)
            {
                _sdt = sdt;
                _dcdk = dcdk;
            }
            public string sdt { get; set; }
            public string dcdk { get; set; }

            public void Input()
            {
                Console.Write("Nhập SĐT: ");
                sdt = Console.ReadLine();
                Console.Write("Nhập địa chỉ đăng ký: ");
                dcdk = Console.ReadLine();
            }

            public void OutputInfo()
            {
                Console.WriteLine($"{sdt}\t\t{dcdk}");
            }

        }
        public static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            ArrayList ds = new ArrayList();

            Console.Write("\nNhập số lượng SĐT trong danh bạ : ");
            int n = Convert.ToInt32(Console.ReadLine());


            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("---Nhập danh bạ thứ: " + i);
                Danhba db = new Danhba();
                db.Input();
                ds.Add(db);
            }

            Console.WriteLine("\n---Danh sách số điện thoại trong danh bạ---");
            foreach (Danhba db in ds)
            {
                Console.WriteLine($"SĐT\t\tĐịa chỉ đăng ký");
                db.OutputInfo();
            }
            Console.WriteLine("*************************");
            Console.WriteLine("***Hình Thức 1");
            Console.Write("Nhập SĐT cần tìm trong danh bạ : ");
            string sdt = Console.ReadLine();
            foreach (Danhba db in ds)
            {
                if (String.Compare(db.sdt, sdt, true) == 0)
                {
                    Console.WriteLine($"SĐT\t\tĐịa chỉ đăng ký");
                    db.OutputInfo();
                }
            }

            Console.WriteLine("***Hình Thức 2");
            Console.Write("Nhập SĐT cần tìm trong danh bạ : ");
            sdt = Console.ReadLine();

            Console.Write("Nhập ĐỊA CHỈ đăng ký cần tìm : ");
            string dcdk = Console.ReadLine();

            Console.WriteLine($"SĐT\t\tĐịa chỉ đăng ký");
            foreach (Danhba db in ds)
            {
                if (String.Compare(db.dcdk, dcdk, true) == 0)
                {

                    if (String.Compare(db.sdt, sdt, true) == 0)
                    {
                        db.OutputInfo();
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
