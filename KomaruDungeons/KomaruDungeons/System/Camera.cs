using Microsoft.Xna.Framework;

namespace KomaruDungeons.KomaruDungeons.System;

public class Camera
{
    public Vector2 Position { get; private set; }
    public Matrix Matrix => Matrix.CreateTranslation(-Position.X, -Position.Y, 0);

    public Camera(Vector2 position = new Vector2())
    {
        Position = position;
    }

    public void MovePosition(Vector2 newPos)
    {
        Position = newPos;
    }
}