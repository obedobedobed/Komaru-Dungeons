using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.System;

public class Atlas
{
    public Texture2D Sprite { get; private set; }
    public Rectangle[] SpriteRects { get; private set; }

    public Atlas(Texture2D sprite, Point spriteSize)
    {
        Sprite = sprite;
        var tmpRects = new List<Rectangle>();

        for (int y = 0; y < sprite.Height; y += spriteSize.Y)
        {
            for (int x = 0; x < sprite.Width; x += spriteSize.X)
            {
                tmpRects.Add(new Rectangle(new Point(x, y), spriteSize));
            }
        }

        SpriteRects = tmpRects.ToArray();
    }
}