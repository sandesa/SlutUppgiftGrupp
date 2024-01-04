using CampSleepAway2._0;
using Spectre.Console;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.IdentityModel.Tokens;

using (var campContext = new CampContext())
{
    Menu();
    //var cabin = new Cabin()
    //{
    //    Title = "TestCabin 1",
    //    NumberOfResidence = 10,
    //};

    //var cabin1 = new Cabin()
    //{
    //    Title = "TestCabin 2",
    //    NumberOfResidence = 5,
    //};

    //var councelor = new Councelor()
    //{
    //    PersonId = 4
    //};
    //campContext.Councelors.Add(councelor);
    //campContext.SaveChanges();


    //campContext.Councelors.Add(new Councelor()
    //{
    ////    PersonId = 8
    //});
    //campContext.Cabins.Add(cabin);
    //campContext.Cabins.Add(cabin1);
    //campContext.SaveChanges();

    //campContext.NextOfKins.Add(new NextOfKin()
    //{
    //    PersonId = 8,
    //    CamperId = 1
    //});
    //campContext.SaveChanges();
    //string dirr = Directory.GetCurrentDirectory();
    //Console.WriteLine(dirr);
    //Selections.SelectCabins();
    //Selections.SelectCampers();
    //Selections.SelectPersonFromCouncelor();
    //Selections.SelectPersonFromNextOfKin(1);
    //Selections.SelectPerson();

    //var camper = new Camper()
    //{
    //    PersonId = 3
    //};
    //var person = new Person()
    //{
    //    FirstName = "Samuel",
    //    LastName = "Sandenäs",
    //    BirthDate = DateTime.Parse("02/03/1998")
    //};
    //campContext.Campers.Add(camper);
    //campContext.SaveChanges();

    //var people = ReadCSV("C:\\Users\\samue\\source\\repos\\SlutUppgiftGrupp\\CampSleepAway2.0\\data.csv");
    //Console.WriteLine($"{people.Count} hittades i CSV-filen");

    //foreach (var person in people)
    //{
    //    campContext.People.Add(person);
    //}
    //campContext.SaveChanges();
}

static void Menu()
{
    string[] menuSelections = new[]
    {
        "Show data", "Assign councelor", "Assign camper to cabin",
        "Add a visit", "Add data", "Update data", "Delete data",
    };
    var menuSelection = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Main menu: [blue]What do you want to do?[/]?")
        .PageSize(10)
        .MoreChoicesText("[Green](Move up and down with arrows)[/]")
        .AddChoices(menuSelections));

    if (menuSelection == menuSelections[0])
    {
        SelectData();
    }
    else if (menuSelection == menuSelections[1])
    {
        AssignCouncelor();
    }
    else if (menuSelection == menuSelections[2])
    {
        AssignCamperToCabin();
    }
    else if (menuSelection == menuSelections[3])
    {
        AddVisit();
    }
    else if (menuSelection == menuSelections[4])
    {
        AddData();
    }
    else if (menuSelection == menuSelections[5])
    {
        UpdateDate();
    }
    else if (menuSelection == menuSelections[6])
    {
        DeleteData();
    }


}

