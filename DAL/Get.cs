using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PlaygroundConsole1.Models;


namespace Playground2.DAL
{
    public class Get
    {
        SalesSystem SalesSystem = new SalesSystem();

        public void ViewCustomers()
        {
            Console.Clear();
            using(var db = new BusinessContext())
            {
                
                foreach (var customer in db.Customers)
                {
                    Console.WriteLine($"First Name: {customer.FirstName} \n" +
                        $"Last Name: {customer.LastName} \n" +
                        $"Id: {customer.Id}");
                    Console.WriteLine("-----------------------------");
                }

            }
            
        }

        public void ViewResorts()
        {
            Console.Clear();
            using(var db = new BusinessContext())
            {
                foreach (var resort in db.Resort)
                {
                    Console.WriteLine($"Name: {resort.Name} \n" +
                        $"Location:{resort.Location}");
                    Console.WriteLine("-----------------------------");
                }
            }
        }

        public void ViewEmployees()
        {
            Console.Clear();
            using(var db =new BusinessContext())
            {
               
                foreach(var employee in db.Employees)
                {
                    Console.WriteLine($"First Name: {employee.FirstName} \n" +
                        $"Last Name: {employee.LastName} \n" +
                        $"Id: {employee.Id}");
                    Console.WriteLine("-----------------------------");
                }
            }
        }
    }
}
