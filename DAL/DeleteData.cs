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
        Create create = new Create();

        string deleteMessage = "Are you sure you want to delete [yes] [no]";

        public void DeleteCustomer()
        {
            //Show all customers
            Console.Clear();

            getData.ViewCustomers();

            Console.WriteLine("Which customer do you want to remove? [Enter ID Number]");

            string customerId = Console.ReadLine();


            Console.WriteLine(deleteMessage);

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

        public void DeleteSale()
        {
            Console.Clear();

            getData.ViewSalesReport();

            Console.WriteLine("Which Sale Do you want to remove [Enter Sale Id]");
            int Id = int.Parse(Console.ReadLine());

            Console.WriteLine(deleteMessage);

            string decision = Console.ReadLine();


            if (decision == "yes")
            {
                Sales sale = new Sales
                {
                    Id = Id
                };



                context.Remove<Sales>(sale);

                context.SaveChanges();

                create.UpdateDatePurchaseStatus(false,Id);

                SalesSystem.Init();

            }
            else if (decision == "no")
            {
                SalesSystem.Init();
            }
            else
            {
                DeleteSale();
            }

        }

    }
}
