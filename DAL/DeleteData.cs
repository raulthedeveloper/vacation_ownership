using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore ;
using PlaygroundConsole1.Models;

namespace Playground2.DAL
{
    
    public class DeleteData
    {
        DbContext context = new BusinessContext();
        Get getData = new Get();
        SalesSystem SalesSystem = new SalesSystem();

        public void DeleteCustomer()
        {
            //Show all customers

            getData.ViewCustomers();

            Console.WriteLine("Which customer do you want to remove? [Enter ID Number]");

            string customerId = Console.ReadLine();


            Console.WriteLine("Are you sure you want to delete [yes] [no]");

            string decision = Console.ReadLine();


            if (decision == "yes")
            {
                Customer customer = new Customer
                {
                    Id = int.Parse(customerId)
                };



                context.Remove<Customer>(customer);

                context.SaveChanges();
                SalesSystem.Init();

            } 
            else if(decision == "no")
            {
                SalesSystem.Init();
            }
            else
            {
                DeleteCustomer();
            }
            
        }

    }
}
