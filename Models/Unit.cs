using System;
using System.Collections.Generic;
using System.Text;

namespace Playground2.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public int ResortId { get; set; }
        public Resort Resort { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool Purchased { get; set; }
    }
}
