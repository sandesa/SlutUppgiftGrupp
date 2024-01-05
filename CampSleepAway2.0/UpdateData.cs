using CampSleepAway2._0;
using Microsoft.IdentityModel.Tokens;
using Spectre.Console;

public class UpdateData
{
    public static void DataUpdate()
    {
        string[] updateDataSelections = new[]
        {
            "Cabins", "Campers", "CamperStays", "Councelors", "CouncelorAssignments", "NextOfKins", "People", "Visits"
        };
        using (var campContext = new CampContext())
        {

        }

        var updateDataSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Update data: [blue]What table do you want to update[/]?")
                .PageSize(10)
                .MoreChoicesText("[green](Move up and down with arrows)[/]")
                .AddChoices(updateDataSelections));
        if (updateDataSelection == updateDataSelections[0])
        {
            UpdateCabin();
        }
        else if (updateDataSelection == updateDataSelections[1])
        {
            UpdateCampers();
        }
        else if (updateDataSelection == updateDataSelections[2])
        {
            UpdateCamperStay();
        }
        else if (updateDataSelection == updateDataSelections[3])
        {
            UpdateCouncelor();
        }
        else if (updateDataSelection == updateDataSelections[4])
        {
            UpdateCouncelorAssignemnt();
        }
        else if (updateDataSelection == updateDataSelections[5])
        {
            UpdateNextOfKin();
        }
        else if (updateDataSelection == updateDataSelections[6])
        {
            UpdatePerson();
        }
        else if (updateDataSelection == updateDataSelections[7])
        {
            UpdateVisit();
        }
    }

    public static void UpdateCabin()
    {
        var updateCabins = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select cabin to [blue]update:[/]")
                .PageSize(10)
                .MoreChoicesText("[green](Move up and down with arrows)[/]")
                .AddChoices(Selections.Cabins.SelectCabins()));
        var cabinToUpdate = int.Parse(updateCabins[..2]);

        using (var campContext = new CampContext())
        {
            var cabin = campContext.Cabins.Find(cabinToUpdate);
            if (cabin != null)
            {
                string[] selectColumns = new[]
                {
                    "Title", "Number of residence"
                };
                var selectColumn = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select column to [blue]update:[/]")
                    .PageSize(10)
                    .MoreChoicesText("[green](Move up and down with arrows)[/]")
                    .AddChoices(selectColumns));
                if (selectColumn == selectColumns[0])
                {
                    cabin.Title = UpdateString();
                }
                else if (selectColumn == selectColumns[1])
                {
                    cabin.NumberOfResidence = UpdateInt();
                }
                campContext.SaveChanges();
                Console.WriteLine("The data has been updated");
            }
        }
    }

    public static void UpdateCampers()
    {
        var updateCampers = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select camper to [blue]update:[/]")
                .PageSize(10)
                .MoreChoicesText("[green](Move up and down with arrows)[/]")
                .AddChoices(Selections.Camper.SelectCampers()));
        var camperToUpdate = Selections.Camper.SelectCamperIdFromPersonId(int.Parse(updateCampers[..2]));

        using (var campContext = new CampContext())
        {
            var camper = campContext.Campers.Find(camperToUpdate);
            if (camper != null)
            {
                string[] selectColumns = new[]
                {
                    "FirstName", "LastName", "BirthDate"
                };
                var selectColumn = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select column to [blue]update:[/]")
                    .PageSize(10)
                    .MoreChoicesText("[green](Move up and down with arrows)[/]")
                    .AddChoices(selectColumns));
                var person = campContext.People.Find(camper.PersonId);
                if (selectColumn == selectColumns[0])
                {
                    person.FirstName = UpdateString();
                }
                else if (selectColumn == selectColumns[1])
                {
                    person.LastName = UpdateString();
                }
                else if (selectColumn == selectColumns[2])
                {
                    person.BirthDate = UpdateDate();
                }
                campContext.SaveChanges();
                Console.WriteLine("The data has been updated");
            }
        }
    }

    public static void UpdateCamperStay()
    {
        var updateCamperStay = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select camper stay to [blue]update:[/]")
                .PageSize(10)
                .MoreChoicesText("[green](Move up and down with arrows)[/]")
                .AddChoices(Selections.CamperStay.SelectCamperStays()));
        var camperStayToUpdate = int.Parse(updateCamperStay[..2]);

        using (var campContext = new CampContext())
        {
            var camperStay = campContext.CamperStays.Find(camperStayToUpdate);
            if (camperStay != null)
            {
                string[] selectColumns = new[]
                {
                    "CamperID", "CabinID", "Start date", "End date"
                };
                var selectColumn = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select column to [blue]update:[/]")
                    .PageSize(10)
                    .MoreChoicesText("[green](Move up and down with arrows)[/]")
                    .AddChoices(selectColumns));
                if (selectColumn == selectColumns[0])
                {
                    camperStay.CamperId = UpdateInt();
                }
                else if (selectColumn == selectColumns[1])
                {
                    camperStay.CabinId = UpdateInt();
                }
                else if (selectColumn == selectColumns[2])
                {
                    camperStay.StartDate = UpdateDate();
                }
                else if (selectColumn == selectColumns[3])
                {
                    camperStay.StartDate = UpdateDate();
                }
                campContext.SaveChanges();
                Console.WriteLine("The data has been updated");
            }
        }
    }

    public static void UpdateCouncelor()
    {
        var updateCouncelor = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select councelor to [blue]update:[/]")
                .PageSize(10)
                .MoreChoicesText("[green](Move up and down with arrows)[/]")
                .AddChoices(Selections.Councelor.SelectCouncelors()));
        var councelorToUpdate = Selections.Councelor.SelectCouncelorIdFromPersonId(int.Parse(updateCouncelor[..2]));

        using (var campContext = new CampContext())
        {
            var councelor = campContext.Councelors.Find(councelorToUpdate);
            if (councelor != null)
            {
                string[] selectColumns = new[]
                {
                    "FirstName", "LastName", "BirthDate"
                };
                var selectColumn = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select column to [blue]update:[/]")
                    .PageSize(10)
                    .MoreChoicesText("[green](Move up and down with arrows)[/]")
                    .AddChoices(selectColumns));
                var person = campContext.People.Find(councelor.PersonId);
                if (selectColumn == selectColumns[0])
                {
                    person.FirstName = UpdateString();
                }
                else if (selectColumn == selectColumns[1])
                {
                    person.LastName = UpdateString();
                }
                else if (selectColumn == selectColumns[2])
                {
                    person.BirthDate = UpdateDate();
                }
                campContext.SaveChanges();
                Console.WriteLine("The data has been updated");
            }
        }
    }

    public static void UpdateCouncelorAssignemnt()
    {
        var updateCouncelorAssignment = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select councelor assignment to [blue]update:[/]")
                .PageSize(10)
                .MoreChoicesText("[green](Move up and down with arrows)[/]")
                .AddChoices(Selections.CouncelorAssignment.SelectCouncelorAssignments()));
        var councelorAssignmentToUpdate = int.Parse(updateCouncelorAssignment[..2]);

        using (var campContext = new CampContext())
        {
            var councelorAssignment = campContext.CouncelorAssignments.Find(councelorAssignmentToUpdate);
            if (councelorAssignment != null)
            {
                string[] selectColumns = new[]
                {
                    "CouncelorID", "CabinID", "Start date", "End date"
                };
                var selectColumn = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select column to [blue]update:[/]")
                    .PageSize(10)
                    .MoreChoicesText("[green](Move up and down with arrows)[/]")
                    .AddChoices(selectColumns));
                if (selectColumn == selectColumns[0])
                {
                    councelorAssignment.CouncelorId = UpdateInt();
                }
                else if (selectColumn == selectColumns[1])
                {
                    councelorAssignment.CabinId = UpdateInt();
                }
                else if (selectColumn == selectColumns[2])
                {
                    councelorAssignment.StartDate = UpdateDate();
                }
                else if (selectColumn == selectColumns[3])
                {
                    councelorAssignment.StartDate = UpdateDate();
                }
                campContext.SaveChanges();
                Console.WriteLine("The data has been updated");
            }
        }
    }

    public static void UpdateNextOfKin()
    {
        var updateNextOfKin = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select Next Of Kin to [blue]update:[/]")
                .PageSize(10)
                .MoreChoicesText("[green](Move up and down with arrows)[/]")
                .AddChoices(Selections.NextOfKin.SelectNextOfKin()));
        var nextOfKinToUpdate = int.Parse(updateNextOfKin[..2]);

        using (var campContext = new CampContext())
        {
            var nextOfKin = campContext.NextOfKins.Find(nextOfKinToUpdate);
            if (nextOfKin != null)
            {
                string[] selectColumns = new[]
                {
                    "PersonID", "CamperID"
                };
                var selectColumn = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select column to [blue]update:[/]")
                    .PageSize(10)
                    .MoreChoicesText("[green](Move up and down with arrows)[/]")
                    .AddChoices(selectColumns));
                if (selectColumn == selectColumns[0])
                {
                    nextOfKin.PersonId = UpdateInt();
                }
                else if (selectColumn == selectColumns[1])
                {
                    nextOfKin.CamperId = UpdateInt();
                }
                campContext.SaveChanges();
                Console.WriteLine("The data has been updated");
            }
        }
    }

    public static void UpdatePerson()
    {
        var updatePerson = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select Person to [blue]update:[/]")
                .PageSize(10)
                .MoreChoicesText("[green](Move up and down with arrows)[/]")
                .AddChoices(Selections.Person.SelectPeople()));
        var personToUpdate = int.Parse(updatePerson[..2]);

        using (var campContext = new CampContext())
        {
            var person = campContext.People.Find(personToUpdate);
            if (person != null)
            {
                string[] selectColumns = new[]
                {
                    "FirstName", "LastName", "BirthDate"
                };
                var selectColumn = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select column to [blue]update:[/]")
                    .PageSize(10)
                    .MoreChoicesText("[green](Move up and down with arrows)[/]")
                    .AddChoices(selectColumns));
                if (selectColumn == selectColumns[0])
                {
                    person.FirstName = UpdateString();
                }
                else if (selectColumn == selectColumns[1])
                {
                    person.LastName = UpdateString();
                }
                else if (selectColumn == selectColumns[2])
                {
                    person.BirthDate = UpdateDate();
                }
                campContext.SaveChanges();
                Console.WriteLine("The data has been updated");
            }
        }
    }

    public static void UpdateVisit()
    {
        var updateVisit = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select camper stay to [blue]update:[/]")
                .PageSize(10)
                .MoreChoicesText("[green](Move up and down with arrows)[/]")
                .AddChoices(Selections.Visit.SelectVisits()));
        var visitToUpdate = int.Parse(updateVisit[..2]);

        using (var campContext = new CampContext())
        {
            var visit = campContext.Visits.Find(visitToUpdate);
            if (visit != null)
            {
                string[] selectColumns = new[]
                {
                    "CamperID", "Start date", "End date"
                };
                var selectColumn = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select column to [blue]update:[/]")
                    .PageSize(10)
                    .MoreChoicesText("[green](Move up and down with arrows)[/]")
                    .AddChoices(selectColumns));
                if (selectColumn == selectColumns[0])
                {
                    visit.CamperId = UpdateInt();
                }
                else if (selectColumn == selectColumns[1])
                {
                    visit.StartDate = UpdateDate();
                }
                else if (selectColumn == selectColumns[2])
                {
                    visit.EndDate = UpdateDate();
                }

                campContext.SaveChanges();
                Console.WriteLine("The data has been updated");
            }
        }
    }

    public static string UpdateString()
    {
        Console.WriteLine("Type the new data:");
        string newData = Console.ReadLine();
        while (newData.IsNullOrEmpty())
        {
            Console.WriteLine("The data can't be null or empty.");
            newData = Console.ReadLine();
        }
        return newData;
    }
    public static int UpdateInt()
    {
        Console.WriteLine("Type the new data:");
        string newNumberOfResidence = Console.ReadLine();
        int number;
        while (!int.TryParse(newNumberOfResidence, out number))
        {
            Console.WriteLine("The data can't be null or empty.");
            newNumberOfResidence = Console.ReadLine();
        }
        return number;
    }
    public static DateTime UpdateDate()
    {
        Console.WriteLine("Type the new data:");
        string date = Console.ReadLine();
        DateTime newDate;
        while (!DateTime.TryParse(date, out newDate))
        {
            Console.WriteLine("The data can't be null or empty.");
            date = Console.ReadLine();
        }
        return newDate;
    }


}



