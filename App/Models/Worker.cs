using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class Worker : IDisposable
    {
        public Worker()
        {
            Organizations = new List<Organization>();    
        }

        public void Dispose()
        { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual List<Organization> Organizations { get; set; }
    }
}
