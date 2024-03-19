namespace GridDemo.Models
{
    public class Countries
    {
        public string Name { get; set; }

        public Countries(string name)
        {
            this.Name = name;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }

   
}
