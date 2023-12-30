using CampSleepAway2._0;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;

using (var campContext = new CampContext())
{
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
    //    PersonId = 8
    //});
    //campContext.SaveChanges();
    //campContext.Cabins.Add(cabin);
    //campContext.Cabins.Add(cabin1);
    //campContext.SaveChanges();

    //campContext.NextOfKins.Add(new NextOfKin()
    //{
    //    PersonId = 8,
    //    CamperId = 1
    //});
    //campContext.SaveChanges();

    Selections.SelectCabins();
    Selections.SelectPersonFromCampers();
    Selections.SelectPersonFromCouncelor();
    Selections.SelectPersonFromNextOfKin(1);
    Selections.SelectPerson();

    //var person = new Person()
    //{
    //    FirstName = "Samuel",
    //    LastName = "Sandenäs",
    //    BirthDate = DateTime.Parse("02/03/1998")
    //};
    //campContext.People.Add(person);
    //campContext.SaveChanges();

    //var people = ReadCSV("C:\\Users\\Samuel Sandenäs\\source\\repos\\SlutUppgiftGrupp\\CampSleepAway2.0\\data.csv");
    //Console.WriteLine($"{people.Count} hittades i CSV-filen");

    //foreach (var person in people)
    //{
    //    campContext.People.Add(person);
    //}
    //campContext.SaveChanges();
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