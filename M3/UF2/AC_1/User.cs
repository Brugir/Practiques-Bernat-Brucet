using System.Collections.Generic;

public class User
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public LinkedList<VideoGame> RentedGames { get; set; }

    public User(string name, string lastName, int age, string address, string phone)
    {
        Name = name;
        LastName = lastName;
        Age = age;
        Address = address;
        Phone = phone;
        RentedGames = new LinkedList<VideoGame>();
    }

    public override string ToString()
    {
        return $"{Name} {LastName} - {Age} años - {Address} - Tel: {Phone}";
    }
}
