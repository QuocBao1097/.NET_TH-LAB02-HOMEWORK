using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV_PHAN2_CAU1
{

    abstract class Person
    {
        private string name;
        private int age;
        public abstract void Show();
    }

    class Employee : Person
    {
        private double salary;
        public override void Show()
        {
            Console.WriteLine("Create again Show Method!");
        }
        public double addSalary()
        {
            return salary * 1.1;
        }
        public double addSalary(float x)
        {
            return salary * x;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee(); // Create a employ Object
            //...
        }
    }
}
