using CampSleepAway2._0;
using Spectre.Console;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;

using (var campContext = new CampContext())
{
    
    //Menu();
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

    ////campContext.Councelors.Add(new Councelor()
    ////{
    //////    PersonId = 8
    ////});
    //campContext.Cabins.Add(cabin);
    //campContext.Cabins.Add(cabin1);
    //campContext.SaveChanges();

    //campContext.NextOfKins.Add(new NextOfKin()
    //{
    //    PersonId = 8,
    //    CamperId = 1
    //});
    //campContext.SaveChanges();
    string dirr = Directory.GetCurrentDirectory();
    Console.WriteLine(dirr);
    //Selections.SelectCabins();
    Selections.SelectPersonFromCampers();
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
        "Show data", "Assign counselor", "Assign camper to cabin",
        "Add a visit", "Add data", "Update data", "Delete data",
    };
    var menuSelection = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Main menu: [blue]What do you want to do?[/]?")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down with arrows)[/]")
        .AddChoices(menuSelections));

    if (menuSelection == menuSelections[0])
    {
        string[] showDataSelections= new[]
    {
        "Cabins", "Campers", "Camper stays", "Councelors",
        "Councelor assignments", "Next of kin", "Visits", "People",
        "Show all"
    };
        var showData = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Show data: [blue]What data do you wanna look at?[/]?")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down with arrows)[/]")
            .AddChoices(showDataSelections));
        if (showData == showDataSelections[0])
        {
            Selections.SelectCabins();
        }
        else if (showData == showDataSelections[1])
        {
            Selections.SelectPersonFromCampers();
        }
        else if (showData == showDataSelections[2])
        {
            Selections.SelectCamperStay();
        }
        else if (showData == showDataSelections[3])
        {
            Selections.SelectPersonFromCouncelor();
        }
        else if (showData == showDataSelections[4])
        {
            Selections.SelectCouncelorAssignments();
        }
        //else if (showData == showDataSelections[5])
        //{
        //    var arrOfCampers = Selections.SelectPersonFromCampers();
        //    foreach(var data in Selections.SelectPersonFromCampers())
        //    {

        //    }
        //    string[] selectCamper = new[]
        //    {
        //        "Show data", "Assign counselor", "Assign camper to cabin",
        //        "Add a visit", "Add data", "Update data", "Delete data",
        //    };

        //    var selectCamperToShowKin = AnsiConsole.Prompt(
        //    new SelectionPrompt<string>()
        //        .Title("Main menu: [blue]What do you want to do?[/]?")
        //        .PageSize(10)
        //        .MoreChoicesText("[grey](Move up and down with arrows)[/]")
        //        .AddChoices());
        //}






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