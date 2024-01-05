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

    public class Cabins
    {
        public static void DeleteCabin(int id)
        {
            DeleteEntity<Cabin>(id);
        }
        public static void DeleteAllCabins()
        {
            using (var campContext = new CampContext())
            {
                var all = from c in campContext.Cabins select c;
                campContext.Cabins.RemoveRange(all);
                campContext.SaveChanges();
            }
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
            using (var campContext = new CampContext())
            {
                var all = from c in campContext.Campers select c;
                campContext.Campers.RemoveRange(all);
                campContext.SaveChanges();
            }
        }
    }
    public class CamperStays
    {
        public static void DeleteCamperStay(int id)
        {
            DeleteEntity<CamperStay>(id);
        }
        public static void DeleteAllCamperStays()
        {
            using (var campContext = new CampContext())
            {
                var all = from c in campContext.CamperStays select c;
                campContext.CamperStays.RemoveRange(all);
                campContext.SaveChanges();
            }
        }
    }
    public class Councelors
    {
        public static void DeleteCouncelor(int id)
        {
            DeleteEntity<Councelor>(id);
        }
        public static void DeleteAllCouncelors()
        {
            using (var campContext = new CampContext())
            {
                var all = from c in campContext.Councelors select c;
                campContext.Councelors.RemoveRange(all);
                campContext.SaveChanges();
            }
        }
    }
    public class CouncelorAssignments
    {
        public static void DeleteCouncelorAssignment(int id)
        {
            DeleteEntity<CouncelorAssignment>(id);
        }
        public static void DeleteAllCouncelorAssignments()
        {
            using (var campContext = new CampContext())
            {
                var all = from c in campContext.CouncelorAssignments select c;
                campContext.CouncelorAssignments.RemoveRange(all);
                campContext.SaveChanges();
            }
        }
    }
    public class NextOfKins
    {
        public static void DeleteNextOfKin(int id)
        {
            DeleteEntity<NextOfKin>(id);
        }
        public static void DeleteAllNextOfKin()
        {
            using (var campContext = new CampContext())
            {
                var all = from c in campContext.NextOfKins select c;
                campContext.NextOfKins.RemoveRange(all);
                campContext.SaveChanges();
            }
        }
    }
    public class Visits
    {
        public static void DeleteVisit(int id)
        {
            DeleteEntity<NextOfKin>(id);
        }
        public static void DeleteAllVisits()
        {
            using (var campContext = new CampContext())
            {
                var all = from c in campContext.Visits select c;
                campContext.Visits.RemoveRange(all);
                campContext.SaveChanges();
            }
        }
    }
    public class People
    {
        public static void DeletePerson(int id)
        {
            DeleteEntity<Person>(id);
        }
        public static void DeleteAllPeople()
        {
            using (var campContext = new CampContext())
            {
                var all = from c in campContext.People select c;
                campContext.People.RemoveRange(all);
                campContext.SaveChanges();
            }
        }
    }
}
