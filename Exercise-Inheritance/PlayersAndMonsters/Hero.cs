using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndMonsters;

public class Hero
{
    public string UserName {  get; set; }
    public int Level {  get; set; }

    public Hero(string userName, int level)
    {
        UserName=userName;
        Level=level;
    }
    public override string ToString()
    =>
        $"Type: {this.GetType().Name} Username: {UserName} Level: {Level}";
}
