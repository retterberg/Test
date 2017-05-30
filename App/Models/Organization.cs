using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class Organization : IDisposable
    {
        public Organization()
        {
            Workers = new List<Worker>();
            Credits = new List<Credit>();
        }

        public void Dispose()
        { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public virtual List<Worker> Workers { get; set; }
        public virtual List<Credit> Credits { get; set; }
    }
}
