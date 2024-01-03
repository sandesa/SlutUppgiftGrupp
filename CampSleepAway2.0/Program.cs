﻿using CampSleepAway2._0;
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

    //var person = new Person()
    //{
    //    FirstName = "Samuel",
    //    LastName = "Sandenäs",
    //    BirthDate = DateTime.Parse("02/03/1998")
    //};
    //campContext.People.Add(person);
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
    else
    {
        DeleteData();
    }


}

static void DeleteData()
{

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
            PrintData(Selections.SelectCabins());
        }
        else if (showData == showDataSelections[1])
        {
            PrintData(Selections.SelectCampers());
        }
        else if (showData == showDataSelections[2])
        {
            PrintData(Selections.SelectCamperStays());
        }
        else if (showData == showDataSelections[3])
        {
            PrintData(Selections.SelectCouncelors());
        }
        else if (showData == showDataSelections[4])
        {
            PrintData(Selections.SelectCouncelorAssignments());
        }
        else if (showData == showDataSelections[5])
        {
            PrintData(Selections.SelectNextOfKinToCampers());
        }
        else if (showData == showDataSelections[6])
        {
            PrintData(Selections.SelectVisits());
        }
        else if (showData == showDataSelections[7])
        {
            PrintData(Selections.SelectPeople());
        }
    }

static void AssignCouncelor()
{
    var selectCouncelor = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Select [blue]councelor[/] to assign: ")
        .PageSize(10)
        .MoreChoicesText("[Green](Move up and down with arrows)[/]")
        .AddChoices(Selections.SelectCouncelors()));
    var councelorId = int.Parse(selectCouncelor[..2]);

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
                    .AddChoices(Selections.SelectCabins()));
                var cabinId = int.Parse(selectCabin[..2]);

                var checkCabins = campContext.CouncelorAssignments.Find(cabinId);

                if (checkCabins is null)
                {
                    AnsiConsole.Markup($"Type in [blue]start date[/] and the [blue]end date[/] in the format dd/mm/yyyy");
                    var startDate = DateTime.Parse(Console.ReadLine());
                    var endDate = DateTime.Parse(Console.ReadLine());

                    var assignCouncelor = new CouncelorAssignment()
                    {
                        CouncelorId = councelorId,
                        CabinId = cabinId,
                        StartDate = startDate,
                        EndDate = endDate
                    };
                    AnsiConsole.Markup($"[blue]Councelor[/] is assigned to cabin with ID: [blue]{cabinId}[/]");
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
        .AddChoices(Selections.SelectCampers()));
    var camperId = int.Parse(selectCamper[..2]);

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
                .AddChoices(Selections.SelectCabins()));
            var cabinId = int.Parse(selectCabin[..2]);

            var checkCabins = campContext.CouncelorAssignments.Count(c => c.CabinId == cabinId);
            if (checkCabins > 0)
            {
                checkCabins = campContext.CamperStays.Count(c => c.CabinId == cabinId);
                if (checkCabins <= 4 )
                {
                    AnsiConsole.Markup($"Type in [blue]start date[/] and the [blue]end date[/] in the format dd/mm/yyyy");
                    var startDate = DateTime.Parse(Console.ReadLine());
                    var endDate = DateTime.Parse(Console.ReadLine());

                    var assignCamperToCabin = new CamperStay()
                    {
                        CamperId = camperId,
                        CabinId = cabinId,
                        StartDate = startDate,
                        EndDate = endDate
                    };
                    AnsiConsole.Markup($"[blue]Camper[/] is assigned to cabin with ID: [blue]{cabinId}[/]");
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