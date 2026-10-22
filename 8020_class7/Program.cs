using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8020_class7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee("Noa", new DateTime(2015, 6, 1), 30000);
            Employee e2 = new Employee();
            Console.WriteLine(e1);
            Console.WriteLine(e2);
            Console.WriteLine(Employee.GetNumEmployees());

            Manager m1 = new Manager("Tamar", new DateTime(2010, 4, 3), 35000, "SW Manager");
            Console.WriteLine(m1);

            Manager m2 = new Manager("Shay", "HW manager");

            Manager m3 = new Manager("Silicon manager");
            Console.WriteLine(m2);
            Console.WriteLine(m3);
        }

        static int Add (int a, int b)
        {
            return a + b;
        }


    }

    public class Employee
    {
        private string name;
        protected int salary;
        private DateTime startDate;
        private const int defaultSalary = 10000;
        private static int numEmployees = 0;

        public Employee (string name, DateTime startDate, int salary)
        {
            this.name = name;
            this.startDate = startDate;
            this.salary = salary;
            numEmployees++;
        }

        public Employee() : this ("EinShem", DateTime.Now, defaultSalary)
        {
            
        }

        public Employee(string name) : this (name, DateTime.Now, defaultSalary)
        {

        }

        public virtual int Bonus()
        {
            return (DateTime.Now.Year - startDate.Year) * 1000;
        }

        public static int GetNumEmployees()
        {
            return numEmployees;
        }

        public override string ToString()
        {
            return ($"name = {name}, start Date = {startDate}, salary = {salary}, bonus = {Bonus()}");
        }
    }

    public class Manager : Employee
    {
        private string title;

        public Manager(string name, DateTime startDate, int salary, string title) : base(name, startDate, salary)
        {
            this.title = title;
        }

        public Manager(string name, string title) : base (name)
        {
            this.title = title;
        }

        public Manager(string title)
        {
            this.title = title;
        }

        public void Raise(int raise)
        {
            salary += raise;
        }

        public override string ToString()
        {
            //return base.ToString();
            return base.ToString() + $" title = {title}";
        }

        public override int Bonus()
        {
            return 3 * base.Bonus();
        }
    }
}
