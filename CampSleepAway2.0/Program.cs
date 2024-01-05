using CampSleepAway2._0;
using Spectre.Console;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

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
        UpdateData();
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
        if (Selections.Cabins.SelectCabins().Count() == 0)
        {
            Console.WriteLine("The table is empty.");
        }
        else
        {
            var deleteAllOrOne = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Do you want to [blue]delete all[/] data or delete just [blue]one[/]?: ")
            .PageSize(10)
            .MoreChoicesText("[Green](Move up and down with arrows)[/]")
            .AddChoices(new[]
            {
                "All", "One"
            } ));
            if (deleteAllOrOne == "All")
            {
                RemoveData.Cabins.DeleteAllCabins();
            }
            else
            {
                var selectDataToDelete= AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Select [blue]data[/] to delete: ")
                .PageSize(10)
                .MoreChoicesText("[Green](Move up and down with arrows)[/]")
                .AddChoices(Selections.Cabins.SelectCabins()));
                var idToDelete= int.Parse(selectDataToDelete[..2]);

                Console.WriteLine($"Are you sure you want to delete cabin: {Selections.Cabins.SelectCabinTitleFromID(idToDelete)}?  y/n");
                string warning = Console.ReadLine();

                if (warning == "y")
                {
                    RemoveData.Cabins.DeleteCabin(idToDelete);
                }
                else
                {
                    Console.WriteLine("The cabin was not deleted.");
                }
            }
        }
    }
    else if (selectTable == tableSelections[1])
    {
        if (Selections.Camper.SelectCampers().Count() == 0)
        {
            Console.WriteLine("The table is empty.");
        }
        else
        {
            var deleteAllOrOne = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Do you want to [blue]delete all[/] data or delete just [blue]one[/]?: ")
            .PageSize(10)
            .MoreChoicesText("[Green](Move up and down with arrows)[/]")
            .AddChoices(new[]
            {
                "All", "One"
            }));
            if (deleteAllOrOne == "All")
            {
                RemoveData.Campers.DeleteAllCampers();
            }
            else
            {
                var selectDataToDelete = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Select [blue]data[/] to delete: ")
                .PageSize(10)
                .MoreChoicesText("[Green](Move up and down with arrows)[/]")
                .AddChoices(Selections.Camper.SelectCampers()));
                var idToDelete = int.Parse(selectDataToDelete[..2]);

                Console.WriteLine($"Are you sure you want to delete camper: '{Selections.Camper.SelectCamperFromPersonID(idToDelete)}'?  y/n");
                string warning = Console.ReadLine();

                if (warning == "y")
                {
                    RemoveData.Campers.DeleteCamper(Selections.Camper.SelectCamperIdFromPersonId(idToDelete));
                }
                else
                {
                    Console.WriteLine("The camper was not deleted.");
                }   
            }
        }
    }
    else if (selectTable == tableSelections[2])
    {
        if (Selections.CamperStay.SelectCamperStays().Count() == 0)
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
            .AddChoices(Selections.CamperStay.SelectCamperStays()));
            var idToDelete = int.Parse(selectDataToDelete[..2]);

            Console.WriteLine($"Are you sure you want to delete the data?  y/n");
            string warning = Console.ReadLine();

            if (warning == "y")
            {
                RemoveData.CamperStays.DeleteCamperStay(idToDelete);
            }
            else
            {
                Console.WriteLine("The camper stay was not deleted.");
            }
        }
    }
    else if (selectTable == tableSelections[3])
    {
        if (Selections.Councelor.SelectCouncelors().Count() == 0)
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
            .AddChoices(Selections.Councelor.SelectCouncelors()));
            var idToDelete = int.Parse(selectDataToDelete[..2]);

            Console.WriteLine($"Are you sure you want to delete councelor: '{Selections.Councelor.SelectCouncelorFromPersonID(idToDelete)}'?  y/n");
            string warning = Console.ReadLine();

            if (warning == "y")
            {
                RemoveData.Councelors.DeleteCouncelor(Selections.Councelor.SelectCouncelorIdFromPersonId(idToDelete));
            }
            else
            {
                Console.WriteLine("The councelor was not deleted.");
            }
        }
    }
    else if (selectTable == tableSelections[4])
    {
        if (Selections.CouncelorAssignment.SelectCouncelorAssignments().Count() == 0)
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
            .AddChoices(Selections.CouncelorAssignment.SelectCouncelorAssignments()));
            var idToDelete = int.Parse(selectDataToDelete[..2]);

            Console.WriteLine($"Are you sure you want to delete councelor assignment data?  y/n");
            string warning = Console.ReadLine();

            if (warning == "y")
            {
                RemoveData.CouncelorAssignments.DeleteCouncelorAssignment(idToDelete);
            }
            else
            {
                Console.WriteLine("The councelor assignment data was not deleted.");
            }
        }
    }
    else if (selectTable == tableSelections[5])
    {
        if (Selections.NextOfKin.SelectNextOfKin().Count() == 0)
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
            .AddChoices(Selections.NextOfKin.SelectNextOfKin()));
            var idToDelete = int.Parse(selectDataToDelete[..2]);

            Console.WriteLine($"Are you sure you want to delete data?  y/n");
            string warning = Console.ReadLine();

            if (warning == "y")
            {
                RemoveData.NextOfKins.DeleteNextOfKin(idToDelete);
            }
            else
            {
                Console.WriteLine("The next of kin data was not deleted.");
            }
        }
    }
    else if (selectTable == tableSelections[6])
    {
        if (Selections.Visit.SelectVisits().Count() == 0)
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
            .AddChoices(Selections.Visit.SelectVisits()));
            var idToDelete = int.Parse(selectDataToDelete[..2]);

            Console.WriteLine($"Are you sure you want to delete data?  y/n");
            string warning = Console.ReadLine();

            if (warning == "y")
            {
                RemoveData.Visits.DeleteVisit(idToDelete);
            }
            else
            {
                Console.WriteLine("The visit data was not deleted.");
            }
        }
    }
    else if (selectTable == tableSelections[7])
    {
        if (Selections.Person.SelectPeople().Count() == 0)
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
            .AddChoices(Selections.Person.SelectPeople()));
            var idToDelete = int.Parse(selectDataToDelete[..2]);

            Console.WriteLine($"Are you sure you want to delete '{Selections.Person.SelectFullNameFromPersonID(idToDelete)}' and all the connections?  y/n");
            string warning = Console.ReadLine();

            if (warning == "y")
            {
                RemoveData.People.DeletePerson(idToDelete);
            }
            else
            {
                Console.WriteLine("The camper was not deleted.");
            }
        }
    }
}

