using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo;

public class Team
{
    private string name;

    private readonly List<Person> firstTeam;
    private readonly List<Person> reserveTeam;

    public string Name => name;
    public IReadOnlyCollection<Person> FirstTeam => firstTeam;
    public IReadOnlyCollection<Person> ReserveTeam => reserveTeam;

    public Team(string name)
    {
        this.name=name;
        firstTeam=new List<Person>();
        reserveTeam=new List<Person>();
    }

 public void AddPlayer(Person person)
    {
        if(person.Age<40) firstTeam.Add(person);
        else reserveTeam.Add(person);
    }
}
