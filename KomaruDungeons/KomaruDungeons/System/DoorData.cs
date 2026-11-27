using Microsoft.Xna.Framework;

namespace KomaruDungeons.KomaruDungeons.System;

// Needed for safety
public class DoorData : RectangleData
{
    public DoorData(Atlas atlas) : base(atlas, Vector2.Zero)
    {
        
    }

    public override SpriteRectangle GetRect(Vector2 pos)
    {
        return new Door(atlas, pos);
    }
}