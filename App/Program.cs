using App.Models;
using System;
using System.Linq;



namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Context.Context())
            {
                int id;
Main:
                Console.WriteLine("\nEnter: 1 - View, 2 - Edit, 3 - Add, 4 - Delete, 5 - Write To Excel, 6 - Exit");
                switch (Console.ReadLine())
                {
/*----------------------------------------------------------------------------------------------------------------------------------*/
                    case "1":
                        {
View:
                            Console.WriteLine("\nEnter: 1 - View Organizations, 2 - View Workers, 3 - Exit");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    foreach (var o in db.Organizations)
                                    {
                                        using (o)
                                        {
                                            Console.WriteLine("\nOrganization:");
                                            Console.WriteLine("Id: {0}, Name: {1}, Phone: {2}, Adress: {3}", o.Id, o.Name, o.Phone, o.Address);
                                            Console.WriteLine("******************************");
                                            try
                                            {
                                                Console.WriteLine("Workers in {0}:", o.Name);
                                                foreach (var w in o.Workers)
                                                {
                                                    using (w)
                                                        Console.WriteLine("Id: {0}, Name: {1}", w.Id, w.Name);
                                                }
                                                Console.WriteLine("\nCredits in {0}:", o.Name);
                                                foreach (var c in o.Credits)
                                                {
                                                    using (c)
                                                        Console.WriteLine("Id: {0}, Info: {1}, Date: {2}", c.Id, c.Info, c.Date);
                                                }
                                                Console.WriteLine("----------------------------------");
                                            }
                                            catch { Console.WriteLine("Error");  goto View ; }
                                        }
                                    }
                                    goto View;

                                case "2":
                                    foreach (var w in db.Workers)
                                    {
                                        using (w)
                                        {
                                            Console.WriteLine("\nWorker:");
                                            Console.WriteLine("Id: {0}, Name: {1}, Gender: {2}, Phone: {3}, Email: {4}", w.Id, w.Name, w.Gender, w.Phone, w.Email);
                                            Console.WriteLine("******************************");
                                            try
                                            {
                                                Console.WriteLine("{0} organizations:", w.Name);
                                                foreach (var o in w.Organizations)
                                                {
                                                    using (o)
                                                        Console.WriteLine("Id: {0}, Name: {1}", w.Id, w.Name);
                                                }
                                            }
                                            catch { Console.WriteLine("Error"); goto View; }
                                            Console.WriteLine("----------------------------------");
                                        }
                                    }
                                    goto View;

                                case "3":
                                    goto Main;

                                default:
                                    goto View;
                            }
                        }
                       
/*----------------------------------------------------------------------------------------------------------------------------------*/
                    case "2":
                        {
Edit:
                            Console.WriteLine("\nEnter: 1 - Edit Organization, 2 - Edit Worker, 3 - Exit");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    {
                                        Console.WriteLine("Enter: Organization id");
                                        try { id = Convert.ToInt16(Console.ReadLine()); }
                                        catch { Console.WriteLine("Wrong id"); goto Edit; }
                                        using (var o = db.Organizations.Find(id))
                                        {
                                            if (o == null)
                                            {
                                                Console.WriteLine("Organization id {0} not found", id);
                                                goto Edit;
                                            }
                                            String s;
                                            Console.WriteLine("Enter: Name, old Name {0}, press ENTER for skip", o.Name);
                                            if ((s = Console.ReadLine()) != "")
                                                o.Name = s;
                                            Console.WriteLine("Enter: Phone, old Phone {0}, press ENTER for skip", o.Phone);
                                            if ((s = Console.ReadLine()) != "")
                                                o.Phone = s;
                                            Console.WriteLine("Enter: Address, old Address {0}, press ENTER for skip", o.Address);
                                            if ((s = Console.ReadLine()) != "")
                                                o.Address = s;
                                            db.SaveChanges();
                                            Console.WriteLine("Organization {0} changed", o.Name);
                                        }
                                    }
                                    goto Edit;

                                case "2":
                                    {
                                        Console.WriteLine("Enter: Worker id");
                                        try { id = Convert.ToInt16(Console.ReadLine()); }
                                        catch { Console.WriteLine("Wrong id"); goto Edit; }
                                        using (var w = db.Workers.Find(id))
                                        {
                                            if (w == null)
                                            {
                                                Console.WriteLine("Worker id {0} not found", id);
                                                goto Edit;
                                            }
                                            String s;
                                            Console.WriteLine("Enter: Name, old Name {0}, press ENTER for skip", w.Name);
                                            if ((s = Console.ReadLine()) != "")
                                                w.Name = s;
                                            Console.WriteLine("Enter: Gender, old Gender {0}, press ENTER for skip", w.Gender);
                                            if ((s = Console.ReadLine()) != "")
                                                w.Gender = s;
                                            Console.WriteLine("Enter: Phone, old Phone {0}, press ENTER for skip", w.Phone);
                                            if ((s = Console.ReadLine()) != "")
                                                w.Phone = s;
                                            Console.WriteLine("Enter: Email, old Email {0}, press ENTER for skip", w.Email);
                                            if ((s = Console.ReadLine()) != "")
                                                w.Email = s;
                                            db.SaveChanges();
                                            Console.WriteLine("Worker {0} changed", w.Name);
                                        }
                                    }
                                    goto Edit;

                                case "3":
                                    goto Main;

                                default:
                                    goto Edit;
                            }
                        }

