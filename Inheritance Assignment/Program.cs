using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

class Employee
{
    public int Id { get; set; }
    public string EmployeeName { get; set; }
    public DateTime JoiningDate { get; set; }
    public string Project_Assigned { get; set; }

    public Employee(int id, string employeeName, DateTime joiningDate,
     string project_Assigned)
    {
        Id = id;
        EmployeeName = employeeName;
        JoiningDate = joiningDate;
        Project_Assigned = project_Assigned;
    }
    public virtual void DisplayDetails()
    {
        Console.WriteLine("DevelopersID: " + Id);
        Console.WriteLine("DevelopersName: " + EmployeeName);
        Console.WriteLine("Joining Date: " + JoiningDate);
        Console.WriteLine("Project_Assigned: " + Project_Assigned);

    }

    public Employee()
    {
        Console.WriteLine("Enter Id");
        this.Id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Developers name");
        this.EmployeeName = Console.ReadLine();
        Console.WriteLine("Enter Joining");
        this.JoiningDate = DateTime.Parse((Console.ReadLine()));
        Console.WriteLine("Enter Project Assigned");
        this.Project_Assigned = Console.ReadLine();


    }


}

class OnContractDeveloper : Employee
{
    public int Duration { get; set; }
    public int Charges_Per_Day { get; set; }
    public int TotalSalary;
    public OnContractDeveloper() : base()
    {
        Console.WriteLine("Enter Duration");
        this.Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Charges per day");
        this.Charges_Per_Day = int.Parse(Console.ReadLine());
        TotalCharges();
    }
    public int TotalCharges()
    {

        TotalSalary = Duration * Charges_Per_Day;
        return TotalSalary;
    }
    public override void DisplayDetails()
    {

        base.DisplayDetails();
        Console.WriteLine("Duration" + Duration);
        Console.WriteLine("Charges Per day" + Charges_Per_Day);
        Console.WriteLine("Total Charges" + TotalSalary);
    }

}
class Onpayroll : Employee
{
    public string Dept { get; set; }
    public string Manager { get; set; }
    public int NetSalary { get; set; }
    public int Exp { get; set; }
    public int basicSalary { get; set; }
    public int da, hra, pf;
    public Onpayroll() : base()
    {
        Console.WriteLine("Enter Department");
        this.Dept = Console.ReadLine();
        Console.WriteLine("Enter Manager");
        this.Manager = Console.ReadLine();
        Console.WriteLine("Enter EXp");
        this.Exp = int.Parse((Console.ReadLine()));
        Console.WriteLine("Enter basic salary");
        this.basicSalary = int.Parse((Console.ReadLine()));

        CalculateNetSalary();
    }
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Department :" + Dept);
        Console.WriteLine("Manager :" + Manager);
        Console.WriteLine("EXp :" + Exp);
        Console.WriteLine("Net Salary :" + NetSalary);
    }
    public int CalculateNetSalary()

    {
        if (Exp > 10)
        {
            da = (int)(0.1 * basicSalary);
            hra = (int)(0.085 * basicSalary);
            pf = 6200;
        }
        else if (Exp > 7)
        {
            da = (int)(0.07 * basicSalary);
            hra = (int)(0.065 * basicSalary);
            pf = 4100;
        }
        else if (Exp > 5)
        {
            da = (int)(0.041 * basicSalary);
            hra = (int)(0.038 * basicSalary);
            pf = 1800;
        }
        else
        {
            da = (int)(0.019 * basicSalary);
            hra = (int)(0.02 * basicSalary);
            pf = 1200;
        }

        NetSalary = basicSalary + da + hra - pf;
        return NetSalary;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int i;
        Console.WriteLine("Enter the number of employees");
        i = int.Parse(Console.ReadLine());
        while (i>=0)
        {
            Console.Write("Type (1 - OnContract, 2 - OnPayroll): ");
            int type = int.Parse(Console.ReadLine());
            if (type == 1)
            {
                OnContractDeveloper developer = new OnContractDeveloper();
                developer.DisplayDetails();


            }
            if (type == 2)
            {
                Onpayroll dev = new Onpayroll();
                dev.DisplayDetails();
            }
            i--;
        }

        //int i = 0;
        //List<Developer> developers = new List<Developer>();
        //while (i < 3)
        //{
        //    Console.Write("Type (1 - OnContract, 2 - OnPayroll): ");
        //    int type = int.Parse(Console.ReadLine());
        //    if (type == 1)
        //    {
        //        OnContractDeveloper developer = new OnContractDeveloper();
        //        developers.Add(developer);


        //    }
        //    if (type == 2)
        //    {
        //        Onpayroll dev = new Onpayroll();
        //        developers.Add(dev);
        //    }
        //    i++;
        //}


        ////Onpayroll dev = new Onpayroll();
        ////Onpayroll dev1 = new Onpayroll();
        ////developers.Add(dev);
        ////developers.Add(dev1);
        ////foreach (Onpayroll i in developers)
        ////{ 
        ////   i.Display_details();
        ////    Console.WriteLine(i.CalculateNetSalary());
        ////}
        //var onPayrollDeveopersList = developers.OfType<Onpayroll>().ToList();
        //var onContractList = developers.OfType<OnContractDeveloper>().ToList();

        //var dev1 = from emp in onPayrollDeveopersList
        //           select emp;
        //foreach (var deve in dev1)
        //{
        //    deve.DisplayDetails();
        //}


        //var dev2 = from emp1 in onContractList
        //           select emp1;
        //foreach (var deve1 in dev2)
        //{
        //    deve1.DisplayDetails();
        //}
        //var devs = from dd in onPayrollDeveopersList
        //           where dd.NetSalary > 20000
        //           select dd;
        //foreach (var developer in devs)
        //{
        //    developer.DisplayDetails();
        //}
        ////var dev = from emp in onPayrollDeveopersList
        ////          select emp;
        ////foreach (var deve in dev) { 
        ////       deve.DisplayDetails();
        ////}
        //var listContainiungD = developers.Where(x => x.DeveloperName.Contains('D')).ToList();
        //if (listContainiungD.Count == 0)
        //{
        //    Console.WriteLine("No Name");
        //}
        //else
        //    foreach (var item in listContainiungD)
        //    {
        //        item.DisplayDetails();
        //    }

        //var devs3 = from record in onPayrollDeveopersList
        //            where record.JoiningDate >= new DateTime(2020, 1, 1) && record.JoiningDate < new DateTime(2022, 1, 1)
        //            select record;
        //foreach (var dd4 in devs3)
        //{
        //    dd4.DisplayDetails();
        //}
        //var devs33 = from record1 in onContractList
        //             where record1.JoiningDate >= new DateTime(2020, 1, 1) && record1.JoiningDate < new DateTime(2022, 1, 1)
        //             select record1;
        //foreach (var dd6 in devs33)
        //{
        //    dd6.DisplayDetails();
        //}
        //var devs7 = from record3 in onPayrollDeveopersList
        //            where record3.JoiningDate == new DateTime(2020, 1, 12)
        //            select record3;
        //foreach (var dd7 in devs7)
        //{
        //    dd7.DisplayDetails();
        //}
        //var devs8 = from record4 in onContractList
        //            where record4.JoiningDate == new DateTime(2020, 1, 12)
        //            select record4;
        //foreach (var dd8 in devs8)
        //{
        //    dd8.DisplayDetails();
        //}
    }
}
