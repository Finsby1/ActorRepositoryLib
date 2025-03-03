namespace ActorRepositoryLib;

public class ActorsRepository
{
    private int _nextId = 1;
    private readonly List<Actor> _actors = new();

    public Actor? GetActorById(int Id)
    {
        return _actors.FirstOrDefault(x => x.Id == Id);
    }

    public List<Actor> GetActors()
    {
        return _actors;
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