/*----------------------------------------------------------------------------------------------------------------------------------*/
                    case "3":
                        {
Add:
                            Console.WriteLine("\nEnter: 1 - Add Organization, 2 - Add Worker, 3 - Add Worker to Organization, 4 - Add Credit to Organization, 5 - Exit");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    {
                                        using (var o = new Organization())
                                        {
                                            Console.WriteLine("Enter: Name");
                                            o.Name = Console.ReadLine();
                                            Console.WriteLine("Enter: Phone");
                                            o.Phone = Console.ReadLine();
                                            Console.WriteLine("Enter: Address");
                                            o.Address = Console.ReadLine();
                                            db.Organizations.Add(o);
                                            db.SaveChanges();
                                            Console.WriteLine("Organization {0} added", o.Name);
                                        }
                                    }
                                    goto Add;

                                case "2":
                                    {
                                        using (var w = new Worker())
                                        {
                                            Console.WriteLine("Enter: Name");
                                            w.Name = Console.ReadLine();
                                            Console.WriteLine("Enter: Gender");
                                            w.Gender = Console.ReadLine();
                                            Console.WriteLine("Enter: Phone");
                                            w.Phone = Console.ReadLine();
                                            Console.WriteLine("Enter: Email");
                                            w.Email = Console.ReadLine();
                                            db.Workers.Add(w);
                                            db.SaveChanges();
                                            Console.WriteLine("Worker {0} added", w.Name);
                                        }
                                    }
                                    goto Add;

                                case "3":
                                    {
                                        Console.WriteLine("Enter: organization id");
                                        try { id = Convert.ToInt16(Console.ReadLine()); }
                                        catch { Console.WriteLine("Wrong id"); goto Add; }
                                        using (var o = db.Organizations.Find(id))
                                        {
                                            if (o == null)
                                            {
                                                Console.WriteLine("Organization id {0} not found", id);
                                                goto Add;
                                            }
                                            Console.WriteLine("Enter: worker id");
                                            try { id = Convert.ToInt16(Console.ReadLine()); }
                                            catch { Console.WriteLine("Wrong id"); goto Add; }
                                            using (var w = db.Workers.Find(id))
                                            {
                                                if (w == null)
                                                {
                                                    Console.WriteLine("Worker id {0} not found", id);
                                                    goto Add;
                                                }
                                                foreach (var w1 in o.Workers)
                                                {
                                                    using (w1)
                                                    {
                                                        if (w1.Id == id)
                                                        {
                                                            Console.WriteLine("Worker already accepted");
                                                            goto Add;
                                                        }
                                                    }
                                                }
                                                o.Workers.Add(w);
                                                db.SaveChanges();
                                                Console.WriteLine("Worker {0} added to Organization {1}", w.Name, o.Name);
                                            }
                                        }
                                    }
                                    goto Add;

                                case "4":
                                    {
                                        Console.WriteLine("Enter: organization id");
                                        try { id = Convert.ToInt16(Console.ReadLine()); }
                                        catch { Console.WriteLine("Wrong id"); goto Add; }
                                        using (var o = db.Organizations.Find(id))
                                        {
                                            if (o == null)
                                            {
                                                Console.WriteLine("Organization id {0} not found", id);
                                                goto Add;
                                            }
                                            using (var c = new Credit())
                                            {
                                                Console.WriteLine("Enter: Credit Info");
                                                c.Info = Console.ReadLine();
                                                o.Credits.Add(c);
                                                db.Credits.Add(c);
                                                db.SaveChanges();
                                                Console.WriteLine("Credit {0} added to Organization {1}", c.Id, o.Name);
                                            }
                                        }
                                    }
                                    goto Add;

                                case "5":
                                    goto Main;

                                default:
                                    goto Add;
                            }
                        }                     
