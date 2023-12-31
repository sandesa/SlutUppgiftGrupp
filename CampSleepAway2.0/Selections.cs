﻿using CampSleepAway2._0;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

public class Selections
{
    public static void SelectCabins()
    {
        using (var campContext = new CampContext())
        {
            var selectData = campContext.Cabins.Select(x => x).ToList();

            foreach (var data in selectData)
            {
                AnsiConsole.Markup($"[green]{data.Id}[/]\t[deepskyblue3_1]{data.Title}[/]\t[greenyellow]{data.NumberOfResidence}[/]");
                Console.WriteLine();
            }
        }
    }

    public static void SelectPersonFromCampers()
    {
        using (var campContext = new CampContext())
        {
            var selectData = campContext.Campers.Select(x => x.Person).ToList();

            foreach (var data in selectData)
            {
                AnsiConsole.Markup($"[green]{data.Id}[/]\t[deepskyblue3_1]{data.FirstName}[/]\t[greenyellow]{data.LastName}[/]");
            }
        }
    }

    public static void SelectPersonFromCouncelor()
    {
        using (var campContext = new CampContext())
        {
            var selectData = campContext.Councelors.Select(x => x.Person).ToList();

            foreach (var data in selectData)
            {
                AnsiConsole.Markup($"[green]{data.Id}[/]\t[deepskyblue3_1]{data.FirstName}[/]\t[greenyellow]{data.LastName}[/]");
                Console.WriteLine();
            }
        }
    }

    public static void SelectPersonFromNextOfKin(int id)
    {
        using (var campContext = new CampContext())
        {
            var selectData = campContext.NextOfKins.Include(x => x.Person)
                                        .Include(c => c.Camper)
                                        .Where(c => c.Camper.Id == id)
                                        .ToList();

            foreach (var data in selectData)
            {
                if (data is not null)
                {
                    AnsiConsole.Markup($"[green]{data.Person.Id}[/]\t[deepskyblue3_1]{data.Person.FirstName}[/]\t[greenyellow]{data.Person.LastName}[/]");
                    Console.WriteLine();
                }
                else
                {
                    AnsiConsole.Markup($"[green]{data.Person.Id}[/]\t[deepskyblue3_1]{data.Person.FirstName}[/]\t[greenyellow]{data.Person.LastName}[/]. This person doesn't have kins. Unlucky.");
                    Console.WriteLine();
                }
            }
        }
    }
    public static void SelectPerson()
    {
        using (var campContext = new CampContext())
        {
            var selectData = campContext.People.Select(x => x).ToList();

            foreach (var data in selectData)
            {
                AnsiConsole.Markup($"[green]{data.Id}[/]\t[deepskyblue3_1]{data.FirstName}[/]\t[greenyellow]{data.LastName}[/]");
                Console.WriteLine();
            }
        }
    }
    public static void SelectCamperStay()
    {
        using (var campContext = new CampContext())
        {
            var selectData = campContext.Stays.Select(x => x).ToList();

            foreach (var data in selectData)
            {
                AnsiConsole.Markup($"[green]{data.Id}[/]\t[deepskyblue3_1]{data.Camper.Id}[/]\t[greenyellow]{data.Cabin.Id}[/]");
                Console.WriteLine();
            }
        }
    }
    public static void SelectCouncelorAssignments()
    {
        using (var campContext = new CampContext())
        {
            var selectData = campContext.Assignments.Select(x => x).ToList();

            foreach (var data in selectData)
            {
                AnsiConsole.Markup($"[green]{data.Id}[/]\t[deepskyblue3_1]{data.Councelor.Id}[/]\t[greenyellow]{data.Cabin.Id}[/]");
                Console.WriteLine();
            }
        }
    }
}