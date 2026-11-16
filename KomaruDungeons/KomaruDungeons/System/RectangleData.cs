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
    private RectangleTag tag;

    public RectangleData(Texture2D sprite, Vector2 size, RectangleTag tag = RectangleTag.Default)
    {
        this.sprite = sprite;
        this.size = size;
        this.tag = tag;
        mode = SpriteRectangleMode.Solo;
    }

    public RectangleData(Atlas atlas, Vector2 size, RectangleTag tag = RectangleTag.Default)
    {
        this.atlas = atlas;
        this.size = size;
        this.tag = tag;
        mode = SpriteRectangleMode.Atlas;
    }

    public SpriteRectangle GetRect(Vector2 pos)
    {
        return mode switch
        {
            SpriteRectangleMode.Solo  => new SpriteRectangle(sprite, pos, size, tag),
            SpriteRectangleMode.Atlas => new SpriteRectangle(atlas, pos, size, tag),
            _                         => null
        };
    }

    public SpriteRectangle GetRectCenterized(Vector2 pos)
    {
        var centerizedPos = pos - size / 2;

        return mode switch
        {
            SpriteRectangleMode.Solo  => new SpriteRectangle(sprite, centerizedPos, size, tag),
            SpriteRectangleMode.Atlas => new SpriteRectangle(atlas, centerizedPos, size, tag),
            _                         => null
        };
    }
}