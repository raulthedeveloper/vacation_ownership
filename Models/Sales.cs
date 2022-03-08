using Playground2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundConsole1.Models
{
    public class Sales
    {
        public int Id { get; set; } 
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; } 
        public Employee Employee { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        
        public int ResortId { get; set; }
        public Resort Resort { get; set; }
    }
}
