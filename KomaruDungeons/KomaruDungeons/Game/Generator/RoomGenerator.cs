using System;
using System.Collections.Generic;
using KomaruDungeons.KomaruDungeons.System;
using KomaruDungeons.KomaruDungeons.Tiles;
using Microsoft.Xna.Framework;

namespace KomaruDungeons.KomaruDungeons.Game.Generator;

public static class RoomGenerator
{
    public static SpriteRectangle[] Generate(Vector2 pos)
    {
        var generated = new List<SpriteRectangle>();
        var layout = RoomLayouts.Layouts[Random.Shared.Next(0, RoomLayouts.Layouts.Length)];

        float posY = pos.Y;
        for (int y = 0; y < layout.GetLength(0); y++)
        {
            float posX = pos.X;
            for (int x = 0; x < layout.GetLength(1); x++)
            {
                switch (layout[y, x])
                {
                    case RoomLayouts.GROUND_INDEX:
                        generated.Add(GroundTile.Data.GetRect(new Vector2(posX, posY)));
                        break;
                    case RoomLayouts.WALL_INDEX:
                        generated.Add(WallTile.Data.GetRect(new Vector2(posX - 4, posY - 4)));
                        break;
                    case RoomLayouts.BOX_INDEX:
                        generated.Add(BoxTile.Data.GetRect(new Vector2(posX, posY)));
                        break;
                }
                
                posX += 64;
            }

            posY += 64;
        }

        return generated.ToArray();
    }
}