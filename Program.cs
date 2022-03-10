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
            

            SalesSystem salesSystem = new SalesSystem();

            salesSystem.Init();
        }
    }

    class SalesSystem
    {
        private readonly SeedData data = new SeedData();
        public DbContext context = new BusinessContext();
        private string exitMessage = "Press [Enter] when finished";

        public void Init()
        {

        Console.WriteLine("What would you like to do? \n" +
            "[1.View Data] \n" +
            "[2.Create Sale] \n" +
            "[3.Add New Data] \n" +           
            "[4.Delete Data] \n" +
            "[4.Update Data \n" +
            "[6.Exit Program]");


            switch (Console.ReadLine())
            {
               
                case "1":
                    Console.Clear();

                    ViewData();
                    Console.Clear();
                   
                    break;
                case "2":
                    Console.Clear();

                    AddSale();
                    Console.Clear();
                    Init();

                    break;

                case "3":
                    Console.Clear();

                    AddNewData();
                    Console.Clear();
                   
                    break;
                case "4":
                    Delete();
                    Console.Clear();
                    Init();
                    break;
                case "5":
                    Console.WriteLine("Good Bye...");
                    System.Threading.Thread.Sleep(2000);
                    break;

                default:
                    Console.Clear();
                    Init();
                    break;
            }
        }


        private void ViewData()
        {
            Get GetData = new Get();

            Console.WriteLine("What would you like to do? \n" +
            "[1.View Sales Report] \n" +
            "[2.View All Customers] \n" +
            "[3.View All Employees] \n" +
            "[4.View All Resorts] \n" +
            "[5.Back To Main Menu]");

            switch (Console.ReadLine())
            {
                case "1":
                    
                    GetData.ViewSalesReport();
                    Console.Clear();
                        ViewData();

                    break;
                case "2":
                    ViewCustomers();
                    Console.Clear();
                    ViewData();

                    break;
                case "3":
                    ViewEmployees();
                    Console.Clear();
                    ViewData();
                    break;
               
                case "4":
                    ViewResorts();
                    Console.Clear();
                    ViewData();
                    break;
               
                case "5":
                    Console.Clear();
                    ViewData();
                    break;
                default:
                    Console.Clear();
                    ViewData();
                    break;
            }
        }

        private void UpdateData()
        {
            //Will be used to update the data
            Console.WriteLine("You are updating the data");
        }

        private void AddSale()
        {
            Create create = new Create();
            create.AddSale();
        }

        private void ViewEmployees()
        {
            Get GetData = new Get();
            GetData.ViewEmployees();
            Console.WriteLine(exitMessage);

            Console.ReadLine();
            
        }

        private void ViewResorts()
        {
            Get GetData = new Get();
            GetData.ViewResorts();
            Console.WriteLine(exitMessage);

            Console.ReadLine();
           
        }
        
        private void ViewCustomers()
        {
            Get GetData = new Get();

            GetData.ViewCustomers();
            Console.WriteLine(exitMessage);

            Console.ReadLine();
            
        }

        private void AddNewData()
        {
            Console.Clear();

            Create addData = new Create();

            Console.WriteLine($"[1.Add New Customer] \n" +
                $"[2.Add New Employee] \n" +
                $"[3.Add New Resort] \n" +
                $"[4.Back To Main Menu]");

            string decision = Console.ReadLine();

            switch (decision)
            {
                case "1":
                    addData.AddCustomer();
                    Console.Clear();
                    AddNewData();
                    break;
                case "2":
                    addData.AddEmployee();
                    Console.Clear();
                    AddNewData();
                    break;
                case "3":
                    addData.AddResort();
                    Console.Clear();
                    AddNewData();
                    break;
                case "4":
                    
                    Console.Clear();
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
                    Console.Clear();
                    break;
                case "2":
                    deleteData.DeleteSale();
                    Console.Clear();
                    break;
                //case "3":
                //    addData.AddEmployee();
                //    break;
                default:
                    break;
            }
        }

       

        
    }
}
