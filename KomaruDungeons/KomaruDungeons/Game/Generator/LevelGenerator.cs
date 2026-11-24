using System;
using System.Collections.Generic;
using KomaruDungeons.KomaruDungeons.System;
using Microsoft.Xna.Framework;

namespace KomaruDungeons.KomaruDungeons.Game.Generator;

public static class LevelGenerator
{
    public static Room[] Generate()
    {
        var generated = new List<Room>();
        var layout = LevelLayouts.Layouts[Random.Shared.Next(0, LevelLayouts.Layouts.Length)];

        float yPos = 0f;
        for (int y = 0; y < layout.GetLength(0); y++)
        {
            float xPos = 0f;
            for (int x = 0; x < layout.GetLength(1); x++)
            {
                int index = layout[y, x];
                var pos = new Vector2(xPos, yPos);
                generated.AddRange(new Room(pos, RoomGenerator.Generate(pos, index), index));
                xPos += Game1.ROOM_WIDTH;
            }
            yPos += Game1.ROOM_HEIGHT;
        }

        int rectsCount = 0;

        foreach (var room in generated)
        {
            rectsCount += room.Rectangles.Length;
        }

        Console.WriteLine($"returned total {generated.Count} rooms ({rectsCount} rects)");
        return generated.ToArray();
    }
}