static void AddData()
{
    string[] addDataSelections = new[]
    {
        "Add new person",
        "Add new Camper",
    };

    var addDataSelection = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Add data: [blue]What data do you want to add?[/]?")
            .PageSize(10)
            .MoreChoicesText("[green](Move up and down with arrows)[/]")
            .AddChoices(addDataSelections));

    if (addDataSelection == addDataSelections[0])
    {
        AddPerson();
    }
    else if (addDataSelection == addDataSelections[1])
    {
        AddCamper();
    }
}

static void AddPerson()
{
    AnsiConsole.MarkupLine($"[blue]Add a new person:[/]");

    AnsiConsole.MarkupLine("Enter first name:");
    var firstName = Console.ReadLine();

    AnsiConsole.MarkupLine("Enter last name:");
    var lastName = Console.ReadLine();

    AnsiConsole.MarkupLine("Enter birth date (mm/dd/yyyy):");
    var birthDateString = Console.ReadLine();
    var birthDate = DateTime.Parse(birthDateString);

    var newPerson = new Person
    {
        FirstName = firstName,
        LastName = lastName,
        BirthDate = birthDate
    };
    using (CampContext context = new CampContext())
    {
        context.Add<Person>(newPerson);
        context.SaveChanges();
    }
    AnsiConsole.Markup($"[blue]Person {newPerson.FirstName} {newPerson.LastName} added successfully.[/]");
}

static void AddCamper()
{
    AnsiConsole.MarkupLine($"[blue]Add a new camper:[/]");

    var existingPersons = GetExistingPersons();

    var selectedPerson = AnsiConsole.Prompt(
        new SelectionPrompt<Person>()
        .PageSize(10)
        .MoreChoicesText("[green](Move up and down with arrows)[/]")
        .AddChoices(existingPersons));

    var newCamper = new Camper
    {
        PersonId = selectedPerson.Id
    };

    AnsiConsole.Markup($"[blue]Camper {selectedPerson.FullName} added successfully.[/]");
}

static List <Person> GetExistingPersons()
{
    using (CampContext context = new CampContext())
    {
        return context.People.ToList();
    }
}


