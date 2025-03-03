namespace ActorRepositoryLib;

public class Actor
{
    private string _name;
    private int _birthYear;
    
    public int Id { get; set; }

    public string Name
    {
        get => _name;
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Name cannot be null.");
            }

            if (value.Length < 4)
            {
                throw new ArgumentException("Name must be at least 4 characters long.");
            }
            _name = value;
        }
    }

    public int BirthYear 
    { 
        get => _birthYear;
        set
        {
            if (value < 1820)
            {
                throw new ArgumentOutOfRangeException("Birth year must be at least 1820.");
            }
            _birthYear = value;
        }
    }

    public Actor(int id, string name, int birthYear)
    {
        Id = id;
        Name = name;
        BirthYear = birthYear;
    }

    public Actor()
    {
        
    }
}