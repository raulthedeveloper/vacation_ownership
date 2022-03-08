using System;
using System.Collections.Generic;
using System.Text;
using PlaygroundConsole1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Playground2.Models;

namespace Playground2.DAL
{
    
    public class Create
    {
        private DbContext _dbContext;
        SalesSystem SalesSystem = new SalesSystem();
        Get getdata = new Get();

       public Create(DbContext context)
        {
            _dbContext = context;
        }
        public void AddCustomer()
        {
           
            Console.WriteLine("Enter First Name");
            string FirstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name");
            string LastName = Console.ReadLine();   

            Customer customer = new Customer { FirstName = FirstName, LastName = LastName };
            _dbContext.Add(customer);
            _dbContext.SaveChanges();
            Console.WriteLine("Customer Was added");

            Console.Clear();

            SalesSystem.Init();

            

        }

        public void AddResort()
        {
            // Add Conditional to just add units to existing resort
            Console.WriteLine("Do you only want to Units to existing Resorts? [yes] [no]");

            string decision = Console.ReadLine();

            if (decision == "no")
            {

                Console.WriteLine("Enter Resort Name");
                string ResortName = Console.ReadLine();

                Console.WriteLine("Enter Location");
                string Location = Console.ReadLine();


                Console.WriteLine("Enter Price");
                string Price = Console.ReadLine();

                Resort resort = new Resort
                {
                    Name = ResortName,
                    Location = Location,
                    
                };

                _dbContext.Add(resort);
                _dbContext.SaveChanges();

                Console.WriteLine("Would You like to add Units to the Resort");

                if (Console.ReadLine() == "yes")
                {
                    AddUnits();
                }

                Console.WriteLine("Resort Saved");
            }else if (decision == "yes")
            {
                AddUnits();
      
            }
            else
            {
                AddResort();
            }
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }

        public void AddUnits()
        {
            getdata.ViewResorts();

            Console.WriteLine("Enter Resort Id");
            int ResortId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Unit Name");
            string UnitName = Console.ReadLine();

            Console.WriteLine("Enter Price of Units");
            int Price = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter how many rooms on that floor");

            int RoomCount = Int32.Parse(Console.ReadLine());

            if(RoomCount <= 0)
            {
                Console.WriteLine("Please Enter a number higher than 0");
            }
            else if(RoomCount > 50)
            {
                Console.WriteLine("Please Enter A number less than 50");
            }
            else
            {
                for (int i = 0; i < RoomCount; i++)
                {
                    Unit unit = new Unit { ResortId = ResortId, Name = UnitName, Price = Price };

                    _dbContext.Add(unit);
                    _dbContext.SaveChanges();

                }
                Console.WriteLine("Unit Data Saved");
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }

           

            

            Console.WriteLine("Do you want to add more units? [yes] [no]");
            if(Console.ReadLine() == "yes")
            {
                Console.Clear();
                AddUnits();
            }
            else if(Console.ReadLine() == "no")
            {
                Console.Clear();
                SalesSystem.Init();
                
            }

            

        }


        public void AddSale()
        {
            // Show All Employees in console with ID
            getdata.ViewCustomers();
            

            Console.WriteLine("Employee ID");
            string EmployeeId = Console.ReadLine();

            Console.Clear();

            getdata.ViewEmployees();

            // Show All Customers in Console with ID
            Console.WriteLine("Customer ID");
            string CustomerId = Console.ReadLine();

            Sales sales = new Sales
            {
                EmployeeId = Int32.Parse(EmployeeId),
                CustomerId = Int32.Parse(CustomerId),
                
            };

            Console.WriteLine("Sale Was added");
        }

        public void AddEmployee()
        {
            Console.WriteLine("Enter First Name");
            string FirstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name");
            string LastName = Console.ReadLine();

            Employee employee = new Employee { FirstName = FirstName, LastName = LastName };
            _dbContext.Add(employee);
            _dbContext.SaveChanges();
            Console.WriteLine("Employee Was Added");
        }
    }
}
