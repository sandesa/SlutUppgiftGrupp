using CampSleepAway2._0;
using Spectre.Console;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

public class Program
{
    static bool run = true;
    static void Main(string[] args)
    {
        //ReadDataCSV("C:\\Users\\Samuel Sandenäs\\source\\repos\\SlutUppgiftGrupp\\CampSleepAway2.0\\data.csv");

        using (var campContext = new CampContext())
        {
            while (run)
            {
                Menu();
            }
        }
    }

    static void Menu()
    {
        string[] menuSelections = new[]
        {
        "Show data", "Assign councelor to cabin", "Assign camper to cabin",
        "Add a visit", "Add data", "Update data", "Delete data", "Exit"
    };
        var menuSelection = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Main menu: [blue]What do you want to do?[/]?")
            .PageSize(10)
            .MoreChoicesText("[Green](Move up and down with arrows)[/]")
            .AddChoices(menuSelections));
        Console.Clear();

        if (menuSelection == menuSelections[0])
        {
            SelectData();
            Console.WriteLine();
        }
        else if (menuSelection == menuSelections[1])
        {
            AssignCouncelor();
            Console.WriteLine();
        }
        else if (menuSelection == menuSelections[2])
        {
            AssignCamperToCabin();
            Console.WriteLine();
        }
        else if (menuSelection == menuSelections[3])
        {
            AddVisit();
        }
        else if (menuSelection == menuSelections[4])
        {
            AddData.AddNewData();
        }
        else if (menuSelection == menuSelections[5])
        {
            UpdateData.DataUpdate();
        }
        else if (menuSelection == menuSelections[6])
        {
            DeleteData();
        }
        else if (menuSelection == menuSelections[7])
        {
            run = false;
        }
    }

    static void DeleteData()
    {
        string[] tableSelections = new[]
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
                }));
                if (deleteAllOrOne == "All")
                {
                    Console.WriteLine($"Are you sure you want to delete all data??  y/n");
                    string warning = Console.ReadLine();

                    if (warning == "y")
                    {
                        RemoveData.Cabins.DeleteAllCabins();
                    }
                    else
                    {
                        Console.WriteLine("The cabins was not deleted.");
                    }
                }
                else
                {
                    var selectDataToDelete = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("Select [blue]data[/] to delete: ")
                    .PageSize(10)
                    .MoreChoicesText("[Green](Move up and down with arrows)[/]")
                    .AddChoices(Selections.Cabins.SelectCabins()));
                    var idToDelete = int.Parse(selectDataToDelete[..2]);

                    Console.WriteLine($"Are you sure you want to delete cabin: {Selections.Cabins.SelectCabinTitleFromID(idToDelete)}?  y/n");
                    string warning = Console.ReadLine();

                    if (warning == "y")
                    {
                        RemoveData.Cabins.DeleteCabin(idToDelete);
                    }
                    else
                    {
                        Console.WriteLine("The data was not deleted.");
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
                    Console.WriteLine($"Are you sure you want to delete all data??  y/n");
                    string warning = Console.ReadLine();

                    if (warning == "y")
                    {
                        RemoveData.Campers.DeleteAllCampers();
                    }
                    else
                    {
                        Console.WriteLine("The data was not deleted.");
                    }
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
                    Console.WriteLine($"Are you sure you want to delete all data??  y/n");
                    string warning = Console.ReadLine();

                    if (warning == "y")
                    {
                        RemoveData.CamperStays.DeleteAllCamperStays();
                    }
                    else
                    {
                        Console.WriteLine("The data was not deleted.");
                    }
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
        }
        else if (selectTable == tableSelections[3])
        {
            if (Selections.Councelor.SelectCouncelors().Count() == 0)
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
                    Console.WriteLine($"Are you sure you want to delete all data??  y/n");
                    string warning = Console.ReadLine();

                    if (warning == "y")
                    {
                        RemoveData.Councelors.DeleteAllCouncelors();
                    }
                    else
                    {
                        Console.WriteLine("The data was not deleted.");
                    }
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
        }
        else if (selectTable == tableSelections[4])
        {
            if (Selections.CouncelorAssignment.SelectCouncelorAssignments().Count() == 0)
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
                    Console.WriteLine($"Are you sure you want to delete all data??  y/n");
                    string warning = Console.ReadLine();

                    if (warning == "y")
                    {
                        RemoveData.CouncelorAssignments.DeleteAllCouncelorAssignments();
                    }
                    else
                    {
                        Console.WriteLine("The data was not deleted.");
                    }
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
        }
        else if (selectTable == tableSelections[5])
        {
            if (Selections.NextOfKin.SelectNextOfKin().Count() == 0)
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
                    Console.WriteLine($"Are you sure you want to delete all data??  y/n");
                    string warning = Console.ReadLine();

                    if (warning == "y")
                    {
                        RemoveData.NextOfKins.DeleteAllNextOfKin();
                    }
                    else
                    {
                        Console.WriteLine("The data was not deleted.");
                    }
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
        }
        else if (selectTable == tableSelections[6])
        {
            if (Selections.Visit.SelectVisits().Count() == 0)
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
                    Console.WriteLine($"Are you sure you want to delete all data??  y/n");
                    string warning = Console.ReadLine();

                    if (warning == "y")
                    {
                        RemoveData.Visits.DeleteAllVisits();
                    }
                    else
                    {
                        Console.WriteLine("The data was not deleted.");
                    }
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
        }
        else if (selectTable == tableSelections[7])
        {
            if (Selections.Person.SelectPeople().Count() == 0)
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
                    Console.WriteLine($"Are you sure you want to delete all data??  y/n");
                    string warning = Console.ReadLine();

                    if (warning == "y")
                    {
                        RemoveData.People.DeleteAllPeople();
                    }
                    else
                    {
                        Console.WriteLine("The data was not deleted.");
                    }
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
            .Title("Select [blue]camper[/] to assign: ")
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
                    if (checkCabins <= 4)
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
            AnsiConsole.MarkupLine($"[green]{data}[/]");
        }
    }

    static void ReadDataCSV(string filePath)
    {
        var people = new List<Person>();
        var campers = new List<Camper>();
        var councelors = new List<Councelor>();
        var nextOfKins = new List<NextOfKin>();
        var cabins = new List<Cabin>();
        //C: \Users\Samuel Sandenäs\source\repos\SlutUppgiftGrupp\CampSleepAway2.0\data.csv

        using var reader = new StreamReader(filePath);

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line == null)
            {
                break;
            }

            var values = line.Split(',');

            if (values.Length == 4)
            {
                var assignment = values[0];
                var firstName = values[1];
                var lastName = values[2];
                var birthDate = DateTime.ParseExact(values[3], "mm/dd/yyyy", null);

                var person = new Person
                {
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = birthDate
                };
                people.Add(person);
                using (var campContext = new CampContext())
                {
                    foreach (var p in people)
                    {
                        campContext.People.Add(p);
                        campContext.SaveChanges();

                        if (assignment == "Campers")
                        {
                            var camper = new Camper()
                            {
                                PersonId = p.Id
                            };
                            campers.Add(camper);
                            campContext.Campers.Add(camper);
                        }
                        else if (assignment == "Councelors")
                        {
                            var councelor = new Councelor()
                            {
                                PersonId = p.Id
                            };
                            councelors.Add(councelor);
                            campContext.Councelors.Add(councelor);
                        }
                        else if (assignment == "NextOfKins")
                        {
                            var nextOfKin1 = new NextOfKin()
                            {
                                PersonId = p.Id,
                                CamperId = 1
                            };
                            nextOfKins.Add(nextOfKin1);
                            campContext.NextOfKins.Add(nextOfKin1);
                        }
                    }
                    campContext.SaveChanges();
                }
            }
            else if (values.Length == 3)
            {
                var title = values[1];
                var numberOfResidence = values[2];

                var cabin = new Cabin
                {
                    Title = title,
                    NumberOfResidence = int.Parse(numberOfResidence)
                };
                cabins.Add(cabin);
                using (var campContext = new CampContext())
                {
                    foreach (var c in people)
                    {
                        campContext.Cabins.Add(cabin);
                    }
                    campContext.SaveChanges();
                }
            }
        }
    }
}