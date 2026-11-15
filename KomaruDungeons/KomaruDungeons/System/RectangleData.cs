using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.System;

// Needed for safety
public class RectangleData
{
    private Texture2D sprite;
    private Atlas atlas;
    private Vector2 size;
    private SpriteRectangleMode mode;

    public RectangleData(Texture2D sprite, Vector2 size)
    {
        this.sprite = sprite;
        this.size = size;
        mode = SpriteRectangleMode.Solo;
    }

    public RectangleData(Atlas atlas, Vector2 size)
    {
        this.atlas = atlas;
        this.size = size;
        mode = SpriteRectangleMode.Atlas;
    }

    public SpriteRectangle GetRect(Vector2 pos)
    {
        return mode switch
        {
            SpriteRectangleMode.Solo  => new SpriteRectangle(sprite, pos, size),
            SpriteRectangleMode.Atlas => new SpriteRectangle(atlas, pos, size),
            _                         => null
        };
    }

    public SpriteRectangle GetRectCenterized(Vector2 pos)
    {
        var centerizedPos = pos - size / 2;

        return mode switch
        {
            SpriteRectangleMode.Solo  => new SpriteRectangle(sprite, centerizedPos, size),
            SpriteRectangleMode.Atlas => new SpriteRectangle(atlas, centerizedPos, size),
            _                         => null
        };
    }
}