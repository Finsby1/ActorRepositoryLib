namespace ActorRepositoryLib;

public class ActorsRepository
{
    private int _nextId = 1;
    private readonly List<Actor> _actors = new();

    public Actor? GetActorById(int Id)
    {
        return _actors.FirstOrDefault(x => x.Id == Id);
    }

    public IEnumerable<Actor> GetActors(int? birthYearAfter = null, string? nameIncludes = null, string? orderBy = null)
    {
        IEnumerable<Actor> result = new List<Actor>(_actors);
        
        //filtering
        if (birthYearAfter ! != null)
        {
            result = result.Where(x => x.BirthYear > birthYearAfter);
        }
        
        //sorting
        if (orderBy != null)
        {
            orderBy = orderBy.ToLower();
            switch (orderBy)
            {
                case "name": 
                case "name asc":
                    result = result.OrderBy(x => x.Name);
                    break;
                case "name desc":
                    result = result.OrderByDescending(x => x.Name);
                    break;
                case "birth year":
                case "birth year asc":
                    result = result.OrderBy(x => x.BirthYear);
                    break;
                case "birth year desc":
                    result = result.OrderByDescending(x => x.BirthYear);
                    break;
                default:
                    break;
            }
        }
        return result;
    }

    public Actor AddActor(Actor actor)
    {
        actor.Id = _nextId++;
        _actors.Add(actor);
        return actor;
    }

    public Actor? RemoveActor(int id)
    {
        Actor? actor = GetActorById(id);
        if (actor == null)
        {
            return null;
        }
        _actors.Remove(actor);
        return actor;
    }

    public Actor? UpdateActor(int id, Actor data)
    {
        Actor? actor = GetActorById(id);
        if (actor == null)
        {
            return null;
        }
        actor.Name = data.Name;
        actor.BirthYear = data.BirthYear;
        return actor;
    }
}