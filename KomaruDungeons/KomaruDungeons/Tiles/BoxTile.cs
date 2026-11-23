using System;
using KomaruDungeons.KomaruDungeons.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.Tiles;

// Abstract description of box tile
public static class BoxTile
{
    private static Texture2D sprite;
    private static readonly Vector2 size = new Vector2(64, 64);

    public static void Setup(Texture2D sprite)
    {
        BoxTile.sprite = sprite;
    }

    public static RectangleData Data => new RectangleData(sprite, size, Layers.WALL_LAYER, RectangleTag.BoxTile);
}