static void DeleteData()
{
    string[] tableSelections= new[]
    {
        "Cabins", "Campers", "Camper stays", "Councelors",
        "Councelor assignments", "Next of kin", "Visits", "People"
    };
    

    var selectTable = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Select [blue]table[/] to delete from: ")
        .PageSize(10)
        .MoreChoicesText("[Green](Move up and down with arrows)[/]")
        .AddChoices(tableSelections));
    if (selectTable == tableSelections[0])
    {
        if (Selections.SelectionsToArray.SelectCabins().Count() == 0)
        {
            Console.WriteLine("The table is empty.");
        }
        else
        {
            var selectDataToDelete= AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select [blue]data[/] to delete: ")
            .PageSize(10)
            .MoreChoicesText("[Green](Move up and down with arrows)[/]")
            .AddChoices(Selections.SelectionsToArray.SelectCabins()));
            var idToDelete= int.Parse(selectDataToDelete[..2]);

            Console.WriteLine($"Are you sure you want to delete cabin: {Selections.Cabins.SelectCabinTitleFromID(idToDelete)}?  y/n");
            string warning = Console.ReadLine();

            if (warning == "y")
            {
                RemoveData.Cabin.DeleteCabin(idToDelete);
            }
            else
            {
                Console.WriteLine("The cabin was not deleted.");
            }
        }
    }
    else if (selectTable == tableSelections[1])
    {
        if (Selections.SelectionsToArray.SelectCampers().Count() == 0)
        {
            Console.WriteLine("The table is empty.");
        }
        else
        {
            var selectDataToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select [blue]data[/] to delete: ")
            .PageSize(10)
            .MoreChoicesText("[Green](Move up and down with arrows)[/]")
            .AddChoices(Selections.SelectionsToArray.SelectCampers()));
            var idToDelete = int.Parse(selectDataToDelete[..2]);

            Console.WriteLine($"Are you sure you want to delete camper: {Selections.Camper.SelectCamperFromPersonID(idToDelete)}?  y/n");
            string warning = Console.ReadLine();

            if (warning == "y")
            {
                RemoveData.Camper.DeleteCamper(Selections.Camper.SelectCamperIdFromPersonId(idToDelete));
            }
            else
            {
                Console.WriteLine("The camper was not deleted.");
            }   
        }
    }
}

static void UpdateDate()
{

}

static void AddData()
{

}

static void AddVisit()
{

}

static void SelectData()
    {
        string[] showDataSelections = new[]
        {
        "Cabins", "Campers", "Camper stays", "Councelors",
        "Councelor assignments", "Next of kin", "Visits", "People"
        };
        var showData = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Show data: [blue]What data do you wanna look at?[/]?")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down with arrows)[/]")
            .AddChoices(showDataSelections));
        if (showData == showDataSelections[0])
        {
            PrintData(Selections.SelectionsToArray.SelectCabins());
        }
        else if (showData == showDataSelections[1])
        {
            PrintData(Selections.SelectionsToArray.SelectCampers());
        }
        else if (showData == showDataSelections[2])
        {
            PrintData(Selections.SelectionsToArray.SelectCamperStays());
        }
        else if (showData == showDataSelections[3])
        {
            PrintData(Selections.SelectionsToArray.SelectCouncelors());
        }
        else if (showData == showDataSelections[4])
        {
            PrintData(Selections.SelectionsToArray.SelectCouncelorAssignments());
        }
        else if (showData == showDataSelections[5])
        {
            PrintData(Selections.SelectionsToArray.SelectNextOfKinToCampers());
        }
        else if (showData == showDataSelections[6])
        {
            PrintData(Selections.SelectionsToArray.SelectVisits());
        }
        else if (showData == showDataSelections[7])
        {
            PrintData(Selections.SelectionsToArray.SelectPeople());
        }
    }

static void AssignCouncelor()
{
    var selectCouncelor = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Select [blue]councelor[/] to assign: ")
        .PageSize(10)
        .MoreChoicesText("[Green](Move up and down with arrows)[/]")
        .AddChoices(Selections.SelectionsToArray.SelectCouncelors()));
    var councelorId = Selections.Councelor.SelectCouncelorIdFromPersonId(int.Parse(selectCouncelor[..2]));

    using (var campContext = new CampContext())
    {
        var checkCouncelor = campContext.CouncelorAssignments.Find(councelorId);
        {
            if (checkCouncelor is null)
            {
                var selectCabin = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select [blue]cabin[/] to assign the [blue]councelor[/] to: ")
                    .PageSize(10)
                    .MoreChoicesText("[Green](Move up and down with arrows)[/]")
                    .AddChoices(Selections.SelectionsToArray.SelectCabins()));
                var cabinId = int.Parse(selectCabin[..2]);

                var checkCabins = campContext.CouncelorAssignments.Find(cabinId);

                if (checkCabins is null)
                {
                    AnsiConsole.MarkupLine($"Type in [blue]start date[/] and the [blue]end date[/] in the format mm/dd/yyyy:");
                    var startDate = DateTime.Parse(Console.ReadLine());
                    var endDate = DateTime.Parse(Console.ReadLine());

                    var assignCouncelor = new CouncelorAssignment()
                    {
                        CouncelorId = councelorId,
                        CabinId = cabinId,
                        StartDate = startDate,
                        EndDate = endDate
                    };
                    campContext.CouncelorAssignments.Add(assignCouncelor);
                    campContext.SaveChanges();
                    AnsiConsole.Markup($"[blue]Councelor[/] is assigned to cabin: [blue]{Selections.Cabins.SelectCabinTitleFromID(cabinId)}[/]");
                }
            }
        }
    }
}

