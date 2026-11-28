namespace KomaruDungeons.KomaruDungeons.System.Collisions;

public class CollisionInfo
{
    public bool Collided { get; private set; }
    public CollisionDirection Direction { get; private set; }

    public CollisionInfo(bool collided, CollisionDirection direction)
    {
        Collided = collided;
        Direction = direction;
    }
}