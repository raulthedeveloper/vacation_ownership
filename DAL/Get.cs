using System;
using System.Collections.Generic;
using System.Text;
using PlaygroundConsole1.Models;
using System.Linq;




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

        public void ViewResortsList()
        {
            using (var db = new BusinessContext())
            {
                foreach (var resort in db.Resort)
                {
                    Console.WriteLine($"Id:{resort.Id} \n" + $"Name:{resort.Name} \n" +
                        $"Location:{resort.Location}");
                    Console.WriteLine("-----------------------------");
                }

                ViewUnits();

            }

            
        }

        public void ViewResorts()
        {
            Console.Clear();
            using(var db = new BusinessContext())
            {
                foreach (var resort in db.Resort)
                {
                    Console.WriteLine($"Id:{resort.Id} \n" + $"Name:{resort.Name} \n" +
                        $"Location:{resort.Location}");
                    Console.WriteLine("-----------------------------");
                }
            }
            Console.WriteLine("Do you want to see units of a resort? [yes] [no]");

            string decision = Console.ReadLine().ToLower();

            if (decision == "yes")
            {
                ViewUnits();
            }
            else if (decision == "no")
            {
                Console.Clear();
                SalesSystem.Init();
            }
            else
            {
                Console.WriteLine("Please enter [yes] or [no]");
            }

        }

        public void ViewUnits()
        {

            // uses join to view units associated with resort and owners to units
            using (var db = new BusinessContext())
            {



                Console.WriteLine("Select Resort Id");
                int SelectResortId = Int32.Parse(Console.ReadLine());

                var ResortUnits = db.Unit.Where(n => n.ResortId == SelectResortId).Join(
                    db.Resort,
                    unit => unit.ResortId,
                    resort => resort.Id,
                    (unit, resort) => new
                    {
                        UnitId = unit.Id,
                        ResortName = resort.Name,
                        ResortLocation = resort.Location,
                        UnitName = unit.Name,
                        UnitPrice = unit.Price,
                        UnitPurchased = unit.Purchased
                    }
                    ).ToList();

                if (ResortUnits.Count > 0)
                {

                    Console.WriteLine("Enter Unit Id to See Details");
                    foreach (var units in ResortUnits)
                    {
                        Console.WriteLine(
                            $"Unit Id: {units.UnitId} \n" +
                            $"Resort:{units.ResortName} \n" +
                            $"Location:{units.ResortLocation} \n" +
                            $"Unit Name:{units.UnitName} \n" +
                            $"Price:{units.UnitPrice} \n" +
                            $"UnitPurchased: {units.UnitPurchased}");

                        Console.WriteLine("---------------------------");
                    }

                    // Show list of Unit names and then query rows with select names
                    Console.WriteLine("Do You want to see a units details? [yes] [no]");

                    if (Console.ReadLine() == "yes")
                    {
                        GetUnitDetails();

                    }
                }
                else
                {
                    Console.WriteLine("This Resort doesn't have unit data available");
                }
               

            }


        }

        private void GetUnitDetails()
        {
            
            Console.WriteLine("Enter Unit Id to See Details");

            int unitId = Int32.Parse(Console.ReadLine());

            using(var db = new BusinessContext())
            {
               var selectedUnit = db.Unit.Find(unitId);

                if (selectedUnit.Purchased)
                {
                    // Get the detail from individual query not all instances
                    // REWRITE LINQ Below VVV
                    db.Unit.Join(
                        db.Customers,
                        unit => unit.Id,
                        customer => customer.Id,
                        (unit, customer) => new
                        {
                            unitName = unit.Name,
                            unitPrice = unit.Price,
                            customerName = customer.FirstName + " " + customer.LastName
                        }
                        ).ToString();

                    // Get Details (if owned add customer information too)

                    
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(
                     $"Id: {selectedUnit.Id} \n" +   
                    $"Unit Name: {selectedUnit.Name} \n" +
                    $"Unit Price: {selectedUnit.Price} \n" +
                    $"Owned: {selectedUnit.Purchased}");
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

        public void ViewSalesReport()
        {

            // I need to get the unit Id also to match sales Id

            Console.Clear();
            using (var db = new BusinessContext())
            {
               
                var salesReport =
                    from sale in db.Sales
                    join employee in db.Employees on sale.EmployeeId equals employee.Id
                    join unit in db.Unit on sale.UnitId equals unit.Id
                    join resort in db.Resort on unit.ResortId equals resort.Id
                    select new
                    {
                        SalesId = sale.Id,
                        EmployeeId = employee.Id,
                        EmployeeName = employee.FirstName + " " + employee.LastName,
                        ResortName = resort.Name,
                        ResortLocation = resort.Location,
                        CustomerId = sale.CustomerId,
                        UnitName = unit.Name,
                        SalePrice = unit.Price

                    };



                foreach (var report in salesReport)
                {
                    Console.WriteLine(
                        $"Sale Id:{report.SalesId} \n" +
                        $"Employee Id:{report.EmployeeId} \n" +                      
                        $"Name: {report.EmployeeName} \n" +
                        $"Resort Name: {report.ResortName} \n" +
                        $"Resort Location: {report.ResortLocation} \n" +
                        $"Customer Id: {report.CustomerId} \n" + 
                        $"Unit Name: {report.UnitName} \n" +
                        $"Sale Price: {report.SalePrice}");

                    Console.WriteLine("-----------------------------");
                }

                Console.WriteLine("Press [Enter] to continue");
                Console.ReadLine();

            }
        }

        
    }
}
