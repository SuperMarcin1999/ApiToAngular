namespace ApiToAngular.Models
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Place { get; set; }

        public SuperHero(int id, string name, string firstName, string lastName, string place)
        {
            Id = id;
            Name = name;
            FirstName = firstName;
            LastName = lastName;
            Place = place;
        }

        //    id?: number;
        //name = "";
        //firstName = "";
        //lastName = "";
        //place = "";
    }
}
