using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class Credit : IDisposable
    {
        public Credit()
        {
            Date = DateTime.Now;
        }

        public void Dispose()
        { }

        public int Id { get; set; }
        public string Info { get; set; }
        public DateTime Date { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
