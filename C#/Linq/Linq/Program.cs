using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        public static Employee employee;
        public static Incentive incentive;
        static void Main(string[] args)
        {
            
           
            employee = new Employee();
            incentive = new Incentive();
            List<Employee> empl = new List<Employee>()
        {
            new Employee(){EmpId = 1,FirstName="Rutva",LastName="Gajera",Salary=20000,JoinDate="20 Jan 2020",Department=".net"},
            new Employee(){EmpId = 2,FirstName="Khushi",LastName="Vekaria",Salary=10000,JoinDate="22 Jan 2020",Department="php"},
            new Employee(){EmpId = 3,FirstName="Krishna",LastName="Nariya",Salary=15000,JoinDate="20 Jan 2020",Department=".net"},
            new Employee(){EmpId = 3,FirstName="Radha",LastName="Patel",Salary=15000,JoinDate="21 Jan 2020",Department=".php"}
        };

            var emp = from e in empl select e;
            Console.WriteLine("LastName FirstName");
            foreach (var e in emp)
                Console.WriteLine(e.LastName.ToUpper() + " " + e.FirstName);

            var unique = empl.Select(o => new { o.Department }).Distinct();
            foreach (var u in unique)
                Console.WriteLine(u);

            var oInJohn = from s in empl where s.FirstName == "Rutva" select s;
            foreach (var i in oInJohn)
            {
                Console.WriteLine(i.FirstName.IndexOf("t"));
                Console.WriteLine(i.FirstName.Replace("t", "$"));
            }

            var fist3Char = from s in empl select s.FirstName;
            foreach (var i in fist3Char)
            {
                Console.WriteLine(i.Substring(0, 3));
                Console.WriteLine("Lenght : " + i.Length);
            }

            var fistCharP = from s in empl where s.FirstName.StartsWith("K") select s.FirstName;
            foreach (var i in fistCharP)
                Console.WriteLine("Start with K : "+i);

            var x = empl.Where(f => f.FirstName == "Khushi");
            foreach (var i in x)
            {
                Console.WriteLine("Khushi Empid : "+i.EmpId);
            }

            var dist = empl.Select(o => o.Department).Distinct();
            foreach (var i in dist)
            {
                Console.WriteLine(i);
            }

            int max1 = empl.Max(f => f.Salary);
            Console.WriteLine("Max Salary : "+max1);
            var max2 = from s in empl where s.Salary < (empl.Select(f => f.Salary).Max()) select s.Salary;
            Console.WriteLine(max2);

            var top10 = (from s in empl orderby s.Salary select s).Take(2).ToList();
            foreach (var i in top10)
                Console.WriteLine("Salary : "+i.Salary);

            var depTotalSalary = empl.Where(x => x.Department == ".net").Select(o => o.Salary).Sum();
            Console.WriteLine("Total Salary of .net department : "+depTotalSalary);

        }
    }
}

