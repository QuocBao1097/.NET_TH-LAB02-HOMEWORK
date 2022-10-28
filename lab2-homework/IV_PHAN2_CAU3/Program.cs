using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV_PHAN2_CAU3
{
    public class Max_Min<T> where T : IComparable
    {
        private T[] Numbers;
        public Max_Min(int size) => Numbers = new T[size];
        public int count => Numbers.Length;
        public void Set(int index, T value)
        {
            if (index >= 0 && index < Numbers.Length)
                Numbers[index] = value;
        }
        public T Get(int index)
        {
            return (index >= 0 && index < Numbers.Length) ? Numbers[index] : default(T);
        }
        public T Max()
        {
            T maximun = Numbers[0];
            if (maximun.GetType() == typeof(string))
            {
                for (int i = 1; i < Numbers.Length; i++)
                {
                    if (Numbers[i].ToString().Length > maximun.ToString().Length)
                    {
                        maximun = Numbers[i];
                    }
                }
            }
            else
            {
                for (int i = 1; i < Numbers.Length; i++)
                {
                    if (Numbers[i].CompareTo(maximun) > 0)
                    {
                        maximun = Numbers[i];
                    }
                }
            }
            return maximun;
        }



        public T Min()
        {
            T minium = Numbers[0];
            if (minium.GetType() == typeof(string))
            {
                for (int i = 1; i < Numbers.Length; i++)
                {
                    if (Numbers[i].ToString().Length < minium.ToString().Length)
                    {
                        minium = Numbers[i];
                    }
                }
            }
            else
            {
                for (int i = 1; i < Numbers.Length; i++)
                {
                    if (Numbers[i].CompareTo(minium) < 0)
                    {
                        minium = Numbers[i];
                    }
                }
            }
            return minium;
        }
    }
    public class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("NHẬP SỐ LƯỢNG PHẦN TỬ TRONG MẢNG: ");
            int n = Convert.ToInt32(Console.ReadLine());
            var dsFloat = new Max_Min<float>(n);
            int length = dsFloat.count;

            for (int i = 0; i < length; i++)
            {

                Console.Write($"NHẬP PHẦN TỬ THỨ {i}: ");
                float x = float.Parse(Console.ReadLine());
                dsFloat.Set(i, x);
            }


            Console.WriteLine("-----------RESULT----------- ");
            float result1 = dsFloat.Max();
            Console.Write("___MAX: ");
            Console.WriteLine(result1);

            float result2 = dsFloat.Min();
            Console.Write("___MIN: ");
            Console.WriteLine(result2);

            Console.ReadKey();
        }
    }
}
