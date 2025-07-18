﻿using System;

namespace PersonsInfo;

public class StartUp
{
    public static void Main(string[] args)
    {

        var lines = int.Parse(Console.ReadLine());

        var persons = new List<Person>();

        for (int i = 0; i < lines; i++)

        {

            var cmdArgs = Console.ReadLine().Split();

            var person = new Person(cmdArgs[0],

            cmdArgs[1],

            int.Parse(cmdArgs[2]),

            decimal.Parse(cmdArgs[3]));


            persons.Add(person);

        }

        var parcentage = decimal.Parse(Console.ReadLine());

      

        persons.ForEach(p => p.IncreaseSalary(parcentage));

        persons.ForEach(p => Console.WriteLine(p.ToString()));
        Team team = new Team("SoftUni");
        foreach (var p in persons)
        {
            team.AddPlayer(p);
        }
        Console.WriteLine(team.FirstTeam.Count);
        Console.WriteLine(team.ReserveTeam.Count);

    }
}