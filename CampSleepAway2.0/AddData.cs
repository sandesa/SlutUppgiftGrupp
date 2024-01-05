using CampSleepAway2._0;
using Microsoft.IdentityModel.Tokens;
using Spectre.Console;

public class AddData
{
    public static void AddNewData()
    {
        string[] addDataSelections = new[]
        {
        "Add new Person",
        "Add new Camper",
        "Add new Cabin",
        "Add new Councelor",
        "Add new Next Of Kin"
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
        else if (addDataSelection == addDataSelections[2])
        {
            AddCabin();
        }
    }
    public static void AddPerson()
    {
        AnsiConsole.MarkupLine($"[blue]Add a new person:[/]");

        AnsiConsole.MarkupLine("Enter first name:");
        var firstName = Console.ReadLine();
        while (firstName.IsNullOrEmpty())
        {
            Console.WriteLine("You must add a first name.");
            firstName = Console.ReadLine();
        }

        AnsiConsole.MarkupLine("Enter last name:");
        var lastName = Console.ReadLine();
        while (lastName.IsNullOrEmpty())
        {
            Console.WriteLine("You must add a last name.");
            firstName = Console.ReadLine();
        }

        AnsiConsole.MarkupLine("Enter birth date (mm/dd/yyyy):");
        var birthDateString = Console.ReadLine();
        DateTime birthDate;
        while (!DateTime.TryParse(birthDateString, out birthDate))
        {
            Console.WriteLine("You must add a birth date.");
            birthDateString = Console.ReadLine();
        }

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

    public static void AddCamper()
    {
        string[] addNewOrExisting = new[]
        {
        "Add new",
        "Add from existing",
        };

        var newOrExisting = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Do you want to add a [blue]new[/] person or select from [blue]existing[/] people?")
                .PageSize(10)
                .MoreChoicesText("[green](Move up and down with arrows)[/]")
                .AddChoices(addNewOrExisting));
        if (newOrExisting == addNewOrExisting[0])
        {
            AnsiConsole.MarkupLine($"[blue]Add a new camper:[/]");

            AnsiConsole.MarkupLine("Enter Camper's first name:");
            var firstName = Console.ReadLine();
            while (firstName.IsNullOrEmpty())
            {
                Console.WriteLine("You must add a first name.");
                firstName = Console.ReadLine();
            }

            AnsiConsole.MarkupLine("Enter Camper's last name:");
            var lastName = Console.ReadLine();
            while (lastName.IsNullOrEmpty())
            {
                Console.WriteLine("You must add a last name.");
                firstName = Console.ReadLine();
            }

            AnsiConsole.MarkupLine("Enter birth date (mm/dd/yyyy):");
            var birthDateString = Console.ReadLine();
            DateTime birthDate;
            while (!DateTime.TryParse(birthDateString, out birthDate))
            {
                Console.WriteLine("You must add a birth date.");
                birthDateString = Console.ReadLine();
            }

            var newPerson = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
            };
            using (CampContext context = new CampContext())
            {
                context.People.Add(newPerson);
                var newPersonId = context.People.Last().Id;
                var newCamper = new Camper { Id = newPersonId };
                context.Campers.Add(newCamper);
                context.SaveChanges();
            }

            AnsiConsole.Markup($"[blue]Camper {newPerson.FullName} added successfully.[/]");
        }
        else
        {
            var selectPerson = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select [blue]person[/] to add to [blue]campers[/]?")
                .PageSize(10)
                .MoreChoicesText("[green](Move up and down with arrows)[/]")
                .AddChoices(Selections.Person.SelectPeople()));
            var personId = int.Parse(selectPerson[..2]);

            using (CampContext context = new CampContext())
            {
                var newCamper = new Camper { Id = personId };
                context.Campers.Add(newCamper);
                context.SaveChanges();
            }
            AnsiConsole.Markup($"[blue]Camper added successfully.[/]");
        }
    }
    public static void AddCabin()
    {
        AnsiConsole.MarkupLine($"[blue]Add a new cabin:[/]");

        AnsiConsole.MarkupLine("Enter cabin title:");
        var title = Console.ReadLine();
        while (title.IsNullOrEmpty())
        {
            Console.WriteLine("You must add a title.");
            title = Console.ReadLine();
        }

        AnsiConsole.MarkupLine("Enter number of residence (max 4):");
        var numberOfResidence = Console.ReadLine();
        int nOR;
        while (!int.TryParse(numberOfResidence, out nOR))
        {
            Console.WriteLine("You must add a number.");
            numberOfResidence = Console.ReadLine();
        }

        var newCabin = new Cabin
        {
            Title = title,
            NumberOfResidence = nOR,
        };
        using (CampContext context = new CampContext())
        {
            context.Cabins.Add(newCabin);
            context.SaveChanges();
        }
        AnsiConsole.Markup($"[blue]Cabin {newCabin.Title} added successfully.[/]");
    }
    public static void AddCouncelor()
    {
        string[] addNewOrExisting = new[]
        {
        "Add new",
        "Add from existing",
        };

        var newOrExisting = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Do you want to add a [blue]new[/] person or select from [blue]existing[/] people?")
                .PageSize(10)
                .MoreChoicesText("[green](Move up and down with arrows)[/]")
                .AddChoices(addNewOrExisting));
        if (newOrExisting == addNewOrExisting[0])
        {
            AnsiConsole.MarkupLine($"[blue]Add a new councelor:[/]");

            AnsiConsole.MarkupLine("Enter Councelor's first name:");
            var firstName = Console.ReadLine();
            while (firstName.IsNullOrEmpty())
            {
                Console.WriteLine("You must add a first name.");
                firstName = Console.ReadLine();
            }

            AnsiConsole.MarkupLine("Enter Councelor's last name:");
            var lastName = Console.ReadLine();
            while (lastName.IsNullOrEmpty())
            {
                Console.WriteLine("You must add a last name.");
                firstName = Console.ReadLine();
            }

            AnsiConsole.MarkupLine("Enter birth date (mm/dd/yyyy):");
            var birthDateString = Console.ReadLine();
            DateTime birthDate;
            while (!DateTime.TryParse(birthDateString, out birthDate))
            {
                Console.WriteLine("You must add a birth date.");
                birthDateString = Console.ReadLine();
            }

            var newPerson = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
            };
            using (CampContext context = new CampContext())
            {
                context.People.Add(newPerson);
                var newPersonId = context.People.Last().Id;
                var newCouncelor = new Councelor { Id = newPersonId };
                context.Councelors.Add(newCouncelor);
                context.SaveChanges();
            }

            AnsiConsole.Markup($"[blue]Councelor {newPerson.FullName} added successfully.[/]");
        }
        else
        {
            var selectPerson = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select [blue]person[/] to add to [blue]campers[/]?")
                .PageSize(10)
                .MoreChoicesText("[green](Move up and down with arrows)[/]")
                .AddChoices(Selections.Person.SelectPeople()));
            var personId = int.Parse(selectPerson[..2]);

            using (CampContext context = new CampContext())
            {
                var newCouncelor = new Councelor { Id = personId };
                context.Councelors.Add(newCouncelor);
                context.SaveChanges();
            }
            AnsiConsole.Markup($"[blue]Councelor added successfully.[/]");
        }
    }
    public static void AddNextOfKin()
    {
        string[] addNewOrExisting = new[]
        {
        "Add new",
        "Add from existing",
        };

        var newOrExisting = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Do you want to add a [blue]new[/] person or select from [blue]existing[/] people?")
                .PageSize(10)
                .MoreChoicesText("[green](Move up and down with arrows)[/]")
                .AddChoices(addNewOrExisting));
        if (newOrExisting == addNewOrExisting[0])
        {
            AnsiConsole.MarkupLine($"[blue]Add a new Next Of Kin:[/]");

            AnsiConsole.MarkupLine("Enter person's first name:");
            var firstName = Console.ReadLine();
            while (firstName.IsNullOrEmpty())
            {
                Console.WriteLine("You must add a first name.");
                firstName = Console.ReadLine();
            }

            AnsiConsole.MarkupLine("Enter person's last name:");
            var lastName = Console.ReadLine();
            while (lastName.IsNullOrEmpty())
            {
                Console.WriteLine("You must add a last name.");
                firstName = Console.ReadLine();
            }

            AnsiConsole.MarkupLine("Enter birth date (mm/dd/yyyy):");
            var birthDateString = Console.ReadLine();
            DateTime birthDate;
            while (!DateTime.TryParse(birthDateString, out birthDate))
            {
                Console.WriteLine("You must add a birth date.");
                birthDateString = Console.ReadLine();
            }

            var newPerson = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
            };
            using (CampContext context = new CampContext())
            {
                context.People.Add(newPerson);
                var newPersonId = context.People.Last().Id;
                var selectCamper = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select [blue]camper[/] that the person is related to?")
                        .PageSize(10)
                        .MoreChoicesText("[green](Move up and down with arrows)[/]")
                        .AddChoices(Selections.Camper.SelectCampers()));
                var camperId = Selections.Camper.SelectCamperIdFromPersonId(int.Parse(selectCamper[..2]));
                var newNextOfKin = new NextOfKin { PersonId = newPersonId, CamperId = camperId };
                context.NextOfKins.Add(newNextOfKin);
                context.SaveChanges();
            }

            AnsiConsole.Markup($"[blue]NextOfKin {newPerson.FullName} added successfully.[/]");
        }
        else
        {
            var selectPerson = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select [blue]person[/] to add to [blue]Next Of Kin[/]?")
                .PageSize(10)
                .MoreChoicesText("[green](Move up and down with arrows)[/]")
                .AddChoices(Selections.Person.SelectPeople()));
            var personId = int.Parse(selectPerson[..2]);

            using (CampContext context = new CampContext())
            {
                var selectCamper = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select [blue]camper[/] that the person is related to?")
                        .PageSize(10)
                        .MoreChoicesText("[green](Move up and down with arrows)[/]")
                        .AddChoices(Selections.Camper.SelectCampers()));
                var camperId = Selections.Camper.SelectCamperIdFromPersonId(int.Parse(selectCamper[..2]));
                var newNextOfKin = new NextOfKin { PersonId = personId, CamperId = camperId };
                context.NextOfKins.Add(newNextOfKin);
                context.SaveChanges();
            }
            AnsiConsole.Markup($"[blue]NextOfKin added successfully.[/]");
        }
    }

}
