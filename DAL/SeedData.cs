using System;
using System.Collections.Generic;
using System.Linq;

using PlaygroundConsole1.Models;

namespace PlaygroundConsole1.Models.DAL
{
    public class SeedData
    {
        public List<Customer> customers()
        {
            return  new List<Customer>
        {

            new Customer
            {
                Id = 1,
                FirstName = "Carmen",
                LastName = "Rodriguez",
            },
           

            new Customer
            {
                Id = 2,
                FirstName="Stephanie",
                LastName= "Vasquez"
            },
            new Customer
            {
                Id = 3,
                FirstName = "Peter",
                LastName = "Parker"
            },
            new Customer
            {
                Id = 4,
                FirstName = "Nico",
                LastName = "Rodriguez"
            },
            new Customer
            {
                Id = 5,
                FirstName = "Kristen",
                LastName = "Vasquez"
            },
            new Customer
            {
                Id = 6,
                FirstName ="Thomas",
                LastName = "Holland"
                },
            new Customer
            {
                Id = 7,
                FirstName = "Miguel",
                LastName = "Jimenez"
            }
        };
        }

        public List<Employee> employees()
        {
            return new List<Employee>
            {
                new Employee {
                Id = 1,
                FirstName = "Raul",
                LastName = "Rodriguez"
                },
                new Employee {
                Id=2,
                FirstName = "Scott",
                LastName = "McGlenn"
                },
                new Employee {
                Id =3,
                FirstName = "Norma",
                LastName = "Hendricks"
                },

            };
        }
       
        public List<Sales> sales()
        {
            return new List<Sales>
            {
                new Sales
                {
                    Id = 1,
                    CustomerId = 1, 
                    EmployeeId = 1,
                    
                },
                 new Sales
                {
                    Id = 2,
                    CustomerId = 2,
                    EmployeeId = 3,
                    
                },
                  new Sales
                {
                    Id = 3,
                    CustomerId = 3,
                    EmployeeId = 1,
                    
                },
                   new Sales
                {
                    Id = 4,
                    CustomerId = 4,
                    EmployeeId = 2,
                    
                },
                   new Sales
                   {
                    Id = 5,
                    CustomerId = 5,
                    EmployeeId = 3,
                    
                   },
                   new Sales
                   {
                    Id = 6,
                    CustomerId = 6,
                    EmployeeId = 1,
                   
                   },
                    new Sales
                   {
                    Id = 7,
                    CustomerId = 7,
                    EmployeeId = 2,
                    
                   }

            };
        }


    }
}
