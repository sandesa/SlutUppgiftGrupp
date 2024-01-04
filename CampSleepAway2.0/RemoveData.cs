using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CampSleepAway2._0;
using Microsoft.EntityFrameworkCore;

public class RemoveData
{
    public static void DeleteEntity<T>(int id) where T : class
    {
        using (var campContext = new CampContext())
        {
            var entityToDelete = campContext.Set<T>().Find(id);

            if (entityToDelete != null)
            {
                campContext.Set<T>().Remove(entityToDelete);
                int result = campContext.SaveChanges();
                if (result > 0)
                {
                    Console.WriteLine($"The {typeof(T).Name} with ID {id} was deleted.");
                }
                else
                {
                    Console.WriteLine($"The {typeof(T).Name} with ID {id} couldn't be removed.");
                }
            }
            else
            {
                Console.WriteLine($"The {typeof(T).Name} with ID {id} couldn't be found.");
            }
        }
    }
    
    public static void DeleteAllData(string tableName)
    {
        using (var campContext = new CampContext())
        {
            var delete = campContext.Database.ExecuteSql($"TRUNCATE TABLE [{tableName}]");
        }
    }
    public class Cabins
    {
        public static void DeleteCabin(int id)
        {
            DeleteEntity<Cabin>(id);
        }
        public static void DeleteAllCabins()
        {
            DeleteAllData("Cabins");
        }
    }
    public class Campers
    {
        public static void DeleteCamper(int id)
        {
            DeleteEntity<Camper>(id);
        }
        public static void DeleteAllCampers()
        {
            DeleteAllData("Campers");
        }
    }
    public class CamperStays
    {
        public static void DeleteCamperStay(int id)
        {
            DeleteEntity<CamperStay>(id);
        }
    }
    public class Councelors
    {
        public static void DeleteCouncelor(int id)
        {
            DeleteEntity<Councelor>(id);
        }
    }
    public class CouncelorAssignments
    {
        public static void DeleteCouncelorAssignment(int id)
        {
            DeleteEntity<CouncelorAssignment>(id);
        }
    }
    public class NextOfKins
    {
        public static void DeleteNextOfKin(int id)
        {
            DeleteEntity<NextOfKin>(id);
        }
    }
    public class Visits
    {
        public static void DeleteVisit(int id)
        {
            DeleteEntity<NextOfKin>(id);
        }
    }
    public class People
    {
        public static void DeletePerson(int id)
        {
            DeleteEntity<Person>(id);
        }
    }

    //public class Cabin
    //{
    //    public static void DeleteCabin(int id)
    //    {
    //        using (var campContext = new CampContext())
    //        {
    //            var cabinToDelete = campContext.Cabins.SingleOrDefault(x  => x.Id == id);

    //            if (cabinToDelete != null)
    //            {
    //                campContext.Cabins.Remove(cabinToDelete);
    //                int result = campContext.SaveChanges();
    //                if (result > 0)
    //                {
    //                    Console.WriteLine($"The cabin with title: {Selections.Cabins.SelectCabinTitleFromID(id)} was deleted.");
    //                }
    //                else
    //                {
    //                    Console.WriteLine("The cabin with id: " + id + " couldn't be removed");
    //                }
    //            }
    //            else
    //            {
    //                Console.WriteLine("The cabin with id: " + id + " couldn't be removed");
    //            }
    //        }
    //    }
    //}
    //public class Camper
    //{
    //    public static void DeleteCamper(int id)
    //    {
    //        using (var campContext = new CampContext())
    //        {
    //            var camperToDelete = campContext.Campers.SingleOrDefault(x => x.Id == id);

    //            if (camperToDelete != null)
    //            {
    //                campContext.Campers.Remove(camperToDelete);
    //                int result = campContext.SaveChanges();
    //                if (result > 0)
    //                {
    //                    Console.WriteLine($"The camper was deleted.");
    //                }
    //                else
    //                {
    //                    Console.WriteLine("The camper with id: " + id + " couldn't be removed");
    //                }
    //            }
    //            else
    //            {
    //                Console.WriteLine("The camper with id: " + id + " couldn't be removed");
    //            }
    //        }
    //    }
    //}
    //public class CamperStay
    //{
    //    public static void DeleteCamperStay(int id)
    //    {
    //        using (var campContext = new CampContext())
    //        {
    //            var dataToDelete = campContext.CamperStays.SingleOrDefault(x => x.Id == id);