/*----------------------------------------------------------------------------------------------------------------------------------*/
                    case "4":
                        {
Delete:
                            Console.WriteLine("\nEnter: 1 - Delete Organization, 2 - Delete Worker, 3 - Delete Worker from Organization, 4 - Exit");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    {
                                        Console.WriteLine("Enter: Organization id");
                                        try { id = Convert.ToInt16(Console.ReadLine()); }
                                        catch { Console.WriteLine("Wrong id"); goto Delete; }
                                        using (var o = db.Organizations.Find(id))
                                        {
                                            if (o == null)
                                            {
                                                Console.WriteLine("Organization id {0} not found", id);
                                                goto Delete;
                                            }
                                            var credits = o.Credits;
                                            foreach (var c in credits.ToList())
                                                db.Credits.Remove(c);
                                            db.Organizations.Remove(o);
                                            db.SaveChanges();
                                            Console.WriteLine("Organization {0} removed", o.Name);
                                        }
                                    }
                                    goto Delete;

                                case "2":
                                    {
                                        Console.WriteLine("Enter: Worker id");
                                        try { id = Convert.ToInt16(Console.ReadLine()); }
                                        catch { Console.WriteLine("Wrong id"); goto Delete; }
                                        using (var w = db.Workers.Find(id))
                                        {
                                            if (w == null)
                                            {
                                                Console.WriteLine("Worker id {0} not found", id);
                                                goto Delete;
                                            }
                                            db.Workers.Remove(w);
                                            db.SaveChanges();
                                            Console.WriteLine("Worker {0} removed", w.Name);
                                        }     
                                    }
                                    goto Delete;

                                case "3":
                                    {
                                        Console.WriteLine("Enter: Organization id");
                                        try { id = Convert.ToInt16(Console.ReadLine()); }
                                        catch { Console.WriteLine("Wrong id"); goto Delete; }
                                        using (var o = db.Organizations.Find(id))
                                        {
                                            if (o == null)
                                            {
                                                Console.WriteLine("Organization id {0} not found", id);
                                                goto Delete;
                                            }
                                            Console.WriteLine("Enter: Worker id");
                                            try { id = Convert.ToInt16(Console.ReadLine()); }
                                            catch { Console.WriteLine("Wrong id"); goto Delete; }
                                            var w = o.Workers;
                                            foreach (var worker in w)
                                            {
                                                using (worker)
                                                { 
                                                    if (worker.Id == id)
                                                    {
                                                        o.Workers.Remove(worker);
                                                        Console.WriteLine("Worker {0} removed from {1}", worker.Name, o.Name);
                                                        break;
                                                    }
                                                }
                                            }
                                            db.SaveChanges();
                                        }
                                    }
                                    goto Delete;

                                case "4":
                                    goto Main;

                                default:
                                    goto Delete;
                            }
                        }
/*----------------------------------------------------------------------------------------------------------------------------------*/
                    case "5":
                        {
                            Console.WriteLine("Enter: Organization id");
                            try { id = Convert.ToInt16(Console.ReadLine()); }
                            catch { Console.WriteLine("Wrong id"); goto Main; }
                            using (var o = db.Organizations.Find(id))
                            {
                                Console.WriteLine("Enter: Date");
                                //DateTime dt;
                                string line = Console.ReadLine();
                                /*while (!DateTime.TryParseExact(line, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                                {
                                    Console.WriteLine("Invalid date, please retry");
                                    line = Console.ReadLine();
                                }*/
                                var credits = o.Credits.Where(c => c.Date.ToString("dd/MM/yyyy") == line);
                                if (credits.Count() == 0)
                                {
                                    Console.WriteLine("Not Found");
                                    goto Main;
                                }
                                Doc d = new Doc(credits);
                            }
                        }
                        goto Main;
/*----------------------------------------------------------------------------------------------------------------------------------*/
                    case "6":
                        break;
/*----------------------------------------------------------------------------------------------------------------------------------*/
                    default:
                        goto Main;
                }
            }
        }
    }
}       
