namespace dataaccess;

public partial class Pet
{
    public Pet(string id, string name, DateTime createdAt, int age)
    {
        Id = id;
        Name = name;
        CreatedAt = createdAt;
        Age = age;
    }
    
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Age { get; set; }
    
    
}