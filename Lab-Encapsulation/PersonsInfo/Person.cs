using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo;

public class Person
{

    private  string firstName;
    private  string lastName;
    private  int age;
    private  decimal salary;
    public string FirstName
    {
      get { return firstName; }
         set
        {
            if (value.Length<3)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }
            firstName=value;
        }
    }
    
    public string LastName 
    {
        get { return this.lastName; }
         set
        {
            if (value.Length<3)
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            } 
            lastName=value;
        }
    }
    public int Age
    {
        get { return this.age; }
       set
        {
            if (value<=0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            age=value;
        }
    }

    public decimal Salary 
    { get { return salary; }
         set
        {
            if (value<650m)
            {
                throw new ArgumentException("Salary cannot be less than 650 leva!");
            }
            salary=value;
        }
    }

    public Person(string firstName, string lastName, int age, decimal salary)
    {
       
       FirstName = firstName;
       
       LastName=lastName;
       
        Age=age;
      
       Salary=salary;
    }
    public override string ToString()
    => $"{FirstName} {LastName} receives {Salary:f2} leva.";

    public void IncreaseSalary(decimal percentage)
    {
        this.Salary += this.Salary * (this.Age > 30 ? percentage / 100 : percentage / 200);
    }


    

}
