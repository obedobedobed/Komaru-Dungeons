using Microsoft.Xna.Framework;

namespace KomaruDungeons.KomaruDungeons.System;

public static class EmptyRectangle
{
    public static SpriteRectangle Get => new SpriteRectangle(Game1.EmptyPixel, Vector2.Zero, Vector2.Zero);
    public static RectangleData Data => new RectangleData(Game1.EmptyPixel, Vector2.Zero);
}