using System.Text.Json.Serialization;

namespace LearningProject;

public sealed class Human
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Human> humans = new List<Human>();
        
        try
        {
            var fileContent = File.ReadAllText("humans.txt");
            
            //Deserialize means it understands the string and make it list by understanding the type
            // this (<>) tells deserializer to which type it should convert the string
            humans = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Human>>(fileContent);
        }
        catch (Exception ex)
        {
            // If the file does not exist, create a default values
            humans =  new()
            {
                new Human { FirstName = "John", LastName = "Doe" },
                new Human { FirstName = "Jane", LastName = "Doe" }
            };
        }
         
        // this makes sure file is there
        File.WriteAllText("humans.txt", Newtonsoft.Json.JsonConvert.SerializeObject(humans));

        foreach (var human in humans)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}