using Microsoft.Xna.Framework;

namespace KomaruDungeons.KomaruDungeons.System;

public class RectangleF
{
    public Vector2 position;
    public Vector2 size;

    public Rectangle ToRectangle
    {
        get
        {
            return new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
        }
    }

    public RectangleF(Vector2 position, Vector2 size)
    {
        this.position = position;
        this.size = size;
    }
}