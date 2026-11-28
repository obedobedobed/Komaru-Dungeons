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
        Point[] roomCheckDirs = [new Point(0, -1), new Point(0, 1), new Point(-1, 0), new Point(1, 0)];

        float yPos = 0f;
        for (int y = 0; y < layout.GetLength(0); y++)
        {
            float xPos = 0f;
            for (int x = 0; x < layout.GetLength(1); x++)
            {
                int index = layout[y, x];
                var pos = new Vector2(xPos, yPos);

                bool topDoor = false;
                bool bottomDoor = false;
                bool rightDoor = false;
                bool leftDoor = false;

                for (int i = 0; i < roomCheckDirs.Length; i++)
                {
                    if (roomCheckDirs[i].Y < 0 && y == 0                       ||
                        roomCheckDirs[i].Y > 0 && y == layout.GetLength(0) - 1 ||
                        roomCheckDirs[i].X < 0 && x == 0                       ||
                        roomCheckDirs[i].X > 0 && x == layout.GetLength(1) - 1)
                    {
                        continue;
                    }

                    if (layout[y + roomCheckDirs[i].Y, x + roomCheckDirs[i].X] != LevelLayouts.EMPTY_INDEX)
                    {
                        switch (i)
                        {
                            case 0:
                                topDoor = true;
                                break;
                            case 1:
                                bottomDoor = true;
                                break;
                            case 2:
                                leftDoor = true;
                                break;
                            case 3:
                                rightDoor = true;
                                break;
                        }
                    }
                }

                generated.AddRange(new Room(pos, RoomGenerator.Generate(pos, index, topDoor, bottomDoor, rightDoor, leftDoor), (RoomType)index));
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