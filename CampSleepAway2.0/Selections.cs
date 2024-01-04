using CampSleepAway2._0;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

public class Selections
{
    public class Cabins
    {
        public static string[] SelectCabinID()
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.Cabins.Select(x => x.Id).ToList();
                List<string> result = new List<string>();
                
                foreach (var data in selectData)
                {
                    string temp = data.ToString();
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }
        public static string[] SelectCabinTitles()
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.Cabins.Select(x => x.Title).ToList();
                List<string> result = new List<string>();

                foreach (var data in selectData)
                {
                    string temp = data.ToString();
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }
        public static string[] SelectCabinNumOfRes()
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.Cabins.Select(x => x.NumberOfResidence).ToList();
                List<string> result = new List<string>();

                foreach (var data in selectData)
                {
                    string temp = data.ToString();
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }
        public static string SelectCabinTitleFromID(int id)
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.Cabins.Select(x => x).Where(x => x.Id == id ).ToList();
                if (selectData is not null)
                {
                    foreach (var data in selectData)
                    {
                        return data.Title;
                    }
                }
                return "There is no cabin with ID: " + id;
            }
        }
    }

    public class Camper
    {
        public static string SelectCamperFromID(int id)
        {
            using (var campContext = new CampContext())
            {
                //var selectData = from x in campContext.Campers
                //           join y in campContext.People
                //           on x.Id equals y.Id
                //           where x.Id == id
                //           select x;
                var selectData = campContext.Campers.Select(x => x)
                                            .Where(x => x.Id == id).ToList();
                if (selectData is not null)
                {
                    foreach (var data in selectData)
                    {
                        return data.Person.FirstName+ " " + data.Person.LastName;
                    }
                }
                return "There is no person with ID: " + id;
            }
        }
    }

    public class CamperStay
    {

    }

    public class Councelor
    {

    }

    public class CouncelorAssignment
    {

    }

    public class NextOfKin
    {

    }

    public class Person
    {

    }

    public class Visit
    {
        
    }

    public class SelectionsToArray
    {
        public static string[] SelectCabins()
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.Cabins.Select(x => x).ToList();
                List<string> result = new List<string>();

                foreach (var data in selectData)
                {
                    string temp = $"{data.Id}\t{data.Title}\t{data.NumberOfResidence}";
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }

        public static string[] SelectCampers()
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.Campers.Select(x => x.Person).ToList();
                List<string> result = new List<string>();

                foreach (var data in selectData)
                {
                    string temp = $"{data.Id}\t{data.FirstName} {data.LastName}\t{data.BirthDate}";
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }

        public static string[] SelectCouncelors()
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.Councelors.Select(x => x.Person).ToList();
                List<string> result = new List<string>();

                foreach (var data in selectData)
                {
                    string temp = $"{data.Id}\t{data.FirstName} {data.LastName}\t{data.BirthDate}";
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }

        public static string[] SelectNextOfKinToCampers()
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.NextOfKins.Select(x => x)
                                            .OrderBy(c => c.Camper.Person.FirstName)
                                            .ToList();
                List<string> result = new List<string>();

                foreach (var data in selectData)
                {
                    string temp = $"{data.Person.FirstName} {data.Person.LastName} is a relative to: {data.Camper.Person.FirstName} {data.Camper.Person.LastName}";
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }

        public static string[] SelectPeople()
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.People.Select(x => x).ToList();
                List<string> result = new List<string>();

                foreach (var data in selectData)
                {
                    string temp = $"{data.Id}\t{data.FirstName} {data.LastName}\t{data.BirthDate}";
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }

        public static string[] SelectCamperStays()
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.CamperStays.Select(x => x).ToList();
                List<string> result = new List<string>();

                foreach (var data in selectData)
                {
                    string temp = $"{data.Id}\t{data.Camper.Person.FirstName} {data.Camper.Person.LastName}\t{data.Cabin.Id}\t{data.StartDate}\t{data.EndDate}";
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }

        public static string[] SelectCouncelorAssignments()
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.CouncelorAssignments.Select(x => x).ToList();
                List<string> result = new List<string>();

                foreach (var data in selectData)
                {
                    string temp = $"{data.Id}\t{data.Councelor.Person.FirstName} {data.Councelor.Person.LastName} is assigned to cabin: {data.Cabin.Id}\t{data.StartDate} {data.EndDate}";
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }

        public static string[] SelectVisits()
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.Visits.Select(x => x).ToList();
                List<string> result = new List<string>();

                foreach (var data in selectData)
                {
                    string temp = $"{data.Id}\t{data.Camper.Person.FirstName} {data.Camper.Person.LastName} is visited by: {data.NextOfKins}\t{data.StartDate} {data.EndDate}";
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }
    }
}
