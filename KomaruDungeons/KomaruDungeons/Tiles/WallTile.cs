using System;
using KomaruDungeons.KomaruDungeons.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.Tiles;

// Abstract description of wall tile
public static class WallTile
{
    private static Texture2D sprite;
    private static readonly Vector2 size = new Vector2(72, 72);

    public static void Setup(Texture2D sprite)
    {
        WallTile.sprite = sprite;
    }

    public static RectangleData Data => new RectangleData(sprite, size, RectangleTag.WallTile);
}