static void AddVisit()
{
    //var selectCamper = AnsiConsole.Prompt(
    //new SelectionPrompt<string>()
    //    .Title("Select [blue]camper[/] to receive a visit: ")
    //    .PageSize(10)
    //    .MoreChoicesText("[Green](Move up and down with arrows)[/]")
    //    .AddChoices(Selections.Camper.SelectCampers()));
    //var camperId = Selections.Camper.SelectCamperIdFromPersonId(int.Parse(selectCamper[..2]));

    //using (var campContext = new CampContext())
    //{
    //    var checkCouncelor = campContext.Visits.Find(camperId);
    //    {   

    //        var selectNextOfKin = AnsiConsole.Prompt(
    //        new SelectionPrompt<string>()
    //            .Title("Select [blue]next of kin[/] that will [blue]visit[/] the camper: ")
    //            .PageSize(10)
    //            .MoreChoicesText("[Green](Move up and down with arrows)[/]")
    //            .AddChoices(Selections.NextOfKin.SelectNextOfKinToCamperFromId(camperId)));
    //        var nextOfKinId = int.Parse(selectNextOfKin[..2]);
    //        //var kin = new 


    //        AnsiConsole.MarkupLine($"Type in [blue]start date[/] and the [blue]end date[/] in the format mm/dd/yyyy:");
    //        var startDate = DateTime.Parse(Console.ReadLine());
    //        var endDate = DateTime.Parse(Console.ReadLine());

    //        var visit = new Visit()
    //        {
    //            CamperId = camperId,
    //            NextOfKins = nextOfKinId,
    //            StartDate = startDate,
    //            EndDate = endDate
    //        };
    //        campContext.Visits.Add(visit);
    //        campContext.SaveChanges();
    //        AnsiConsole.Markup($"The [blue]visit[/] is added.");


    //    }   
    //}
    var selectCamper = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Select [blue]camper[/] to receive a visit: ")
            .PageSize(10)
            .MoreChoicesText("[Green](Move up and down with arrows)[/]")
            .AddChoices(Selections.Camper.SelectCampers()));
    var camperId = Selections.Camper.SelectCamperIdFromPersonId(int.Parse(selectCamper[..2]));

    using (var campContext = new CampContext())
    {
        var selectedCamper = campContext.Campers.Include(c => c.Kins)
            .FirstOrDefault(c => c.Id == camperId);

        if (selectedCamper != null)
        {
            var selectNextOfKin = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select [blue]next of kin[/] that will [blue]visit[/] the camper: ")
                    .PageSize(10)
                    .MoreChoicesText("[Green](Move up and down with arrows)[/]")
                    .AddChoices(selectedCamper.Kins.Select(nok => $"{nok.Id.ToString().PadLeft(2)} - {nok.Person.FullName}")));

            var nextOfKinId = int.Parse(selectNextOfKin[..2]);
            var selectedNextOfKin = selectedCamper.Kins.FirstOrDefault(n => n.Id == nextOfKinId);

            if (selectedNextOfKin != null)
            {
                AnsiConsole.MarkupLine($"Type in [blue]start date[/] and the [blue]end date[/] in the format mm/dd/yyyy:");
                var startDate = DateTime.Parse(Console.ReadLine());
                var endDate = DateTime.Parse(Console.ReadLine());

                var visit = new Visit()
                {
                    CamperId = camperId,
                    Camper = selectedCamper,
                    StartDate = startDate,
                    EndDate = endDate
                };

                visit.NextOfKins.Add(selectedNextOfKin); // Associate the selected NextOfKin with the Visit

                campContext.Visits.Add(visit);
                campContext.SaveChanges();
                AnsiConsole.Markup($"The [blue]visit[/] is added.");
            }
            else
            {
                AnsiConsole.Markup($"Invalid selection for Next of Kin.");
            }
        }
        else
        {
            AnsiConsole.Markup($"Invalid selection for Camper.");
        }
    }

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
            PrintData(Selections.Presentation.SelectCabins());
        }
        else if (showData == showDataSelections[1])
        {
            PrintData(Selections.Presentation.SelectCampers());
        }
        else if (showData == showDataSelections[2])
        {
            PrintData(Selections.Presentation.SelectCamperStays());
        }
        else if (showData == showDataSelections[3])
        {
            PrintData(Selections.Presentation.SelectCouncelors());
        }
        else if (showData == showDataSelections[4])
        {
            PrintData(Selections.Presentation.SelectCouncelorAssignments());
        }
        else if (showData == showDataSelections[5])
        {
            PrintData(Selections.Presentation.SelectNextOfKin());
        }
        else if (showData == showDataSelections[6])
        {
            PrintData(Selections.Presentation.SelectVisits());
        }
        else if (showData == showDataSelections[7])
        {
            PrintData(Selections.Presentation.SelectPeople());
        }
    }

static void AssignCouncelor()
{
    var selectCouncelor = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Select [blue]councelor[/] to assign: ")
        .PageSize(10)
        .MoreChoicesText("[Green](Move up and down with arrows)[/]")
        .AddChoices(Selections.Councelor.SelectCouncelors()));
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
                    .AddChoices(Selections.Cabins.SelectCabins()));
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
        .AddChoices(Selections.Camper.SelectCampers()));
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
                .AddChoices(Selections.Cabins.SelectCabins()));
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