static void AssignCamperToCabin()
{
    var selectCamper = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Select [blue]councelor[/] to assign: ")
        .PageSize(10)
        .MoreChoicesText("[Green](Move up and down with arrows)[/]")
        .AddChoices(Selections.SelectionsToArray.SelectCampers()));
    var camperId = Selections.Camper.SelectCamperIdFromPersonId(int.Parse(selectCamper[..2]));

    using (var campContext = new CampContext())
    {
        var checkCamper = campContext.CamperStays.Find(camperId);
        if (checkCamper is null)
        {
            var selectCabin = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select [blue]cabin[/] to assign the [blue]councelor[/] to: ")
                .PageSize(10)
                .MoreChoicesText("[Green](Move up and down with arrows)[/]")
                .AddChoices(Selections.SelectionsToArray.SelectCabins()));
            var cabinId = int.Parse(selectCabin[..2]);

            var checkCabins = campContext.CouncelorAssignments.Count(c => c.CabinId == cabinId);
            if (checkCabins > 0)
            {
                checkCabins = campContext.CamperStays.Count(c => c.CabinId == cabinId);
                if (checkCabins <= 4 )
                {
                    AnsiConsole.MarkupLine($"Type in [blue]start date[/] and the [blue]end date[/] in the format mm/dd/yyyy");
                    var startDate = DateTime.Parse(Console.ReadLine());
                    var endDate = DateTime.Parse(Console.ReadLine());

                    var assignCamperToCabin = new CamperStay()
                    {
                        CamperId = camperId,
                        CabinId = cabinId,
                        StartDate = startDate,
                        EndDate = endDate
                    };
                    campContext.CamperStays.Add(assignCamperToCabin);
                    campContext.SaveChanges();
                    AnsiConsole.Markup($"[blue]Camper[/] is assigned to cabin: [blue]{Selections.Cabins.SelectCabinTitleFromID(cabinId)}[/]");
                }
            }
        }
    }

    
}

static void PrintData(string[] arrayOfData)
{
    foreach (var data in arrayOfData)
    {
        AnsiConsole.MarkupLine($"[blue]{data}[/]");
    }
}

static List<Person> ReadCSV(string filePath)
{
    var people = new List<Person>();
    //C: \Users\Samuel Sandenäs\source\repos\SlutUppgiftGrupp\CampSleepAway2.0\data.csv

    using var reader = new StreamReader(filePath);

    // Read the header line
    var headerLine = reader.ReadLine();

    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        if (line == null)
        {
            break;
        }

        // Split the line by comma
        var values = line.Split(',');

        if (values.Length == 3)
        {
            var firstName = values[0];
            var lastName = values[1];
            var birthDate = DateTime.ParseExact(values[2], "d/M/yyyy", null);

            // Create a Department object if it doesn't exist
            //var department = departments.Find(d => d.Name == departmentName);
            //if (department is null)
            //{
            //    department = new Department
            //    {
            //        Name = departmentName
            //    };
            //    departments.Add(department);
            //}

            // Create EmployeeProfile object
            //var profile = new EmployeeProfile
            //{
            //    Phone = phone,
            //    Email = email
            //};
            //profiles.Add(profile);

            // Create Employee object
            var person = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate
            };
            people.Add(person);

            // Create Skill objects
            //foreach (var skillTitle in skillTitles)
            //{
            //    var skill = skills.Find(s => s.Title == skillTitle);
            //    if (skill is null)
            //    {
            //        skill = new Skill { Title = skillTitle };
            //        skills.Add(skill);
            //    }

            //    // Add skill to the employee's skills collection
            //    employee.Skills.Add(skill);
            //}
        }
    }
    return people;
}