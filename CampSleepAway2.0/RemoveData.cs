using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampSleepAway2._0;

public class RemoveData
{
    public class Cabin
    {
        public static void DeleteCabin(int id)
        {
            using (var campContext = new CampContext())
            {
                var cabinToDelete = campContext.Cabins.SingleOrDefault(x  => x.Id == id);

                if (cabinToDelete != null)
                {
                    campContext.Cabins.Remove(cabinToDelete);
                    int result = campContext.SaveChanges();
                    if (result > 0)
                    {
                        Console.WriteLine($"The cabin with title: {Selections.Cabins.SelectCabinTitleFromID(id)} was deleted.");
                    }
                    else
                    {
                        Console.WriteLine("The cabin with id: " + id + " couldn't be removed");
                    }
                }
                else
                {
                    Console.WriteLine("The cabin with id: " + id + " couldn't be removed");
                }
            }
        }
    }
    public class Camper
    {
        public static void DeleteCamper(int id)
        {
            using (var campContext = new CampContext())
            {
                var camperToDelete = campContext.Campers.SingleOrDefault(x => x.Id == id);

                if (camperToDelete != null)
                {
                    campContext.Campers.Remove(camperToDelete);
                    int result = campContext.SaveChanges();
                    if (result > 0)
                    {
                        Console.WriteLine($"The camper was deleted.");
                    }
                    else
                    {
                        Console.WriteLine("The camper with id: " + id + " couldn't be removed");
                    }
                }
                else
                {
                    Console.WriteLine("The camper with id: " + id + " couldn't be removed");
                }
            }
        }
    }
}
