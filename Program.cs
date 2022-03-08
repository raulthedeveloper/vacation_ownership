using System;
using PlaygroundConsole1.Models.DAL;
using PlaygroundConsole1.Models;
using System.Linq;
using Playground2.DAL;
using Microsoft.EntityFrameworkCore;

namespace Playground2
{
    public class Program
    {
        DeleteData deleteData = new DeleteData();
        static void Main(string[] args)
        {
            //string firstName = Console.ReadLine();

            //IEnumerable<Customer> numQuery1 =
            //from customer in data.customers() where customer.FirstName == firstName select customer;

            //IEnumerable<Customer> numQuery1 = data.customers().Where(x => x.FirstName == firstName);

            //foreach (Customer i in numQuery1)
            //{
            //    Console.Write(i.LastName);
            //}

            SalesSystem salesSystem = new SalesSystem();

            salesSystem.Init();
        }
    }

    class SalesSystem
    {
        private readonly SeedData data = new SeedData();
        public DbContext context = new BusinessContext();
       

        public void Init()
        {
            Get GetData = new Get();

        Console.WriteLine("What would you like to do? \n" +
            "[1.View Sales Report] \n" +
            "[2.View Employee Sales] \n" +
            "[3.View All Employees] \n" +
            "[4.View All Customer \n" +
            "[5.View All Resorts] \n" +
            "[6.Add New Data] \n" +
            "[7.Delete Data] \n" +
            "[8.Exit Program]");

            string decision = Console.ReadLine();

            switch (decision)
            {
                case "1":
                    SalesReport();
                    Console.Clear();
                    
                    break;
                case "2":
                    GetEmployeeStats();
                    Console.Clear();
                   
                    break;
                case "3":
                    ViewEmployees();

                    break;
                case "4":
                    ViewCustomers();

                    break;
                case "5":
                    ViewResorts();
                    break;
                case "6":
                    AddNewData();
                    Console.Clear();
                   
                    break;
                case "7":
                    Delete();
                    Console.Clear();
                    Init();
                    break;
                case "8":
                    Console.WriteLine("Good Bye...");
                    System.Threading.Thread.Sleep(2000);
                    break;
                default:
                    Console.Clear();
                    Init();
                    break;
            }
        }

        private void ViewEmployees()
        {
            Get GetData = new Get();
            GetData.ViewEmployees();
            Console.WriteLine("Please type \"done\" when finished view");

            if (Console.ReadLine() == "done")
            {
                Console.Clear();
                Init();
            }
            else
            {
                Console.Clear();
                ViewEmployees();
            }
        }

        private void ViewResorts()
        {
            Get GetData = new Get();
            GetData.ViewResorts();
            Console.WriteLine("Please type \"done\" when finished view");

            if (Console.ReadLine() == "done")
            {
                Console.Clear();
                Init();
            }
            else
            {
                Console.Clear();
                ViewResorts();
            }
        }
        
        private void ViewCustomers()
        {
            Get GetData = new Get();

            GetData.ViewCustomers();
            Console.WriteLine("Please type \"done\" when finished view");

            if (Console.ReadLine() == "done")
            {
                Console.Clear();
                Init();
            }
            else
            {
                ViewCustomers();
            }
        }

        private void AddNewData()
        {
            Console.Clear();

            Create addData = new Create(context);

            Console.WriteLine($"[1.Add New Customer] \n" +
                $"[2.Add New Sale] \n" +
                $"[3.Add New Employee] \n" +
                $"[4.Add New Resort]");

            string decision = Console.ReadLine();

            switch (decision)
            {
                case "1":
                    addData.AddCustomer();
                    Init();
                    break;
                case "2":
                   addData.AddSale();
                    Init();
                    break;
                case "3":
                    addData.AddEmployee();
                    Init();
                    break;
                case "4":
                    addData.AddResort();
                    Init();
                    break;
                default:
                    break;
            }
        }

        private void GetEmployeeStats()
        {


            var employeeStats = data.employees().GroupJoin(data.sales(), e => e.Id,
               s => s.Id, (employee, sales) => new
               {
                   employee = employee,
                   sale = sales

               });

            foreach (var stat in employeeStats)
            {
                Console.WriteLine($"{stat.employee.FirstName}");
                foreach (var sale in stat.sale)
                {
                }
                {

                }
            }
        }

        private void Delete()
        {
            var deleteData = new DeleteData();
            Console.WriteLine($"[1.Delete Customer] \n" +
              $"[2.Delete Sale] \n" +
              $"[3.Delete Employee]");

            string decision = Console.ReadLine();

            switch (decision)
            {
                case "1":
                    deleteData.DeleteCustomer();
                    break;
                //case "2":
                //    addData.AddSale();
                //    break;
                //case "3":
                //    addData.AddEmployee();
                //    break;
                default:
                    break;
            }
        }

       

        private void SalesReport()
        {
            var innerJoinQuery =
            from sales in data.sales()
            join customer in data.customers() on sales.CustomerId equals customer.Id
            join employee in data.employees() on sales.EmployeeId equals employee.Id
            select new {  customer = $"{customer.FirstName}  {customer.LastName}", SalesRep = $"{employee.FirstName}  {employee.LastName}" };

            foreach (var salesReport in innerJoinQuery)
            {
                Console.WriteLine($"Customer: {salesReport.customer} \nSales Rep: {salesReport.SalesRep}");
                Console.WriteLine("--------------------------------");


            }
        }
    }
}
