using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV_PHAN1_CAU3
{
    internal class Program
    {
        public class Xe
        {
            private string _tenChuXe;
            private string _loaiXe;
            private double _triGia;
            private int _dungTich;
            public Xe()
            {

            }
            public Xe(string tenChuxe, string loaiXe, double triGia, int dungTich)
            {
                this._tenChuXe = tenChuxe;
                this._loaiXe = loaiXe;
                this._triGia = triGia;
                this._dungTich = dungTich;
            }
            public string tenChuxe { set; get; }
            public string loaiXe { set; get; }
            public double triGia { set; get; }
            public int dungTich { set; get; }
            public double tinhThue()
            {
                double thue;
                if (dungTich < 100)
                    thue = triGia * 0.01;
                else if (dungTich >= 100 && dungTich < 175)
                    thue = triGia * 0.03;
                else
                    thue = triGia * 0.05;
                return thue;
            }

            public override string ToString()
            {
                Console.WriteLine($"{tenChuxe}\t\t {loaiXe}\t\t {triGia}\t\t  {dungTich}\t\t {tinhThue()} ");
                return "";
            }

            public void input()
            {
                Console.WriteLine($"----- Nhap Thong Tin Xe -----");

                Console.Write("Ten Chu Xe: ");
                tenChuxe = Console.ReadLine();
                if (tenChuxe == "")
                {
                    Console.WriteLine("Ket thuc chuong trinh...");
                    Console.WriteLine("---------------------");
                    return;
                }

                Console.Write("Loai xe: ");
                loaiXe = Console.ReadLine();

                Console.Write("Tri gia: ");
                triGia = Convert.ToDouble(Console.ReadLine());

                Console.Write("Dung Tich: ");
                dungTich = Convert.ToInt32(Console.ReadLine());
            }
            public void ouput()
            {
                ToString();
            }
        }

        public static void Main(string[] args)
        {
            Xe[] xe = new Xe[100];
            int n = 0;
            do
            {
                xe[n] = new Xe();
                xe[n].input();
                n++;
            } while (xe[n - 1].tenChuxe != "");
            n--;
            Console.WriteLine("--- Thong Tin Chi Tiet ---");
            Console.WriteLine("Ten chu xe \t Loai xe \t Tri gia \t Dung tich \t Thue");
            for (int i = 0; i < n; i++)
            {
                xe[i].ouput();
            }

            Console.ReadKey();
        }
    }
}
