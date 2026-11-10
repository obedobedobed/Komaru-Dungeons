using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.System;

public class ColorRectangle : SpriteRectangle
{
    private Color color;

    public ColorRectangle(Color color, Vector2 position, Vector2 size) : base(Game1.Pixel, position, size)
    {
        this.color = color;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(sprite, Rect.ToRectangle, null, color, rotation, rotationOrigin, SpriteEffects.None, 0f);
    }

    public void DrawMod(SpriteBatch spriteBatch, float widthMod = 1f, float heightMod = 1f)
    {
        var modRect = new RectangleF
        (
            position,
            new Vector2(size.X * widthMod, size.Y * heightMod)
        );

        spriteBatch.Draw(sprite, modRect.ToRectangle, null, color, rotation, rotationOrigin, SpriteEffects.None, 0f);
    }
}