    //            if (dataToDelete != null)
    //            {
    //                campContext.CamperStays.Remove(dataToDelete);
    //                int result = campContext.SaveChanges();
    //                if (result > 0)
    //                {
    //                    Console.WriteLine($"The camper stay data was deleted.");
    //                }
    //                else
    //                {
    //                    Console.WriteLine("The camper stay data with id: " + id + " couldn't be removed");
    //                }
    //            }
    //            else
    //            {
    //                Console.WriteLine("The camper stay data with id: " + id + " couldn't be removed");
    //            }
    //        }
    //    }
    //}
    //public class Councelor
    //{
    //    public static void DeleteCouncelor(int id)
    //    {
    //        using (var campContext = new CampContext())
    //        {
    //            var councelorToDelete = campContext.Councelors.SingleOrDefault(x => x.Id == id);

    //            if (councelorToDelete != null)
    //            {
    //                campContext.Councelors.Remove(councelorToDelete);
    //                int result = campContext.SaveChanges();
    //                if (result > 0)
    //                {
    //                    Console.WriteLine($"The councelor was deleted.");
    //                }
    //                else
    //                {
    //                    Console.WriteLine("The councelor with id: " + id + " couldn't be removed");
    //                }
    //            }
    //            else
    //            {
    //                Console.WriteLine("The councelor with id: " + id + " couldn't be removed");
    //            }
    //        }
    //    }
    //}
    //public class CouncelorAssignment
    //{
    //    public static void DeleteCouncelorAssignment(int id)
    //    {
    //        using (var campContext = new CampContext())
    //        {
    //            var dataToDelete = campContext.CouncelorAssignments.SingleOrDefault(x => x.Id == id);

    //            if (dataToDelete != null)
    //            {
    //                campContext.CouncelorAssignments.Remove(dataToDelete);
    //                int result = campContext.SaveChanges();
    //                if (result > 0)
    //                {
    //                    Console.WriteLine($"The councelor assignment data was deleted.");
    //                }
    //                else
    //                {
    //                    Console.WriteLine("The councelor assignment data with id: " + id + " couldn't be removed");
    //                }
    //            }
    //            else
    //            {
    //                Console.WriteLine("The councelor assignment data with id: " + id + " couldn't be removed");
    //            }
    //        }
    //    }
    //}
    //public class NextOfKin
    //{
    //    public static void DeleteNextOfKin(int id)
    //    {
    //        using (var campContext = new CampContext())
    //        {
    //            var dataToDelete = campContext.NextOfKins.SingleOrDefault(x => x.Id == id);

    //            if (dataToDelete != null)
    //            {
    //                campContext.NextOfKins.Remove(dataToDelete);
    //                int result = campContext.SaveChanges();
    //                if (result > 0)
    //                {
    //                    Console.WriteLine($"The next of kin data was deleted.");
    //                }
    //                else
    //                {
    //                    Console.WriteLine("The next of kin data with id: " + id + " couldn't be removed");
    //                }
    //            }
    //            else
    //            {
    //                Console.WriteLine("The next of kin data with id: " + id + " couldn't be removed");
    //            }
    //        }
    //    }
    //}
    //public class Visit
    //{
    //    public static void DeleteVisit(int id)
    //    {
    //        using (var campContext = new CampContext())
    //        {
    //            var dataToDelete = campContext.Visits.SingleOrDefault(x => x.Id == id);

    //            if (dataToDelete != null)
    //            {
    //                campContext.Visits.Remove(dataToDelete);
    //                int result = campContext.SaveChanges();
    //                if (result > 0)
    //                {
    //                    Console.WriteLine($"The visit data was deleted.");
    //                }
    //                else
    //                {
    //                    Console.WriteLine("The visit data with id: " + id + " couldn't be removed");
    //                }
    //            }
    //            else
    //            {
    //                Console.WriteLine("The visit data with id: " + id + " couldn't be removed");
    //            }
    //        }
    //    }
    //}
    //public class Person
    //{
    //    public static void DeletePerson(int id)
    //    {
    //        using (var campContext = new CampContext())
    //        {
    //            var dataToDelete = campContext.People.SingleOrDefault(x => x.Id == id);

    //            if (dataToDelete != null)
    //            {
    //                campContext.People.Remove(dataToDelete);
    //                int result = campContext.SaveChanges();
    //                if (result > 0)
    //                {
    //                    Console.WriteLine($"The person data was deleted.");
    //                }
    //                else
    //                {
    //                    Console.WriteLine("The person data with id: " + id + " couldn't be removed");
    //                }
    //            }
    //            else
    //            {
    //                Console.WriteLine("The person data with id: " + id + " couldn't be removed");
    //            }
    //        }
    //    }
    //}
}
