namespace GridDemo.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }

        public Person(string name, int age, string gender, string country)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Country = country;
        }
        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Gender} {this.Country}";
        }
    }
}
