using KomaruDungeons.KomaruDungeons.System;
using Microsoft.Xna.Framework;

namespace KomaruDungeons.KomaruDungeons.Tiles;

// Abstract description of door tile
public static class DoorTile
{
    private static Atlas atlas;
    private static readonly Vector2 size = new Vector2(64, 64);

    public static void Setup(Atlas atlas)
    {
        DoorTile.atlas = atlas;
    }

    public static RectangleData Data => new DoorData(atlas);
}