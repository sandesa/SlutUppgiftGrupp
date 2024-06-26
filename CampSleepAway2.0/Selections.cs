﻿using CampSleepAway2._0;
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
        public static string SelectCabinTitleFromID(int id)
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.Cabins.Select(x => x).Where(x => x.Id == id).ToList();
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
    }

    public class Camper
    {
        public static string SelectCamperFromPersonID(int id)
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.Campers.Select(x => x.Person).Where(c => c.Id == id).ToList();

                if (selectData is not null)
                {
                    foreach (var data in selectData)
                    {
                        return data.FullName;
                    }
                }
                return "There is no person with ID: " + id;
            }
        }
        public static int SelectCamperIdFromPersonId(int id)
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.Campers.Select(x => x).Where(c => c.PersonId == id).ToList();

                if (selectData is not null)
                {
                    foreach (var data in selectData)
                    {
                        return data.Id;
                    }
                }
                return 0;
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
    }

    public class CamperStay
    {
        public static string[] SelectCamperStays()
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.CamperStays.Include(x => x.Camper.Person)
                                                        .ToList();
                List<string> result = new List<string>();

                foreach (var data in selectData)
                {
                    string temp = $"{data.Id}\t{data.Camper.Person.FullName}\t\t{data.CabinId}\t\t{data.StartDate}\t{data.EndDate}";
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }
    }

    public class Councelor
    {
        public static int SelectCouncelorIdFromPersonId(int id)
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.Councelors.Select(x => x).Where(c => c.PersonId == id).ToList();

                if (selectData is not null)
                {
                    foreach (var data in selectData)
                    {
                        return data.Id;
                    }
                }
                return 0;
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
                    string temp = $"{data.Id}\t{data.FullName}\t\t{data.BirthDate}";
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }
        public static string SelectCouncelorFromPersonID(int id)
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.Councelors.Select(x => x.Person).Where(c => c.Id == id).ToList();

                if (selectData is not null)
                {
                    foreach (var data in selectData)
                    {
                        return data.FullName;
                    }
                }
                return "There is no person with ID: " + id;
            }
        }
    }

    public class CouncelorAssignment
    {
        public static string[] SelectCouncelorAssignments()
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.CouncelorAssignments.Include(x => x.Councelor.Person)
                                                                 .Include(x => x.Cabin).ToList();
                List<string> result = new List<string>();

                foreach (var data in selectData)
                {
                    string temp = $"{data.Id}  {data.Councelor.Person.FullName} is assigned to cabin: '{data.Cabin.Id}'.  StartDate: {data.StartDate}  EndDate: {data.EndDate}";
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }
    }

    public class NextOfKin
    {
        public static string[] SelectNextOfKin()
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.NextOfKins.Include(x => x.Person)
                                            .Include(x => x.Camper.Person)
                                            .OrderBy(c => c.Camper.Person.FirstName)
                                            .ToList();
                List<string> result = new List<string>();

                foreach (var data in selectData)
                {
                    string temp = $"{data.Id}  '{data.Person.FullName}' is a relative to '{data.Camper.Person.FullName}'";
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }
        public static string[] SelectNextOfKinToCamperFromId(int id)
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.NextOfKins.Include(x => x.Person)
                                            .Include(x => x.Camper.Person)
                                            .Where(x => x.CamperId == id)
                                            .OrderBy(c => c.Camper.Person.FirstName)
                                            .ToList();
                List<string> result = new List<string>();

                foreach (var data in selectData)
                {
                    string temp = $"{data.Id}  '{data.Person.FullName}' is a relative to '{data.Camper.Person.FullName}'";
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }

    }

    public class Person
    {
        public static string[] SelectPeople()
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.People.Select(x => x).ToList();
                List<string> result = new List<string>();

                foreach (var data in selectData)
                {
                    string temp = $"{data.Id}\t{data.FullName}\t{data.BirthDate}";
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }
        public static string SelectFullNameFromPersonID(int id)
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.People.Select(x => x).Where(c => c.Id == id).ToList();

                if (selectData is not null)
                {
                    foreach (var data in selectData)
                    {
                        return data.FullName;
                    }
                }
                return "There is no person with ID: " + id;
            }
        }
    }

    public class Visit
    {
        public static string[] SelectVisits()
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.Visits.Include(x => x.Camper.Person)
                                                   .Include(x => x.NextOfKins).ToList();
                List<string> result = new List<string>();

                foreach (var data in selectData)
                {
                    string temp = $"{data.Id}\t{data.Camper.Person.FullName} is visited by: {data.NextOfKins}\t Date: {data.StartDate}   Ended:{data.EndDate}";
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }
    }

    public class Presentation
    {
        public static string[] SelectCabins()
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.Cabins.Select(x => x).ToList();
                List<string> result = new List<string>();
                string title = "ID:\tTitle:\t\tNumber of residence:";
                result.Add(title);

                foreach (var data in selectData)
                {
                    string temp = $"{data.Id}\t{data.Title}\t\t{data.NumberOfResidence}";
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
                string title = "ID:\tFull name:\tBirthdate:";
                result.Add(title);

                foreach (var data in selectData)
                {
                    string temp = $"{data.Id}\t{data.FullName}\t{data.BirthDate}";
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
                string title = "ID:\tCouncelor fullname:\tBirthdate:";
                result.Add(title);

                foreach (var data in selectData)
                {
                    string temp = $"{data.Id}\t{data.FullName}\t\t{data.BirthDate}";
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }

        public static string[] SelectNextOfKin()
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.NextOfKins.Include(x => x.Person)
                                            .Include(x => x.Camper.Person)
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
                string title = "ID:\tFull name:\t\tBirthdate:";
                result.Add(title);

                foreach (var data in selectData)
                {
                    string temp = $"{data.Id}\t{data.FullName}\t\t{data.BirthDate}";
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }

        public static string[] SelectCamperStays()
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.CamperStays.Include(x => x.Camper.Person)
                                                        .ToList();
                List<string> result = new List<string>();
                string title = "ID:\tCamper fullname:\tCabinID:\tStartDate:\t\tEndDate:";
                result.Add(title);

                foreach (var data in selectData)
                {
                    string temp = $"{data.Id}\t{data.Camper.Person.FirstName} {data.Camper.Person.LastName}\t\t{data.CabinId}\t\t{data.StartDate}\t{data.EndDate}";
                    result.Add(temp);
                }
                return result.ToArray();
            }
        }

        public static string[] SelectCouncelorAssignments()
        {
            using (var campContext = new CampContext())
            {
                var selectData = campContext.CouncelorAssignments.Include(x => x.Councelor.Person)
                                                                 .Include(x => x.Cabin).ToList();
                List<string> result = new List<string>();

                foreach (var data in selectData)
                {
                    string temp = $"ID:{data.Id}  '{data.Councelor.Person.FullName}' is assigned to cabin: '{data.Cabin.Id}'.  StartDate: {data.StartDate}  EndDate:{data.EndDate}";
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
