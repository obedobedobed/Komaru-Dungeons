using System;
using Microsoft.Xna.Framework;

namespace KomaruDungeons.KomaruDungeons.System;

public class Room
{
    public Vector2 Position { get; private set; }
    public SpriteRectangle[] Rectangles { get; private set; }
    public RoomType Type { get; private set; }

    public RectangleF Rect => new RectangleF(Position, new Vector2(Game1.ROOM_WIDTH, Game1.ROOM_HEIGHT));
    public RectangleF InsideRect => new RectangleF(Position + new Vector2(64, 64), new Vector2(Game1.ROOM_WIDTH, Game1.ROOM_HEIGHT) - new Vector2(128, 128));

    public bool Entered { get; private set; } = false;

    public Room(Vector2 position, SpriteRectangle[] rects, RoomType type)
    {
        Position = position;
        Rectangles = rects;
        Type = type;
    }

    public void OnPlayerEntered()
    {
        Console.WriteLine("player enter");

        switch (Type)
        {
            case RoomType.Start:
                // Nothing
                break;
            case RoomType.Enemies:
                ToggleDoors();
                break;
            case RoomType.Shop:
                // Nothing
                break;
            case RoomType.Boss:
                // No bosses yet
                break;
        }

        Entered = true;
    }

    public void OnPlayerExit()
    {
        Entered = false;
    }

    public void ToggleDoors()
    {
        foreach (var rect in Rectangles)
        {
            if (rect is Door door)
            {
                door.Toggle();
            }
        }
    }
}