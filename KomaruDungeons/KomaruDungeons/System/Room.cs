using Microsoft.Xna.Framework;

namespace KomaruDungeons.KomaruDungeons.System;

public class Room
{
    public Vector2 Position { get; private set; }
    public SpriteRectangle[] Rectangles { get; private set; }
    public int Type { get; private set; }

    public Room(Vector2 position, SpriteRectangle[] rects, int type)
    {
        Position = position;
        Rectangles = rects;
        Type = type;
    }
}