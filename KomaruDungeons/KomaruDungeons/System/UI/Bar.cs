using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.System.UI;

public class Bar : SpriteRectangle
{
    private Color bgColor;
    private Color lineColor;

    public Bar(Vector2 position, Vector2 size, Color bgColor, Color lineColor) : base(Game1.Pixel, position, size)
    {
        this.bgColor = bgColor;
        this.lineColor = lineColor;
        Tag = RectangleTag.PlayerHealthBar;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        throw new Exception("Bar: Use overload with AMOUNT");
    }

    public void Draw(SpriteBatch spriteBatch, float amount)
    {
        spriteBatch.Draw(sprite, Rect.ToRectangle, bgColor);

        var lineRect = new RectangleF
        (
            position,
            new Vector2(size.X * amount, size.Y)
        );
        spriteBatch.Draw(sprite, lineRect.ToRectangle, lineColor);
    }
}