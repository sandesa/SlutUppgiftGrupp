using CampSleepAway2._0;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Spectre.Console;

public class UpdateDate
{
    public void UpdateData()
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
    }

    public void UpdateCabin()
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
                    Console.WriteLine("Type the new title:");
                    string newTitle = Console.ReadLine();
                    while (newTitle.IsNullOrEmpty())
                    {
                        Console.WriteLine("The cabin must have a title.");
                        newTitle = Console.ReadLine();
                    }
                    cabin.Title = newTitle;
                }
                else if (selectColumn == selectColumns[1])
                {
                    Console.WriteLine("Type the new number of residence:");
                    string newNumberOfResidence = Console.ReadLine();
                    int number;
                    while (!int.TryParse(newNumberOfResidence, out number))
                    {
                        Console.WriteLine("The cabin must have a number of residence.");
                        newNumberOfResidence = Console.ReadLine();
                    }
                    cabin.NumberOfResidence = number;
                }
                campContext.SaveChanges();
                Console.WriteLine("The data has been updated");
            }
        }
    }

    static void UpdatePerson()
    {
        AnsiConsole.MarkupLine($"[blue]Update person information:[/]");

        var existingPersons = GetExistingPersons();

        if (existingPersons.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No existing persons to update.[/]");
            return;
        }

        var selectedPerson = AnsiConsole.Prompt(
            new SelectionPrompt<Person>()
            .Title("Select the person to update:")
            .PageSize(10)
            .MoreChoicesText("[green](Move up and down with arrows)[/]")
            .AddChoices(existingPersons));

        AnsiConsole.MarkupLine("Enter updated first name:");
        var updatedFirstName = Console.ReadLine();

        AnsiConsole.MarkupLine("Enter updated last name:");
        var updatedLastName = Console.ReadLine();

        selectedPerson.FirstName = updatedFirstName;
        selectedPerson.LastName = updatedLastName;

        using (CampContext context = new CampContext())
        {
            context.Update<Person>(selectedPerson);
            context.SaveChanges();
        }

        AnsiConsole.Markup($"[blue]Person {selectedPerson.FullName} updated successfully.[/]");
    }
    static List<Person> GetExistingPersons()
    {
        using (CampContext context = new CampContext())
        {
            return context.People.ToList();
        }
    }

}



